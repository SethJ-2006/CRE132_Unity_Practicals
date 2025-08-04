using UnityEngine;

/// <summary>
/// Demonstrates for loops in C# and their practical applications in game development
/// This script shows different types of for loops and how they're used in Unity
/// </summary>
public class ForLoops : MonoBehaviour
{
    [Header("=== LOOP CONFIGURATION ===")]
    public int numberOfEnemies = 5;
    public int levelSize = 10;
    public float spawnDistance = 2f;
    
    [Header("=== ARRAY DEMONSTRATION ===")]
    public string[] playerNames = {"Alice", "Bob", "Charlie", "Diana", "Eve"};
    public int[] highScores = {1500, 1200, 980, 750, 500};
    
    [Header("=== COUNTDOWN SETTINGS ===")]
    public int countdownStart = 10;
    public int multiplicationTable = 7;
    
    [Header("=== RESULTS (READ-ONLY) ===")]
    [SerializeField] private int totalScore;
    [SerializeField] private string concatenatedNames;
    [SerializeField] private int evenNumberCount;
    
    void Start()
    {
        Debug.Log("=== FOR LOOPS DEMONSTRATION ===");
        Debug.Log("Learning how for loops work and their game applications");
        
        // Demonstrate different types of for loops
        BasicForLoop();
        CountingBackwards();
        ProcessingArrays();
        NestedLoops();
        PracticalGameExamples();
        StringManipulationWithLoops();
    }
    
    /// <summary>
    /// Demonstrates a basic for loop counting upwards
    /// </summary>
    private void BasicForLoop()
    {
        Debug.Log("\n--- BASIC FOR LOOP ---");
        Debug.Log("Counting from 0 to " + (numberOfEnemies - 1));
        
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Debug.Log("Spawning enemy #" + (i + 1) + " at index " + i);
        }
        
        Debug.Log("Total enemies spawned: " + numberOfEnemies);
    }    
    /// <summary>
    /// Demonstrates counting backwards with a for loop
    /// </summary>
    private void CountingBackwards()
    {
        Debug.Log("\n--- COUNTDOWN FOR LOOP ---");
        Debug.Log("Starting countdown from " + countdownStart);
        
        for (int countdown = countdownStart; countdown > 0; countdown--)
        {
            Debug.Log("Countdown: " + countdown);
        }
        
        Debug.Log("BLAST OFF! 🚀");
    }
    
    /// <summary>
    /// Demonstrates processing arrays with for loops
    /// </summary>
    private void ProcessingArrays()
    {
        Debug.Log("\n--- PROCESSING ARRAYS ---");
        Debug.Log("Processing player names and high scores");
        
        totalScore = 0;
        concatenatedNames = "";
        
        for (int i = 0; i < playerNames.Length; i++)
        {
            Debug.Log("Player " + (i + 1) + ": " + playerNames[i] + " - Score: " + highScores[i]);
            
            totalScore += highScores[i];
            concatenatedNames += playerNames[i];
            
            // Add comma separator except for last name
            if (i < playerNames.Length - 1)
            {
                concatenatedNames += ", ";
            }
        }        
        Debug.Log("Total combined score: " + totalScore);
        Debug.Log("All player names: " + concatenatedNames);
    }
    
    /// <summary>
    /// Demonstrates nested for loops for creating grids or 2D structures
    /// </summary>
    private void NestedLoops()
    {
        Debug.Log("\n--- NESTED FOR LOOPS ---");
        Debug.Log("Creating a " + levelSize + "x" + levelSize + " grid layout");
        
        for (int row = 0; row < 3; row++)
        {
            string rowOutput = "Row " + row + ": ";
            
            for (int col = 0; col < 5; col++)
            {
                rowOutput += "[" + row + "," + col + "] ";
            }
            
            Debug.Log(rowOutput);
        }
    }
    
    /// <summary>
    /// Demonstrates practical game development applications of for loops
    /// </summary>
    private void PracticalGameExamples()
    {
        Debug.Log("\n--- PRACTICAL GAME EXAMPLES ---");
        
        // Example 1: Spawning enemies in a line
        Debug.Log("Spawning enemies in formation:");
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float xPosition = i * spawnDistance;
            Debug.Log("Enemy " + (i + 1) + " spawned at position X: " + xPosition);
        }        
        // Example 2: Multiplication table
        Debug.Log("\nMultiplication table for " + multiplicationTable + ":");
        for (int i = 1; i <= 10; i++)
        {
            int result = multiplicationTable * i;
            Debug.Log(multiplicationTable + " x " + i + " = " + result);
        }
        
        // Example 3: Finding even numbers
        evenNumberCount = 0;
        Debug.Log("\nEven numbers from 1 to 20:");
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 == 0)
            {
                Debug.Log(i + " is even");
                evenNumberCount++;
            }
        }
        Debug.Log("Total even numbers found: " + evenNumberCount);
    }
    
    /// <summary>
    /// Demonstrates using for loops with string manipulation
    /// </summary>
    private void StringManipulationWithLoops()
    {
        Debug.Log("\n--- STRING MANIPULATION WITH LOOPS ---");
        
        string message = "HELLO WORLD";
        string reversedMessage = "";
        
        // Reverse a string using a for loop
        for (int i = message.Length - 1; i >= 0; i--)
        {
            reversedMessage += message[i];
        }
        
        Debug.Log("Original message: " + message);
        Debug.Log("Reversed message: " + reversedMessage);
    }
}