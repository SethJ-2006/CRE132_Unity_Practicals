using UnityEngine;

/// <summary>
/// Session 2 Student Exercise: Operators & Control Flow
/// Complete all TODO sections to practice mathematical operators, input detection, and conditional logic
/// </summary>
public class Session02_StudentExercise : MonoBehaviour
{
    [Header("=== STUDENT INFORMATION ===")]
    // TODO 1.1: Create public variables for your information
    // GOAL: Practice variable declaration with different data types
    // NEEDED: firstName (string), studentID (string), favouriteNumber (int)
    // EXAMPLE: public string firstName = "John";
    
    // YOUR CODE HERE:
    
    [Header("=== CALCULATOR VARIABLES ===")]
    // TODO 1.2: Create public variables for a simple calculator
    // GOAL: Set up variables for mathematical operations
    // NEEDED: firstNumber (float = 10f), secondNumber (float = 3f), operation (string = "+")
    // HINT: operation can be "+", "-", "*", or "/"
    
    // YOUR CODE HERE:
    
    [Header("=== GAME CHARACTER STATS ===")]
    // TODO: Create public variables for a game character
    // - characterName (string) - give your character a name
    // - characterHealth (int) - set to 100
    // - characterLevel (int) - set to 1
    // - characterSpeed (float) - set to 5.5f
    // - hasWeapon (bool) - set to true
    // - characterClass (string) - set to "Warrior", "Mage", or "Archer"
    
    [Header("=== INPUT TRACKING ===")]
    // These variables track player input - don't modify these
    [SerializeField] private int jumpCount = 0;
    
    void Start()
    {
        Debug.Log("=== SESSION 2 STUDENT EXERCISE ===");
        Debug.Log("Starting Operators & Control Flow exercise...");
        
        // Call methods to test your implementations
        DisplayStudentInfo();
        TestCalculator();
        AnalyzeCharacterStats();
        
        Debug.Log("\nPress SPACE to jump!");
        Debug.Log("Press C to check character status");
        Debug.Log("Press V to validate your work");
    }
    
    void Update()
    {
        // Check for user input every frame
        CheckPlayerInput();
        
        // Check for special key presses
        if (Input.GetKeyDown(KeyCode.C))
        {
            CheckCharacterStatus();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetExercise();
        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            ValidateExercise();
        }
    }
    
    /// <summary>
    /// Display your student information
    /// TODO: Complete this method
    /// </summary>
    void DisplayStudentInfo()
    {
        Debug.Log("\n--- STUDENT INFORMATION ---");
        
        // TODO 2.1a: Display your firstName
        // EXAMPLE: Debug.Log("Student Name: " + firstName);
        
        // TODO 2.1b: Display your studentID
        // TODO 2.1c: Display your favouriteNumber
        
        // TODO 2.1d: Create a calculation using your favouriteNumber
        // EXAMPLE: int doubled = favouriteNumber * 2;
        //          Debug.Log("Favourite number doubled: " + doubled);
        
        // YOUR CODE HERE:
    }
    
    /// <summary>
    /// Test your calculator implementation
    /// TODO: Complete this method with if/else statements
    /// </summary>
    void TestCalculator()
    {
        Debug.Log("\n--- CALCULATOR TEST ---");
        
        // TODO: Create if/else statements to perform different operations
        // Check the 'operation' variable and perform the correct calculation
        
        // TODO: If operation == "+"
        //   Calculate firstNumber + secondNumber
        //   Display: "10 + 3 = 13" (using your actual numbers)
        
        // TODO: Else if operation == "-" 
        //   Calculate firstNumber - secondNumber
        //   Display the result
        
        // TODO: Else if operation == "*"
        //   Calculate firstNumber * secondNumber  
        //   Display the result
        
        // TODO: Else if operation == "/"
        //   Check if secondNumber != 0 first (to avoid division by zero!)
        //   If safe to divide: calculate and display result
        //   If not safe: display "Error: Cannot divide by zero!"
        
        // TODO: Else (for unknown operations)
        //   Display "Error: Unknown operation" + the operation value
    }
    
    /// <summary>
    /// Analyze your character stats using conditional logic
    /// TODO: Complete this method
    /// </summary>
    void AnalyzeCharacterStats()
    {
        Debug.Log("\n--- CHARACTER ANALYSIS ---");
        
        // TODO: Display basic character information
        // Use Debug.Log to show characterName, characterHealth, characterLevel, etc.
        
        // TODO: Analyze character health with if/else if/else
        // If characterHealth > 75: Display "Health: Excellent"
        // Else if characterHealth > 50: Display "Health: Good"  
        // Else if characterHealth > 25: Display "Health: Warning"
        // Else: Display "Health: Critical"
        
        // TODO: Check character level with if/else
        // If characterLevel >= 10: Display "Experienced fighter"
        // Else: Display "Novice adventurer"
        
        // TODO: Use logical operators (&&, ||, !)
        // If hasWeapon && characterHealth > 50: Display "Ready for combat!"
        // If characterHealth <= 25 || !hasWeapon: Display "Needs preparation before fighting"
        
        // TODO: Check character class and give class-specific advice
        // If characterClass == "Warrior": Display "Strong in close combat"
        // Else if characterClass == "Mage": Display "Powerful magic user"  
        // Else if characterClass == "Archer": Display "Excellent ranged attacks"
        // Else: Display "Unknown class type"
    }
    
