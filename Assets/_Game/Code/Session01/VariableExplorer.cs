using System;
using UnityEngine;

/// <summary>
/// CRE132 Session 1: Variable Explorer
/// 
/// This script demonstrates all C# variable types and concepts covered in W3Schools.
/// 
/// W3Schools Topics Covered:
/// - C# Variables (declaration, assignment, naming)
/// - C# Data Types (int, float, double, bool, char, string, long)
/// - C# Constants (const and readonly)
/// - C# Type Casting (implicit and explicit)
/// 
/// Learning Objectives:
/// 1. Understand different C# data types and when to use them
/// 2. Learn variable declaration and assignment
/// 3. Understand constants vs variables
/// 4. Apply proper variable naming conventions
/// 5. Practice type conversion and casting
/// 6. See how variables appear in Unity's Inspector
/// </summary>
public class VariableExplorer : MonoBehaviour
{
    #region Core Data Types - Integers
    
    [Header("=== INTEGER NUMBERS ===")]
    [Tooltip("Integer - whole numbers without decimals (e.g., 1, 100, -50)")]
    public int playerScore = 1000;
    
    [Tooltip("Integer - count of items or enemies")]
    public int enemyCount = 25;
    
    [Tooltip("Integer - player level or progress")]
    public int playerLevel = 5;
    
    // Private integer examples (won't show in Inspector)
    private int privateScore = 500;
    private int calculatedValue; // Declared but not yet assigned
    
    #endregion
    
    #region Core Data Types - Decimal Numbers
    
    [Header("=== DECIMAL NUMBERS ===")]
    [Tooltip("Float - decimal numbers like 5.75, 0.5, -12.3. Always add 'f' at the end!")]
    public float playerSpeed = 5.75f;
    
    [Tooltip("Float - player health with decimal precision")]
    public float playerHealth = 100.0f;
    
    [Tooltip("Float - temperature or other measurements")]
    public float temperature = 23.5f;
    
    #endregion
    
    #region Core Data Types - True/False
    
    [Header("=== TRUE/FALSE VALUES ===")]
    [Tooltip("Boolean - can only be true or false")]
    public bool isPlayerAlive = true;
    
    [Tooltip("Boolean - another example")]
    public bool gameIsRunning = false;
    
    [Tooltip("Boolean - useful for checking conditions")]
    public bool hasKey = false;
    
    #endregion
    
    #region Core Data Types - Text
    
    [Header("=== TEXT (STRINGS) ===")]
    [Tooltip("String - text in double quotes like \"Hello World\"")]
    public string playerName = "Hero";
    
    [Tooltip("String - can contain spaces and punctuation")]
    public string welcomeMessage = "Welcome to CRE132!";
    
    [Tooltip("String - can be empty")]
    public string emptyString = "";
    
    #endregion
    
    
    #region Variable Naming Examples
    
    [Header("=== VARIABLE NAMING CONVENTIONS ===")]
    // Good variable names - descriptive and follow C# conventions
    public int currentHealthPoints = 100;
    public float movementSpeed = 5.0f;
    public bool canJump = true;
    public string firstName = "John";
    
    // Acceptable but less descriptive
    public int hp = 100;
    public float speed = 5.0f;
    
    // These would cause errors (illegal variable names):
    // public int 123number = 5;      // Cannot start with number
    // public float my-variable = 1f; // Cannot contain hyphens
    // public string class = "test";  // Cannot use C# keywords
    
    #endregion
    
    #region Unity Lifecycle Methods
    
    /// <summary>
    /// Awake() runs before Start() - perfect for initialisation
    /// Note: readonly variables must be set at declaration in Unity MonoBehaviour
    /// because Awake() is not a true constructor in C# terms
    /// </summary>
    void Awake()
    {
        Debug.Log("=== CRE132 Session 1: Variable Explorer ===");
        Debug.Log("Learning about the 4 core data types: int, float, bool, string");
    }
    
    /// <summary>
    /// Start() - demonstrate all our variables and data types
    /// </summary>
    void Start()
    {
        Debug.Log("--- Variable Explorer Starting ---");
        
        // Call our demonstration methods
        DemonstrateVariableDeclaration();
        ShowDataTypeExamples();
        ExploreVariableOperations();
    }
    
    #endregion
    
    #region Variable Demonstration Methods
    
