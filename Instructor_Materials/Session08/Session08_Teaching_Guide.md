# Session 8: Data Persistence & Final Project

## Session Overview

**Duration**: 150-180 minutes  
**W3Schools Topics**: Files, Data Structures, Review & Integration  
**Unity Concepts**: Data persistence, complete game architecture, professional deployment  
**Course Position**: Capstone session integrating all Sessions 1-7 concepts

## Learning Objectives

By the end of this session, students will:
1. ✅ **Complete Course Integration**: Apply all Sessions 1-7 concepts in professional context
2. ✅ Master file I/O operations using Unity's persistent data path with robust error handling
3. ✅ Implement JSON serialisation/deserialisation for complex game data structures
4. ✅ Use PlayerPrefs system for settings, preferences, and simple data persistence
5. ✅ Apply Dictionary data structures for efficient lookup and game configuration systems
6. ✅ Create complete "Data Quest" mini-game integrating all course concepts
7. ✅ Demonstrate professional code organization and performance-conscious development
8. ✅ **Portfolio Readiness**: Build systems suitable for employment demonstration

## Scripts Included

### 1. `FileManager.cs`
**Purpose**: Basic file I/O operations with Unity's persistent data path and robust error handling  
**Key Features**:
- Unity persistent data path management for cross-platform compatibility
- File read/write operations with proper error handling and validation
- Text and binary file operations for different data types
- Performance considerations for file operations in games
- **Course Integration**: Uses error handling patterns and method design from Sessions 2-3

### 2. `PlayerData.cs` & `JSONManager.cs`
**Purpose**: Serializable data class and complete JSON save/load system  
**Key Features**:
- Serializable data classes for game state persistence (Session 5 class design)
- JSON serialisation/deserialisation using Unity's JsonUtility
- Complex data structure handling (arrays, lists, nested objects)
- Auto-save functionality with timer-based and event-based saving
- **Course Integration**: Uses Collections (Session 4), Classes (Session 5), and constructors

### 3. `PlayerPrefsManager.cs`
**Purpose**: Settings and preferences management system  
**Key Features**:
- PlayerPrefs wrapper for type-safe preference management
- Settings categories (graphics, audio, gameplay, controls)
- DefaultValue patterns and preference validation
- **Course Integration**: Uses Session 5 access modifiers and Session 3 methods for encapsulation

### 4. `DictionaryManager.cs`
**Purpose**: Dictionary operations for fast data lookup and game configuration  
**Key Features**:
- Dictionary creation, manipulation, and performance optimization
- Item database systems with fast lookup capabilities
- Configuration management using key-value pairs
- **Course Integration**: Uses Session 4 collections knowledge with advanced data structures

### 5. `DataQuestGame.cs`
**Purpose**: Complete mini-game integrating all course concepts and demonstrating professional architecture  
**Key Features**:
- **Sessions 1-3**: Variables, operators, loops, methods for game logic
- **Session 4**: Collections for managing game entities and items
- **Sessions 5-6**: OOP with inheritance hierarchies for game systems
- **Session 7**: Interfaces and state management for professional architecture  
- **Session 8**: Data persistence for save/load and configuration systems
- Complete game loop with professional error handling and performance optimization
## Teaching Sequence

### Phase 1: File I/O Foundations - Building on Course Fundamentals (30 minutes)
**Using `FileManager.cs` - Integration with Sessions 2-3:**

1. **Course Integration Review (5 minutes)**:
   ```csharp
   // "We've learned all the pieces - now let's put them together professionally"
   // Session 1: Variables for file paths and data
   // Session 2: Conditional logic for error handling  
   // Session 3: Methods for reusable file operations
   // Session 4: Collections for managing multiple files
   // Session 5: Classes to organize file management systems
   ```

2. **Unity Persistent Data Path (10 minutes)**:
   ```csharp
   public class FileManager : MonoBehaviour
   {
       // Session 1: Variables and constants
       private static readonly string DATA_FOLDER = "GameData";
       private static readonly string SAVE_EXTENSION = ".json";
       
       // Session 5: Properties for encapsulation
       public static string DataPath => Path.Combine(Application.persistentDataPath, DATA_FOLDER);
       
       // Session 3: Methods with error handling (Session 2 conditional logic)
       public static bool EnsureDataFolderExists()
       {
           try
           {
               if (!Directory.Exists(DataPath))  // Session 2: Conditional logic
               {
                   Directory.CreateDirectory(DataPath);
                   Debug.Log($"Created data folder: {DataPath}");
               }
               return true;
           }
           catch (System.Exception e)  // Session 8: Exception handling
           {
               Debug.LogError($"Failed to create data folder: {e.Message}");
               return false;
           }
       }
   }
   ```

3. **Robust File Operations (15 minutes)**:
   ```csharp
   // Session 3: Methods with parameters and return values
   public static bool WriteTextFile(string fileName, string content)
   {
       if (!EnsureDataFolderExists()) return false;  // Session 2: Early return pattern
       
       string fullPath = Path.Combine(DataPath, fileName);
       
       try
       {
           File.WriteAllText(fullPath, content);
           Debug.Log($"Successfully wrote file: {fileName}");
           return true;
       }
       catch (System.Exception e)
       {
           Debug.LogError($"Failed to write file {fileName}: {e.Message}");
           return false;
       }
   }
   
   public static string ReadTextFile(string fileName)
   {
       string fullPath = Path.Combine(DataPath, fileName);
       
       // Session 2: Conditional validation
       if (!File.Exists(fullPath))
       {
           Debug.LogWarning($"File not found: {fileName}");
           return string.Empty;  // Session 3: Default return values
       }
       
       try
       {
           string content = File.ReadAllText(fullPath);
           Debug.Log($"Successfully read file: {fileName}");
           return content;
       }
       catch (System.Exception e)
       {
           Debug.LogError($"Failed to read file {fileName}: {e.Message}");
           return string.Empty;
       }
   }
   
   // Session 4: Working with file collections
   public static List<string> GetAllSaveFiles()
   {
       List<string> saveFiles = new List<string>();  // Session 4: Lists
       
       if (!Directory.Exists(DataPath)) return saveFiles;
       
       try
       {
           string[] files = Directory.GetFiles(DataPath, "*" + SAVE_EXTENSION);
           
           // Session 3: foreach loops with Session 4 collections
           foreach (string filePath in files)
           {
               string fileName = Path.GetFileNameWithoutExtension(filePath);
               saveFiles.Add(fileName);  // Session 4: List operations
           }
       }
       catch (System.Exception e)
       {
           Debug.LogError($"Failed to get save files: {e.Message}");
       }
       
       return saveFiles;
   }
   ```

