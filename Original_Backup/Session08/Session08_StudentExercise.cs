using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// Session 08 Student Exercise: Data Persistence & Final Project
/// Complete the TODO sections to create a data-driven game system
/// Integrates all concepts from the entire CRE132 course
/// 
/// LEARNING OBJECTIVES:
/// - Master file I/O operations for game save systems
/// - Implement JSON serialisation for complex data structures  
/// - Use PlayerPrefs for simple settings and preferences
/// - Apply Dictionaries for efficient data management
/// - Create a complete mini-game with persistent data
/// - Integrate all previous session concepts (OOP, collections, methods, etc.)
/// </summary>
public class Session08_StudentExercise : MonoBehaviour
{
    [Header("=== EXERCISE 1: FILE I/O BASICS ===")]
    [SerializeField] private string studentName = "Your Name Here";
    [SerializeField] private string exerciseFileName = "student_exercise.txt";
    [SerializeField] private string lastFileContent = "";
    
    [Header("=== EXERCISE 2: JSON SAVE SYSTEM ===")]
    [SerializeField] private StudentGameData gameData;
    [SerializeField] private string saveFileName = "student_save.json";
    
    [Header("=== EXERCISE 3: PLAYER PREFERENCES ===")]
    [SerializeField] private float gameVolume = 1.0f;
    [SerializeField] private int difficultyLevel = 1; // 1=Easy, 2=Normal, 3=Hard
    [SerializeField] private bool tutorialCompleted = false;
    
    [Header("=== EXERCISE 4: DICTIONARY SYSTEMS ===")]
    [SerializeField] private Dictionary<string, GameItem> itemCatalog;
    [SerializeField] private Dictionary<string, int> playerInventory;
    [SerializeField] private Dictionary<string, float> gameStatistics;
    
    [Header("=== EXERCISE 5: COMPLETE GAME SYSTEM ===")]
    [SerializeField] private int playerScore = 0;
    [SerializeField] private float gameTimer = 0f;
    [SerializeField] private bool gameActive = false;

    // Private variables for file paths
    private string exerciseFilePath;
    private string saveFilePath;

    /// <summary>
    /// Student data structure for JSON serialisation
    /// TODO 1: Add your own additional fields to this data structure
    /// </summary>
    [System.Serializable]
    public class StudentGameData
    {
        public string playerName;
        public int level;
        public int score;
        public float playTime;
        public Vector3 playerPosition;
        public List<string> collectedItems;
        
        // TODO 1A: Add a public integer field called "lives" with default value 3
        // TODO 1B: Add a public boolean field called "hasKey" with default value false
        // TODO 1C: Add a public string field called "currentArea" with default value "Starting Zone"
        // TODO 1D: Add a public List<string> field called "unlockedAreas" 

        public StudentGameData()
        {
            playerName = "Student";
            level = 1;
            score = 0;
            playTime = 0f;
            playerPosition = Vector3.zero;
            collectedItems = new List<string>();
            
            // TODO 1E: Initialise your new fields here with appropriate default values
        }
    }

    /// <summary>
    /// Game item structure for dictionary exercises
    /// TODO 2: Complete the GameItem class
    /// </summary>
    [System.Serializable]
    public class GameItem
    {
        public string itemName;
        public string description;
        public int value;
        public string category;
        
        // TODO 2A: Add a public boolean field called "isConsumable"
        // TODO 2B: Add a public float field called "effectPower"
        
        public GameItem(string name, string desc, int itemValue, string cat)
        {
            itemName = name;
            description = desc;
            value = itemValue;
            category = cat;
            
            // TODO 2C: Set default values for your new fields:
            // isConsumable should be false, effectPower should be 1.0f
        }
        
        // TODO 2D: Create a method called "UseItem" that returns a string
        // The method should return different messages based on the category:
        // "Weapon" -> "You equipped the [itemName]!"
        // "Potion" -> "You consumed the [itemName] and gained [effectPower] power!"
        // "Key" -> "You used the [itemName] to unlock something!"
        // Default -> "You used the [itemName]."
    }

