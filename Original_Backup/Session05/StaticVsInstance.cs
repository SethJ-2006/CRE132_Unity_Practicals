using UnityEngine;

/// <summary>
/// Demonstrates the difference between static and instance members in OOP.
/// Shows when to use static vs instance, and how they behave differently.
/// 
/// Learning Goals:
/// - Understand static vs instance members
/// - Learn when to use each type
/// - See how static members are shared across all objects
/// - Practice with static methods, fields, and properties
/// - Understand static constructors and utility classes
/// </summary>
public class StaticVsInstance : MonoBehaviour
{
    [Header("Static vs Instance Demo Settings")]
    [Tooltip("Time between automatic demonstrations")]
    public float demonstrationInterval = 4.0f;
    
    [Header("Demo Statistics")]
    [Tooltip("These are INSTANCE variables - each StaticVsInstance object has its own copy")]
    public int instanceDemosRun = 0;
    public int objectsCreated = 0;
    
    private float nextDemoTime;
    
    /// <summary>
    /// Enemy class demonstrating static vs instance members
    /// </summary>
    public class Enemy
    {
        // STATIC MEMBERS - shared by ALL Enemy objects
        public static int totalEnemiesCreated = 0;
        public static int totalEnemiesKilled = 0;
        public static int maxEnemiesAllowed = 10;
        public static float globalDifficultyMultiplier = 1.0f;
        
        // Static readonly - set once, shared by all
        public static readonly string speciesName = "Hostile Entity";
        
        // INSTANCE MEMBERS - each Enemy object has its own copy
        public string enemyName;
        public int health;
        public int damage;
        public float speed;
        public bool isAlive;
        public Vector3 position;
        
        // Instance properties with private backing fields
        private int experience;
        private float timeAlive;
        
        /// <summary>
        /// Static constructor - runs once when the class is first used
        /// Used to initialize static members
        /// </summary>
        static Enemy()
        {
            Debug.Log("🏗️ Static constructor called - initializing Enemy class");
            totalEnemiesCreated = 0;
            totalEnemiesKilled = 0;
            maxEnemiesAllowed = 10;
            globalDifficultyMultiplier = 1.0f;
        }
        
        /// <summary>
        /// Instance constructor - runs every time a new Enemy is created
        /// </summary>
        public Enemy(string name, int hp, int dmg, float spd)
        {
            // Set instance members
            enemyName = name;
            health = hp;
            damage = dmg;
            speed = spd;
            isAlive = true;
            position = Vector3.zero;
            experience = 0;
            timeAlive = 0;
            
            // Update static counter
            totalEnemiesCreated++;
            
            Debug.Log($"👹 Enemy '{enemyName}' created. Total enemies: {totalEnemiesCreated}");
        }
        
        // INSTANCE METHODS - called on specific objects
        public void TakeDamage(int damageAmount)
        {
            if (!isAlive) return;
            
            health -= damageAmount;
            Debug.Log($"{enemyName} took {damageAmount} damage. Health: {health}");
            
            if (health <= 0)
            {
                Die();
            }
        }
        
        public void Die()
        {
            if (!isAlive) return;
            
            isAlive = false;
            totalEnemiesKilled++;  // Update static counter
            
            Debug.Log($"💀 {enemyName} died after {timeAlive:F1} seconds. Total killed: {totalEnemiesKilled}");
        }
        
        public void Update(float deltaTime)
        {
            if (isAlive)
            {
                timeAlive += deltaTime;
            }
        }
        
        public string GetStatus()
        {
            string status = isAlive ? "ALIVE" : "DEAD";
            return $"{enemyName}: {health}HP [{status}] (alive {timeAlive:F1}s)";
        }
        
        // STATIC METHODS - called on the class, not on objects
        
        /// <summary>
        /// Static method to check if more enemies can be spawned
        /// </summary>
        public static bool CanSpawnEnemy()
        {
            int aliveEnemies = totalEnemiesCreated - totalEnemiesKilled;
            return aliveEnemies < maxEnemiesAllowed;
        }
        
        /// <summary>
        /// Static method to get global enemy statistics
        /// </summary>
        public static string GetGlobalStats()
        {
            int aliveEnemies = totalEnemiesCreated - totalEnemiesKilled;
            return $"Global Enemy Stats: Created={totalEnemiesCreated}, Killed={totalEnemiesKilled}, Alive={aliveEnemies}, Max={maxEnemiesAllowed}";
        }
        
        /// <summary>
        /// Static method to adjust global difficulty
        /// </summary>
        public static void SetGlobalDifficulty(float multiplier)
        {
            globalDifficultyMultiplier = Mathf.Clamp(multiplier, 0.1f, 5.0f);
            Debug.Log($"🎚️ Global difficulty set to {globalDifficultyMultiplier:F1}x");
        }
        