### Phase 2: JSON Serialisation - Advanced Data Structures (35 minutes)
**Using `PlayerData.cs` & `JSONManager.cs` - Sessions 4-5 Integration:**

1. **Serializable Data Classes (10 minutes)**:
   ```csharp
   // Session 5: Classes with proper encapsulation and constructors
   [System.Serializable]
   public class PlayerData
   {
       // Session 1: Variables with appropriate data types
       public string playerName = "Unknown";
       public int level = 1;
       public float experience = 0f;
       public int health = 100;
       public int maxHealth = 100;
       
       // Session 4: Collections for complex data
       public List<string> inventory = new List<string>();
       public List<int> questsCompleted = new List<int>();
       
       // Session 5: Constructors for flexible object creation
       public PlayerData() { }  // Default constructor for JSON
       
       public PlayerData(string name, int startLevel)
       {
           playerName = name;
           level = startLevel;
           maxHealth = 100 + (level * 10);  // Session 2: Mathematical operations
           health = maxHealth;
           
           // Session 4: Initialize collections
           inventory = new List<string> { "Basic Sword", "Health Potion" };
           questsCompleted = new List<int>();
       }
       
       // Session 3: Methods for data manipulation
       public void AddItem(string item)
       {
           if (!string.IsNullOrEmpty(item))  // Session 2: Validation
           {
               inventory.Add(item);  // Session 4: List operations
           }
       }
       
       public bool RemoveItem(string item)
       {
           return inventory.Remove(item);  // Session 4: List operations with return value
       }
       
       public void AddExperience(float exp)
       {
           experience += exp;  // Session 2: Assignment operators
           
           // Session 2: Conditional logic for leveling up
           while (experience >= GetExperienceForNextLevel())
           {
               LevelUp();
           }
       }
       
       private void LevelUp()
       {
           level++;  // Session 2: Increment operator
           int healthIncrease = 10;
           maxHealth += healthIncrease;
           health = maxHealth;  // Full heal on level up
           Debug.Log($"Level up! Now level {level}");
       }
       
       private float GetExperienceForNextLevel()
       {
           return level * 100f;  // Session 2: Mathematical operations
       }
   }
   ```

2. **JSON Manager System (15 minutes)**:
   ```csharp
   // Session 5: Static utility class for JSON operations
   public static class JSONManager
   {
       // Session 1: Constants for configuration
       private const string PLAYER_DATA_FILE = "PlayerData.json";
       private const string SETTINGS_FILE = "Settings.json";
       
       // Session 3: Generic method for saving any serializable object
       public static bool SaveData<T>(T data, string fileName) where T : class
       {
           try
           {
               string json = JsonUtility.ToJson(data, true);  // Pretty print for debugging
               return FileManager.WriteTextFile(fileName, json);
           }
           catch (System.Exception e)
           {
               Debug.LogError($"Failed to serialize data: {e.Message}");
               return false;
           }
       }
       
       // Session 3: Generic method for loading any serializable object
       public static T LoadData<T>(string fileName) where T : class, new()
       {
           try
           {
               string json = FileManager.ReadTextFile(fileName);
               
               // Session 2: Conditional validation
               if (string.IsNullOrEmpty(json))
               {
                   Debug.LogWarning($"No data found in {fileName}, creating new instance");
                   return new T();  // Session 5: Default constructor
               }
               
               T data = JsonUtility.FromJson<T>(json);
               return data ?? new T();  // Session 5: Null coalescing
           }
           catch (System.Exception e)
           {
               Debug.LogError($"Failed to deserialize data: {e.Message}");
               return new T();  // Session 5: Fallback to default constructor
           }
       }
       
       // Specific methods for common data types
       public static bool SavePlayerData(PlayerData data)
       {
           return SaveData(data, PLAYER_DATA_FILE);
       }
       
       public static PlayerData LoadPlayerData()
       {
           return LoadData<PlayerData>(PLAYER_DATA_FILE);
       }
   }
   ```

3. **Auto-Save System (10 minutes)**:
   ```csharp
   public class AutoSaveManager : MonoBehaviour
   {
       // Session 1: Variables for configuration
       [SerializeField] private float saveInterval = 30f;  // Save every 30 seconds
       [SerializeField] private bool autoSaveEnabled = true;
       
       // Session 1: Private variables for state tracking
       private float lastSaveTime = 0f;
       private PlayerData currentPlayerData;
       
       // Session 5: Properties for controlled access
       public PlayerData PlayerData 
       { 
           get => currentPlayerData; 
           set => currentPlayerData = value; 
       }
       
       void Start()
       {
           // Load existing data or create new
           currentPlayerData = JSONManager.LoadPlayerData();
           
           if (string.IsNullOrEmpty(currentPlayerData.playerName))
           {
               // Session 5: Initialize with default data
               currentPlayerData = new PlayerData("New Player", 1);
           }
       }
       
       void Update()
       {
           // Session 2: Conditional auto-save logic
           if (autoSaveEnabled && Time.time - lastSaveTime >= saveInterval)
           {
               SaveGame();
           }
       }
       
       public void SaveGame()
       {
           if (JSONManager.SavePlayerData(currentPlayerData))
           {
               lastSaveTime = Time.time;
               Debug.Log("Game saved successfully!");
           }
       }
       
       // Save on application focus loss or quit
       void OnApplicationFocus(bool hasFocus)
       {
           if (!hasFocus) SaveGame();
       }
       
       void OnApplicationPause(bool pauseStatus)
       {
           if (pauseStatus) SaveGame();
       }
   }
   ```


### Phase 3: PlayerPrefs and Simple Data Persistence (25 minutes)
**Using `PlayerPrefsManager.cs` - Sessions 3-5 Integration:**

