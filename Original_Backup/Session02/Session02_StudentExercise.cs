using UnityEngine;

/// <summary>
/// Session 2 Student Exercise: Operators & Control Flow
/// Complete all TODO sections to practice mathematical operators, input detection, and conditional logic
/// </summary>
public class Session02_StudentExercise : MonoBehaviour
{
    [Header("=== STUDENT INFORMATION ===")]
    // TODO: Create public variables for your information
    // - firstName (string) - your first name
    // - studentID (string) - your student ID
    // - favouriteNumber (int) - any number you like
    
    [Header("=== CALCULATOR VARIABLES ===")]
    // TODO: Create public variables for a simple calculator
    // - firstNumber (float) - set to 10f
    // - secondNumber (float) - set to 3f
    // - operation (string) - set to "+" (can be "+", "-", "*", "/")
    
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
    [SerializeField] private int totalKeyPresses = 0;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private Vector3 lastMouseClick;
    
    void Start()
    {
        Debug.Log("=== SESSION 2 STUDENT EXERCISE ===");
        Debug.Log("Starting Operators & Control Flow exercise...");
        
        // Call methods to test your implementations
        DisplayStudentInfo();
        TestCalculator();
        AnalyzeCharacterStats();
        
        Debug.Log("\nPress SPACE to jump, WASD to move, mouse to click!");
        Debug.Log("Press C to check character status");
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
    }
    
    /// <summary>
    /// Display your student information
    /// TODO: Complete this method
    /// </summary>
    void DisplayStudentInfo()
    {
        Debug.Log("\n--- STUDENT INFORMATION ---");
        
        // TODO: Use Debug.Log to display your firstName
        // Example: Debug.Log("Student Name: " + firstName);
        
        // TODO: Use Debug.Log to display your studentID
        
        // TODO: Use Debug.Log to display your favouriteNumber
        
        // TODO: Create a calculation using your favouriteNumber
        // Example: Calculate favouriteNumber * 2 and display the result
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
    /// Check for player input and respond accordingly
    /// TODO: Complete this method
    /// </summary>
    void CheckPlayerInput()
    {
        // TODO: Check for Space key press (GetKeyDown)
        // When Space is pressed:
        //   - Increase jumpCount by 1 (jumpCount += 1)
        //   - Display "Jump! Total jumps: " + jumpCount
        
        // TODO: Check for movement keys (GetKey - held down)
        // Create a bool variable called "currentlyMoving" set to false
        // If W key is held: set currentlyMoving to true, display "Moving forward"
        // If A key is held: set currentlyMoving to true, display "Moving left" 
        // If S key is held: set currentlyMoving to true, display "Moving backward"
        // If D key is held: set currentlyMoving to true, display "Moving right"
        // Set isMoving = currentlyMoving (for Inspector display)
        
        // TODO: Check for mouse clicks (GetMouseButtonDown)
        // If left mouse button clicked (button 0):
        //   - Get mouse position: Vector3 mousePos = Input.mousePosition
        //   - Set lastMouseClick = mousePos
        //   - Display "Left click at: " + mousePos
        
        // TODO: Count total key presses
        // Use Input.inputString to detect any key press
        // If Input.inputString.Length > 0: increase totalKeyPresses by 1
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
        
        // TODO: Reset all tracking variables to their starting values
        // jumpCount = 0
        // totalKeyPresses = 0  
        // isMoving = false
        // lastMouseClick = Vector3.zero
        
        // TODO: Display a reset confirmation message
        
        // TODO: Call DisplayStudentInfo() again to show info after reset
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
□ CheckPlayerInput() - detects keyboard and mouse input
□ CheckCharacterStatus() - complex conditional analysis (C key)
□ ResetExercise() - resets tracking variables (R key)

✅ CONCEPTS DEMONSTRATED:
□ Mathematical operators (+, -, *, /, %)
□ Assignment operators (=, +=, -=, *=, /=)
□ Comparison operators (==, !=, >, <, >=, <=)
□ Logical operators (&&, ||, !)
□ If/else/else if statements
□ Input detection (GetKeyDown, GetKey, GetMouseButtonDown)
□ Complex conditional logic
□ Division by zero protection

✅ TESTING COMPLETED:
□ All variables show correctly in Inspector
□ Calculator works with different operations  
□ Character analysis provides appropriate feedback
□ Input detection responds to keyboard and mouse
□ C key shows character status
□ R key resets the exercise
□ No red errors in Console

=== REMEMBER ===
- Every line of code ends with a semicolon ;
- Use == for comparison, = for assignment
- Check for division by zero before dividing
- Use GetKeyDown for single presses, GetKey for held keys
- Test your code frequently by pressing Play!
*/