        /// <summary>
        /// Static method to clear all enemy statistics
        /// </summary>
        public static void ResetGlobalStats()
        {
            totalEnemiesCreated = 0;
            totalEnemiesKilled = 0;
            Debug.Log("🔄 Enemy statistics reset");
        }
        
        /// <summary>
        /// Static utility method for calculating enemy power
        /// </summary>
        public static int CalculateEnemyPower(int health, int damage, float speed)
        {
            return Mathf.RoundToInt((health * 0.5f + damage * 2.0f + speed * 10.0f) * globalDifficultyMultiplier);
        }
    }
    
    /// <summary>
    /// Game Manager class showing proper use of static members for singleton-like behavior
    /// </summary>
    public static class GameManager
    {
        // Static fields for global game state
        public static int currentLevel = 1;
        public static float gameTime = 0;
        public static int playerScore = 0;
        public static bool isPaused = false;
        
        // Static properties with validation
        public static int MaxLevel 
        { 
            get { return 100; } 
        }
        
        public static string GameStatus
        {
            get 
            { 
                return isPaused ? "PAUSED" : "RUNNING"; 
            }
        }
        
        // Static methods for global game operations
        public static void StartGame()
        {
            currentLevel = 1;
            gameTime = 0;
            playerScore = 0;
            isPaused = false;
            Debug.Log("🎮 Game Started!");
        }
        
        public static void PauseGame()
        {
            isPaused = !isPaused;
            Debug.Log($"⏸️ Game {(isPaused ? "Paused" : "Resumed")}");
        }
        
        public static void AddScore(int points)
        {
            if (isPaused) return;
            
            playerScore += points;
            Debug.Log($"📈 Score increased by {points}. Total: {playerScore}");
        }
        
        public static void NextLevel()
        {
            if (currentLevel < MaxLevel)
            {
                currentLevel++;
                Debug.Log($"🆙 Advanced to level {currentLevel}");
            }
            else
            {
                Debug.Log("🏆 Maximum level reached!");
            }
        }
        
        public static void UpdateGameTime(float deltaTime)
        {
            if (!isPaused)
            {
                gameTime += deltaTime;
            }
        }
        
        public static string GetGameInfo()
        {
            return $"Level: {currentLevel}, Score: {playerScore}, Time: {gameTime:F1}s, Status: {GameStatus}";
        }
        
        public static void ResetGame()
        {
            currentLevel = 1;
            gameTime = 0;
            playerScore = 0;
            isPaused = false;
            Debug.Log("🔄 Game reset to defaults");
        }
    }
    
    /// <summary>
    /// Utility class with only static methods - no instances needed
    /// </summary>
    public static class MathUtils
    {
        // Static constants
        public const float PI_DOUBLED = Mathf.PI * 2.0f;
        public const int PERCENTAGE_MAX = 100;
        
        // Static readonly values (calculated once)
        public static readonly float GoldenRatio = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;
        
        /// <summary>
        /// Calculate percentage between two values
        /// </summary>
        public static float CalculatePercentage(float value, float max)
        {
            if (max == 0) return 0;
            return (value / max) * PERCENTAGE_MAX;
        }
        
        /// <summary>
        /// Calculate distance between two points
        /// </summary>
        public static float Distance2D(Vector2 point1, Vector2 point2)
        {
            return Vector2.Distance(point1, point2);
        }
        
        /// <summary>
        /// Check if a value is within a range
        /// </summary>
        public static bool InRange(float value, float min, float max)
        {
            return value >= min && value <= max;
        }
        
        /// <summary>
        /// Clamp a value and return whether it was changed
        /// </summary>
        public static bool ClampValue(ref float value, float min, float max)
        {
            float original = value;
            value = Mathf.Clamp(value, min, max);
            return original != value;
        }
        
        /// <summary>
        /// Generate a random point within a circle
        /// </summary>
        public static Vector2 RandomPointInCircle(float radius)
        {
            return Random.insideUnitCircle * radius;
        }
    }
    
    /// <summary>
    /// Player class showing mix of static and instance members
    /// </summary>
    public class Player
    {
        // STATIC MEMBERS - shared across all players
        public static int totalPlayersCreated = 0;
        public static string gameVersion = "1.0.0";
        public static readonly int maxPlayersInGame = 4;
        
        // INSTANCE MEMBERS - unique to each player
        public string playerName;
        public int playerID;
        public int level;
        public float health;
        public Vector3 position;
        
        public Player(string name)
        {
            playerName = name;
            totalPlayersCreated++;
            playerID = totalPlayersCreated;  // Use static counter for unique ID
            level = 1;
            health = 100;
            position = Vector3.zero;
            
            Debug.Log($"👤 Player '{playerName}' created with ID {playerID}. Total players: {totalPlayersCreated}");
        }
        
