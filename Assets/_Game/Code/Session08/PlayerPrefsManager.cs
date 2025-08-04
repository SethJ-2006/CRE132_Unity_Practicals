using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Demonstrates Unity's PlayerPrefs system for simple data persistence
/// Perfect for settings, preferences, and simple progress tracking
/// Data persists between game sessions and survives application uninstalls
/// </summary>
public class PlayerPrefsManager : MonoBehaviour
{
    [Header("Player Preferences")]
    [SerializeField] private float masterVolume = 1.0f;
    [SerializeField] private float musicVolume = 0.8f;
    [SerializeField] private float sfxVolume = 0.8f;
    [SerializeField] private int graphicsQuality = 2; // 0=Low, 1=Medium, 2=High
    [SerializeField] private bool fullscreen = true;
    [SerializeField] private string playerName = "Player";
    
    [Header("Game Progress")]
    [SerializeField] private int highScore = 0;
    [SerializeField] private int totalPlayTime = 0; // in seconds
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private bool[] levelUnlocked = new bool[10]; // 10 levels
    
    [Header("Control Settings")]
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private bool invertYAxis = false;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("Status")]
    [SerializeField] private string lastLoadTime = "Never";
    [SerializeField] private string lastSaveTime = "Never";
    [SerializeField] private int totalSaves = 0;
    /// <summary>
    /// Unity Start method - loads saved preferences
    /// </summary>
    void Start()
    {
        Debug.Log("=== PLAYERPREFS DEMO STARTED ===");
        
        // Load all saved preferences
        LoadPreferences();
        
        // Display current values
        DisplayAllPreferences();
        
        Debug.Log("Controls:");
        Debug.Log("P = Save Preferences | O = Load Preferences");
        Debug.Log("R = Reset to Defaults | T = Generate Test Data");
        Debug.Log("1/2 = Change Volume | 3/4 = Change Quality");
        Debug.Log("5/6 = Change Level | 7 = Toggle Fullscreen");
    }

    /// <summary>
    /// Unity Update method - handles input for testing
    /// </summary>
    void Update()
    {
        HandleInput();
        
        // Simulate playtime tracking
        totalPlayTime++;
        
        // Auto-save every 100 frames (roughly every 1.6 seconds at 60fps)
        if (Time.frameCount % 100 == 0)
        {
            SavePreferences();
        }
    }
    /// <summary>
    /// Handles keyboard input for testing PlayerPrefs functionality
    /// </summary>
    private void HandleInput()
    {
        // Save and Load operations
        if (Input.GetKeyDown(KeyCode.P))
        {
            SavePreferences();
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadPreferences();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetToDefaults();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            GenerateTestData();
        }
        
        // Volume controls
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            masterVolume = Mathf.Clamp(masterVolume - 0.1f, 0f, 1f);
            Debug.Log($"Master Volume: {masterVolume:F1}");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            masterVolume = Mathf.Clamp(masterVolume + 0.1f, 0f, 1f);
            Debug.Log($"Master Volume: {masterVolume:F1}");
        }
        
        // Graphics quality
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            graphicsQuality = Mathf.Max(0, graphicsQuality - 1);
            Debug.Log($"Graphics Quality: {GetQualityName(graphicsQuality)}");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            graphicsQuality = Mathf.Min(2, graphicsQuality + 1);
            Debug.Log($"Graphics Quality: {GetQualityName(graphicsQuality)}");
        }
        
        // Level progression
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentLevel = Mathf.Max(1, currentLevel - 1);
            Debug.Log($"Current Level: {currentLevel}");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentLevel = Mathf.Min(10, currentLevel + 1);
            UnlockLevel(currentLevel); // Unlock the level we moved to
            Debug.Log($"Current Level: {currentLevel}");
        }
        
        // Toggle fullscreen
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            fullscreen = !fullscreen;
            Debug.Log($"Fullscreen: {fullscreen}");
        }
    }
    /// <summary>
    /// Saves all current preferences using PlayerPrefs
    /// </summary>
    public void SavePreferences()
    {
        Debug.Log("💾 Saving preferences to PlayerPrefs...");
        
        // Audio settings
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        
        // Graphics settings
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0); // PlayerPrefs doesn't store bools directly
        
        // Player data
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("TotalPlayTime", totalPlayTime);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        
        // Level unlocks (store as comma-separated string)
        string levelUnlocksString = "";
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            levelUnlocksString += levelUnlocked[i] ? "1" : "0";
            if (i < levelUnlocked.Length - 1) levelUnlocksString += ",";
        }
        PlayerPrefs.SetString("LevelUnlocks", levelUnlocksString);
        
        // Control settings
        PlayerPrefs.SetFloat("MouseSensitivity", mouseSensitivity);
        PlayerPrefs.SetInt("InvertYAxis", invertYAxis ? 1 : 0);
        PlayerPrefs.SetString("JumpKey", jumpKey.ToString());
        PlayerPrefs.SetString("InteractKey", interactKey.ToString());
        
        // Save metadata
        PlayerPrefs.SetString("LastSaveTime", System.DateTime.Now.ToString());
        totalSaves++;
        PlayerPrefs.SetInt("TotalSaves", totalSaves);
        
        // Force save to disk (important!)
        PlayerPrefs.Save();
        
        lastSaveTime = System.DateTime.Now.ToString("HH:mm:ss");
        Debug.Log("✅ Preferences saved successfully!");
    }
    /// <summary>
    /// Loads all preferences from PlayerPrefs with default fallbacks
    /// </summary>
    public void LoadPreferences()
    {
        Debug.Log("📂 Loading preferences from PlayerPrefs...");
        
        // Audio settings with defaults
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.8f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
        
        // Graphics settings with defaults
        graphicsQuality = PlayerPrefs.GetInt("GraphicsQuality", 2);
        fullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        
        // Player data with defaults
        playerName = PlayerPrefs.GetString("PlayerName", "Player");
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        totalPlayTime = PlayerPrefs.GetInt("TotalPlayTime", 0);
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        
        // Level unlocks
        string levelUnlocksString = PlayerPrefs.GetString("LevelUnlocks", "1,0,0,0,0,0,0,0,0,0"); // First level unlocked by default
        string[] unlockArray = levelUnlocksString.Split(',');
        for (int i = 0; i < levelUnlocked.Length && i < unlockArray.Length; i++)
        {
            levelUnlocked[i] = unlockArray[i] == "1";
        }
        
        // Control settings with defaults
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
        invertYAxis = PlayerPrefs.GetInt("InvertYAxis", 0) == 1;
        
        // Key bindings (with error handling)
        try
        {
            jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", "Space"));
            interactKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InteractKey", "E"));
        }
        catch
        {
            jumpKey = KeyCode.Space;
            interactKey = KeyCode.E;
            Debug.LogWarning("⚠️ Error loading key bindings, using defaults");
        }
        
        // Load metadata
        lastLoadTime = System.DateTime.Now.ToString("HH:mm:ss");
        totalSaves = PlayerPrefs.GetInt("TotalSaves", 0);
        
        Debug.Log("✅ Preferences loaded successfully!");
        DisplayAllPreferences();
    }
    /// <summary>
    /// Resets all preferences to default values
    /// </summary>
    public void ResetToDefaults()
    {
        Debug.Log("🔄 Resetting to default preferences...");
        
        // Reset to default values
        masterVolume = 1.0f;
        musicVolume = 0.8f;
        sfxVolume = 0.8f;
        graphicsQuality = 2;
        fullscreen = true;
        playerName = "Player";
        highScore = 0;
        totalPlayTime = 0;
        currentLevel = 1;
        mouseSensitivity = 1.0f;
        invertYAxis = false;
        jumpKey = KeyCode.Space;
        interactKey = KeyCode.E;
        
        // Reset level unlocks (only first level unlocked)
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            levelUnlocked[i] = (i == 0);
        }
        
        // Save the defaults
        SavePreferences();
        
        Debug.Log("✅ Reset to defaults complete!");
    }

    /// <summary>
    /// Generates random test data for demonstration
    /// </summary>
    private void GenerateTestData()
    {
        Debug.Log("🎲 Generating test data...");
        
        masterVolume = Random.Range(0.5f, 1.0f);
        musicVolume = Random.Range(0.3f, 1.0f);
        sfxVolume = Random.Range(0.3f, 1.0f);
        graphicsQuality = Random.Range(0, 3);
        fullscreen = Random.Range(0, 2) == 1;
        playerName = "TestPlayer" + Random.Range(100, 999);
        highScore = Random.Range(1000, 50000);
        currentLevel = Random.Range(1, 6);
        mouseSensitivity = Random.Range(0.5f, 2.0f);
        invertYAxis = Random.Range(0, 2) == 1;
        
        // Unlock levels up to current level
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            levelUnlocked[i] = (i < currentLevel);
        }
        
        Debug.Log("✅ Test data generated!");
        DisplayAllPreferences();
    }
    /// <summary>
    /// Unlocks a specific level
    /// </summary>
    public void UnlockLevel(int levelNumber)
    {
        if (levelNumber > 0 && levelNumber <= levelUnlocked.Length)
        {
            if (!levelUnlocked[levelNumber - 1])
            {
                levelUnlocked[levelNumber - 1] = true;
                Debug.Log($"🔓 Level {levelNumber} unlocked!");
            }
        }
    }

    /// <summary>
    /// Displays all current preferences in the console
    /// </summary>
    private void DisplayAllPreferences()
    {
        Debug.Log("=== CURRENT PREFERENCES ===");
        Debug.Log($"Player Name: {playerName}");
        Debug.Log($"Audio: Master={masterVolume:F1}, Music={musicVolume:F1}, SFX={sfxVolume:F1}");
        Debug.Log($"Graphics: Quality={GetQualityName(graphicsQuality)}, Fullscreen={fullscreen}");
        Debug.Log($"Progress: Level={currentLevel}, High Score={highScore}, Playtime={totalPlayTime}s");
        Debug.Log($"Controls: Mouse Sensitivity={mouseSensitivity:F1}, Invert Y={invertYAxis}");
        Debug.Log($"Key Bindings: Jump={jumpKey}, Interact={interactKey}");
        
        string unlockedLevels = "";
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            if (levelUnlocked[i]) unlockedLevels += (i + 1) + " ";
        }
        Debug.Log($"Unlocked Levels: {unlockedLevels}");
        Debug.Log($"Save Info: Total Saves={totalSaves}, Last Save={lastSaveTime}");
        Debug.Log("============================");
    }

    /// <summary>
    /// Helper method to get graphics quality name
    /// </summary>
    private string GetQualityName(int quality)
    {
        switch (quality)
        {
            case 0: return "Low";
            case 1: return "Medium";
            case 2: return "High";
            default: return "Unknown";
        }
    }

    /// <summary>
    /// Clears all PlayerPrefs (use with caution!)
    /// </summary>
    public void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("🗑️ All PlayerPrefs cleared!");
        ResetToDefaults();
    }
}