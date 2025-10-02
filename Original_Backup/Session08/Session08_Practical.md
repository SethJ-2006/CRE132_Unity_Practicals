# Session 08: Data Persistence & Final Project
*CRE132 Game Development Fundamentals - Northern Irish University*

## 🎯 **Learning Objectives**
By the end of this session, you will:
- **Master file I/O operations** for saving and loading game data
- **Implement JSON serialisation** for complex data structures
- **Use PlayerPrefs** for simple persistent data storage
- **Work with Dictionaries** for efficient data management
- **Create a complete mini-game** integrating all course concepts
- **Apply professional code organisation** and performance best practices
- **Build a data-driven game system** suitable for portfolio projects

---

## 🔧 **Unity Project Setup**

### **Scene Preparation**
1. **Open Unity** and navigate to `Assets/_Game/Scenes/`
2. **Create new scene**: Right-click → Create → Scene
3. **Name the scene**: `08_Data_Persistence`
4. **Open the scene**: Double-click to load it
5. **Save the scene**: `Ctrl+S` to ensure it's saved

### **GameObject Setup**
1. **Create Empty GameObject**: Right-click in Hierarchy → Create Empty
2. **Rename to**: `DataManager`
3. **Create another Empty GameObject**: Name it `GameController`
4. **Create UI Canvas**: Right-click → UI → Canvas
5. **Create Text elements**: In Canvas, create multiple Text (TextMeshPro) objects for displaying data

---

## 📚 **Core Concepts Overview**

### **What We'll Learn**
- **File I/O**: Reading and writing files to Unity's persistent data path
- **JSON Serialisation**: Converting C# objects to JSON strings for storage
- **PlayerPrefs**: Unity's built-in system for simple key-value persistence
- **Dictionaries**: Hash tables for fast data lookup and storage
- **Game Architecture**: Professional patterns for data-driven game systems
- **Error Handling**: Robust file operations with proper exception handling

---

## 💾 **Part 1: File I/O Operations**

### **Understanding Unity's File System**
Unity provides several paths for file storage:
- **Application.persistentDataPath**: User data that persists between app updates
- **Application.dataPath**: Read-only application data
- **Application.streamingAssetsPath**: Files that can be read at runtime

### **Script 1: Basic File Operations**

#### **Step 1: Create the FileManager Script**
1. **In Project window**: Navigate to `Assets/_Game/Code/Session08/`
2. **Right-click**: Create → C# Script
3. **Name it**: `FileManager`
4. **Double-click** to open in Visual Studio Code

#### **Step 2: Implement File Operations**
Replace the entire contents with this code:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// Demonstrates basic file I/O operations in Unity
/// Covers reading, writing, and managing files in persistent data path
/// Essential for save systems and data persistence
/// </summary>
public class FileManager : MonoBehaviour
{
    [Header("File Operations Demo")]
    [SerializeField] private string fileName = "gamedata.txt";
    [SerializeField] private string testMessage = "Hello from Unity file system!";
    
    [Header("File Status")]
    [SerializeField] private bool fileExists = false;
    [SerializeField] private string filePath = "";
    [SerializeField] private string lastFileContent = "";

    /// <summary>
    /// Unity Start method - runs when the GameObject becomes active
    /// Initialises file system demo and displays current status
    /// </summary>
    void Start()
    {
        Debug.Log("=== FILE MANAGER DEMO STARTED ===");
        
        // Get the full file path
        filePath = Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log($"File will be saved to: {filePath}");
        
        // Check if file already exists
        CheckFileExists();
        
        // Display current file system information
        DisplayFileSystemInfo();
        
        Debug.Log("Press SPACE to write file, R to read file, D to delete file");
    }

    /// <summary>
    /// Unity Update method - handles user input for file operations
    /// </summary>
    void Update()
    {
        // Write file when SPACE is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WriteToFile();
        }
        
        // Read file when R is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadFromFile();
        }
        
        // Delete file when D is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteFile();
        }
        
        // Check file status continuously
        CheckFileExists();
    }

    /// <summary>
    /// Writes text data to a file in the persistent data path
    /// Includes error handling for robust file operations
    /// </summary>
    private void WriteToFile()
    {
        try
        {
            Debug.Log($"Writing to file: {fileName}");
            
            // Add timestamp to make each write unique
            string contentToWrite = $"{testMessage}\nWritten at: {DateTime.Now}\nRandom number: {UnityEngine.Random.Range(1, 1000)}";
            
            // Write all text to file (overwrites existing content)
            File.WriteAllText(filePath, contentToWrite);
            
            Debug.Log("✅ File written successfully!");
            Debug.Log($"Content written: {contentToWrite}");
            
            CheckFileExists();
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error writing file: {ex.Message}");
        }
    }

    /// <summary>
    /// Reads text data from a file and displays it
    /// Includes error handling for missing files
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                Debug.Log($"Reading from file: {fileName}");
                
                // Read all text from file
                string fileContent = File.ReadAllText(filePath);
                lastFileContent = fileContent;
                
                Debug.Log("✅ File read successfully!");
                Debug.Log($"File content:\n{fileContent}");
            }
            else
            {
                Debug.LogWarning("⚠️ File does not exist. Press SPACE to create it first.");
                lastFileContent = "File not found";
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error reading file: {ex.Message}");
            lastFileContent = "Error reading file";
        }
    }

    /// <summary>
    /// Deletes the file if it exists
    /// Includes confirmation and error handling
    /// </summary>
    private void DeleteFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("✅ File deleted successfully!");
                lastFileContent = "";
                CheckFileExists();
            }
            else
            {
                Debug.LogWarning("⚠️ File does not exist, nothing to delete.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error deleting file: {ex.Message}");
        }
    }

    /// <summary>
    /// Checks if the file exists and updates the status
    /// </summary>
    private void CheckFileExists()
    {
        fileExists = File.Exists(filePath);
    }

    /// <summary>
    /// Displays useful information about Unity's file system
    /// </summary>
    private void DisplayFileSystemInfo()
    {
        Debug.Log("=== UNITY FILE SYSTEM INFO ===");
        Debug.Log($"Persistent Data Path: {Application.persistentDataPath}");
        Debug.Log($"Data Path: {Application.dataPath}");
        Debug.Log($"Streaming Assets Path: {Application.streamingAssetsPath}");
        Debug.Log($"Temporary Cache Path: {Application.temporaryCachePath}");
        Debug.Log("================================");
    }
}
```

#### **Step 3: Attach Script and Test**
1. **Select DataManager GameObject** in Hierarchy
2. **In Inspector**: Click "Add Component"
3. **Search for**: FileManager
4. **Add the component**
5. **Press Play** to test the file operations
6. **Use the controls**:
   - **SPACE**: Write file
   - **R**: Read file  
   - **D**: Delete file

#### **📋 Expected Output**
When you press SPACE, you should see:
```
Writing to file: gamedata.txt
✅ File written successfully!
Content written: Hello from Unity file system!
Written at: [current date/time]
Random number: [random number]
```

---

## 🔄 **Part 2: JSON Serialisation**

### **Understanding JSON in Unity**
JSON (JavaScript Object Notation) is perfect for saving complex game data:
- **Player progress** (level, score, unlocked items)
- **Game settings** (volume, graphics quality, key bindings)
- **Save game states** (position, inventory, quest progress)

### **Script 2: JSON Data Management**

#### **Step 1: Create PlayerData Class**
Create a new script called `PlayerData`:

```csharp
using System;
using System.Collections.Generic;