        // Instance method
        public void Move(Vector3 newPosition)
        {
            position = newPosition;
            Debug.Log($"{playerName} moved to {position}");
        }
        
        // Instance method using static data
        public void DisplayInfo()
        {
            Debug.Log($"Player: {playerName} (ID: {playerID}, Level: {level}, Health: {health})");
            Debug.Log($"Game Version: {gameVersion}, Total Players Created: {totalPlayersCreated}");
        }
        
        // Static method
        public static bool CanCreateMorePlayers()
        {
            return totalPlayersCreated < maxPlayersInGame;
        }
        
        // Static method
        public static void PrintAllPlayerStats()
        {
            Debug.Log($"=== PLAYER STATISTICS ===");
            Debug.Log($"Game Version: {gameVersion}");
            Debug.Log($"Total Players Created: {totalPlayersCreated}");
            Debug.Log($"Max Players Allowed: {maxPlayersInGame}");
            Debug.Log($"Can Create More: {CanCreateMorePlayers()}");
        }
    }
    
    void Start()
    {
        Debug.Log("=== STATIC VS INSTANCE DEMONSTRATION STARTED ===");
        Debug.Log("This demonstrates the key differences between static and instance members");
        Debug.Log("Static = shared by ALL objects, Instance = unique to each object");
        Debug.Log("");
        
        DemonstrateBasicStaticVsInstance();
        DemonstrateStaticUtilityClass();
        DemonstrateGameManager();
        
        nextDemoTime = Time.time + demonstrationInterval;
    }
    
