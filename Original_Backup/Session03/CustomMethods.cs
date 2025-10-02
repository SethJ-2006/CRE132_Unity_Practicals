using UnityEngine;

/// <summary>
/// Demonstrates creating and using custom methods in C# for game development
/// This script shows method parameters, return types, and overloading
/// </summary>
public class CustomMethods : MonoBehaviour
{
    [Header("=== GAME SETTINGS ===")]
    public string playerName = "Hero";
    public int playerLevel = 10;
    public float baseDamage = 25f;
    public float weaponMultiplier = 1.5f;
    
    [Header("=== RESULTS (READ-ONLY) ===")]
    [SerializeField] private float calculatedDamage;
    [SerializeField] private int playerExperience;
    [SerializeField] private string gameStatus;
    
    void Start()
    {
        Debug.Log("=== CUSTOM METHODS DEMONSTRATION ===");
        Debug.Log("Learning how to create and use custom methods");
        
        // Demonstrate different types of methods
        DemonstrateVoidMethods();
        DemonstrateReturnMethods();
        DemonstrateParameterMethods();
        DemonstrateMethodOverloading();
        DemonstratePracticalGameMethods();
    }
    
    /// <summary>
    /// Demonstrates void methods (methods that don't return anything)
    /// </summary>
    private void DemonstrateVoidMethods()
    {
        Debug.Log("\n--- VOID METHODS (NO RETURN VALUE) ---");
        
        // Call methods that perform actions but don't return values
        PrintWelcomeMessage();
        LogPlayerStats();
        DisplayGameInstructions();
    }
    
    /// <summary>
    /// Simple void method that prints a welcome message
    /// </summary>
    private void PrintWelcomeMessage()
    {
        Debug.Log("🎮 Welcome to the Method Demonstration!");
        Debug.Log("This method doesn't return anything, it just performs an action.");
    }    
    /// <summary>
    /// Logs current player statistics
    /// </summary>
    private void LogPlayerStats()
    {
        Debug.Log($"Player: {playerName}, Level: {playerLevel}");
    }
    
    /// <summary>
    /// Displays game instructions
    /// </summary>
    private void DisplayGameInstructions()
    {
        Debug.Log("Instructions: Use WASD to move, Space to jump, Mouse to attack!");
    }
    
    /// <summary>
    /// Demonstrates methods that return values
    /// </summary>
    private void DemonstrateReturnMethods()
    {
        Debug.Log("\n--- RETURN METHODS (METHODS THAT GIVE BACK VALUES) ---");
        
        // Call methods and use their return values
        int randomNumber = GenerateRandomNumber();
        Debug.Log("Generated random number: " + randomNumber);
        
        bool isHighLevel = IsPlayerHighLevel();
        Debug.Log("Is player high level? " + isHighLevel);
        
        string statusMessage = GetPlayerStatus();
        gameStatus = statusMessage;
        Debug.Log("Player status: " + statusMessage);
        
        float totalDamage = CalculateBaseDamage();
        calculatedDamage = totalDamage;
        Debug.Log("Base damage calculated: " + totalDamage);
    }    
    /// <summary>
    /// Generates a random number between 1 and 100
    /// </summary>
    /// <returns>A random integer</returns>
    private int GenerateRandomNumber()
    {
        return Random.Range(1, 101);
    }
    
    /// <summary>
    /// Checks if the player is considered high level
    /// </summary>
    /// <returns>True if player level is 15 or higher</returns>
    private bool IsPlayerHighLevel()
    {
        return playerLevel >= 15;
    }
    
    /// <summary>
    /// Gets a status message based on player level
    /// </summary>
    /// <returns>A string describing the player's status</returns>
    private string GetPlayerStatus()
    {
        if (playerLevel < 5)
        {
            return "Novice Adventurer";
        }
        else if (playerLevel < 15)
        {
            return "Experienced Hero";
        }
        else
        {
            return "Legendary Champion";
        }
    }
    
