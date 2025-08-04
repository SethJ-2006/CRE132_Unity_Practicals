using UnityEngine;

/// <summary>
/// Demonstrates while loops in C# and their practical applications in game development
/// This script shows different types of while loops and when to use them
/// </summary>
public class WhileLoops : MonoBehaviour
{
    [Header("=== GAME SIMULATION SETTINGS ===")]
    public int startingHealth = 100;
    public int startingMana = 50;
    public int targetScore = 1000;
    
    [Header("=== RANDOM GENERATION ===")]
    public int diceTarget = 6;
    public int maxAttempts = 20;
    
    [Header("=== RESULTS (READ-ONLY) ===")]
    [SerializeField] private int finalHealth;
    [SerializeField] private int totalTurns;
    [SerializeField] private int diceRolls;
    [SerializeField] private bool targetReached;
    
    void Start()
    {
        Debug.Log("=== WHILE LOOPS DEMONSTRATION ===");
        Debug.Log("Learning how while loops work and their game applications");
        
        // Demonstrate different types of while loops
        BasicWhileLoop();
        HealthDamageSimulation();
        ScoreTargetLoop();
        DiceRollingGame();
        DoWhileExample();
        InfiniteLoopPrevention();
    }
    
    /// <summary>
    /// Demonstrates a basic while loop with a simple counter
    /// </summary>
    private void BasicWhileLoop()
    {
        Debug.Log("\n--- BASIC WHILE LOOP ---");
        
        int counter = 0;
        while (counter < 5)
        {
            Debug.Log("Counter value: " + counter);
            counter++; // IMPORTANT: Always modify the condition variable!
        }
        
        Debug.Log("Loop finished. Final counter value: " + counter);
    }    
    /// <summary>
    /// Simulates a combat system where player takes damage until health reaches zero
    /// </summary>
    private void HealthDamageSimulation()
    {
        Debug.Log("\n--- HEALTH DAMAGE SIMULATION ---");
        
        int currentHealth = startingHealth;
        int turnNumber = 1;
        
        Debug.Log("Starting combat with " + currentHealth + " health");
        
        while (currentHealth > 0)
        {
            int damage = Random.Range(5, 25); // Random damage between 5-24
            currentHealth -= damage;
            
            // Prevent negative health display
            if (currentHealth < 0) currentHealth = 0;
            
            Debug.Log("Turn " + turnNumber + ": Took " + damage + " damage. Health: " + currentHealth);
            
            turnNumber++;
            
            // Safety check to prevent infinite loops in case of logic errors
            if (turnNumber > 50)
            {
                Debug.LogWarning("Combat simulation stopped to prevent infinite loop");
                break;
            }
        }
        
        finalHealth = currentHealth;
        totalTurns = turnNumber - 1;
        Debug.Log("Combat ended after " + totalTurns + " turns");
    }    
    /// <summary>
    /// Demonstrates accumulating values until reaching a target score
    /// </summary>
    private void ScoreTargetLoop()
    {
        Debug.Log("\n--- SCORE TARGET LOOP ---");
        
        int currentScore = 0;
        int attempts = 0;
        
        Debug.Log("Trying to reach target score: " + targetScore);
        
        while (currentScore < targetScore)
        {
            int pointsEarned = Random.Range(50, 200);
            currentScore += pointsEarned;
            attempts++;
            
            Debug.Log("Attempt " + attempts + ": Earned " + pointsEarned + " points. Total: " + currentScore);
        }
        
        targetReached = currentScore >= targetScore;
        Debug.Log("Target reached in " + attempts + " attempts! Final score: " + currentScore);
    }
    
    /// <summary>
    /// Simulates rolling dice until we get the target number
    /// </summary>
    private void DiceRollingGame()
    {
        Debug.Log("\n--- DICE ROLLING GAME ---");
        Debug.Log("Rolling dice until we get a " + diceTarget);
        
        int rollCount = 0;
        int currentRoll = 0;
        
        while (currentRoll != diceTarget && rollCount < maxAttempts)
        {
            currentRoll = Random.Range(1, 7); // Dice roll 1-6
            rollCount++;
            
            Debug.Log("Roll " + rollCount + ": " + currentRoll);
        }        
        diceRolls = rollCount;
        
        if (currentRoll == diceTarget)
        {
            Debug.Log("SUCCESS! Got " + diceTarget + " after " + rollCount + " rolls!");
        }
        else
        {
            Debug.Log("Reached maximum attempts (" + maxAttempts + ") without success");
        }
    }
    
    /// <summary>
    /// Demonstrates a do-while loop (executes at least once)
    /// </summary>
    private void DoWhileExample()
    {
        Debug.Log("\n--- DO-WHILE LOOP EXAMPLE ---");
        
        int magicNumber = Random.Range(1, 6);
        int guess = 0;
        int guessCount = 0;
        
        Debug.Log("Guessing a magic number between 1-5");
        
        do
        {
            guess = Random.Range(1, 6);
            guessCount++;
            Debug.Log("Guess " + guessCount + ": " + guess);
        }
        while (guess != magicNumber && guessCount < 10);
        
        if (guess == magicNumber)
        {
            Debug.Log("Found the magic number " + magicNumber + " in " + guessCount + " guesses!");
        }
        else
        {
            Debug.Log("Couldn't find magic number " + magicNumber + " in 10 guesses");
        }
    }    
    /// <summary>
    /// Demonstrates how to prevent infinite loops with safety checks
    /// </summary>
    private void InfiniteLoopPrevention()
    {
        Debug.Log("\n--- INFINITE LOOP PREVENTION ---");
        
        int safetyCounter = 0;
        int randomValue = Random.Range(1, 100);
        
        Debug.Log("Looking for an even number. Starting with: " + randomValue);
        
        // Without safety counter, this could potentially run forever
        while (randomValue % 2 != 0) // While number is odd
        {
            randomValue = Random.Range(1, 100);
            safetyCounter++;
            
            Debug.Log("Attempt " + safetyCounter + ": " + randomValue);
            
            // Safety break to prevent infinite loops
            if (safetyCounter >= 20)
            {
                Debug.LogWarning("Safety break activated after 20 attempts");
                break;
            }
        }
        
        if (randomValue % 2 == 0)
        {
            Debug.Log("Found even number " + randomValue + " after " + safetyCounter + " attempts");
        }
        else
        {
            Debug.Log("Stopped searching after reaching safety limit");
        }
        
        Debug.Log("\n🎯 WHILE LOOP TIPS:");
        Debug.Log("• Always modify the condition variable inside the loop");
        Debug.Log("• Use safety counters to prevent infinite loops");
        Debug.Log("• Consider using 'break' to exit early when needed");
        Debug.Log("• Do-while loops execute at least once, while loops might not execute at all");
    }
}