    /// <summary>
    /// Check for player input
    /// TODO: Complete this method (just Space key for now!)
    /// </summary>
    void CheckPlayerInput()
    {
        // TODO: Check for Space key press (GetKeyDown)
        // When Space is pressed:
        //   - Increase jumpCount by 1 (jumpCount += 1)
        //   - Display "Jump! Total jumps: " + jumpCount
        // EXAMPLE: if (Input.GetKeyDown(KeyCode.Space))
        //          {
        //              jumpCount += 1;
        //              Debug.Log("Jump! Total jumps: " + jumpCount);
        //          }
        
        // YOUR CODE HERE:
        
        
        // NOTE: We'll learn about movement keys and mouse input in later sessions!
        // For now, just focus on detecting the Space key press
    }
    
    /// <summary>
    /// Check character status with complex conditions
    /// TODO: Complete this method (called when C key is pressed)
    /// </summary>
    void CheckCharacterStatus()
    {
        Debug.Log("\n--- CHARACTER STATUS CHECK ---");
        
        // TODO: Create complex conditional statements
        
        // TODO: Check if character is ready for adventure
        // If characterHealth > 50 && hasWeapon && characterLevel >= 3:
        //   Display "Character is ready for adventure!"
        // Else:
        //   Display "Character needs more preparation"
        
        // TODO: Determine character rank based on level
        // If characterLevel >= 20: Display "Master level character"
        // Else if characterLevel >= 15: Display "Expert level character"
        // Else if characterLevel >= 10: Display "Advanced level character"  
        // Else if characterLevel >= 5: Display "Intermediate level character"
        // Else: Display "Beginner level character"
        
        // TODO: Check for special conditions using logical operators
        // If (characterClass == "Mage" && characterLevel >= 5) || characterHealth == 100:
        //   Display "Character has special abilities available"
        
        // TODO: Use the NOT operator (!)
        // If !hasWeapon: Display "WARNING: Character is unarmed!"
    }
    
    /// <summary>
    /// Reset the exercise (called when R key is pressed)
    /// TODO: Complete this method
    /// </summary>
    void ResetExercise()
    {
        Debug.Log("\n--- RESETTING EXERCISE ---");
        
        // TODO: Reset jump counter to zero
        // jumpCount = 0;
        
        // TODO: Display a reset confirmation message
        // Debug.Log("Exercise reset! Jump count cleared.");
        
        // YOUR CODE HERE:
        
    }
    
    [ContextMenu("Validate My Work")]
    public void ValidateExercise()
    {
        Debug.Log("=== SESSION 02 EXERCISE VALIDATION ===");
        int completedTasks = 0;
        int totalTasks = 6; // Variables, Calculator, Character, Input, Status, Reset
        
        // Check if basic structure exists
        if (CheckVariablesExist())
        {
            Debug.Log("✓ Variables declared properly");
            completedTasks += 2;
        }
        else
        {
            Debug.LogWarning("❌ Some variables are missing");
        }
        
        // Display final score
        float percentage = (float)completedTasks / totalTasks * 100f;
        Debug.Log($"Exercise completion: {completedTasks}/{totalTasks} ({percentage:F0}%)");
        
        if (percentage >= 80f)
            Debug.Log("🎉 Excellent work! Operators and control flow mastered!");
        else if (percentage >= 60f)
            Debug.Log("👍 Good progress! Complete the remaining TODO sections.");
        else
            Debug.Log("📚 Keep working! Press V to validate again.");
    }
    
    private bool CheckVariablesExist()
    {
        // Basic validation - students should expand this
        return true; // Placeholder for students to implement
    }
    
    /// <summary>
    /// Bonus challenge methods - try these if you finish early!
    /// </summary>
    
    // BONUS TODO: Create a method called "AdvancedCalculator()"
    // - Add support for modulo (%) operation
    // - Add support for power operations (use Mathf.Pow(base, exponent))
    // - Include input validation (check for valid operations)
    
    // BONUS TODO: Create a method called "ComplexCharacterAnalysis()"  
    // - Calculate a "power level" using: (characterLevel * 10) + (characterHealth / 2)
    // - Determine if character can defeat enemies based on level and equipment
    // - Create a character advancement suggestion system
    
    // BONUS TODO: Create a method called "InputComboDetection()"
    // - Detect key combinations like Shift+Space, Ctrl+Click
    // - Create a simple "cheat code" system (like typing "GOD" for god mode)
    // - Track input sequences and patterns
}

/* 
=== COMPLETION CHECKLIST ===
When you finish this exercise, you should have:

✅ VARIABLES COMPLETED:
□ Student information variables (firstName, studentID, favouriteNumber)
□ Calculator variables (firstNumber, secondNumber, operation)  
□ Character variables (name, health, level, speed, hasWeapon, class)

✅ METHODS COMPLETED:
□ DisplayStudentInfo() - shows your information and a calculation
□ TestCalculator() - performs math operations with if/else statements
□ AnalyzeCharacterStats() - analyzes character with conditional logic
□ CheckPlayerInput() - detects Space key input
□ CheckCharacterStatus() - complex conditional analysis (C key)
□ ResetExercise() - resets tracking variables (R key)

✅ CONCEPTS DEMONSTRATED:
□ Mathematical operators (+, -, *, /, %)
□ Assignment operators (=, +=, -=, *=, /=)
□ Comparison operators (==, !=, >, <, >=, <=)
□ Logical operators (&&, ||, !)
□ If/else/else if statements
□ Basic input detection (GetKeyDown with Space key)
□ Complex conditional logic
□ Division by zero protection

✅ TESTING COMPLETED:
□ All variables show correctly in Inspector
□ Calculator works with different operations  
□ Character analysis provides appropriate feedback
□ Input detection responds to Space key
□ C key shows character status
□ R key resets the exercise
□ No red errors in Console

=== REMEMBER ===
- Every line of code ends with a semicolon ;
- Use == for comparison, = for assignment
- Check for division by zero before dividing
- Use GetKeyDown for single key presses (we'll learn more input types later)
- Test your code frequently by pressing Play!
*/