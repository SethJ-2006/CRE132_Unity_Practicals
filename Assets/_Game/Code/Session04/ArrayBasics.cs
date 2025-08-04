using UnityEngine;

/// <summary>
/// Demonstrates array basics in C# and their practical applications in game development
/// This script shows array creation, access, and manipulation with game-focused examples
/// </summary>
public class ArrayBasics : MonoBehaviour
{
    [Header("=== GAME DATA ARRAYS ===")]
    public string[] playerNames = {"Alice", "Bob", "Charlie", "Diana", "Eve"};
    public int[] highScores = {15000, 12500, 10000, 8500, 7000};
    public float[] weaponDamage = {25.5f, 18.0f, 32.5f, 15.0f, 28.0f};
    
    [Header("=== LEVEL CONFIGURATION ===")]
    public Vector3[] enemySpawnPoints = {
        new Vector3(-5f, 2f, 0f),
        new Vector3(0f, 3f, 0f),
        new Vector3(5f, 1f, 0f),
        new Vector3(-3f, -2f, 0f),
        new Vector3(3f, -1f, 0f)
    };
    
    [Header("=== COLOUR SETTINGS ===")]
    public Color[] teamColours = {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        Color.magenta
    };
    
    [Header("=== RESULTS (READ-ONLY) ===")]
    [SerializeField] private int totalPlayers;
    [SerializeField] private float averageScore;
    [SerializeField] private string topPlayer;
    [SerializeField] private int arrayOperations;
    
    void Start()
    {
        Debug.Log("=== ARRAY BASICS DEMONSTRATION ===");
        Debug.Log("Learning how arrays work and their game applications");
        
        // Demonstrate different array concepts
        ArrayCreationAndAccess();
        ArrayPropertiesAndInformation();
        ProcessingArraysWithLoops();
        PracticalGameExamples();
        ArraySearchingAndFinding();
        ModifyingArrayElements();
    }    
    /// <summary>
    /// Demonstrates array creation and basic element access
    /// </summary>
    private void ArrayCreationAndAccess()
    {
        Debug.Log("\n--- ARRAY CREATION AND ACCESS ---");
        
        // Different ways to create arrays
        int[] scores = new int[5];                          // Empty array with 5 slots
        string[] items = {"Sword", "Shield", "Potion"};     // Array with initial values
        float[] values = new float[] {1.5f, 2.3f, 3.7f};  // Explicit array creation
        
        Debug.Log("Array sizes: scores=" + scores.Length + ", items=" + items.Length + ", values=" + values.Length);
        
        // Accessing array elements
        Debug.Log("First player name: " + playerNames[0]);
        Debug.Log("Last player name: " + playerNames[playerNames.Length - 1]);
        Debug.Log("Third high score: " + highScores[2]);
        
        // Modifying array elements
        scores[0] = 1000;
        scores[1] = 2000;
        scores[4] = 5000; // Last element
        
        Debug.Log("Modified scores: [" + scores[0] + ", " + scores[1] + ", " + scores[2] + ", " + scores[3] + ", " + scores[4] + "]");
        
        arrayOperations++;
    }
    
    /// <summary>
    /// Demonstrates array properties and getting information about arrays
    /// </summary>
    private void ArrayPropertiesAndInformation()
    {
        Debug.Log("\n--- ARRAY PROPERTIES AND INFORMATION ---");
        
        totalPlayers = playerNames.Length;
        Debug.Log("Total players in leaderboard: " + totalPlayers);
        Debug.Log("Number of spawn points: " + enemySpawnPoints.Length);
        Debug.Log("Available team colours: " + teamColours.Length);
        
        // Check if arrays have elements
        if (weaponDamage.Length > 0)
        {
            Debug.Log("Weapon array is not empty - contains " + weaponDamage.Length + " weapons");
            Debug.Log("First weapon damage: " + weaponDamage[0]);
        }
        else
        {
            Debug.Log("No weapons found in array!");
        }
        
        arrayOperations++;
    }    
    /// <summary>
    /// Demonstrates processing arrays using different types of loops
    /// </summary>
    private void ProcessingArraysWithLoops()
    {
        Debug.Log("\n--- PROCESSING ARRAYS WITH LOOPS ---");
        
        // Using for loop to process arrays (when you need the index)
        Debug.Log("Player leaderboard (using for loop):");
        for (int i = 0; i < playerNames.Length; i++)
        {
            Debug.Log($"#{i + 1}: {playerNames[i]} - Score: {highScores[i]}");
        }
        
        // Using foreach loop to process arrays (when you just need the values)
        Debug.Log("\nWeapon damage values (using foreach loop):");
        foreach (float damage in weaponDamage)
        {
            Debug.Log($"Weapon deals {damage} damage");
        }
        
        // Calculate average score
        float totalScore = 0f;
        foreach (int score in highScores)
        {
            totalScore += score;
        }
        averageScore = totalScore / highScores.Length;
        Debug.Log($"Average high score: {averageScore:F1}");
        
        // Display spawn points
        Debug.Log("\nEnemy spawn positions:");
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            Debug.Log($"Spawn Point {i + 1}: {enemySpawnPoints[i]}");
        }
        