1. **Type-Safe PlayerPrefs Wrapper (15 minutes)**:
   ```csharp
   // Session 5: Static utility class with proper encapsulation
   public static class PlayerPrefsManager
   {
       // Session 1: Constants for preference keys
       private const string MASTER_VOLUME = "MasterVolume";
       private const string MUSIC_VOLUME = "MusicVolume";
       private const string SFX_VOLUME = "SFXVolume";
       private const string GRAPHICS_QUALITY = "GraphicsQuality";
       private const string FULLSCREEN = "Fullscreen";
       private const string DIFFICULTY = "Difficulty";
       
       // Session 3: Methods with default values and validation
       public static float GetFloat(string key, float defaultValue = 0f)
       {
           return PlayerPrefs.GetFloat(key, defaultValue);
       }
       
       public static void SetFloat(string key, float value)
       {
           PlayerPrefs.SetFloat(key, value);
           PlayerPrefs.Save();  // Ensure immediate save
       }
       
       public static int GetInt(string key, int defaultValue = 0)
       {
           return PlayerPrefs.GetInt(key, defaultValue);
       }
       
       public static void SetInt(string key, int value)
       {
           PlayerPrefs.SetInt(key, value);
           PlayerPrefs.Save();
       }
       
       public static bool GetBool(string key, bool defaultValue = false)
       {
           return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
       }
       
       public static void SetBool(string key, bool value)
       {
           PlayerPrefs.SetInt(key, value ? 1 : 0);
           PlayerPrefs.Save();
       }
       
       // Session 3: Specific methods for common settings
       public static float MasterVolume
       {
           get => GetFloat(MASTER_VOLUME, 1.0f);
           set => SetFloat(MASTER_VOLUME, Mathf.Clamp01(value));  // Session 2: Validation
       }
       
       public static bool IsFullscreen
       {
           get => GetBool(FULLSCREEN, true);
           set => SetBool(FULLSCREEN, value);
       }
       
       public static string Difficulty
       {
           get => PlayerPrefs.GetString(DIFFICULTY, "Normal");
           set 
           {
               // Session 2: Validation with Session 7 switch statement
               string validatedDifficulty = value switch
               {
                   "Easy" or "Normal" or "Hard" => value,
                   _ => "Normal"  // Default fallback
               };
               PlayerPrefs.SetString(DIFFICULTY, validatedDifficulty);
               PlayerPrefs.Save();
           }
       }
   }
   ```

2. **Settings Management System (10 minutes)**:
   ```csharp
   public class SettingsManager : MonoBehaviour
   {
       // Session 1: Variables for UI references
       [Header("Audio Settings")]
       [SerializeField] private Slider masterVolumeSlider;
       [SerializeField] private Slider musicVolumeSlider;
       
       [Header("Graphics Settings")]
       [SerializeField] private Toggle fullscreenToggle;
       [SerializeField] private Dropdown qualityDropdown;
       
       void Start()
       {
           LoadSettings();
       }
       
       private void LoadSettings()
       {
           // Session 2: Conditional null checking before accessing components
           if (masterVolumeSlider != null)
           {
               masterVolumeSlider.value = PlayerPrefsManager.MasterVolume;
               masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
           }
           
           if (fullscreenToggle != null)
           {
               fullscreenToggle.isOn = PlayerPrefsManager.IsFullscreen;
               fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
           }
       }
       
       // Session 3: Event handler methods
       private void OnMasterVolumeChanged(float value)
       {
           PlayerPrefsManager.MasterVolume = value;
           AudioListener.volume = value;  // Apply immediately
       }
       
       private void OnFullscreenChanged(bool isFullscreen)
       {
           PlayerPrefsManager.IsFullscreen = isFullscreen;
           Screen.fullScreen = isFullscreen;  // Apply immediately
       }
   }
   ```

### Phase 4: Dictionary Management and Advanced Data Structures (25 minutes)
**Using `DictionaryManager.cs` - Session 4 Advanced Collections:**

1. **Dictionary-Based Item Database (15 minutes)**:
   ```csharp
   // Session 5: Serializable class for item data
   [System.Serializable]
   public class ItemData
   {
       public string itemName;
       public string description;
       public int value;
       public string itemType;
       public bool isConsumable;
       
       // Session 5: Constructor
       public ItemData(string name, string desc, int itemValue, string type, bool consumable = false)
       {
           itemName = name;
           description = desc;
           value = itemValue;
           itemType = type;
           isConsumable = consumable;
       }
   }
   
   public class ItemDatabase : MonoBehaviour
   {
       // Session 4: Dictionary for fast lookup
       private Dictionary<string, ItemData> itemDatabase = new Dictionary<string, ItemData>();
       
       void Start()
       {
           InitializeDatabase();
       }
       
       private void InitializeDatabase()
       {
           // Session 4: Adding items to dictionary
           AddItem(new ItemData("Health Potion", "Restores 50 HP", 25, "Consumable", true));
           AddItem(new ItemData("Iron Sword", "A sturdy sword", 100, "Weapon", false));
           AddItem(new ItemData("Magic Staff", "Increases magic power", 200, "Weapon", false));
           AddItem(new ItemData("Gold Coin", "Currency for trading", 1, "Currency", false));
           
           Debug.Log($"Item database initialized with {itemDatabase.Count} items");
       }
       
       private void AddItem(ItemData item)
       {
           // Session 2: Validation before adding
           if (item != null && !string.IsNullOrEmpty(item.itemName))
           {
               itemDatabase[item.itemName] = item;  // Dictionary assignment
           }
       }
       
       // Session 3: Public methods for external access
       public ItemData GetItem(string itemName)
       {
           // Session 2: Safe dictionary access
           if (itemDatabase.ContainsKey(itemName))
           {
               return itemDatabase[itemName];
           }
           
           Debug.LogWarning($"Item not found: {itemName}");
           return null;
       }
       
       public List<ItemData> GetItemsByType(string itemType)
       {
           List<ItemData> results = new List<ItemData>();  // Session 4: Lists
           
           // Session 3: foreach with Session 4: Dictionary iteration
           foreach (KeyValuePair<string, ItemData> pair in itemDatabase)
           {
               // Session 2: String comparison
               if (pair.Value.itemType.Equals(itemType, System.StringComparison.OrdinalIgnoreCase))
               {
                   results.Add(pair.Value);
               }
           }
           
           return results;
       }
       
       public bool ItemExists(string itemName)
       {
           return itemDatabase.ContainsKey(itemName);
       }
   }
   ```