/// <summary>
/// Data class representing player information for save/load operations
/// Uses [Serializable] attribute to enable JSON serialisation
/// </summary>
[Serializable]
public class PlayerData
{
    // Basic player information
    public string playerName;
    public int level;
    public float experience;
    public int health;
    public int maxHealth;
    
    // Game progress
    public int currentScore;
    public int highScore;
    public float playtime; // in seconds
    
    // Player position (for save/load location)
    public float positionX;
    public float positionY;
    public float positionZ;
    
    // Inventory system
    public List<string> inventory;
    public List<int> inventoryQuantities;
    
    // Achievement system
    public List<string> unlockedAchievements;
    
    // Game settings
    public float musicVolume;
    public float soundVolume;
    public bool fullscreenMode;
    
    // Timestamps
    public string lastSaveTime;
    public string firstPlayTime;

    /// <summary>
    /// Constructor with default values
    /// </summary>
    public PlayerData()
    {
        playerName = "New Player";
        level = 1;
        experience = 0f;
        health = 100;
        maxHealth = 100;
        currentScore = 0;
        highScore = 0;
        playtime = 0f;
        
        positionX = 0f;
        positionY = 0f;
        positionZ = 0f;
        
        inventory = new List<string>();
        inventoryQuantities = new List<int>();
        unlockedAchievements = new List<string>();
        
        musicVolume = 0.8f;
        soundVolume = 0.8f;
        fullscreenMode = true;
        
        lastSaveTime = DateTime.Now.ToString();
        firstPlayTime = DateTime.Now.ToString();
    }

    /// <summary>
    /// Add item to inventory with quantity
    /// </summary>
    public void AddToInventory(string item, int quantity = 1)
    {
        int existingIndex = inventory.IndexOf(item);
        if (existingIndex >= 0)
        {
            // Item already exists, increase quantity
            inventoryQuantities[existingIndex] += quantity;
        }
        else
        {
            // New item, add to lists
            inventory.Add(item);
            inventoryQuantities.Add(quantity);
        }
    }