    /// <summary>
    /// Unity Start method - initialises all exercise systems
    /// TODO 3: Complete the initialisation
    /// </summary>
    void Start()
    {
        Debug.Log("=== SESSION 08 STUDENT EXERCISE STARTED ===");
        Debug.Log($"Student: {studentName}");
        
        // Set up file paths
        exerciseFilePath = Path.Combine(Application.persistentDataPath, exerciseFileName);
        saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);
        
        // TODO 3A: Call the InitialiseGameData() method
        // TODO 3B: Call the LoadPlayerPreferences() method  
        // TODO 3C: Call the InitialiseDictionaries() method
        // TODO 3D: Call the LoadGameData() method
        
        Debug.Log("Exercise initialised! Use number keys 1-9 to test different systems.");
        Debug.Log("Controls: 1=File I/O, 2=JSON Save, 3=PlayerPrefs, 4=Dictionaries, 5=Game System");
    }

    /// <summary>
    /// Unity Update method - handles exercise testing
    /// TODO 4: Complete the input handling
    /// </summary>
    void Update()
    {
        // TODO 4A: Add input detection for KeyCode.Alpha1 to call TestFileIO()
        // TODO 4B: Add input detection for KeyCode.Alpha2 to call TestJSONSave()
        // TODO 4C: Add input detection for KeyCode.Alpha3 to call TestPlayerPrefs()
        // TODO 4D: Add input detection for KeyCode.Alpha4 to call TestDictionaries()
        // TODO 4E: Add input detection for KeyCode.Alpha5 to call TestGameSystem()
        
        // Update game timer when game is active
        if (gameActive)
        {
            gameTimer += Time.deltaTime;
            
            // TODO 4F: Add code to increase playerScore by 1 every second
            // Hint: Use Time.deltaTime and a counter variable
        }
    }

    /// <summary>
    /// TODO 5: Complete the file I/O exercise
    /// Create a method that writes student information to a text file
    /// </summary>
    public void TestFileIO()
    {
        Debug.Log("🗃️ Testing File I/O...");
        
        try
        {
            // TODO 5A: Create a string variable called "fileContent"
            // TODO 5B: Set fileContent to include:
            // - "Student Exercise Data\n"
            // - "Student Name: [studentName]\n" 
            // - "Current Date: [current date and time]\n"
            // - "Exercise Status: File I/O Complete\n"
            
            // TODO 5C: Use File.WriteAllText() to write fileContent to exerciseFilePath
            
            // TODO 5D: Read the file back using File.ReadAllText() and store in lastFileContent
            
            Debug.Log("✅ File I/O test completed!");
            Debug.Log($"File content: {lastFileContent}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ File I/O error: {ex.Message}");
        }
    }

    /// <summary>
    /// TODO 6: Complete the JSON save system exercise
    /// </summary>
    public void TestJSONSave()
    {
        Debug.Log("💾 Testing JSON Save System...");
        
        try
        {
            // TODO 6A: Set gameData.playerName to your studentName
            // TODO 6B: Set gameData.score to playerScore
            // TODO 6C: Set gameData.playTime to gameTimer
            // TODO 6D: Add some test items to gameData.collectedItems list
            
            // TODO 6E: Use JsonUtility.ToJson() to convert gameData to a JSON string
            // TODO 6F: Use File.WriteAllText() to save the JSON string to saveFilePath
            
            Debug.Log("✅ JSON save completed!");
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ JSON save error: {ex.Message}");
        }
    }

    /// <summary>
    /// TODO 7: Complete the PlayerPrefs exercise
    /// </summary>
    public void TestPlayerPrefs()
    {
        Debug.Log("⚙️ Testing PlayerPrefs...");
        
        // TODO 7A: Use PlayerPrefs.SetFloat() to save gameVolume with key "GameVolume"
        // TODO 7B: Use PlayerPrefs.SetInt() to save difficultyLevel with key "Difficulty" 
        // TODO 7C: Use PlayerPrefs.SetInt() to save tutorialCompleted as 1 or 0 with key "TutorialDone"
        // TODO 7D: Use PlayerPrefs.SetString() to save studentName with key "StudentName"
        
        // TODO 7E: Call PlayerPrefs.Save() to ensure data is written to disk
        
        Debug.Log("✅ PlayerPrefs test completed!");
        Debug.Log($"Saved - Volume: {gameVolume}, Difficulty: {difficultyLevel}, Tutorial: {tutorialCompleted}");
    }

    /// <summary>
    /// TODO 8: Complete the Dictionary systems exercise
    /// </summary>
    public void TestDictionaries()
    {
        Debug.Log("📚 Testing Dictionary Systems...");
        
        // TODO 8A: Add a new item to itemCatalog with key "magic_sword"
        // Create a new GameItem with name "Magic Sword", description "A powerful blade", value 500, category "Weapon"
        
        // TODO 8B: Add the "magic_sword" to playerInventory with quantity 1
        
        // TODO 8C: Increase the "ItemsFound" statistic in gameStatistics by 1
        
        // TODO 8D: Display all items in playerInventory using a foreach loop
        // Use Debug.Log to show each item and its quantity
        
        Debug.Log("✅ Dictionary test completed!");
    }

    /// <summary>
    /// TODO 9: Complete the integrated game system exercise
    /// </summary>
    public void TestGameSystem()
    {
        Debug.Log("🎮 Testing Complete Game System...");
        
        if (!gameActive)
        {
            StartGame();
        }
        else
        {
            EndGame();
        }
    }

    /// <summary>
    /// TODO 10: Complete the game start functionality
    /// </summary>
    private void StartGame()
    {
        Debug.Log("🚀 Starting game...");
        
        // TODO 10A: Set gameActive to true
        // TODO 10B: Reset gameTimer to 0
        // TODO 10C: Reset playerScore to 0
        // TODO 10D: Add "Game Started" to gameStatistics with current time as value
        
        Debug.Log("Game started! Score will increase automatically.");
    }

    /// <summary>
    /// TODO 11: Complete the game end functionality
    /// </summary>
    private void EndGame()
    {
        Debug.Log("🏁 Ending game...");
        
        // TODO 11A: Set gameActive to false
        // TODO 11B: Save the final score to PlayerPrefs with key "LastScore"
        // TODO 11C: Save the play time to PlayerPrefs with key "LastPlayTime"  
        // TODO 11D: Call SaveGameData() to save the complete game state
        
        Debug.Log($"Game ended! Final score: {playerScore}, Time played: {gameTimer:F1} seconds");
    }

    /// <summary>
    /// TODO 12: Complete the data initialisation
    /// </summary>
    private void InitialiseGameData()
    {
        // TODO 12A: Create a new StudentGameData object and assign it to gameData
        // TODO 12B: Set the playerName field to your studentName
    }

    /// <summary>
    /// TODO 13: Complete the PlayerPrefs loading
    /// </summary>
    private void LoadPlayerPreferences()
    {
        // TODO 13A: Load gameVolume using PlayerPrefs.GetFloat() with default value 1.0f
        // TODO 13B: Load difficultyLevel using PlayerPrefs.GetInt() with default value 1
        // TODO 13C: Load tutorialCompleted by getting an int (1 or 0) and converting to bool
        
        Debug.Log($"Loaded preferences - Volume: {gameVolume}, Difficulty: {difficultyLevel}");
    }

    /// <summary>
    /// TODO 14: Complete the dictionary initialisation
    /// </summary>
    private void InitialiseDictionaries()
    {
        // TODO 14A: Create new Dictionary<string, GameItem> and assign to itemCatalog
        // TODO 14B: Create new Dictionary<string, int> and assign to playerInventory  
        // TODO 14C: Create new Dictionary<string, float> and assign to gameStatistics
        
        // TODO 14D: Add some starting items to itemCatalog:
        // - "health_potion": name "Health Potion", description "Restores health", value 50, category "Potion"
        // - "basic_sword": name "Basic Sword", description "A simple weapon", value 100, category "Weapon"
        // - "room_key": name "Room Key", description "Opens locked doors", value 25, category "Key"
        
        // TODO 14E: Initialise some statistics in gameStatistics:
        // - "ItemsFound": 0
        // - "EnemiesDefeated": 0  
        // - "SecretsDiscovered": 0
        
        Debug.Log($"Dictionaries initialised with {itemCatalog.Count} items");
    }

    /// <summary>
    /// TODO 15: Complete the game data loading system
    /// </summary>
    private void LoadGameData()
    {
        try
        {
            // TODO 15A: Check if the save file exists using File.Exists()
            // TODO 15B: If it exists, read the JSON using File.ReadAllText()
            // TODO 15C: Convert the JSON back to StudentGameData using JsonUtility.FromJson()
            // TODO 15D: Update playerScore with the loaded score
            // TODO 15E: Update gameTimer with the loaded playTime
            
            Debug.Log("Game data loaded successfully!");
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"Could not load game data: {ex.Message}");
            // This is normal for first run
        }
    }

    /// <summary>
    /// TODO 16: Complete the game data saving system  
    /// </summary>
    private void SaveGameData()
    {
        try
        {
            // TODO 16A: Update gameData fields with current values:
            // - score = playerScore
            // - playTime = gameTimer  
            // - playerPosition = transform.position
            
            // TODO 16B: Convert gameData to JSON string using JsonUtility.ToJson()
            // TODO 16C: Write the JSON to file using File.WriteAllText()
            
            Debug.Log("Game data saved successfully!");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Save failed: {ex.Message}");
        }
    }

    /// <summary>
    /// BONUS TODO 17: Create your own custom save system feature
    /// Add a method that demonstrates advanced data persistence
    /// Ideas: Multiple save slots, data backup, settings export, etc.
    /// </summary>
    public void BonusAdvancedFeature()
    {
        // TODO 17: Implement your own creative data persistence feature here!
        // This is your chance to go beyond the basic requirements
        // and show advanced understanding of data systems
        
        Debug.Log("🌟 Bonus feature not yet implemented - add your own advanced data system!");
    }

    /// <summary>
    /// Helper method to display exercise completion status
    /// TODO 18: Complete the progress tracking
    /// </summary>
    private void CheckExerciseCompletion()
    {
        Debug.Log("=== EXERCISE COMPLETION STATUS ===");
        
        // TODO 18A: Check each exercise component and log completion status:
        // - File I/O: Check if lastFileContent is not empty
        // - JSON Save: Check if save file exists
        // - PlayerPrefs: Check if preferences have been saved
        // - Dictionaries: Check if dictionaries are initialised and have data
        // - Game System: Check if game has been started/stopped
        
        Debug.Log("Use this method to track your progress through the exercises!");
    }
}