    /// <summary>
    /// Calculates base damage without any parameters
    /// </summary>
    /// <returns>The calculated base damage</returns>
    private float CalculateBaseDamage()
    {
        return baseDamage * weaponMultiplier;
    }    
    /// <summary>
    /// Demonstrates methods with parameters
    /// </summary>
    private void DemonstrateParameterMethods()
    {
        Debug.Log("\n--- METHODS WITH PARAMETERS ---");
        
        // Methods with different parameter combinations
        GiveExperience(250);
        
        float damage = CalculateDamage(baseDamage, weaponMultiplier, true);
        Debug.Log($"Damage with critical hit: {damage}");
        
        bool levelUp = CheckLevelUp(playerLevel, 1500);
        Debug.Log($"Player can level up: {levelUp}");
        
        string greeting = CreateGreeting(playerName, "Warrior");
        Debug.Log($"Greeting: {greeting}");
        
        // Method with multiple parameters
        DisplayCombatResult("Goblin", 45, true, 150);
    }
    
    /// <summary>
    /// Gives experience points to the player
    /// </summary>
    /// <param name="amount">Amount of experience to give</param>
    private void GiveExperience(int amount)
    {
        playerExperience += amount;
        Debug.Log($"Player gained {amount} experience! Total: {playerExperience}");
    }
    
    /// <summary>
    /// Calculates damage with weapon multiplier and critical hit chance
    /// </summary>
    /// <param name="baseDmg">Base damage amount</param>
    /// <param name="multiplier">Weapon damage multiplier</param>
    /// <param name="isCritical">Whether this is a critical hit</param>
    /// <returns>Total calculated damage</returns>
    private float CalculateDamage(float baseDmg, float multiplier, bool isCritical)
    {
        float totalDamage = baseDmg * multiplier;
        
        if (isCritical)
        {
            totalDamage *= 2f;
            Debug.Log("💥 Critical hit!");
        }
        
        return totalDamage;
    }    
    /// <summary>
    /// Checks if a player can level up based on current level and experience
    /// </summary>
    /// <param name="currentLevel">Player's current level</param>
    /// <param name="currentExp">Player's current experience</param>
    /// <returns>True if player has enough experience to level up</returns>
    private bool CheckLevelUp(int currentLevel, int currentExp)
    {
        int requiredExp = currentLevel * 100; // Simple formula: level * 100
        return currentExp >= requiredExp;
    }
    
    /// <summary>
    /// Creates a personalised greeting message
    /// </summary>
    /// <param name="name">Player's name</param>
    /// <param name="playerClass">Player's class/type</param>
    /// <returns>A formatted greeting string</returns>
    private string CreateGreeting(string name, string playerClass)
    {
        return $"Greetings, {name} the {playerClass}! May your adventures be legendary!";
    }
    
    /// <summary>
    /// Displays the result of a combat encounter
    /// </summary>
    /// <param name="enemyName">Name of the defeated enemy</param>
    /// <param name="damageDealt">Damage dealt to the enemy</param>
    /// <param name="victory">Whether the player won</param>
    /// <param name="expGained">Experience points gained</param>
    private void DisplayCombatResult(string enemyName, int damageDealt, bool victory, int expGained)
    {
        string result = victory ? "Victory!" : "Defeat!";
        Debug.Log($"⚔️ Combat vs {enemyName}: {result}");
        Debug.Log($"   Damage dealt: {damageDealt}");
        Debug.Log($"   Experience gained: {expGained}");
    }    
    /// <summary>
    /// Demonstrates method overloading (same name, different parameters)
    /// </summary>
    private void DemonstrateMethodOverloading()
    {
        Debug.Log("\n--- METHOD OVERLOADING ---");
        Debug.Log("Same method name, different parameters:");
        
        // Different versions of the same method
        PlaySound("sword_hit");
        PlaySound("magic_spell", 0.8f);
        PlaySound("explosion", 1.2f, 0.9f);
    }
    
    /// <summary>
    /// Plays a sound effect (basic version)
    /// </summary>
    /// <param name="soundName">Name of the sound to play</param>
    private void PlaySound(string soundName)
    {
        Debug.Log($"🔊 Playing sound: {soundName} (default volume: 1.0, default pitch: 1.0)");
    }
    