    /// <summary>
    /// Remove item from inventory
    /// </summary>
    public bool RemoveFromInventory(string item, int quantity = 1)
    {
        int existingIndex = inventory.IndexOf(item);
        if (existingIndex >= 0)
        {
            inventoryQuantities[existingIndex] -= quantity;
            
            // Remove completely if quantity reaches 0 or below
            if (inventoryQuantities[existingIndex] <= 0)
            {
                inventory.RemoveAt(existingIndex);
                inventoryQuantities.RemoveAt(existingIndex);
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Unlock an achievement if not already unlocked
    /// </summary>
    public bool UnlockAchievement(string achievementName)
    {
        if (!unlockedAchievements.Contains(achievementName))
        {
            unlockedAchievements.Add(achievementName);
            return true; // Newly unlocked
        }
        return false; // Already unlocked
    }
}
```

#### **Step 2: Create JSONManager Script**
Create `JSONManager` script:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// Manages JSON serialisation and deserialisation for player data
/// Demonstrates save/load systems using Unity's JsonUtility
/// </summary>
public class JSONManager : MonoBehaviour
{
    [Header("JSON Save System")]
    [SerializeField] private string saveFileName = "playerdata.json";
    [SerializeField] private PlayerData currentPlayerData;
    
    [Header("Demo Controls")]
    [SerializeField] private bool autoSaveEnabled = true;
    [SerializeField] private float autoSaveInterval = 30f; // seconds
    
    [Header("Status Display")]
    [SerializeField] private string lastSaveTime = "Never";
    [SerializeField] private string lastLoadTime = "Never";
    [SerializeField] private bool saveFileExists = false;

    private string savePath;
    private float autoSaveTimer = 0f;

    /// <summary>
    /// Unity Start method - initialises the save system
    /// </summary>
    void Start()
    {
        Debug.Log("=== JSON SAVE SYSTEM DEMO ===");
        
        // Set up save file path
        savePath = Path.Combine(Application.persistentDataPath, saveFileName);
        Debug.Log($"Save file location: {savePath}");
        
        // Check if save file exists
        CheckSaveFileExists();
        
        // Try to load existing data, or create new player data
        if (saveFileExists)
        {
            LoadPlayerData();
        }
        else
        {
            CreateNewPlayerData();
        }
        
        Debug.Log("Controls: S = Save, L = Load, N = New Data, T = Test Data, C = Clear Save");
    }

    /// <summary>
    /// Unity Update method - handles input and auto-save timer
    /// </summary>
    void Update()
    {
        // Handle manual controls
        HandleInput();
        
        // Update auto-save timer
        if (autoSaveEnabled && currentPlayerData != null)
        {
            autoSaveTimer += Time.deltaTime;
            if (autoSaveTimer >= autoSaveInterval)
            {
                SavePlayerData();
                autoSaveTimer = 0f;
                Debug.Log("🔄 Auto-save triggered");
            }
        }
        
        // Update some game data simulation
        if (currentPlayerData != null)
        {
            currentPlayerData.playtime += Time.deltaTime;
        }
        
        CheckSaveFileExists();
    }

    /// <summary>
    /// Handles keyboard input for save system testing
    /// </summary>
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayerData();
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            CreateNewPlayerData();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            GenerateTestData();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearSaveFile();
        }
    }

    /// <summary>
    /// Creates new player data with default values
    /// </summary>
    private void CreateNewPlayerData()
    {
        currentPlayerData = new PlayerData();
        Debug.Log("✅ New player data created");
        DisplayPlayerData();
    }

    /// <summary>
    /// Saves current player data to JSON file
    /// </summary>
    public void SavePlayerData()
    {
        if (currentPlayerData == null)
        {
            Debug.LogWarning("⚠️ No player data to save!");
            return;
        }

        try
        {
            // Update save timestamp
            currentPlayerData.lastSaveTime = DateTime.Now.ToString();
            
            // Convert PlayerData object to JSON string
            string jsonString = JsonUtility.ToJson(currentPlayerData, true);
            
            // Write JSON to file
            File.WriteAllText(savePath, jsonString);
            
            lastSaveTime = DateTime.Now.ToString("HH:mm:ss");
            Debug.Log("✅ Player data saved successfully!");
            Debug.Log($"JSON data preview:\n{jsonString.Substring(0, Mathf.Min(200, jsonString.Length))}...");
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error saving player data: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads player data from JSON file
    /// </summary>
    public void LoadPlayerData()
    {
        try
        {
            if (File.Exists(savePath))
            {
                // Read JSON string from file
                string jsonString = File.ReadAllText(savePath);
                
                // Convert JSON string back to PlayerData object
                currentPlayerData = JsonUtility.FromJson<PlayerData>(jsonString);
                
                lastLoadTime = DateTime.Now.ToString("HH:mm:ss");
                Debug.Log("✅ Player data loaded successfully!");
                DisplayPlayerData();
            }
            else
            {
                Debug.LogWarning("⚠️ Save file not found. Creating new player data.");
                CreateNewPlayerData();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error loading player data: {ex.Message}");
            Debug.LogWarning("Creating new player data due to load failure.");
            CreateNewPlayerData();
        }
    }

    /// <summary>
    /// Generates test data for demonstration purposes
    /// </summary>
    private void GenerateTestData()
    {
        if (currentPlayerData == null)
        {
            currentPlayerData = new PlayerData();
        }

        // Generate random test data
        currentPlayerData.playerName = "TestPlayer_" + UnityEngine.Random.Range(100, 999);
        currentPlayerData.level = UnityEngine.Random.Range(1, 50);
        currentPlayerData.experience = UnityEngine.Random.Range(0f, 10000f);
        currentPlayerData.currentScore = UnityEngine.Random.Range(0, 100000);
        currentPlayerData.highScore = Mathf.Max(currentPlayerData.currentScore, currentPlayerData.highScore);
        
        // Add random inventory items
        string[] possibleItems = { "Sword", "Shield", "Potion", "Key", "Gem", "Scroll", "Ring", "Bow" };
        for (int i = 0; i < 3; i++)
        {
            string randomItem = possibleItems[UnityEngine.Random.Range(0, possibleItems.Length)];
            currentPlayerData.AddToInventory(randomItem, UnityEngine.Random.Range(1, 5));
        }
        
        // Add random achievements
        string[] achievements = { "First Steps", "Explorer", "Warrior", "Collector", "Speedrunner" };
        for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
        {
            string randomAchievement = achievements[UnityEngine.Random.Range(0, achievements.Length)];
            currentPlayerData.UnlockAchievement(randomAchievement);
        }

        Debug.Log("🎲 Test data generated!");
        DisplayPlayerData();
    }

    /// <summary>
    /// Displays current player data in console for debugging
    /// </summary>
    private void DisplayPlayerData()
    {
        if (currentPlayerData == null)
        {
            Debug.Log("No player data available");
            return;
        }

        Debug.Log("=== CURRENT PLAYER DATA ===");
        Debug.Log($"Name: {currentPlayerData.playerName}");
        Debug.Log($"Level: {currentPlayerData.level} | Experience: {currentPlayerData.experience:F1}");
        Debug.Log($"Health: {currentPlayerData.health}/{currentPlayerData.maxHealth}");
        Debug.Log($"Score: {currentPlayerData.currentScore} | High Score: {currentPlayerData.highScore}");
        Debug.Log($"Playtime: {currentPlayerData.playtime:F1} seconds");
        Debug.Log($"Inventory items: {currentPlayerData.inventory.Count}");
        Debug.Log($"Achievements: {currentPlayerData.unlockedAchievements.Count}");
        Debug.Log($"Last saved: {currentPlayerData.lastSaveTime}");
        Debug.Log("===========================");
    }

    /// <summary>
    /// Deletes the save file
    /// </summary>
    private void ClearSaveFile()
    {
        try
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
                Debug.Log("🗑️ Save file deleted");
                lastSaveTime = "Never";
                lastLoadTime = "Never";
            }
            else
            {
                Debug.LogWarning("⚠️ No save file to delete");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error deleting save file: {ex.Message}");
        }
    }

    /// <summary>
    /// Checks if save file exists
    /// </summary>
    private void CheckSaveFileExists()
    {
        saveFileExists = File.Exists(savePath);
    }
}
```

#### **Step 3: Test JSON Serialisation**
1. **Create new GameObject**: Name it "JSONManager"
2. **Attach JSONManager script**
3. **Press Play** and test:
   - **S**: Save data
   - **L**: Load data
   - **N**: Create new player data
   - **T**: Generate test data
   - **C**: Clear save file

---

*[Continue to next part...]*## 🗝️ **Part 3: PlayerPrefs for Simple Data**

### **Understanding PlayerPrefs**
PlayerPrefs provides a simple key-value storage system perfect for:
- **Game settings** (volume, difficulty)
- **Player preferences** (controls, graphics options)
- **Simple progress tracking** (high scores, unlocks)

### **Script 3: PlayerPrefs Manager**

#### **Step 1: Create PlayerPrefsManager Script**
Create a new script called `PlayerPrefsManager`:

```csharp
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
```

#### **Step 2: Test PlayerPrefs System**
1. **Create GameObject**: Name it "PlayerPrefsManager"
2. **Attach PlayerPrefsManager script**
3. **Press Play** and test the controls:
   - **P**: Save preferences
   - **O**: Load preferences
   - **R**: Reset to defaults
   - **T**: Generate test data
   - **1/2**: Change volume
   - **3/4**: Change graphics quality
   - **5/6**: Change level
   - **7**: Toggle fullscreen

---

## 📊 **Part 4: Dictionary Data Structures**

### **Understanding Dictionaries**
Dictionaries provide fast key-value lookup, perfect for:
- **Item databases** (ID → item properties)
- **Player statistics** (stat name → value)
- **Configuration systems** (setting → value)
- **Localisation** (key → translated text)

### **Script 4: Dictionary Manager**

#### **Step 1: Create DictionaryManager Script**
Create `DictionaryManager` script:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Demonstrates Dictionary usage in Unity for fast data lookup and management
/// Perfect for item databases, player stats, and configuration systems
/// </summary>
public class DictionaryManager : MonoBehaviour
{
    [Header("Item Database")]
    [SerializeField] private Dictionary<string, ItemData> itemDatabase;
    [SerializeField] private Dictionary<int, string> itemIdToName;
    
    [Header("Player Statistics")]
    [SerializeField] private Dictionary<string, float> playerStats;
    [SerializeField] private Dictionary<string, int> playerAchievements;
    
    [Header("Game Configuration")]
    [SerializeField] private Dictionary<string, string> gameSettings;
    [SerializeField] private Dictionary<string, float> difficultyModifiers;
    
    [Header("Status Display")]
    [SerializeField] private int totalItems = 0;
    [SerializeField] private int totalStats = 0;
    [SerializeField] private int totalSettings = 0;

    /// <summary>
    /// Simple data structure for items
    /// </summary>
    [System.Serializable]
    public class ItemData
    {
        public string name;
        public string description;
        public int value;
        public float weight;
        public string rarity;
        public bool consumable;

        public ItemData(string name, string description, int value, float weight, string rarity, bool consumable)
        {
            this.name = name;
            this.description = description;
            this.value = value;
            this.weight = weight;
            this.rarity = rarity;
            this.consumable = consumable;
        }
    }

    /// <summary>
    /// Unity Start method - initialises all dictionary systems
    /// </summary>
    void Start()
    {
        Debug.Log("=== DICTIONARY MANAGER DEMO ===");
        
        // Initialise all dictionaries
        InitialiseItemDatabase();
        InitialisePlayerStats();
        InitialiseGameSettings();
        
        // Display initial data
        DisplayAllDictionaries();
        
        Debug.Log("Controls:");
        Debug.Log("I = Item Lookup | S = Stat Operations | C = Config Operations");
        Debug.Log("A = Add Random Item | R = Remove Item | T = Test All Functions");
    }

    /// <summary>
    /// Unity Update method - handles input for testing
    /// </summary>
    void Update()
    {
        HandleInput();
        UpdateCounts();
    }

    /// <summary>
    /// Handles keyboard input for dictionary testing
    /// </summary>
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TestItemLookup();
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            TestStatOperations();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            TestConfigOperations();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddRandomItem();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveRandomItem();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            TestAllFunctions();
        }
    }

    /// <summary>
    /// Initialises the item database with sample items
    /// </summary>
    private void InitialiseItemDatabase()
    {
        itemDatabase = new Dictionary<string, ItemData>();
        itemIdToName = new Dictionary<int, string>();
        
        // Add sample items
        AddItem("sword_basic", new ItemData("Iron Sword", "A basic iron sword", 100, 3.5f, "Common", false));
        AddItem("potion_health", new ItemData("Health Potion", "Restores 50 HP", 25, 0.2f, "Common", true));
        AddItem("ring_power", new ItemData("Ring of Power", "Increases damage by 25%", 500, 0.1f, "Rare", false));
        AddItem("scroll_fireball", new ItemData("Fireball Scroll", "Casts a fireball spell", 75, 0.1f, "Uncommon", true));
        AddItem("armor_steel", new ItemData("Steel Armor", "Provides excellent protection", 300, 15.0f, "Uncommon", false));
        
        Debug.Log($"✅ Item database initialised with {itemDatabase.Count} items");
    }

    /// <summary>
    /// Initialises player statistics
    /// </summary>
    private void InitialisePlayerStats()
    {
        playerStats = new Dictionary<string, float>();
        playerAchievements = new Dictionary<string, int>();
        
        // Add basic player stats
        playerStats["Health"] = 100f;
        playerStats["Mana"] = 50f;
        playerStats["Strength"] = 10f;
        playerStats["Dexterity"] = 8f;
        playerStats["Intelligence"] = 12f;
        playerStats["Experience"] = 0f;
        playerStats["DamageDealt"] = 0f;
        playerStats["DamageTaken"] = 0f;
        
        // Add achievement counters
        playerAchievements["EnemiesKilled"] = 0;
        playerAchievements["ItemsCollected"] = 0;
        playerAchievements["QuestsCompleted"] = 0;
        playerAchievements["SecretAreas"] = 0;
        playerAchievements["DeathCount"] = 0;
        
        Debug.Log($"✅ Player stats initialised with {playerStats.Count} stats and {playerAchievements.Count} achievements");
    }

    /// <summary>
    /// Initialises game configuration settings
    /// </summary>
    private void InitialiseGameSettings()
    {
        gameSettings = new Dictionary<string, string>();
        difficultyModifiers = new Dictionary<string, float>();
        
        // Game configuration
        gameSettings["GameMode"] = "Adventure";
        gameSettings["Difficulty"] = "Normal";
        gameSettings["Language"] = "English";
        gameSettings["GraphicsQuality"] = "High";
        gameSettings["AutoSave"] = "Enabled";
        
        // Difficulty modifiers
        difficultyModifiers["EnemyHealthMultiplier"] = 1.0f;
        difficultyModifiers["EnemyDamageMultiplier"] = 1.0f;
        difficultyModifiers["ExperienceMultiplier"] = 1.0f;
        difficultyModifiers["LootDropRate"] = 1.0f;
        difficultyModifiers["PlayerHealthMultiplier"] = 1.0f;
        
        Debug.Log($"✅ Game settings initialised with {gameSettings.Count} settings and {difficultyModifiers.Count} modifiers");
    }

    /// <summary>
    /// Adds an item to the database with automatic ID assignment
    /// </summary>
    private void AddItem(string key, ItemData item)
    {
        if (!itemDatabase.ContainsKey(key))
        {
            itemDatabase[key] = item;
            itemIdToName[itemDatabase.Count] = key; // Simple ID assignment
        }
        else
        {
            Debug.LogWarning($"⚠️ Item with key '{key}' already exists!");
        }
    }

    /// <summary>
    /// Tests item lookup functionality
    /// </summary>
    private void TestItemLookup()
    {
        Debug.Log("🔍 Testing item lookup...");
        
        // Test lookup by key
        string[] testKeys = { "sword_basic", "potion_health", "ring_power", "nonexistent_item" };
        
        foreach (string key in testKeys)
        {
            if (itemDatabase.ContainsKey(key))
            {
                ItemData item = itemDatabase[key];
                Debug.Log($"✅ Found '{key}': {item.name} - {item.description} (Value: {item.value})");
            }
            else
            {
                Debug.Log($"❌ Item '{key}' not found in database");
            }
        }
        
        // Test lookup by ID
        Debug.Log("\n🔢 Testing ID-based lookup:");
        for (int id = 1; id <= 3; id++)
        {
            if (itemIdToName.ContainsKey(id))
            {
                string itemKey = itemIdToName[id];
                ItemData item = itemDatabase[itemKey];
                Debug.Log($"ID {id}: {item.name}");
            }
        }
    }

    /// <summary>
    /// Tests player statistics operations
    /// </summary>
    private void TestStatOperations()
    {
        Debug.Log("📊 Testing stat operations...");
        
        // Modify some stats
        ModifyPlayerStat("Health", -10f);
        ModifyPlayerStat("Experience", 25f);
        ModifyPlayerStat("DamageDealt", 150f);
        
        // Increment achievements
        IncrementAchievement("EnemiesKilled", 1);
        IncrementAchievement("ItemsCollected", 3);
        
        // Display modified stats
        Debug.Log($"Current Health: {GetPlayerStat("Health")}");
        Debug.Log($"Total Experience: {GetPlayerStat("Experience")}");
        Debug.Log($"Enemies Killed: {GetPlayerAchievement("EnemiesKilled")}");
    }

    /// <summary>
    /// Tests configuration operations
    /// </summary>
    private void TestConfigOperations()
    {
        Debug.Log("⚙️ Testing config operations...");
        
        // Change some settings
        SetGameSetting("Difficulty", "Hard");
        SetGameSetting("AutoSave", "Disabled");
        
        // Update difficulty modifiers based on new difficulty
        UpdateDifficultyModifiers("Hard");
        
        // Display current settings
        Debug.Log($"Current Difficulty: {GetGameSetting("Difficulty")}");
        Debug.Log($"Enemy Health Multiplier: {GetDifficultyModifier("EnemyHealthMultiplier")}");
        Debug.Log($"Experience Multiplier: {GetDifficultyModifier("ExperienceMultiplier")}");
    }

    /// <summary>
    /// Adds a random item to the database
    /// </summary>
    private void AddRandomItem()
    {
        string[] possibleNames = { "bow_elven", "staff_fire", "dagger_poison", "shield_dragon", "boots_speed" };
        string[] descriptions = { "A mystical weapon", "An ancient artifact", "A cursed item", "A blessed equipment", "A legendary gear" };
        string[] rarities = { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
        
        string key = possibleNames[Random.Range(0, possibleNames.Length)];
        
        if (!itemDatabase.ContainsKey(key))
        {
            ItemData newItem = new ItemData(
                key.Replace('_', ' '),
                descriptions[Random.Range(0, descriptions.Length)],
                Random.Range(50, 1000),
                Random.Range(0.1f, 10f),
                rarities[Random.Range(0, rarities.Length)],
                Random.Range(0, 2) == 1
            );
            
            AddItem(key, newItem);
            Debug.Log($"➕ Added random item: {newItem.name}");
        }
        else
        {
            Debug.Log($"⚠️ Item '{key}' already exists!");
        }
    }

    /// <summary>
    /// Removes a random item from the database
    /// </summary>
    private void RemoveRandomItem()
    {
        if (itemDatabase.Count > 0)
        {
            // Convert keys to array for random selection
            string[] keys = new string[itemDatabase.Count];
            itemDatabase.Keys.CopyTo(keys, 0);
            
            string keyToRemove = keys[Random.Range(0, keys.Length)];
            string itemName = itemDatabase[keyToRemove].name;
            
            itemDatabase.Remove(keyToRemove);
            
            // Also remove from ID mapping
            int idToRemove = -1;
            foreach (var kvp in itemIdToName)
            {
                if (kvp.Value == keyToRemove)
                {
                    idToRemove = kvp.Key;
                    break;
                }
            }
            if (idToRemove != -1)
            {
                itemIdToName.Remove(idToRemove);
            }
            
            Debug.Log($"➖ Removed item: {itemName}");
        }
        else
        {
            Debug.Log("⚠️ No items to remove!");
        }
    }

    /// <summary>
    /// Tests all dictionary functions comprehensively
    /// </summary>
    private void TestAllFunctions()
    {
        Debug.Log("🧪 Running comprehensive dictionary tests...");
        
        TestItemLookup();
        TestStatOperations();
        TestConfigOperations();
        
        Debug.Log("✅ All dictionary tests completed!");
    }

    // Helper methods for stat management
    public void ModifyPlayerStat(string statName, float amount)
    {
        if (playerStats.ContainsKey(statName))
        {
            playerStats[statName] += amount;
        }
    }

    public float GetPlayerStat(string statName)
    {
        return playerStats.ContainsKey(statName) ? playerStats[statName] : 0f;
    }

    public void IncrementAchievement(string achievementName, int amount)
    {
        if (playerAchievements.ContainsKey(achievementName))
        {
            playerAchievements[achievementName] += amount;
        }
    }

    public int GetPlayerAchievement(string achievementName)
    {
        return playerAchievements.ContainsKey(achievementName) ? playerAchievements[achievementName] : 0;
    }

    public void SetGameSetting(string settingName, string value)
    {
        gameSettings[settingName] = value;
    }

    public string GetGameSetting(string settingName)
    {
        return gameSettings.ContainsKey(settingName) ? gameSettings[settingName] : "";
    }

    public void SetDifficultyModifier(string modifierName, float value)
    {
        difficultyModifiers[modifierName] = value;
    }

    public float GetDifficultyModifier(string modifierName)
    {
        return difficultyModifiers.ContainsKey(modifierName) ? difficultyModifiers[modifierName] : 1.0f;
    }

    /// <summary>
    /// Updates difficulty modifiers based on difficulty setting
    /// </summary>
    private void UpdateDifficultyModifiers(string difficulty)
    {
        switch (difficulty.ToLower())
        {
            case "easy":
                SetDifficultyModifier("EnemyHealthMultiplier", 0.75f);
                SetDifficultyModifier("EnemyDamageMultiplier", 0.8f);
                SetDifficultyModifier("ExperienceMultiplier", 1.2f);
                SetDifficultyModifier("PlayerHealthMultiplier", 1.25f);
                break;
                
            case "normal":
                SetDifficultyModifier("EnemyHealthMultiplier", 1.0f);
                SetDifficultyModifier("EnemyDamageMultiplier", 1.0f);
                SetDifficultyModifier("ExperienceMultiplier", 1.0f);
                SetDifficultyModifier("PlayerHealthMultiplier", 1.0f);
                break;
                
            case "hard":
                SetDifficultyModifier("EnemyHealthMultiplier", 1.5f);
                SetDifficultyModifier("EnemyDamageMultiplier", 1.3f);
                SetDifficultyModifier("ExperienceMultiplier", 0.8f);
                SetDifficultyModifier("PlayerHealthMultiplier", 0.8f);
                break;
        }
    }

    /// <summary>
    /// Updates count displays for inspector
    /// </summary>
    private void UpdateCounts()
    {
        totalItems = itemDatabase?.Count ?? 0;
        totalStats = playerStats?.Count ?? 0;
        totalSettings = gameSettings?.Count ?? 0;
    }

    /// <summary>
    /// Displays all dictionary contents
    /// </summary>
    private void DisplayAllDictionaries()
    {
        Debug.Log("=== DICTIONARY CONTENTS ===");
        
        Debug.Log($"📦 Items ({itemDatabase.Count}):");
        foreach (var kvp in itemDatabase)
        {
            Debug.Log($"  {kvp.Key}: {kvp.Value.name} (${kvp.Value.value})");
        }
        
        Debug.Log($"📊 Player Stats ({playerStats.Count}):");
        foreach (var kvp in playerStats)
        {
            Debug.Log($"  {kvp.Key}: {kvp.Value}");
        }
        
        Debug.Log($"⚙️ Game Settings ({gameSettings.Count}):");
        foreach (var kvp in gameSettings)
        {
            Debug.Log($"  {kvp.Key}: {kvp.Value}");
        }
        
        Debug.Log("============================");
    }
}
```

---

*[Continue with Final Project part...]*## 🎮 **Part 5: Complete Mini-Game Project - "Data Quest"**

### **Project Overview**
We'll create a complete mini-game called "Data Quest" that integrates all concepts from the course:
- **Player movement and input** (Session 04)
- **Inventory system with persistence** (Sessions 05-06)
- **Game state management** (Session 07)
- **Save/load functionality** (Session 08)
- **Achievement system with data tracking**

### **Script 5: Complete Mini-Game**

#### **Step 1: Create the Main Game Script**
Create `DataQuestGame` script:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// Complete mini-game demonstrating all course concepts
/// "Data Quest" - A simple adventure game with persistence
/// Integrates movement, inventory, save/load, achievements, and data management
/// </summary>
public class DataQuestGame : MonoBehaviour
{
    [Header("Game State")]
    [SerializeField] private GameState currentState = GameState.MainMenu;
    [SerializeField] private float gameTime = 0f;
    [SerializeField] private bool isPaused = false;
    
    [Header("Player Data")]
    [SerializeField] private DataQuestPlayerData playerData;
    [SerializeField] private Vector3 playerStartPosition = Vector3.zero;
    
    [Header("Game World")]
    [SerializeField] private List<CollectibleItem> availableItems;
    [SerializeField] private List<Transform> itemSpawnPoints;
    [SerializeField] private GameObject collectiblePrefab; // We'll create this
    
    [Header("UI References")]
    [SerializeField] private UnityEngine.UI.Text gameStateText;
    [SerializeField] private UnityEngine.UI.Text playerInfoText;
    [SerializeField] private UnityEngine.UI.Text inventoryText;
    [SerializeField] private UnityEngine.UI.Text achievementsText;
    
    [Header("Save System")]
    [SerializeField] private string saveFileName = "dataquest_save.json";
    [SerializeField] private bool autoSaveEnabled = true;
    [SerializeField] private float autoSaveInterval = 30f;
    
    private string savePath;
    private float autoSaveTimer = 0f;
    private List<GameObject> spawnedItems;

    /// <summary>
    /// Game states for our mini-game
    /// </summary>
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver,
        Victory
    }

    /// <summary>
    /// Data structure for collectible items
    /// </summary>
    [System.Serializable]
    public class CollectibleItem
    {
        public string itemName;
        public string description;
        public int pointValue;
        public string rarity;
        public Color itemColor;
        public bool isSpecial;

        public CollectibleItem(string name, string desc, int points, string rarity, Color color, bool special = false)
        {
            this.itemName = name;
            this.description = desc;
            this.pointValue = points;
            this.rarity = rarity;
            this.itemColor = color;
            this.isSpecial = special;
        }
    }

    /// <summary>
    /// Complete player data for our mini-game
    /// </summary>
    [System.Serializable]
    public class DataQuestPlayerData
    {
        // Basic progress
        public string playerName;
        public int totalScore;
        public int highScore;
        public float totalPlayTime;
        public int gamesPlayed;
        
        // Current game state
        public float positionX, positionY, positionZ;
        public List<string> collectedItems;
        public List<int> itemQuantities;
        
        // Statistics
        public int itemsCollected;
        public int commonItemsFound;
        public int rareItemsFound;
        public int specialItemsFound;
        public float fastestCompletion;
        
        // Achievements
        public List<string> unlockedAchievements;
        public Dictionary<string, int> achievementProgress;
        
        // Settings
        public float movementSpeed;
        public bool soundEnabled;
        public DateTime lastPlayDate;
        public DateTime firstPlayDate;

        public DataQuestPlayerData()
        {
            playerName = "Adventurer";
            totalScore = 0;
            highScore = 0;
            totalPlayTime = 0f;
            gamesPlayed = 0;
            
            positionX = positionY = positionZ = 0f;
            collectedItems = new List<string>();
            itemQuantities = new List<int>();
            
            itemsCollected = 0;
            commonItemsFound = 0;
            rareItemsFound = 0;
            specialItemsFound = 0;
            fastestCompletion = float.MaxValue;
            
            unlockedAchievements = new List<string>();
            achievementProgress = new Dictionary<string, int>();
            
            movementSpeed = 5f;
            soundEnabled = true;
            lastPlayDate = DateTime.Now;
            firstPlayDate = DateTime.Now;
        }
    }

    /// <summary>
    /// Unity Start method - initialises the complete game
    /// </summary>
    void Start()
    {
        Debug.Log("=== DATA QUEST GAME STARTED ===");
        
        // Set up save system
        savePath = Path.Combine(Application.persistentDataPath, saveFileName);
        
        // Initialise game data
        InitialiseGame();
        
        // Set up UI
        UpdateUI();
        
        Debug.Log("🎮 Welcome to Data Quest!");
        Debug.Log("Controls: WASD = Move, ESC = Pause, F5 = Save, F9 = Load");
        Debug.Log("Goal: Collect all items to win! Data persists between sessions.");
    }

    /// <summary>
    /// Unity Update method - main game loop
    /// </summary>
    void Update()
    {
        HandleInput();
        UpdateGameLogic();
        UpdateUI();
        HandleAutoSave();
    }

    /// <summary>
    /// Initialises the complete game system
    /// </summary>
    private void InitialiseGame()
    {
        // Try to load existing save data
        LoadGame();
        
        // Create collectible items if this is a new game or items were collected
        SetupGameWorld();
        
        // Initialise achievement system
        InitialiseAchievements();
        
        // Set initial game state
        ChangeGameState(GameState.Playing);
    }

    /// <summary>
    /// Sets up the game world with collectible items
    /// </summary>
    private void SetupGameWorld()
    {
        // Define available collectible items
        availableItems = new List<CollectibleItem>
        {
            new CollectibleItem("Crystal Shard", "A glowing crystal fragment", 10, "Common", Color.blue),
            new CollectibleItem("Gold Coin", "Valuable currency", 5, "Common", Color.yellow),
            new CollectibleItem("Magic Gem", "Enchanted precious stone", 25, "Rare", Color.magenta),
            new CollectibleItem("Ancient Rune", "Mysterious carved stone", 50, "Epic", Color.cyan),
            new CollectibleItem("Dragon Scale", "Legendary dragon remnant", 100, "Legendary", Color.red, true)
        };
        
        // Create spawn points in a circle pattern
        itemSpawnPoints = new List<Transform>();
        float radius = 8f;
        int spawnCount = 12;
        
        for (int i = 0; i < spawnCount; i++)
        {
            float angle = (360f / spawnCount) * i * Mathf.Deg2Rad;
            Vector3 spawnPos = new Vector3(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius,
                0f
            );
            
            GameObject spawnPoint = new GameObject($"SpawnPoint_{i}");
            spawnPoint.transform.position = spawnPos;
            spawnPoint.transform.parent = this.transform;
            itemSpawnPoints.Add(spawnPoint.transform);
        }
        
        // Spawn collectible items
        SpawnCollectibleItems();
        
        Debug.Log($"✅ Game world set up with {itemSpawnPoints.Count} spawn points");
    }

    /// <summary>
    /// Spawns collectible items in the world
    /// </summary>
    private void SpawnCollectibleItems()
    {
        // Clear existing items
        if (spawnedItems != null)
        {
            foreach (GameObject item in spawnedItems)
            {
                if (item != null) Destroy(item);
            }
        }
        
        spawnedItems = new List<GameObject>();
        
        // Spawn items at random spawn points
        List<int> availableSpawnIndices = new List<int>();
        for (int i = 0; i < itemSpawnPoints.Count; i++)
        {
            availableSpawnIndices.Add(i);
        }
        
        // Spawn each type of item
        foreach (CollectibleItem itemData in availableItems)
        {
            if (availableSpawnIndices.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, availableSpawnIndices.Count);
                int spawnIndex = availableSpawnIndices[randomIndex];
                availableSpawnIndices.RemoveAt(randomIndex);
                
                GameObject newItem = CreateCollectibleObject(itemData, itemSpawnPoints[spawnIndex].position);
                spawnedItems.Add(newItem);
            }
        }
        
        Debug.Log($"🎯 Spawned {spawnedItems.Count} collectible items");
    }

    /// <summary>
    /// Creates a collectible object in the world
    /// </summary>
    private GameObject CreateCollectibleObject(CollectibleItem itemData, Vector3 position)
    {
        // Create the game object
        GameObject collectible = GameObject.CreatePrimitive(PrimitiveType.Cube);
        collectible.name = $"Collectible_{itemData.itemName}";
        collectible.transform.position = position;
        collectible.transform.localScale = Vector3.one * 0.5f;
        
        // Set visual appearance
        Renderer renderer = collectible.GetComponent<Renderer>();
        renderer.material.color = itemData.itemColor;
        
        // Add trigger collider for collection
        Collider collider = collectible.GetComponent<Collider>();
        collider.isTrigger = true;
        
        // Add collection component
        CollectibleObject collectibleComponent = collectible.AddComponent<CollectibleObject>();
        collectibleComponent.itemData = itemData;
        collectibleComponent.gameManager = this;
        
        // Add visual effects
        collectible.AddComponent<CollectibleRotator>(); // We'll create this
        
        return collectible;
    }

    /// <summary>
    /// Handles all input for the game
    /// </summary>
    private void HandleInput()
    {
        // Pause/unpause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        
        // Save/Load
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }
        
        if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadGame();
        }
        
        // Reset game
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ResetGame();
        }
        
        // Player movement (only when playing)
        if (currentState == GameState.Playing && !isPaused)
        {
            HandlePlayerMovement();
        }
    }

    /// <summary>
    /// Handles player movement input
    /// </summary>
    private void HandlePlayerMovement()
    {
        Vector3 movement = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            movement.y += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            movement.y -= 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            movement.x -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            movement.x += 1f;
        
        if (movement != Vector3.zero)
        {
            // Normalise movement for consistent speed in all directions
            movement = movement.normalized * playerData.movementSpeed * Time.deltaTime;
            
            // Apply movement
            transform.position += movement;
            
            // Update player data position
            playerData.positionX = transform.position.x;
            playerData.positionY = transform.position.y;
            playerData.positionZ = transform.position.z;
        }
    }

    /// <summary>
    /// Updates game logic each frame
    /// </summary>
    private void UpdateGameLogic()
    {
        if (currentState == GameState.Playing && !isPaused)
        {
            // Update play time
            gameTime += Time.deltaTime;
            playerData.totalPlayTime += Time.deltaTime;
            
            // Check win condition
            if (spawnedItems != null && spawnedItems.Count == 0)
            {
                CheckWinCondition();
            }
        }
    }

    /// <summary>
    /// Checks if the player has won the game
    /// </summary>
    private void CheckWinCondition()
    {
        // Count active collectibles
        int remainingItems = 0;
        foreach (GameObject item in spawnedItems)
        {
            if (item != null) remainingItems++;
        }
        
        if (remainingItems == 0)
        {
            // Player wins!
            ChangeGameState(GameState.Victory);
            
            // Update high score
            if (playerData.totalScore > playerData.highScore)
            {
                playerData.highScore = playerData.totalScore;
                Debug.Log($"🏆 New High Score: {playerData.highScore}!");
            }
            
            // Update fastest completion
            if (gameTime < playerData.fastestCompletion)
            {
                playerData.fastestCompletion = gameTime;
                UnlockAchievement("Speed Runner");
            }
            
            playerData.gamesPlayed++;
            SaveGame();
            
            Debug.Log($"🎉 VICTORY! Game completed in {gameTime:F1} seconds!");
        }
    }

    /// <summary>
    /// Handles item collection
    /// </summary>
    public void CollectItem(CollectibleItem itemData, GameObject itemObject)
    {
        Debug.Log($"✨ Collected: {itemData.itemName} (+{itemData.pointValue} points)");
        
        // Add to inventory
        AddToInventory(itemData.itemName);
        
        // Add points
        playerData.totalScore += itemData.pointValue;
        
        // Update statistics
        playerData.itemsCollected++;
        
        switch (itemData.rarity.ToLower())
        {
            case "common":
                playerData.commonItemsFound++;
                break;
            case "rare":
                playerData.rareItemsFound++;
                UnlockAchievement("Rare Collector");
                break;
            case "epic":
                playerData.specialItemsFound++;
                UnlockAchievement("Epic Hunter");
                break;
            case "legendary":
                playerData.specialItemsFound++;
                UnlockAchievement("Legend Seeker");
                break;
        }
        
        // Check achievements
        CheckItemAchievements();
        
        // Remove from world
        spawnedItems.Remove(itemObject);
        Destroy(itemObject);
    }

    /// <summary>
    /// Adds item to inventory
    /// </summary>
    private void AddToInventory(string itemName)
    {
        int existingIndex = playerData.collectedItems.IndexOf(itemName);
        if (existingIndex >= 0)
        {
            playerData.itemQuantities[existingIndex]++;
        }
        else
        {
            playerData.collectedItems.Add(itemName);
            playerData.itemQuantities.Add(1);
        }
    }

    /// <summary>
    /// Checks for item-related achievements
    /// </summary>
    private void CheckItemAchievements()
    {
        if (playerData.itemsCollected >= 10)
            UnlockAchievement("Collector");
        
        if (playerData.itemsCollected >= 50)
            UnlockAchievement("Hoarder");
        
        if (playerData.commonItemsFound >= 5)
            UnlockAchievement("Common Gatherer");
        
        if (playerData.totalScore >= 1000)
            UnlockAchievement("High Scorer");
    }

    /// <summary>
    /// Unlocks an achievement
    /// </summary>
    public void UnlockAchievement(string achievementName)
    {
        if (!playerData.unlockedAchievements.Contains(achievementName))
        {
            playerData.unlockedAchievements.Add(achievementName);
            Debug.Log($"🏅 Achievement Unlocked: {achievementName}!");
        }
    }

    /// <summary>
    /// Initialises the achievement system
    /// </summary>
    private void InitialiseAchievements()
    {
        // This would typically load from a file or database
        // For now, we define achievements in code
        Debug.Log("🏅 Achievement system initialised");
    }

    /// <summary>
    /// Changes the game state
    /// </summary>
    private void ChangeGameState(GameState newState)
    {
        currentState = newState;
        Debug.Log($"🎮 Game State: {currentState}");
    }

    /// <summary>
    /// Toggles pause state
    /// </summary>
    private void TogglePause()
    {
        if (currentState == GameState.Playing)
        {
            isPaused = !isPaused;
            Debug.Log($"⏸️ Game {(isPaused ? "Paused" : "Resumed")}");
        }
    }

    /// <summary>
    /// Saves the complete game state
    /// </summary>
    public void SaveGame()
    {
        try
        {
            playerData.lastPlayDate = DateTime.Now;
            
            string jsonData = JsonUtility.ToJson(playerData, true);
            File.WriteAllText(savePath, jsonData);
            
            Debug.Log("💾 Game saved successfully!");
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Save failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads the complete game state
    /// </summary>
    public void LoadGame()
    {
        try
        {
            if (File.Exists(savePath))
            {
                string jsonData = File.ReadAllText(savePath);
                playerData = JsonUtility.FromJson<DataQuestPlayerData>(jsonData);
                
                // Restore player position
                transform.position = new Vector3(playerData.positionX, playerData.positionY, playerData.positionZ);
                
                Debug.Log("📂 Game loaded successfully!");
                Debug.Log($"Welcome back, {playerData.playerName}! Total Score: {playerData.totalScore}");
            }
            else
            {
                // Create new player data
                playerData = new DataQuestPlayerData();
                Debug.Log("🆕 New game started!");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Load failed: {ex.Message}");
            playerData = new DataQuestPlayerData();
        }
    }

    /// <summary>
    /// Resets the entire game
    /// </summary>
    private void ResetGame()
    {
        playerData = new DataQuestPlayerData();
        gameTime = 0f;
        transform.position = playerStartPosition;
        
        SpawnCollectibleItems();
        ChangeGameState(GameState.Playing);
        
        Debug.Log("🔄 Game reset!");
    }

    /// <summary>
    /// Handles auto-save functionality
    /// </summary>
    private void HandleAutoSave()
    {
        if (autoSaveEnabled && currentState == GameState.Playing)
        {
            autoSaveTimer += Time.deltaTime;
            if (autoSaveTimer >= autoSaveInterval)
            {
                SaveGame();
                autoSaveTimer = 0f;
                Debug.Log("🔄 Auto-save triggered");
            }
        }
    }

    /// <summary>
    /// Updates all UI elements
    /// </summary>
    private void UpdateUI()
    {
        if (gameStateText != null)
        {
            string stateDisplay = $"State: {currentState}";
            if (isPaused) stateDisplay += " (PAUSED)";
            gameStateText.text = stateDisplay;
        }
        
        if (playerInfoText != null)
        {
            playerInfoText.text = $"Score: {playerData.totalScore} | High: {playerData.highScore}\n" +
                                  $"Time: {gameTime:F1}s | Items: {playerData.itemsCollected}";
        }
        
        if (inventoryText != null)
        {
            string inventoryDisplay = "Inventory:\n";
            for (int i = 0; i < playerData.collectedItems.Count; i++)
            {
                inventoryDisplay += $"• {playerData.collectedItems[i]} x{playerData.itemQuantities[i]}\n";
            }
            inventoryText.text = inventoryDisplay;
        }
        
        if (achievementsText != null)
        {
            string achievementDisplay = $"Achievements ({playerData.unlockedAchievements.Count}):\n";
            foreach (string achievement in playerData.unlockedAchievements)
            {
                achievementDisplay += $"🏅 {achievement}\n";
            }
            achievementsText.text = achievementDisplay;
        }
    }
}

/// <summary>
/// Component for collectible objects in the world
/// </summary>
public class CollectibleObject : MonoBehaviour
{
    public DataQuestGame.CollectibleItem itemData;
    public DataQuestGame gameManager;
    
    /// <summary>
    /// Handles collection when player touches the item
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.name.Contains("DataManager"))
        {
            gameManager.CollectItem(itemData, gameObject);
        }
    }
}

/// <summary>
/// Simple component to rotate collectible items
/// </summary>
public class CollectibleRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private float bobHeight = 0.5f;
    [SerializeField] private float bobSpeed = 2f;
    
    private Vector3 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        // Rotate around Y axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        
        // Bob up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
```

#### **Step 2: Set Up the Mini-Game**
1. **Create DataQuestGame GameObject**: Empty object named "DataQuestGame"
2. **Attach DataQuestGame script**
3. **Create Player object**: Create a cube, name it "Player", tag it as "Player"
4. **Position Player**: Set position to (0,0,0)
5. **Create simple UI elements** (optional):
   - Canvas with Text elements for game info
   - Connect UI references in the script

#### **Step 3: Test the Complete Game**
1. **Press Play**
2. **Use WASD** to move around
3. **Collect items** by walking into them
4. **Press F5** to save, **F9** to load
5. **Press ESC** to pause
6. **Press F1** to reset

---

## 📝 **Part 6: Student Exercise**

### **Your Task: Extend the Data Quest Game**
Now it's your turn to extend the mini-game with additional features:

#### **Exercise 1: Add New Item Types**
- Create 3 new collectible items with unique properties
- Add them to the available items list
- Implement special effects for rare items

#### **Exercise 2: Enhanced Save System**
- Add multiple save slots (Save1.json, Save2.json, Save3.json)
- Create a save/load menu system
- Add backup save functionality

#### **Exercise 3: Statistics Tracking**
- Track additional player statistics (distance traveled, time played)
- Create a statistics display screen
- Save statistics separately from game data

#### **Exercise 4: Achievement System**
- Add 5 new achievements with different criteria
- Create an achievement notification system
- Save achievement unlock dates

---

## 🔧 **Troubleshooting Guide**

### **Common File I/O Issues**
**Problem**: "File not found" errors
**Solution**: Check that the file path uses `Application.persistentDataPath`

**Problem**: JSON serialisation fails
**Solution**: Ensure all classes use `[System.Serializable]` attribute

**Problem**: Data doesn't persist between sessions
**Solution**: Call `PlayerPrefs.Save()` after setting values

### **Unity-Specific Issues**
**Problem**: Inspector shows empty references
**Solution**: Reconnect UI Text components in the Inspector

**Problem**: Player doesn't move
**Solution**: Ensure the Player GameObject has the correct tag

**Problem**: Items don't collect
**Solution**: Check that Collider is set to "Is Trigger"

### **Performance Considerations**
- **File I/O**: Don't save every frame - use timers or specific events
- **JSON**: Large data structures can be slow to serialise
- **PlayerPrefs**: Fast for simple data, but limited in size
- **Dictionaries**: Excellent for frequent lookups, but use memory efficiently

---

## ✅ **Session 08 Completion Checklist**

### **Technical Skills Mastered**
- [ ] **File I/O Operations**: Can read and write files to persistent storage
- [ ] **JSON Serialisation**: Can convert objects to/from JSON format
- [ ] **PlayerPrefs Usage**: Can save simple settings and preferences
- [ ] **Dictionary Management**: Can use dictionaries for fast data lookup
- [ ] **Error Handling**: Can handle file operation exceptions properly
- [ ] **Data Persistence**: Can save and load complex game states
- [ ] **Performance Awareness**: Understand when to use different data methods

### **Unity Integration Skills**
- [ ] **Script Attachment**: Can attach data management scripts to GameObjects
- [ ] **Inspector Integration**: Can view and modify data structures in Inspector
- [ ] **Console Debugging**: Can debug file operations using Debug.Log
- [ ] **Scene Management**: Can maintain data across scene changes
- [ ] **Component Communication**: Can pass data between different scripts

### **Programming Concepts Applied**
- [ ] **Object-Oriented Design**: Created reusable data classes and managers
- [ ] **Exception Handling**: Used try-catch blocks for robust file operations
- [ ] **Serialisation**: Understood how to make data persistent
- [ ] **Data Structures**: Applied appropriate collections for different use cases
- [ ] **Game Architecture**: Designed systems that work together effectively

### **Professional Development Practices**
- [ ] **Code Documentation**: Added comprehensive XML comments
- [ ] **Error Prevention**: Implemented robust error handling
- [ ] **User Experience**: Created systems that recover gracefully from errors
- [ ] **Data Validation**: Ensured saved data is valid before loading
- [ ] **Performance Optimization**: Used efficient data access patterns

---

## 🎓 **Congratulations!**

You've completed Session 08 and the entire CRE132 course! You now have:

- **Comprehensive C# knowledge** from basic syntax to advanced object-oriented programming
- **Unity game development skills** including scenes, components, and systems
- **Professional development practices** with proper code organisation and documentation
- **Complete portfolio project** demonstrating all learned concepts
- **Real-world applicable skills** for game development and software engineering

### **Next Steps**
- **Expand your mini-game** with additional features and complexity
- **Create your own projects** using the patterns and techniques learned
- **Explore advanced Unity features** like animation, physics, and networking
- **Join game development communities** to continue learning and sharing
- **Build a portfolio** showcasing your Unity and C# skills

---

*Session 08 Complete - CRE132 Game Development Fundamentals*  
*Northern Irish University - AI and Games Department*  
*Professional Unity Development Course*