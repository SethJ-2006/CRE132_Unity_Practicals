using UnityEngine;

/// <summary>
/// Session 03 Student Exercise: Loops and Methods
/// Complete the TODO sections to practice for loops, while loops, string methods, and custom methods
/// 
/// INSTRUCTIONS:
/// 1. Read each TODO comment carefully
/// 2. Write the requested code in the marked sections
/// 3. Test your code by pressing Play and checking the Console
/// 4. All TODOs must be completed for full marks
/// </summary>
public class Session03_StudentExercise : MonoBehaviour
{
    [Header("=== STUDENT CONFIGURATION ===")]
    public string studentName = "Enter Your Name Here";
    public int favouriteNumber = 7;
    public string[] hobbies = {"Reading", "Gaming", "Coding"};
    
    [Header("=== EXERCISE SETTINGS ===")]
    public int loopCount = 5;
    public float playerHealth = 100f;
    public float maxHealth = 100f;
    
    [Header("=== RESULTS (DO NOT MODIFY) ===")]
    [SerializeField] private int totalSum;
    [SerializeField] private string processedName;
    [SerializeField] private float calculatedResult;
    [SerializeField] private bool allTestsPassed;
    
    void Start()
    {
        Debug.Log("=== SESSION 03 STUDENT EXERCISE ===");
        Debug.Log($"Student: {studentName}");
        Debug.Log("Complete all TODO sections and check your results!\n");
        
        // Call exercise methods
        ExerciseA_BasicForLoop();
        ExerciseB_WhileLoopWithCondition();
        ExerciseC_StringManipulation();
        ExerciseD_CreateCustomMethod();
        ExerciseE_MethodWithParameters();
        ExerciseF_AdvancedChallenge();
        
        // Final results
        DisplayFinalResults();
    }
    
    /// <summary>
    /// EXERCISE A: Create a basic for loop
    /// DIFFICULTY: ⭐ Beginner
    /// </summary>
    private void ExerciseA_BasicForLoop()
    {
        Debug.Log("--- EXERCISE A: Basic For Loop ---");
        
        totalSum = 0;
        
        // TODO A1: Create a for loop that runs 'loopCount' times
        // TODO A1: Inside the loop, add the current loop index (i) to totalSum
        // TODO A1: Also print "Loop iteration: X" where X is the current loop number (starting from 0)
        
        // HINT: for (int i = 0; i < ???; i++)
        // HINT: Use totalSum += i; to add to the total
        // HINT: Use Debug.Log("Loop iteration: " + i);
        
        // YOUR CODE HERE:
        
        
        Debug.Log($"Total sum after for loop: {totalSum}");
        Debug.Log($"Expected sum for {loopCount} iterations: {(loopCount * (loopCount - 1)) / 2}\n");
    }    
    /// <summary>
    /// EXERCISE B: Create a while loop with a condition
    /// DIFFICULTY: ⭐⭐ Intermediate
    /// </summary>
    private void ExerciseB_WhileLoopWithCondition()
    {
        Debug.Log("--- EXERCISE B: While Loop with Condition ---");
        
        float currentHealth = playerHealth;
        int turnCounter = 1;
        
        // TODO B1: Create a while loop that continues while currentHealth > 0
        // TODO B1: Inside the loop:
        //          - Generate random damage between 10 and 20 (use Random.Range(10, 21))
        //          - Subtract the damage from currentHealth
        //          - Print "Turn X: Took Y damage, Health: Z" (replace X, Y, Z with actual values)
        //          - Increment turnCounter
        //          - Add a safety check: if turnCounter > 20, break out of the loop
        
        // HINT: while (currentHealth > 0)
        // HINT: Use Random.Range(10, 21) for damage between 10-20
        // HINT: Use if (turnCounter > 20) { break; }
        
        // YOUR CODE HERE:
        
        
        Debug.Log($"Simulation ended after {turnCounter - 1} turns with {currentHealth} health\n");
    }
    
    /// <summary>
    /// EXERCISE C: String manipulation practice
    /// DIFFICULTY: ⭐⭐ Intermediate
    /// </summary>
    private void ExerciseC_StringManipulation()
    {
        Debug.Log("--- EXERCISE C: String Manipulation ---");
        
        // TODO C1: Take the studentName variable and:
        //          - Remove any extra spaces with Trim()
        //          - Convert to lowercase with ToLower()
        //          - Replace any underscores with spaces using Replace("_", " ")
        //          - Store the result in processedName
        
        // TODO C2: Print the original name and the processed name
        // TODO C3: Print the length of the processed name
        // TODO C4: Check if the processed name contains the word "student" (case insensitive)
        
        // HINT: processedName = studentName.Trim().ToLower().Replace("_", " ");
        // HINT: Use .Contains() to check for "student"
        
        // YOUR CODE HERE:
        
        
        Debug.Log($"Name processing complete\n");
    }    
    /// <summary>
    /// EXERCISE D: Create your first custom method
    /// DIFFICULTY: ⭐⭐⭐ Advanced
    /// </summary>
    private void ExerciseD_CreateCustomMethod()
    {
        Debug.Log("--- EXERCISE D: Create Custom Method ---");
        
        // TODO D1: Call your custom method (created below) with favouriteNumber
        // TODO D1: Store the result in calculatedResult
        
        // YOUR CODE HERE:
        // calculatedResult = YourMethodName(favouriteNumber);
        
        
        Debug.Log($"Method result: {calculatedResult}\n");
    }
    
