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
    #region Integer Data Types
    
    [Header("=== INTEGER DATA TYPES ===")]
    [Tooltip("Standard integer - most commonly used for whole numbers")]
    public int playerScore = 1000;
    
    [Tooltip("Long integer - for very large whole numbers")]
    public long worldPopulation = 8000000000L; // Note the 'L' suffix for long literals
    
    [Tooltip("Short integer - for small whole numbers (rarely used)")]
    public short enemyCount = 25;
    
    [Tooltip("Byte - very small positive numbers (0-255)")]
    public byte playerLevel = 42;
    
    // Private integer examples (won't show in Inspector)
    private int privateScore = 500;
    private int calculatedValue; // Declared but not yet assigned
    
    #endregion
    
    #region Floating Point Data Types
    
    [Header("=== FLOATING POINT DATA TYPES ===")]
    [Tooltip("Float - decimal numbers with ~7 digits precision. Note the 'f' suffix!")]
    public float playerSpeed = 5.75f; // 'f' suffix is required for float literals
    
    [Tooltip("Double - decimal numbers with ~15 digits precision")]
    public double preciseCalculation = 3.141592653589793;
    
    [Tooltip("Decimal - highest precision for financial calculations")]
    public decimal currency = 99.99m; // 'm' suffix for decimal literals
    
    // Examples of different ways to write floating point numbers
    private float temperature = 23.5f;
    private float scientificNotation = 1.5e3f; // 1.5 * 10^3 = 1500
    
    #endregion
    
    #region Boolean and Character Data Types
    
    [Header("=== BOOLEAN AND CHARACTER DATA TYPES ===")]
    [Tooltip("Boolean - true or false values only")]
    public bool isPlayerAlive = true;
    
    [Tooltip("Boolean - another example")]
    public bool gameIsRunning = false;
    
    [Tooltip("Character - single letter, number, or symbol in single quotes")]
    public char playerGrade = 'A';
    
    [Tooltip("Character - can also be special characters")]
    public char specialSymbol = '@';
    
    // Character examples
    private char newlineChar = '\n'; // Special escape character
    private char tabChar = '\t';     // Tab character
    
    #endregion
    
    #region String Data Type
    
    [Header("=== STRING DATA TYPE ===")]
    [Tooltip("String - text in double quotes. Can be empty or very long.")]
    public string playerName = "Hero";
    
    [Tooltip("String - can contain spaces and special characters")]
    public string welcomeMessage = "Welcome to CRE132 Game Development!";
    
    [Tooltip("String - can be empty")]
    public string emptyString = "";
    
    [Tooltip("String - can contain numbers (but they're treated as text)")]
    public string versionNumber = "1.0.0";
    
    // String examples with special characters
    private string multilineString = "Line 1\nLine 2\nLine 3"; // \n creates new lines
    private string quotedString = "He said, \"Hello World!\""; // \" for quotes inside strings
    
    #endregion
    
    #region Constants and Readonly Variables
    
    [Header("=== CONSTANTS AND READONLY ===")]
    // Constants - values that NEVER change during program execution
    public const int MAX_PLAYERS = 4;           // const must be assigned when declared
    public const string GAME_NAME = "CRE132";   // const values are known at compile time
    public const float PI = 3.14159f;           // Mathematical constants are perfect for const
    
    // Readonly - can only be set in constructor or when declared
    public readonly string buildDate = "2025-07-30";  // Set when declared
    public readonly int sessionNumber = 1;            // Must be set here - Unity doesn't use constructors like regular C#
    
    // Static readonly - shared across all instances of this class
    public static readonly string courseCode = "CRE132";
    
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
    
    // These would cause errors if uncommented (illegal variable names):
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
        Debug.Log("Awake() - Initialising the Variable Explorer");
        Debug.Log($"Session Number: {sessionNumber} (readonly, set at declaration)");
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
        DemonstrateTypeCasting();
        ExploreVariableOperations();
        ShowConstantsAndReadonly();
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
    /// Demonstrates each data type with examples and their characteristics
    /// </summary>
    void ShowDataTypeExamples()
    {
        Debug.Log("=== Data Type Examples ===");
        
        // Integer types and their ranges
        Debug.Log($"int range: {int.MinValue} to {int.MaxValue}");
        Debug.Log($"long range: {long.MinValue} to {long.MaxValue}");
        
        // Floating point precision
        float floatExample = 1.23456789f;   // Will be rounded due to precision limits
        double doubleExample = 1.23456789012345;
        
        Debug.Log($"Float precision: {floatExample}");
        Debug.Log($"Double precision: {doubleExample}");
        
        // Boolean examples
        bool result1 = 5 > 3;  // true
        bool result2 = 10 < 5; // false
        Debug.Log($"5 > 3 is {result1}, 10 < 5 is {result2}");
        
        // Character examples
        char letter = 'Z';
        char digit = '7';      // This is a character, not a number!
        char symbol = '$';
        Debug.Log($"Characters: {letter}, {digit}, {symbol}");
        
        // String examples
        string greeting = "Hello";
        string target = "World";
        string combined = greeting + " " + target + "!"; // String concatenation
        Debug.Log($"Combined string: {combined}");
    }
    
    /// <summary>
    /// Demonstrates type casting - converting between data types
    /// </summary>
    void DemonstrateTypeCasting()
    {
        Debug.Log("=== Type Casting Examples ===");
        
        // Implicit casting (automatic) - smaller to larger type
        int intValue = 100;
        long longValue = intValue;     // int automatically becomes long
        float floatValue = intValue;   // int automatically becomes float
        double doubleValue = floatValue; // float automatically becomes double
        
        Debug.Log($"Implicit casting: int {intValue} → long {longValue} → float {floatValue} → double {doubleValue}");
        
        // Explicit casting (manual) - larger to smaller type (data might be lost!)
        double originalDouble = 9.78;
        int convertedInt = (int)originalDouble;  // Explicit cast - decimal part lost!
        
        Debug.Log($"Explicit casting: double {originalDouble} → int {convertedInt}");
        
        // Type conversion methods (safer approach)
        string numberAsString = "123";
        int convertedNumber = Convert.ToInt32(numberAsString);
        
        string decimalAsString = "45.67";
        float convertedFloat = Convert.ToSingle(decimalAsString); // Single = float
        
        Debug.Log($"String to int: '{numberAsString}' → {convertedNumber}");
        Debug.Log($"String to float: '{decimalAsString}' → {convertedFloat}");
        
        // Converting other way - numbers to strings
        int number = 456;
        string numberAsText = number.ToString();
        Debug.Log($"Int to string: {number} → '{numberAsText}'");
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
    
    /// <summary>
    /// Demonstrates constants and readonly variables
    /// </summary>
    void ShowConstantsAndReadonly()
    {
        Debug.Log("=== Constants and Readonly Variables ===");
        
        Debug.Log($"Game constants - MAX_PLAYERS: {MAX_PLAYERS}, GAME_NAME: {GAME_NAME}, PI: {PI}");
        Debug.Log($"Readonly values - buildDate: {buildDate}, sessionNumber: {sessionNumber}");
        Debug.Log($"Static readonly - courseCode: {courseCode}");
        
        // Constants cannot be changed - these lines would cause errors:
        // MAX_PLAYERS = 6;     // Error: Cannot assign to const
        // PI = 3.14f;          // Error: Cannot assign to const
        
        // Readonly cannot be changed after initialization - this would cause an error:
        // sessionNumber = 2;   // Error: readonly field cannot be assigned except at declaration
        // Note: In Unity MonoBehaviour, readonly fields must be set at declaration, not in Awake()!
        
        // But regular variables can be changed anytime:
        playerScore = playerScore + 100;
        Debug.Log($"Updated playerScore: {playerScore}");
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
        Debug.Log($"Integers - playerScore: {playerScore}, worldPopulation: {worldPopulation}");
        Debug.Log($"Floats - playerSpeed: {playerSpeed}, preciseCalculation: {preciseCalculation}");
        Debug.Log($"Booleans - isPlayerAlive: {isPlayerAlive}, gameIsRunning: {gameIsRunning}");
        Debug.Log($"Characters - playerGrade: '{playerGrade}', specialSymbol: '{specialSymbol}'");
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
 * SUMMARY - What students should understand after this script:
 * 
 * 1. DATA TYPES:
 *    - int: whole numbers (-2 billion to +2 billion)
 *    - float: decimal numbers (~7 digit precision) - needs 'f' suffix
 *    - double: high precision decimals (~15 digits)
 *    - bool: true or false only
 *    - char: single character in single quotes 'A'
 *    - string: text in double quotes "Hello"
 *    - long: very large whole numbers - needs 'L' suffix
 * 
 * 2. VARIABLES:
 *    - Declare with: type name = value;
 *    - Can declare first, assign later
 *    - Can change values anytime (unless const/readonly)
 *    - Use descriptive names following C# conventions
 * 
 * 3. CONSTANTS:
 *    - const: never changes, must be set when declared
 *    - readonly: can only be set at declaration (in Unity MonoBehaviour)
 *    - Use UPPERCASE for const by convention
 *    - NOTE: Unity's Awake() is not a constructor, so readonly must be set at declaration
 * 
 * 4. TYPE CASTING:
 *    - Implicit: automatic (small to large type)
 *    - Explicit: manual with (type) - might lose data
 *    - Convert class: safer for string conversion
 * 
 * 5. UNITY INTEGRATION:
 *    - Public variables show in Inspector
 *    - [Header] and [Tooltip] attributes improve Inspector
 *    - [ContextMenu] adds right-click options in Inspector
 */