    /// <summary>
    /// Plays a sound effect with custom volume
    /// </summary>
    /// <param name="soundName">Name of the sound to play</param>
    /// <param name="volume">Volume level (0.0 to 1.0)</param>
    private void PlaySound(string soundName, float volume)
    {
        Debug.Log($"🔊 Playing sound: {soundName} (volume: {volume}, default pitch: 1.0)");
    }
    
    /// <summary>
    /// Plays a sound effect with custom volume and pitch
    /// </summary>
    /// <param name="soundName">Name of the sound to play</param>
    /// <param name="volume">Volume level (0.0 to 1.0)</param>
    /// <param name="pitch">Pitch modification (0.5 = half speed, 2.0 = double speed)</param>
    private void PlaySound(string soundName, float volume, float pitch)
    {
        Debug.Log($"🔊 Playing sound: {soundName} (volume: {volume}, pitch: {pitch})");
    }    
    /// <summary>
    /// Demonstrates practical game development methods
    /// </summary>
    private void DemonstratePracticalGameMethods()
    {
        Debug.Log("\n--- PRACTICAL GAME METHODS ---");
        
        // Inventory management
        bool hasSpace = CheckInventorySpace(25, 30);
        Debug.Log($"Inventory has space: {hasSpace}");
        
        // Distance calculation
        Vector3 playerPos = new Vector3(0, 0, 0);
        Vector3 enemyPos = new Vector3(5, 3, 0);
        float distance = CalculateDistance(playerPos, enemyPos);
        Debug.Log($"Distance to enemy: {distance:F2} units");
        
        // Score calculation
        int finalScore = CalculateScore(1000, 2.5f, 500);
        Debug.Log($"Final score: {finalScore}");
        
        // Health percentage
        float healthPercent = CalculateHealthPercentage(75, 100);
        Debug.Log($"Health percentage: {healthPercent:F1}%");
        
        Debug.Log("\n🎯 CUSTOM METHOD TIPS:");
        Debug.Log("• Give methods descriptive names that explain what they do");
        Debug.Log("• Use parameters to make methods flexible and reusable");
        Debug.Log("• Return values when you need to get information back");
        Debug.Log("• Method overloading allows the same name with different parameters");
        Debug.Log("• Keep methods focused on doing one thing well");
    }
    
    /// <summary>
    /// Checks if there's enough space in inventory for new items
    /// </summary>
    /// <param name="currentItems">Current number of items</param>
    /// <param name="maxCapacity">Maximum inventory capacity</param>
    /// <returns>True if there's space for more items</returns>
    private bool CheckInventorySpace(int currentItems, int maxCapacity)
    {
        return currentItems < maxCapacity;
    }
    
    /// <summary>
    /// Calculates distance between two 3D points
    /// </summary>
    /// <param name="pointA">First position</param>
    /// <param name="pointB">Second position</param>
    /// <returns>Distance between the points</returns>
    private float CalculateDistance(Vector3 pointA, Vector3 pointB)
    {
        return Vector3.Distance(pointA, pointB);
    }
    
    /// <summary>
    /// Calculates final score with base points, multiplier, and bonus
    /// </summary>
    /// <param name="basePoints">Base score points</param>
    /// <param name="multiplier">Score multiplier</param>
    /// <param name="bonus">Bonus points to add</param>
    /// <returns>Final calculated score</returns>
    private int CalculateScore(int basePoints, float multiplier, int bonus)
    {
        return Mathf.RoundToInt(basePoints * multiplier) + bonus;
    }
    
    /// <summary>
    /// Calculates health as a percentage
    /// </summary>
    /// <param name="currentHealth">Current health amount</param>
    /// <param name="maxHealth">Maximum health amount</param>
    /// <returns>Health percentage (0-100)</returns>
    private float CalculateHealthPercentage(int currentHealth, int maxHealth)
    {
        if (maxHealth <= 0) return 0f;
        return ((float)currentHealth / maxHealth) * 100f;
    }
}