    // TODO D2: Create a method called "CalculateSquareAndDouble" that:
    //          - Takes one int parameter called "number"
    //          - Calculates the square of the number (number * number)
    //          - Doubles the result (multiply by 2)
    //          - Returns the final result as a float
    //          - Add a Debug.Log inside the method showing the calculation
    
    // HINT: Method signature should be: private float CalculateSquareAndDouble(int number)
    // HINT: Don't forget the return statement!
    
    // YOUR METHOD HERE:
    
    
    /// <summary>
    /// EXERCISE E: Method with multiple parameters
    /// DIFFICULTY: ⭐⭐⭐ Advanced
    /// </summary>
    private void ExerciseE_MethodWithParameters()
    {
        Debug.Log("--- EXERCISE E: Method with Multiple Parameters ---");
        
        // TODO E1: Call your DisplayHobbyInfo method (created below) for each hobby in the hobbies array
        // TODO E1: Use a for loop to go through all hobbies
        
        // HINT: Use a for loop: for (int i = 0; i < hobbies.Length; i++)
        // HINT: Call: DisplayHobbyInfo(hobbies[i], i + 1);
        
        // YOUR CODE HERE:
        
        
        Debug.Log("Hobby display complete\n");
    }    
    // TODO E2: Create a method called "DisplayHobbyInfo" that:
    //          - Takes two parameters: string hobbyName, int hobbyNumber
    //          - Prints: "Hobby #X: Y" where X is the number and Y is the hobby name
    //          - Has no return value (void)
    
    // HINT: Method signature: private void DisplayHobbyInfo(string hobbyName, int hobbyNumber)
    // HINT: Use Debug.Log($"Hobby #{hobbyNumber}: {hobbyName}");
    
    // YOUR METHOD HERE:
    
    
    /// <summary>
    /// EXERCISE F: Advanced Challenge - Combine everything!
    /// DIFFICULTY: ⭐⭐⭐⭐ Expert
    /// </summary>
    private void ExerciseF_AdvancedChallenge()
    {
        Debug.Log("--- EXERCISE F: Advanced Challenge ---");
        
        // TODO F1: Create a method called "ValidateAndProcessName" (see below)
        // TODO F1: Test it with different names including: "", "   ", "JohnDoe", "a", "VeryLongNameThatExceedsTwentyCharacters"
        
        string[] testNames = {"", "   ", "JohnDoe", "a", "VeryLongNameThatExceedsTwentyCharacters", studentName};
        
        // YOUR CODE HERE - call ValidateAndProcessName for each test name:
        
        
        Debug.Log("Name validation tests complete\n");
    }
    
    // TODO F2: Create a method called "ValidateAndProcessName" that:
    //          - Takes one string parameter called "inputName"
    //          - Returns a string
    //          - Inside the method:
    //            * Trim whitespace from the input
    //            * Check if the trimmed name is between 2 and 20 characters
    //            * If valid: return the name in "Title Case" (first letter uppercase, rest lowercase)
    //            * If invalid: return "INVALID NAME"
    //          - Add Debug.Log statements to show the validation process
    
    // HINT: Use inputName.Trim(), check .Length, use string.IsNullOrEmpty()
    // HINT: Title case: name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower()
    
    // YOUR METHOD HERE:
    
    
    /// <summary>
    /// Displays final results and checks if all exercises were completed
    /// </summary>
    private void DisplayFinalResults()
    {
        Debug.Log("=== FINAL RESULTS ===");
        
        // Simple check to see if student has made progress
        allTestsPassed = (totalSum > 0 && !string.IsNullOrEmpty(processedName) && calculatedResult > 0);
        
        Debug.Log($"Total Sum from Exercise A: {totalSum}");
        Debug.Log($"Processed Name from Exercise C: '{processedName}'");
        Debug.Log($"Calculated Result from Exercise D: {calculatedResult}");
        Debug.Log($"Basic Tests Passed: {allTestsPassed}");
        
        if (allTestsPassed)
        {
            Debug.Log("🎉 Congratulations! You've completed the basic exercises!");
            Debug.Log("💡 Challenge: Try modifying the values and running again!");
        }
        else
        {
            Debug.Log("❌ Some exercises need completion. Check the TODO comments above.");
        }
        
        Debug.Log("\n📚 WHAT YOU'VE LEARNED:");
        Debug.Log("• How to create and use for loops");
        Debug.Log("• How to create and use while loops");
        Debug.Log("• String manipulation methods (Trim, ToLower, Replace, Contains)");
        Debug.Log("• Creating custom methods with parameters");
        Debug.Log("• Methods with return values");
        Debug.Log("• Combining loops with methods for powerful programs");
    }
    
    // TODO BONUS: Create any additional methods you want to experiment with!
    // Ideas: Method to calculate area of a rectangle, method to check if a number is even,
    // method to count vowels in a string, method to generate a random password
}