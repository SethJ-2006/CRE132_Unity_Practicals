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
    
    [Header("=== EXERCISE VALIDATION ===")]
    [SerializeField] private bool runValidation = false;
    
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
        // ExerciseF_AdvancedChallenge(); // Optional advanced challenge
        
        // Final results
        DisplayFinalResults();
    }
    
    void Update()
    {
        if (runValidation)
        {
            runValidation = false;
            ValidateExercise();
        }
    }
    
    [ContextMenu("Validate My Work")]
    public void ValidateExercise()
    {
        Debug.Log("=== SESSION 03 EXERCISE VALIDATION ===");
        int completedTasks = 0;
        int totalTasks = 5; // A through E exercises
        
        // Check if basic structure exists
        if (CheckExerciseStructure())
        {
            Debug.Log("✓ Exercise structure is complete");
            completedTasks += 2;
        }
        else
        {
            Debug.LogWarning("❌ Some exercises are missing implementation");
        }
        
        // Display final score
        float percentage = (float)completedTasks / totalTasks * 100f;
        Debug.Log($"Exercise completion: {completedTasks}/{totalTasks} ({percentage:F0}%)");
        
        if (percentage >= 80f)
            Debug.Log("🎉 Excellent work! Loops and methods mastered!");
        else if (percentage >= 60f)
            Debug.Log("👍 Good progress! Review the missing exercises.");
        else
            Debug.Log("📚 Keep working on the TODO sections!");
    }
    
    private bool CheckExerciseStructure()
    {
        // Basic validation - students should expand this
        return !string.IsNullOrEmpty(studentName) && studentName != "Enter Your Name Here";
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
        // GOAL: Practice basic for loop syntax and variable accumulation
        // NEEDED: Loop from 0 to loopCount, add index to totalSum, print each iteration
        // EXAMPLE: for (int i = 0; i < loopCount; i++)
        // HINT: Use totalSum += i; and Debug.Log("Loop iteration: " + i);
        
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
        // GOAL: Practice while loops with conditions and safety breaks
        // NEEDED: Loop while health > 0, apply random damage (10-20), track turns, safety break at 20 turns
        // EXAMPLE: while (currentHealth > 0)
        // HINT: Use Random.Range(10, 21) and if (turnCounter > 20) { break; }
        
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
        Debug.Log("• Building a solid foundation for more advanced programming");
    }
    
    // TODO BONUS: Create any additional methods you want to experiment with!
    // Ideas: Method to calculate area of a rectangle, method to check if a number is even,
    // method to count vowels in a string, method to generate a random password
}