/* 
=== EXERCISE COMPLETION CHECKLIST ===

PART 1: FILE I/O OPERATIONS
□ TODO 1A-1E: Extended StudentGameData class with additional fields
□ TODO 5A-5D: Implemented file writing and reading functionality

PART 2: JSON SERIALISATION  
□ TODO 2A-2D: Completed GameItem class with methods
□ TODO 6A-6F: Implemented JSON save system

PART 3: PLAYERPREFS SYSTEM
□ TODO 7A-7E: Implemented PlayerPrefs saving
□ TODO 13A-13C: Implemented PlayerPrefs loading

PART 4: DICTIONARY MANAGEMENT
□ TODO 8A-8D: Implemented dictionary operations
□ TODO 14A-14E: Initialised all dictionary systems

PART 5: INTEGRATED GAME SYSTEM
□ TODO 3A-3D: Completed Start method initialisation
□ TODO 4A-4F: Completed Update method input handling  
□ TODO 9-11: Implemented game start/end functionality
□ TODO 12: Completed data initialisation
□ TODO 15-16: Implemented load/save game data systems

BONUS CHALLENGES
□ TODO 17: Created custom advanced data persistence feature
□ TODO 18: Implemented progress tracking system

=== TESTING INSTRUCTIONS ===
1. Complete all TODO sections in order
2. Attach this script to a GameObject in your scene
3. Press Play and use number keys 1-5 to test each system
4. Check Console for output and error messages
5. Verify that data persists between Play sessions
6. Test file creation in Application.persistentDataPath

=== SUCCESS CRITERIA ===
✅ All TODO sections completed without compilation errors
✅ File I/O operations create and read files successfully  
✅ JSON save/load system preserves complex data structures
✅ PlayerPrefs maintain settings between sessions
✅ Dictionaries manage game data efficiently
✅ Complete game system integrates all concepts
✅ Data persists correctly between Unity Play sessions

Congratulations on completing the CRE132 course! You now have comprehensive
knowledge of C# programming, Unity development, and professional data systems.
*/