    /// <summary>
    /// Shows different ways to declare and assign variables
    /// </summary>
    void DemonstrateVariableDeclaration()
    {
        Debug.Log("=== Variable Declaration Examples ===");
        
        // Method 1: Declare and assign in one line
        int score = 100;
        string name = "Player";
        
        // Method 2: Declare first, assign later
        float health;
        health = 75.5f;
        
        // Method 3: Declare multiple variables of same type
        int x, y, z;
        x = 10;
        y = 20;
        z = 30;
        
        // Method 4: Declare and assign multiple variables
        int a = 1, b = 2, c = 3;
        
        Debug.Log($"Score: {score}, Name: {name}, Health: {health}");
        Debug.Log($"Coordinates - X: {x}, Y: {y}, Z: {z}");
        Debug.Log($"Multiple assignment - A: {a}, B: {b}, C: {c}");
        
        // Show that calculated value was initially 0 (default for int)
        Debug.Log($"calculatedValue was initially: {calculatedValue}");
        calculatedValue = score * 2;
        Debug.Log($"calculatedValue after assignment: {calculatedValue}");
    }
    
    
    
    /// <summary>
    /// Shows what you can do with variables once they're declared
    /// </summary>
    void ExploreVariableOperations()
    {
        Debug.Log("=== Variable Operations ===");
        
        // Mathematical operations
        int num1 = 10;
        int num2 = 3;
        
        int addition = num1 + num2;
        int subtraction = num1 - num2;
        int multiplication = num1 * num2;
        int division = num1 / num2;        // Integer division - result is 3, not 3.33...
        int remainder = num1 % num2;       // Modulus - remainder after division
        
        Debug.Log($"Math operations with {num1} and {num2}:");
        Debug.Log($"Addition: {addition}, Subtraction: {subtraction}");
        Debug.Log($"Multiplication: {multiplication}, Division: {division}, Remainder: {remainder}");
        
        // String operations
        string part1 = "Hello";
        string part2 = "World";
        string combined = part1 + " " + part2;  // Concatenation
        int length = combined.Length;            // String property
        
        Debug.Log($"String operations: '{part1}' + ' ' + '{part2}' = '{combined}' (length: {length})");
        
        // Variable reassignment
        int changingNumber = 5;
        Debug.Log($"changingNumber starts as: {changingNumber}");
        changingNumber = 10;
        Debug.Log($"changingNumber changed to: {changingNumber}");
        changingNumber = changingNumber + 5;
        Debug.Log($"changingNumber after adding 5: {changingNumber}");
    }
    
    
    #endregion
    
    #region Inspector Testing Methods
    
    /// <summary>
    /// Public method that can be called to show current variable values
    /// Useful for testing from other scripts or Unity events
    /// </summary>
    [ContextMenu("Show All Variables")]
    public void ShowAllVariableValues()
    {
        Debug.Log("=== Current Variable Values ===");
        Debug.Log($"Integers - playerScore: {playerScore}, enemyCount: {enemyCount}, playerLevel: {playerLevel}");
        Debug.Log($"Floats - playerSpeed: {playerSpeed}, playerHealth: {playerHealth}, temperature: {temperature}");
        Debug.Log($"Booleans - isPlayerAlive: {isPlayerAlive}, gameIsRunning: {gameIsRunning}, hasKey: {hasKey}");
        Debug.Log($"Strings - playerName: '{playerName}', welcomeMessage: '{welcomeMessage}'");
    }
    
    /// <summary>
    /// Demonstrates variable modification through code
    /// </summary>
    [ContextMenu("Modify Variables")]
    public void ModifyVariablesExample()
    {
        Debug.Log("=== Modifying Variables ===");
        
        // Change the values and show the results
        playerScore += 500;  // Add 500 to current score
        playerSpeed *= 1.5f; // Multiply speed by 1.5
        isPlayerAlive = !isPlayerAlive; // Toggle boolean value
        playerName = playerName + " Jr."; // Add to string
        
        Debug.Log($"Modified values - Score: {playerScore}, Speed: {playerSpeed}");
        Debug.Log($"Alive: {isPlayerAlive}, Name: '{playerName}'");
        
        // Show in Inspector by calling the other method
        ShowAllVariableValues();
    }
    
    #endregion
}

/*
 * SESSION 01 SUMMARY:
 * Students learn the 4 core C# data types (int, float, bool, string), 
 * basic variable declaration and assignment, and Unity Inspector integration.
 * Perfect foundation for beginners!
 */