2. **Configuration Management (10 minutes)**:
   ```csharp
   public class GameConfiguration : MonoBehaviour
   {
       // Session 4: Dictionary for game settings
       private Dictionary<string, object> gameConfig = new Dictionary<string, object>();
       
       void Start()
       {
           LoadDefaultConfiguration();
       }
       
       private void LoadDefaultConfiguration()
       {
           // Session 2: Different data types in same dictionary
           gameConfig["PlayerStartHealth"] = 100;
           gameConfig["PlayerStartLevel"] = 1;
           gameConfig["GameDifficulty"] = "Normal";
           gameConfig["EnableAutoSave"] = true;
           gameConfig["SaveInterval"] = 30.0f;
           gameConfig["MaxInventorySize"] = 20;
       }
       
       // Session 3: Generic methods for type-safe access
       public T GetConfig<T>(string key, T defaultValue = default(T))
       {
           if (gameConfig.ContainsKey(key) && gameConfig[key] is T)
           {
               return (T)gameConfig[key];
           }
           return defaultValue;
       }
       
       public void SetConfig<T>(string key, T value)
       {
           gameConfig[key] = value;
       }
       
       // Convenience methods for common types
       public int GetIntConfig(string key, int defaultValue = 0)
       {
           return GetConfig(key, defaultValue);
       }
       
       public bool GetBoolConfig(string key, bool defaultValue = false)
       {
           return GetConfig(key, defaultValue);
       }
       
       public string GetStringConfig(string key, string defaultValue = "")
       {
           return GetConfig(key, defaultValue);
       }
   }
   ```


### Phase 5: Complete Mini-Game Integration - "Data Quest" (45 minutes)
**Using `DataQuestGame.cs` - All Sessions 1-8 Integration:**

1. **Game Architecture Overview (10 minutes)**:
   ```csharp
   // Complete game integrating ALL course concepts
   public class DataQuestGame : MonoBehaviour, IAttackable, IDamageable  // Session 7: Interfaces
   {
       [Header("Player Stats - Session 1: Variables")]
       [SerializeField] private string playerName = "Hero";
       [SerializeField] private int health = 100;
       [SerializeField] private int maxHealth = 100;
       [SerializeField] private int level = 1;
       [SerializeField] private float experience = 0f;
       
       [Header("Game Collections - Session 4")]
       [SerializeField] private List<string> inventory = new List<string>();
       [SerializeField] private List<string> questsCompleted = new List<string>();
       
       // Session 7: Game state management
       private enum GameState { MainMenu, Playing, Inventory, Paused, GameOver }
       private GameState currentState = GameState.MainMenu;
       
       // Session 5: Private fields with public properties
       private ItemDatabase itemDB;
       private GameConfiguration config;
       private AutoSaveManager saveManager;
       
       // Session 8: Data persistence components
       private PlayerData persistentData;
       
       void Start()
       {
           InitializeGame();
       }
       
       private void InitializeGame()
       {
           // Session 5: Component initialization
           itemDB = GetComponent<ItemDatabase>();
           config = GetComponent<GameConfiguration>();
           saveManager = GetComponent<AutoSaveManager>();
           
           // Session 8: Load persistent data
           persistentData = JSONManager.LoadPlayerData();
           if (!string.IsNullOrEmpty(persistentData.playerName))
           {
               LoadPlayerState();
           }
           else
           {
               CreateNewPlayer();
           }
           
           ChangeState(GameState.Playing);
       }
   }
   ```

2. **Complete Game Loop with All Concepts (20 minutes)**:
   ```csharp
   void Update()
   {
       // Session 7: Switch statement for state management
       switch (currentState)
       {
           case GameState.Playing:
               UpdateGameplay();
               break;
           case GameState.Inventory:
               UpdateInventory();
               break;
           case GameState.Paused:
               UpdatePause();
               break;
       }
       
       ProcessInput();
   }
   
   private void UpdateGameplay()
   {
       // Session 2: Input handling with conditional logic
       if (Input.GetKeyDown(KeyCode.Space))
       {
           PerformAction();
       }
       
       if (Input.GetKeyDown(KeyCode.I))
       {
           ChangeState(GameState.Inventory);
       }
       
       // Session 3: Method calls for game systems
       UpdateExperience();
       CheckLevelUp();
       UpdateAutoSave();
   }
   
   private void PerformAction()
   {
       // Session 2: Mathematical operations and Session 4: Random selection
       int randomEvent = Random.Range(0, 4);
       
       // Session 7: Switch statement for event handling
       switch (randomEvent)
       {
           case 0:
               FindItem();
               break;
           case 1:
               EncounterEnemy();
               break;
           case 2:
               FindTreasure();
               break;
           case 3:
               DiscoverQuest();
               break;
       }
       
       // Session 2: Experience gain with mathematical operations
       AddExperience(10f + (level * 2f));
   }
   
   private void FindItem()
   {
       // Session 4: Array of possible items
       string[] possibleItems = { "Health Potion", "Iron Sword", "Magic Staff", "Gold Coin" };
       
       // Session 2: Random selection with Session 4: Array access
       string foundItem = possibleItems[Random.Range(0, possibleItems.Length)];
       
       // Session 4: List operations
       inventory.Add(foundItem);
       
       // Session 8: Dictionary lookup for item details
       ItemData itemData = itemDB.GetItem(foundItem);
       if (itemData != null)
       {
           Debug.Log($"Found {itemData.itemName}: {itemData.description}");
       }
       
       UpdateUI();
   }
   
   private void EncounterEnemy()
   {
       // Session 6: Inheritance - create different enemy types
       Enemy enemy = CreateRandomEnemy();
       
       // Session 7: Interface-based combat
       if (enemy is IAttackable attacker)
       {
           CombatEncounter(attacker);
       }
   }
   
   private Enemy CreateRandomEnemy()
   {
       // Session 6: Polymorphism with inheritance
       int enemyType = Random.Range(0, 3);
       
       return enemyType switch
       {
           0 => new Zombie($"Zombie Level {level}"),
           1 => new Robot($"Robot Level {level}"),
           2 => new Wizard($"Wizard Level {level}"),
           _ => new Enemy($"Enemy Level {level}")
       };
   }
   
   private void CombatEncounter(IAttackable enemy)
   {
       // Session 7: Interface-based combat system
       Debug.Log("Combat encounter!");
       
       // Session 2: Conditional combat logic
       int playerAttack = 20 + (level * 5);  // Mathematical operations
       int enemyAttack = Random.Range(10, 20);
       
       // Session 3: While loop for turn-based combat
       int playerHP = health;
       int enemyHP = 50 + (level * 10);
       
       while (playerHP > 0 && enemyHP > 0)
       {
           // Player attacks
           enemyHP -= playerAttack;
           Debug.Log($"Player attacks for {playerAttack} damage!");
           
           if (enemyHP <= 0)
           {
               Debug.Log("Enemy defeated!");
               AddExperience(25f + (level * 5f));
               FindItem();  // Reward for victory
               break;
           }
           
           // Enemy attacks
           playerHP -= enemyAttack;
           Debug.Log($"Enemy attacks for {enemyAttack} damage!");
           
           if (playerHP <= 0)
           {
               Debug.Log("Player defeated!");
               health = maxHealth / 2;  // Respawn with half health
               break;
           }
       }
       
       health = playerHP > 0 ? playerHP : health;
       UpdateUI();
   }
   ```

