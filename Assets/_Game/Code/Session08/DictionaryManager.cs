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