    void Update()
    {
        // Update game time using static method
        GameManager.UpdateGameTime(Time.deltaTime);
        
        if (Time.time >= nextDemoTime)
        {
            RunAutomaticDemo();
            nextDemoTime = Time.time + demonstrationInterval;
        }
        
        // Manual demonstrations
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DemonstrateBasicStaticVsInstance();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DemonstrateStaticUtilityClass();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DemonstrateGameManager();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DemonstratePlayerSystem();
        }
    }
    
    /// <summary>
    /// Shows basic difference between static and instance members
    /// </summary>
    void DemonstrateBasicStaticVsInstance()
    {
        Debug.Log("--- STATIC VS INSTANCE BASICS ---");
        instanceDemosRun++;  // This is an INSTANCE variable
        
        Debug.Log("Creating multiple Enemy objects to show static vs instance behavior:");
        
        // Create several enemies
        Enemy goblin = new Enemy("Goblin", 50, 10, 2.0f);
        Enemy orc = new Enemy("Orc", 80, 15, 1.5f);
        Enemy troll = new Enemy("Troll", 120, 20, 1.0f);
        objectsCreated += 3;
        
        Debug.Log("\\nShowing INSTANCE data (unique to each object):");
        Debug.Log($"Goblin status: {goblin.GetStatus()}");
        Debug.Log($"Orc status: {orc.GetStatus()}");
        Debug.Log($"Troll status: {troll.GetStatus()}");
        
        Debug.Log("\\nShowing STATIC data (shared by all objects):");
        Debug.Log(Enemy.GetGlobalStats());
        
        Debug.Log("\\nTesting: Only goblin takes damage, but static counter is shared:");
        goblin.TakeDamage(60);  // This will kill the goblin
        
        Debug.Log("After goblin dies:");
        Debug.Log($"Goblin status: {goblin.GetStatus()}");  // Instance data
        Debug.Log(Enemy.GetGlobalStats());  // Static data updated
        
        Debug.Log("\\nStatic methods can be called without creating objects:");
        Debug.Log($"Can spawn more enemies? {Enemy.CanSpawnEnemy()}");
        
        Debug.Log($"This demonstration has run {instanceDemosRun} times (instance variable)");
        Debug.Log("");
    }
    
    /// <summary>
    /// Shows static utility class usage
    /// </summary>
    void DemonstrateStaticUtilityClass()
    {
        Debug.Log("--- STATIC UTILITY CLASS DEMONSTRATION ---");
        instanceDemosRun++;
        
        Debug.Log("MathUtils is a static class - no instances needed!");
        Debug.Log("All methods and properties are static:");
        
        // Use static constants
        Debug.Log($"Pi doubled constant: {MathUtils.PI_DOUBLED}");
        Debug.Log($"Golden ratio: {MathUtils.GoldenRatio}");
        
        // Use static methods
        float percentage = MathUtils.CalculatePercentage(75, 100);
        Debug.Log($"75 out of 100 = {percentage}%");
        
        Vector2 point1 = new Vector2(0, 0);
        Vector2 point2 = new Vector2(3, 4);
        float distance = MathUtils.Distance2D(point1, point2);
        Debug.Log($"Distance between {point1} and {point2} = {distance}");
        
        bool inRange = MathUtils.InRange(50, 0, 100);
        Debug.Log($"Is 50 in range 0-100? {inRange}");
        
        Vector2 randomPoint = MathUtils.RandomPointInCircle(10.0f);
        Debug.Log($"Random point in circle: {randomPoint}");
        
        Debug.Log("✅ Static utility classes are perfect for helper methods!");
        Debug.Log("");
    }
    
    /// <summary>
    /// Shows static class used for global game management
    /// </summary>
    void DemonstrateGameManager()
    {
        Debug.Log("--- STATIC GAME MANAGER DEMONSTRATION ---");
        instanceDemosRun++;
        
        Debug.Log("GameManager is static - manages global game state:");
        
        // Start game
        GameManager.StartGame();
        Debug.Log(GameManager.GetGameInfo());
        
        // Add some score and advance level
        GameManager.AddScore(100);
        GameManager.AddScore(250);
        GameManager.NextLevel();
        Debug.Log(GameManager.GetGameInfo());
        
        // Test pause functionality
        GameManager.PauseGame();
        GameManager.AddScore(50);  // This should be ignored while paused
        Debug.Log(GameManager.GetGameInfo());
        
        GameManager.PauseGame();  // Unpause
        GameManager.AddScore(50);  // This should work
        Debug.Log(GameManager.GetGameInfo());
        
        Debug.Log("✅ Static classes are perfect for singletons and global managers!");
        Debug.Log("");
    }
    
    /// <summary>
    /// Shows mix of static and instance in Player class
    /// </summary>
    void DemonstratePlayerSystem()
    {
        Debug.Log("--- MIXED STATIC/INSTANCE PLAYER SYSTEM ---");
        instanceDemosRun++;
        
        Debug.Log("Creating players to show static counters and instance data:");
        
        // Check if we can create players
        Debug.Log($"Can create players? {Player.CanCreateMorePlayers()}");
        
        // Create some players
        Player player1 = new Player("Alice");
        Player player2 = new Player("Bob");
        Player player3 = new Player("Charlie");
        objectsCreated += 3;
        
        Debug.Log("\\nEach player has unique instance data:");
        player1.Move(new Vector3(10, 0, 5));
        player2.Move(new Vector3(-5, 0, 8));
        player3.Move(new Vector3(0, 0, -3));
        
        player1.DisplayInfo();
        player2.DisplayInfo();
        player3.DisplayInfo();
        
        Debug.Log("\\nStatic data is shared:");
        Player.PrintAllPlayerStats();
        
        Debug.Log("\\nTrying to create more players:");
        if (Player.CanCreateMorePlayers())
        {
            Player player4 = new Player("Dave");
            objectsCreated++;
            player4.DisplayInfo();
        }
        else
        {
            Debug.Log("❌ Cannot create more players - limit reached!");
        }
        
        Player.PrintAllPlayerStats();
        Debug.Log("");
    }
    
    /// <summary>
    /// Runs automatic demonstrations periodically
    /// </summary>
    void RunAutomaticDemo()
    {
        Debug.Log("🔄 Auto-Demo: Testing static vs instance behavior...");
        instanceDemosRun++;
        
        // Show the difference with enemy system
        if (Enemy.CanSpawnEnemy())
        {
            Enemy autoEnemy = new Enemy($"Auto-Enemy-{Random.Range(1, 100)}", Random.Range(30, 100), Random.Range(8, 20), Random.Range(1.0f, 3.0f));
            objectsCreated++;
            
            Debug.Log($"Auto-created: {autoEnemy.GetStatus()}");
            Debug.Log(Enemy.GetGlobalStats());
            
            // Sometimes kill the enemy to show static counter updates
            if (Random.value > 0.5f)
            {
                autoEnemy.TakeDamage(9999);
            }
        }
        else
        {
            Debug.Log("Cannot spawn more enemies - limit reached!");
            Debug.Log("Resetting enemy stats...");
            Enemy.ResetGlobalStats();
        }
        
        // Show instance vs static comparison
        Debug.Log($"Instance demos run: {instanceDemosRun} (unique to this MonoBehaviour)");
        Debug.Log($"Total enemies created: {Enemy.totalEnemiesCreated} (shared by all Enemy objects)");
        Debug.Log("Press 1, 2, 3, or 4 for manual demonstrations!");
        Debug.Log("");
    }
    
    void Reset()
    {
        demonstrationInterval = 4.0f;
        instanceDemosRun = 0;
        objectsCreated = 0;
    }
}