3. **Data Persistence Integration (15 minutes)**:
   ```csharp
   // Session 8: Complete save/load system
   private void SavePlayerState()
   {
       // Session 5: Update persistent data object
       persistentData.playerName = playerName;
       persistentData.level = level;
       persistentData.experience = experience;
       persistentData.health = health;
       persistentData.maxHealth = maxHealth;
       
       // Session 4: Save collections
       persistentData.inventory.Clear();
       persistentData.inventory.AddRange(inventory);
       
       persistentData.questsCompleted.Clear();
       persistentData.questsCompleted.AddRange(questsCompleted);
       
       // Session 8: JSON save operation
       if (JSONManager.SavePlayerData(persistentData))
       {
           Debug.Log("Game progress saved!");
       }
   }
   
   private void LoadPlayerState()
   {
       // Session 5: Load from persistent data
       playerName = persistentData.playerName;
       level = persistentData.level;
       experience = persistentData.experience;
       health = persistentData.health;
       maxHealth = persistentData.maxHealth;
       
       // Session 4: Load collections
       inventory.Clear();
       inventory.AddRange(persistentData.inventory);
       
       questsCompleted.Clear();
       questsCompleted.AddRange(persistentData.questsCompleted);
       
       Debug.Log($"Loaded player: {playerName}, Level {level}");
       UpdateUI();
   }
   
   private void CreateNewPlayer()
   {
       // Session 5: Constructor-like initialization
       persistentData = new PlayerData(playerName, 1);
       
       // Session 4: Initialize collections
       inventory.Clear();
       inventory.Add("Basic Sword");
       inventory.Add("Health Potion");
       
       questsCompleted.Clear();
       
       Debug.Log("Created new player profile");
   }
   
   // Session 7: Interface implementations (IAttackable, IDamageable)
   public void Attack(GameObject target)
   {
       IDamageable damageable = target.GetComponent<IDamageable>();
       if (damageable != null)
       {
           int damage = 20 + (level * 5);
           damageable.TakeDamage(damage);
           Debug.Log($"{playerName} attacks for {damage} damage!");
       }
   }
   
   public int GetAttackDamage()
   {
       return 20 + (level * 5);
   }
   
   public void TakeDamage(int damage)
   {
       health -= damage;
       health = Mathf.Max(0, health);  // Session 2: Mathematical operations
       
       if (health <= 0)
       {
           ChangeState(GameState.GameOver);
       }
       
       UpdateUI();
   }
   
   public bool IsAlive()
   {
       return health > 0;
   }
   
   public int GetCurrentHealth()
   {
       return health;
   }
   
   // Session 3: Utility methods
   private void AddExperience(float exp)
   {
       experience += exp;
       CheckLevelUp();
   }
   
   private void CheckLevelUp()
   {
       float expNeeded = level * 100f;  // Session 2: Mathematical operations
       
       // Session 3: While loop for multiple level ups
       while (experience >= expNeeded)
       {
           level++;
           experience -= expNeeded;
           
           int healthIncrease = 20;
           maxHealth += healthIncrease;
           health = maxHealth;  // Full heal on level up
           
           Debug.Log($"Level up! Now level {level}");
           expNeeded = level * 100f;  // Recalculate for next level
       }
   }
   
   private void ChangeState(GameState newState)
   {
       currentState = newState;
       Debug.Log($"Game state changed to: {newState}");
       
       // Session 7: State-specific actions
       switch (newState)
       {
           case GameState.GameOver:
               SavePlayerState();  // Save progress before game over
               break;
           case GameState.Paused:
               Time.timeScale = 0f;
               break;
           case GameState.Playing:
               Time.timeScale = 1f;
               break;
       }
   }
   ```


### Phase 6: Student Exercise and Course Completion (20 minutes)

**Student Challenges using `Session08_StudentExercise.cs`:**

1. **Data Persistence Mastery**:
   - Implement complete save/load system for custom game data
   - Create backup and recovery systems for corrupted save files
   - Build settings manager with PlayerPrefs integration

2. **Advanced Data Structures**:
   - Design item database using Dictionary for fast lookup
   - Implement inventory system with serialization support
   - Create quest tracking system with complex data relationships

3. **Complete Game Integration**:
   - Build mini-game using all Sessions 1-8 concepts
   - Implement professional error handling and recovery
   - Create modular systems that can be easily extended

4. **Portfolio Project Enhancement**:
   - Add visual polish and UI integration
   - Implement advanced features (leaderboards, achievements)
   - Create documentation for professional presentation

### **🎉 Course Completion Achievement**

**What Students Have Mastered (All Sessions 1-8):**

1. **Programming Fundamentals** ✅:
   - **Session 1**: Variables, data types, basic syntax
   - **Session 2**: Operators, input, conditional logic
   - **Session 3**: Loops, strings, methods

2. **Data Management** ✅:
   - **Session 4**: Arrays, Lists, collections
   - **Session 8**: Dictionaries, advanced data structures

3. **Object-Oriented Programming** ✅:
   - **Session 5**: Classes, objects, constructors, encapsulation
   - **Session 6**: Inheritance, polymorphism, abstract classes

4. **Professional Architecture** ✅:
   - **Session 7**: Interfaces, state management, professional patterns
   - **Session 8**: Data persistence, complete system integration

5. **Unity Game Development** ✅:
   - Transform manipulation and movement systems
   - Visual debugging and professional workflows
   - Component-based architecture
   - Save/load systems and data persistence

6. **Industry-Standard Practices** ✅:
   - Error handling and robust system design
   - Performance considerations and optimization
   - Team development practices with proper encapsulation
   - Professional code organization and documentation

