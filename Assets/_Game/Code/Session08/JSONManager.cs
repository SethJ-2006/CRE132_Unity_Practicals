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