        arrayOperations++;
    }    
    /// <summary>
    /// Demonstrates practical game development applications of arrays
    /// </summary>
    private void PracticalGameExamples()
    {
        Debug.Log("\n--- PRACTICAL GAME EXAMPLES ---");
        
        // Example 1: Random enemy spawning
        Debug.Log("Spawning enemies at random locations:");
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, enemySpawnPoints.Length);
            Vector3 spawnPosition = enemySpawnPoints[randomIndex];
            Debug.Log($"Enemy {i + 1} spawned at: {spawnPosition}");
        }
        
        // Example 2: Weapon selection system
        Debug.Log("\nWeapon selection system:");
        int playerChoice = Random.Range(0, weaponDamage.Length);
        Debug.Log($"Player selected weapon {playerChoice + 1} with damage: {weaponDamage[playerChoice]}");
        
        // Example 3: Team assignment
        Debug.Log("\nAssigning team colours:");
        for (int i = 0; i < Mathf.Min(3, teamColours.Length); i++)
        {
            Debug.Log($"Player {i + 1} assigned colour: {teamColours[i]}");
        }
        
        // Example 4: Difficulty scaling
        float[] difficultyMultipliers = {1.0f, 1.2f, 1.5f, 1.8f, 2.0f};
        Debug.Log("\nDifficulty scaling:");
        for (int level = 0; level < difficultyMultipliers.Length; level++)
        {
            float adjustedDamage = weaponDamage[0] * difficultyMultipliers[level];
            Debug.Log($"Level {level + 1}: Base damage {weaponDamage[0]} becomes {adjustedDamage:F1}");
        }
        
        arrayOperations++;
    }    
    /// <summary>
    /// Demonstrates searching and finding elements in arrays
    /// </summary>
    private void ArraySearchingAndFinding()
    {
        Debug.Log("\n--- ARRAY SEARCHING AND FINDING ---");
        
        // Find the highest score and corresponding player
        int highestScore = 0;
        int topPlayerIndex = 0;
        
        for (int i = 0; i < highScores.Length; i++)
        {
            if (highScores[i] > highestScore)
            {
                highestScore = highScores[i];
                topPlayerIndex = i;
            }
        }
        
        topPlayer = playerNames[topPlayerIndex];
        Debug.Log($"Top player: {topPlayer} with score: {highestScore}");
        
        // Find specific player
        string searchPlayer = "Charlie";
        int playerIndex = -1;
        
        for (int i = 0; i < playerNames.Length; i++)
        {
            if (playerNames[i] == searchPlayer)
            {
                playerIndex = i;
                break;
            }
        }
        
        if (playerIndex >= 0)
        {
            Debug.Log($"Found {searchPlayer} at position {playerIndex + 1} with score: {highScores[playerIndex]}");
        }
        else
        {
            Debug.Log($"Player {searchPlayer} not found in leaderboard");
        }
        
        // Find weapon with specific damage range
        Debug.Log("\nWeapons with damage over 20:");
        for (int i = 0; i < weaponDamage.Length; i++)
        {
            if (weaponDamage[i] > 20f)
            {
                Debug.Log($"Weapon {i + 1}: {weaponDamage[i]} damage");
            }
        }
        
        arrayOperations++;
    }    
    /// <summary>
    /// Demonstrates modifying array elements safely
    /// </summary>
    private void ModifyingArrayElements()
    {
        Debug.Log("\n--- MODIFYING ARRAY ELEMENTS ---");
        
        // Create a copy of high scores to modify
        int[] modifiedScores = new int[highScores.Length];
        for (int i = 0; i < highScores.Length; i++)
        {
            modifiedScores[i] = highScores[i];
        }
        
        Debug.Log("Original scores: [" + string.Join(", ", highScores) + "]");
        
        // Apply bonus points to all scores
        int bonusPoints = 500;
        for (int i = 0; i < modifiedScores.Length; i++)
        {
            modifiedScores[i] += bonusPoints;
        }
        
        Debug.Log("After bonus (+500): [" + string.Join(", ", modifiedScores) + "]");
        
        // Double the score of the top player
        if (modifiedScores.Length > 0)
        {
            modifiedScores[0] *= 2; // Assuming first player is top player
            Debug.Log($"Top player score doubled: {modifiedScores[0]}");
        }
        
        // Reset lowest performing player (last in array)
        if (modifiedScores.Length > 0)
        {
            int lastIndex = modifiedScores.Length - 1;
            modifiedScores[lastIndex] = 1000; // Fresh start
            Debug.Log($"Last player given fresh start: {modifiedScores[lastIndex]}");
        }
        
        Debug.Log("Final modified scores: [" + string.Join(", ", modifiedScores) + "]");
        
        arrayOperations++;
        
        Debug.Log("\n🎯 ARRAY TIPS:");
        Debug.Log("• Arrays have fixed size - you cannot add or remove elements");
        Debug.Log("• Array indices start at 0 and go to Length-1");
        Debug.Log("• Always check array bounds to prevent errors");
        Debug.Log("• Use for loops when you need the index, foreach when you don't");
        Debug.Log("• Arrays are reference types - be careful when copying");
        Debug.Log($"• Total array operations performed: {arrayOperations}");
    }
}