**Professional Skills Achieved:**
- Can design and implement complete game systems from scratch
- Understands professional software architecture patterns
- Ready for junior developer positions or advanced coursework
- Capable of independent project development and team collaboration
- Portfolio-ready projects demonstrating comprehensive C# and Unity knowledge

## Common Student Questions & Answers

**Q: Why use JSON instead of just saving variables directly?**  
A: JSON is **structured, readable, and cross-platform**. It can handle complex nested data, is human-readable for debugging, and works across different systems. Direct variable saving doesn't handle objects, arrays, or relationships well.

**Q: When should I use PlayerPrefs vs JSON files vs other storage?**  
A: Use **PlayerPrefs** for simple settings (volume, difficulty). Use **JSON** for complex game state (player data, inventory, progress). Use **binary files** for performance-critical data or when you need encryption.

**Q: How do I handle save file corruption or missing files?**  
A: Always include **error handling** with try-catch blocks, provide **default values** when files are missing, and consider **backup systems** that save multiple versions of important data.

**Q: What's the difference between Application.persistentDataPath and other Unity paths?**  
A: **persistentDataPath** survives app updates and user data deletion policies. **dataPath** is read-only application data. **streamingAssetsPath** is for files you want to access at runtime but ship with the game.

**Q: Can I save references to GameObjects in JSON?**  
A: No, Unity objects can't be directly serialized to JSON. Save **identifiers** (names, IDs) instead, then find/recreate the objects when loading. Use **ScriptableObjects** for data that needs Unity serialization.

**Q: How do I make my save system secure against cheating?**  
A: Use **data validation** when loading, store **checksums** or hashes of important data, keep critical data on servers when possible, and never trust client-side data completely in multiplayer games.

**Q: What's the performance impact of frequent saving?**  
A: File I/O can cause **frame rate hitches**. Use **background threads** for large saves, **batch** multiple changes before saving, and consider **incremental saves** that only save changed data.

**Q: How do I handle different versions of save files as my game evolves?**  
A: Include **version numbers** in your save data, write **migration code** that converts old formats to new ones, and always test loading saves from previous versions.

## Assessment Checkpoints

### Complete Course Mastery Check (Sessions 1-8):
- [ ] Demonstrates mastery of all fundamental programming concepts (variables through advanced data structures)
- [ ] Implements professional object-oriented design patterns correctly
- [ ] Creates modular, extensible systems using interfaces and inheritance appropriately
- [ ] Builds complete, working game systems with proper data persistence
- [ ] Uses error handling and defensive programming practices throughout
- [ ] Writes code that follows professional standards and is ready for team development

### Professional Development Skills Check:
- [ ] Designs systems that are maintainable, extensible, and performant
- [ ] Implements proper separation of concerns and single responsibility principles
- [ ] Creates comprehensive error handling and recovery systems
- [ ] Uses appropriate data structures and algorithms for different scenarios
- [ ] Demonstrates understanding of Unity-specific optimization and best practices

### Portfolio Project Assessment:
- [ ] Creates complete, demonstrable project suitable for employment applications
- [ ] Implements professional-quality code organization and documentation
- [ ] Shows integration of multiple complex systems working together harmoniously
- [ ] Demonstrates problem-solving skills and independent development capability
- [ ] Exhibits understanding of user experience and professional polish considerations

### Industry Readiness Indicators:
- [ ] Can explain architectural decisions and trade-offs in technical terms
- [ ] Writes code that other developers can understand and extend
- [ ] Understands performance implications and optimization strategies
- [ ] Demonstrates professional debugging and problem-solving approaches
- [ ] Shows readiness for junior developer responsibilities or advanced coursework


## Extension Activities

For students who finish early:

1. **Advanced Data Persistence Systems**:
   - Implement encrypted save files for security-sensitive data
   - Create versioned save systems that can migrate old data formats
   - Build cloud save integration with conflict resolution
   - Design incremental save systems that only save changed data

2. **Performance Optimization Projects**:
   - Implement asynchronous file operations to prevent frame rate hitches
   - Create object pooling systems for frequently created/destroyed objects
   - Build caching layers for expensive Dictionary lookups
   - Design memory-efficient serialization for large datasets

3. **Advanced Unity Integration**:
   - Create custom PropertyDrawers for complex data structures in Inspector
   - Build editor tools for managing save files and game data
   - Implement ScriptableObject-based configuration systems
   - Design modular asset management with addressable assets

4. **Professional Development Patterns**:
   - Implement Repository pattern for data access abstraction
   - Create Unit of Work pattern for transactional save operations
   - Build Observer pattern for save system events and notifications
   - Design Command pattern for undoable game state changes

5. **Complete Portfolio Projects**:
   - Build comprehensive RPG character progression system
   - Create complete inventory and crafting system with persistence
   - Design multiplayer-ready data synchronization systems
   - Implement analytics and telemetry collection systems

## Troubleshooting Common Issues

### **File I/O and Persistence Errors**

**Error: "DirectoryNotFoundException: Could not find a part of the path"**  
→ **Cause**: Trying to write to non-existent directory or using invalid path characters  
→ **Solution**: Always ensure directory exists before file operations
```csharp
// ❌ WRONG - directory might not exist
File.WriteAllText(Path.Combine(Application.persistentDataPath, "Saves", "game.json"), data);

// ✅ CORRECT - ensure directory exists first
string saveDir = Path.Combine(Application.persistentDataPath, "Saves");
if (!Directory.Exists(saveDir))
{
    Directory.CreateDirectory(saveDir);
}
File.WriteAllText(Path.Combine(saveDir, "game.json"), data);
```

**Error: "IOException: The process cannot access the file because it is being used by another process"**  
→ **Cause**: File is locked by another operation or Unity Inspector is viewing it  
→ **Solution**: Use proper file handling with using statements
```csharp
// ❌ DANGEROUS - file might stay locked
FileStream stream = File.Open(path, FileMode.Create);
// If exception occurs here, file stays locked!

// ✅ SAFE - automatically closes file
using (FileStream stream = File.Open(path, FileMode.Create))
{
    // File automatically closed even if exception occurs
}
```

### **JSON Serialization Problems**

**Error: "ArgumentException: JSON parse error: Invalid value"**  
→ **Cause**: Trying to serialize unsupported types or circular references  
→ **Solution**: Use only JsonUtility-supported types and avoid circular references
```csharp
// ❌ WRONG - Dictionary not supported by JsonUtility
[System.Serializable]
public class BadData
{
    public Dictionary<string, int> items; // JsonUtility can't serialize Dictionary
}

// ✅ CORRECT - use List of custom types instead
[System.Serializable]
public class ItemEntry
{
    public string key;
    public int value;
}

[System.Serializable]
public class GoodData
{
    public List<ItemEntry> items; // JsonUtility can serialize this
}
```

**Error: "ArgumentNullException: Value cannot be null"**  
→ **Cause**: Trying to serialize null objects or missing required fields  
→ **Solution**: Add null checks and initialize collections
```csharp
[System.Serializable]
public class PlayerData
{
    public List<string> inventory = new List<string>(); // Initialize collections
    
    public PlayerData()
    {
        // Ensure all required fields are initialized
        if (inventory == null) inventory = new List<string>();
    }
}
```

### **PlayerPrefs Issues**

**Problem: PlayerPrefs not persisting between sessions**  
→ **Cause**: Not calling PlayerPrefs.Save() or Unity Editor clearing prefs  
→ **Solution**: Always call Save() after setting values
```csharp
// ❌ WRONG - changes might not persist
PlayerPrefs.SetFloat("Volume", 0.8f);

// ✅ CORRECT - force immediate save
PlayerPrefs.SetFloat("Volume", 0.8f);
PlayerPrefs.Save(); // Ensures immediate write to disk
```

**Problem: PlayerPrefs values reset in Unity Editor**  
→ **Cause**: Unity Editor clears PlayerPrefs between sessions  
→ **Solution**: Use EditorPrefs for Editor-specific data or test in builds
```csharp
#if UNITY_EDITOR
    // Use EditorPrefs in Editor for persistent testing
    EditorPrefs.SetFloat("Volume", value);
#else
    // Use PlayerPrefs in builds
    PlayerPrefs.SetFloat("Volume", value);
#endif
```

### **Dictionary and Collection Problems**

**Error: "KeyNotFoundException: The given key was not present in the dictionary"**  
→ **Cause**: Accessing dictionary key that doesn't exist  
→ **Solution**: Use ContainsKey() or TryGetValue() for safe access
```csharp
// ❌ DANGEROUS - will throw exception if key missing
ItemData item = itemDatabase["NonExistentItem"];

// ✅ SAFE - check before accessing
if (itemDatabase.ContainsKey("ItemName"))
{
    ItemData item = itemDatabase["ItemName"];
}

// ✅ ALSO SAFE - using TryGetValue
if (itemDatabase.TryGetValue("ItemName", out ItemData item))
{
    // Use item safely
}
```

### **Unity-Specific Data Persistence Issues**

**Problem: Serialized data not showing in Inspector**  
→ **Cause**: Missing [System.Serializable] attribute or unsupported types  
→ **Solution**: Add serialization attributes and use supported types
```csharp
// ❌ WRONG - not serializable
public class PlayerData
{
    public Dictionary<string, int> stats; // Not serializable
}

// ✅ CORRECT - properly serializable
[System.Serializable]
public class PlayerData
{
    public List<StatEntry> stats; // Serializable alternative
}

[System.Serializable]
public class StatEntry
{
    public string statName;
    public int statValue;
}
```

**Problem: Save files not found after build**  
→ **Cause**: Using wrong path or files not included in build  
→ **Solution**: Use Application.persistentDataPath for user data
```csharp
// ❌ WRONG - won't work in builds
string path = "SaveData/player.json";

// ✅ CORRECT - works in all platforms
string path = Path.Combine(Application.persistentDataPath, "SaveData", "player.json");
```


## Unity/Visual Studio Code Integration Notes

### **Session 8 Specific Workflow**

1. **Data Persistence Development Process**:
   - **Design data structures first**: Plan serializable classes before implementation
   - **Test save/load early**: Verify data persistence works before adding complexity
   - **Use Inspector debugging**: Visualize data structures during development
   - **Cross-platform testing**: Verify file paths work on different operating systems

2. **Visual Studio Code Advanced Data Features**:
   - **JSON validation**: VS Code shows JSON syntax errors in real-time
   - **Serialization debugging**: IntelliSense shows which fields are serializable
   - **Path string assistance**: Auto-completion for file system operations
   - **Exception handling**: Red squiggles for unhandled exceptions

3. **Unity Inspector with Data Systems**:
   - **Serialized field visualization**: See complex data structures in Inspector
   - **Runtime data monitoring**: Watch data changes during Play mode
   - **File system integration**: Access persistent data path from Inspector
   - **Debug mode inspection**: View private fields during debugging

### **Professional Data Management Workflow**

1. **Development Best Practices**:
   - **Version control considerations**: Don't commit save files or user data
   - **Testing strategies**: Test save/load with various data states and edge cases
   - **Performance monitoring**: Profile file I/O operations for optimization opportunities
   - **Error recovery design**: Plan for corrupted data and missing files

2. **Debugging Complex Data Systems**:
   - **Data validation logging**: Use Debug.Log to trace data flow and transformations
   - **JSON pretty printing**: Format JSON output for human readability during development
   - **Breakpoint strategies**: Use debugger to inspect data state at critical points
   - **Unit testing**: Test data persistence components independently

## Course Completion Celebration

### **🎓 CRE132 Game Development Fundamentals - Complete!**

**Comprehensive Achievement Summary:**

### **Sessions 1-3: Programming Foundations** ✅
- **Session 1**: Variables, data types, Unity MonoBehaviour lifecycle
- **Session 2**: Operators, input systems, conditional logic
- **Session 3**: Loops, string manipulation, custom methods

### **Session 4: Data Management** ✅
- Arrays and Lists for game data collections
- Unity Transform system and 2D movement patterns
- Visual debugging and performance optimization

### **Sessions 5-6: Object-Oriented Programming Unit** ✅
- **Session 5**: Classes, objects, constructors, access modifiers, encapsulation
- **Session 6**: Inheritance, polymorphism, abstract classes, professional architecture

### **Session 7: Advanced Architecture** ✅
- Interface contracts and multiple implementation
- Switch statements and modern C# patterns
- Professional game state management systems

### **Session 8: Data Persistence & Integration** ✅
- File I/O operations with robust error handling
- JSON serialization for complex data structures
- Professional save/load systems and configuration management
- Complete mini-game integration of all course concepts

### **Professional Skills Achieved:**

1. **Industry-Standard Programming** ✅:
   - Complete C# language mastery from basics to advanced patterns
   - Professional error handling and defensive programming practices
   - Performance-conscious development with optimization awareness
   - Code organization and documentation suitable for team development

2. **Unity Game Development Expertise** ✅:
   - Component-based architecture and Unity-specific patterns
   - Visual debugging and professional development workflows
   - Cross-platform compatibility and deployment considerations
   - Integration with Unity's built-in systems and best practices

3. **Software Architecture Mastery** ✅:
   - Object-oriented design principles and professional patterns
   - Interface-based modular system design
   - State management and complex system coordination
   - Data persistence and configuration management systems

4. **Portfolio-Ready Projects** ✅:
   - Complete, working game systems demonstrating all concepts
   - Professional code quality suitable for employment demonstration
   - Comprehensive documentation and clear architectural decisions
   - Extensible systems ready for further development

### **Career Readiness Indicators:**
- **Junior Developer Ready**: Can contribute meaningfully to professional development teams
- **Independent Project Capable**: Can design and implement complete game systems from scratch
- **Advanced Study Prepared**: Ready for senior-level computer science or game development courses
- **Portfolio Presentation**: Has demonstrable projects for internship and job applications

---

## Files in This Session
- `FileManager.cs` - Basic file I/O operations with Unity's persistent data path
- `PlayerData.cs` - Serializable data class for JSON operations
- `JSONManager.cs` - Complete JSON save/load system with auto-save functionality
- `PlayerPrefsManager.cs` - Settings and preferences management system
- `DictionaryManager.cs` - Dictionary operations for fast data lookup and configuration
- `DataQuestGame.cs` - Complete mini-game integrating all Sessions 1-8 concepts
- `Session08_StudentExercise.cs` - Comprehensive final exercises and portfolio projects
- `Session08_Teaching_Guide.md` - This instructor guide

**Unity Scene**: `08_Data_Persistence.unity`  
**Estimated Total Teaching Time**: 150-180 minutes  
**Prerequisites**: Sessions 1-7 (Complete programming and architecture foundation)  
**Completes**: CRE132 Game Development Fundamentals course
**Prepares For**: Advanced game development coursework or professional development roles

---

## Teaching Tips for Success

### **Critical Session 8 Concepts to Emphasise**

1. **Data Persistence Importance**:
   - **Start with frustration**: Show game that loses all progress when closed
   - **Introduce solution**: Save/load systems that preserve player investment
   - **Professional context**: This is how AAA games maintain massive player progress
   - **Career relevance**: Data systems are critical in almost all software development

2. **Integration Mastery Demonstration**:
   - **Show progression**: From Session 1 variables to Session 8 complete systems
   - **Highlight connections**: Point out how each previous session enables current concepts
   - **Celebrate growth**: Students have achieved professional-level programming skills
   - **Portfolio focus**: These projects demonstrate employment-ready capabilities

3. **Error Handling Professional Practices**:
   - **Murphy's Law demonstration**: Show all the ways file operations can fail
   - **Defensive programming**: Always plan for failure modes and recovery
   - **User experience focus**: Good error handling is invisible to users
   - **Professional standards**: This separates amateur from professional code

### **Course Completion Strategy**

1. **Achievement Recognition**:
   - **Comprehensive skill inventory**: List all capabilities students now possess
   - **Professional readiness emphasis**: Students are now qualified for junior developer roles
   - **Portfolio project celebration**: Students have created demonstrable, professional-quality work
   - **Continued learning pathway**: Point toward advanced courses and professional development

2. **Final Project Excellence**:
   - **Integration demonstration**: Show how all 8 sessions work together seamlessly
   - **Professional polish**: Emphasize code quality, documentation, and user experience
   - **Extensibility showcase**: Demonstrate how systems can be enhanced and expanded
   - **Career preparation**: These projects are suitable for job application portfolios

3. **Transition to Professional Development**:
   - **Industry patterns recognition**: Students now understand professional development practices
   - **Team readiness**: Code quality and organization suitable for collaborative development
   - **Continuous learning**: Students have foundation for advanced topics and specialization
   - **Confidence building**: Students can tackle complex programming challenges independently

### **Student Engagement for Course Finale**

1. **Portfolio Project Showcase**:
   - "Present your complete game system as if interviewing for a developer position"
   - "Demonstrate how your code follows professional standards and best practices"
   - "Explain architectural decisions and trade-offs like a senior developer would"

2. **Integration Challenges**:
   - "Add a new feature that requires modifying multiple systems seamlessly"
   - "Optimize the save system for performance while maintaining all functionality"
   - "Design extension points where future developers could add new content"

3. **Professional Preparation Activities**:
   - "Create documentation that would help a new team member understand your systems"
   - "Explain how your code demonstrates each of the 8 session concepts"
   - "Design test cases that would verify your systems work correctly"

### **Assessment Focus Points for Course Completion**

- **Technical mastery**: Does student demonstrate command of all course concepts?
- **Integration skills**: Can student combine multiple complex systems effectively?
- **Professional readiness**: Is student code quality suitable for employment?
- **Problem-solving capability**: Can student debug and extend complex systems independently?
- **Architectural understanding**: Does student make appropriate design decisions and trade-offs?

### **Course Legacy and Continued Growth**

**What Students Take Forward:**
- **Complete C# programming mastery** suitable for any software development context
- **Professional Unity game development skills** ready for industry application
- **Software architecture understanding** applicable to large-scale system design
- **Problem-solving confidence** to tackle complex programming challenges
- **Portfolio projects** demonstrating professional-quality development capabilities

**Recommended Next Steps:**
- **Advanced Unity specialization**: Graphics programming, networking, or VR/AR development
- **Software engineering principles**: Design patterns, testing, and large-scale architecture
- **Professional development**: Internships, open-source contributions, or junior developer positions
- **Specialized domains**: AI/ML, web development, mobile development, or enterprise software

### **Session 8 Success Indicators**

- Students can explain the complete data flow from user action to persistent storage
- Students create robust systems that handle errors gracefully and provide good user experience
- Students demonstrate integration mastery by combining all course concepts seamlessly
- Students produce portfolio-quality projects suitable for employment demonstration
- Students exhibit confidence and professional readiness for continued development work

**Session 8 represents the culmination of a comprehensive journey from programming novice to professional-ready developer, equipped with both technical skills and the confidence to tackle complex software development challenges.**

