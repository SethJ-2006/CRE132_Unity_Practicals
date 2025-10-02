using UnityEngine;

/// <summary>
/// CRE132 Session 1: Student Exercise
/// 
/// INSTRUCTIONS FOR STUDENTS:
/// 1. Create a new GameObject in your scene called "StudentExercise"
/// 2. Attach this script to that GameObject
/// 3. Fill in the missing code where you see TODO comments
/// 4. Make sure your code compiles without errors
/// 5. Test your script by playing the scene and checking the Console
/// 
/// This exercise tests your understanding of:
/// - Variable declaration and assignment
/// - Different data types
/// - Basic type conversion
/// - Unity Inspector integration
/// - Method creation and calling
/// </summary>
public class Session01_StudentExercise : MonoBehaviour
{
    #region Student Variables - Fill These In!
    
    [Header("=== STUDENT INFORMATION ===")]
    // TODO 1.1: Create a public string variable for your first name
    // EXAMPLE: public string firstName = "John";
    
    // TODO 1.2: Create a public string variable for your student ID
    // EXAMPLE: public string studentID = "12345";
    
    // TODO 1.3: Create a public int variable for your age
    // EXAMPLE: public int age = 20;
    
    [Header("=== GAME CHARACTER STATS ===")]
    // TODO 2.1: Create public variables for a game character
    // GOAL: Practice the 4 core data types with meaningful game variables
    // NEEDED: Character name (string), Health points (int = 100), 
    //         Movement speed (float = 5.5f), Is alive (bool = true)
    
    // YOUR CODE HERE:
    
    [Header("=== SIMPLE GAME SETTINGS ===")]
    // TODO 3.1: Create a public int for maxLevel with value 10
    // HINT: This is a simple variable that can be changed
    // EXAMPLE: public int maxLevel = 10;
    
    #endregion
    
    #region Exercise Validation
    
    [Header("=== EXERCISE VALIDATION ===")]
    [SerializeField] private bool runValidation = false;
    
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
        Debug.Log("=== EXERCISE VALIDATION RESULTS ===");
        int completedTasks = 0;
        int totalTasks = 8; // Adjust based on actual TODO count
        
        // Basic completion check - students can extend this
        if (CheckBasicVariablesDeclared())
        {
            Debug.Log("✓ Basic variables declared correctly");
            completedTasks += 3;
        }
        else
        {
            Debug.LogWarning("❌ Some basic variables are missing");
        }
        
        // Display final score
        float percentage = (float)completedTasks / totalTasks * 100f;
        Debug.Log($"Exercise completion: {completedTasks}/{totalTasks} ({percentage:F0}%)");
        
        if (percentage >= 80f)
            Debug.Log("🎉 Excellent work! Exercise completed successfully!");
        else if (percentage >= 60f)
            Debug.Log("👍 Good progress! Review the missing items and try again.");
        else
            Debug.Log("📚 Keep working! Check the TODO sections and ask for help if needed.");
    }
    
    private bool CheckBasicVariablesDeclared()
    {
        // Simple check - students should replace TODO comments with actual variables
        // This is a basic implementation that students can improve
        return true; // Placeholder - students should implement proper checking
    }
    
    #region Private Variables for Calculations
    
    // These are provided for you - notice they're private
    private int calculatedScore;
    private float experiencePoints;
    private string statusMessage;
    
    #endregion
    
    #region Unity Methods
    
    void Start()
    {
        Debug.Log("=== Session 1 Student Exercise Results ===");
        
        // Call the methods you need to complete
        DisplayStudentInfo();
        DisplayCharacterStats();
        PerformCalculations();
        DisplayFinalResults();
    }
    
    #endregion
    
    #region Methods to Complete
    
    /// <summary>
    /// TODO 4.1: Complete this method to display your student information
    /// GOAL: Practice using Debug.Log with string concatenation
    /// </summary>
    void DisplayStudentInfo()
    {
        Debug.Log("--- Student Information ---");
        
        // TODO 4.1a: Display your first name
        // EXAMPLE: Debug.Log("Student Name: " + firstName);
        
        // TODO 4.1b: Display your student ID
        // TODO 4.1c: Display your age
        
        // YOUR CODE HERE:
        
    }
    
    /// <summary>
    /// TODO: Complete this method to show your character stats
    /// Display all the character variables you created
    /// </summary>
    void DisplayCharacterStats()
    {
        Debug.Log("--- Character Statistics ---");
        
        // TODO: Display character name
        
        // TODO: Display health points
        
        // TODO: Display movement speed
        
        // TODO: Display if character is alive
        
        // TODO: Display maxLevel variable
    }
    
    /// <summary>
    /// TODO: Complete this method to perform some calculations
    /// Use your variables to calculate new values
    /// </summary>
    void PerformCalculations()
    {
        Debug.Log("--- Calculations ---");
        
        // TODO: Set calculatedScore to health points multiplied by 10
        
        // TODO: Set experiencePoints to age multiplied by movement speed
        
        // TODO: Create a status message that combines your name and character name
        // Example: statusMessage = "Player " + yourName + " controls " + characterName;
        
        // Display the results (this is provided for you)
        Debug.Log($"Calculated Score: {calculatedScore}");
        Debug.Log($"Experience Points: {experiencePoints}");
        Debug.Log($"Status: {statusMessage}");
    }
    
    
    /// <summary>
    /// This method is completed for you - it shows the final exercise results
    /// </summary>
    void DisplayFinalResults()
    {
        Debug.Log("--- Exercise Complete ---");
        Debug.Log("If you can see all the information above without errors,");
        Debug.Log("you have successfully completed Session 1!");
        Debug.Log("🎉 Well done! You understand C# fundamentals!");
    }
    
    #endregion
    
    #region Bonus Methods (Optional)
    
    /// <summary>
    /// BONUS: Create your own method that does something interesting
    /// with your variables. Be creative!
    /// </summary>
    [ContextMenu("Run Bonus Method")]
    public void BonusCreativeMethod()
    {
        Debug.Log("--- Bonus Creative Method ---");
        
        // TODO: Write some creative code here!
        // Ideas:
        // - Calculate how many years until your character reaches MAX_LEVEL
        // - Create a story using your variables
        // - Do some fun math with your numbers
        // - Experiment with string operations
        
        Debug.Log("Add your own creative code here!");
    }
    
    #endregion
}

/*
 * GRADING CHECKLIST FOR INSTRUCTORS:
 * 
 * BASIC REQUIREMENTS (Must have all to pass):
 * □ All TODO variables declared with correct types
 * □ Variables have appropriate values assigned
 * □ Script compiles without errors
 * □ All Debug.Log statements work and show data
 * 
 * GOOD UNDERSTANDING:
 * □ Proper use of public variables (show in Inspector)
 * □ Good variable naming conventions used
 * □ Comments added to explain their code
 * □ All 4 data types used correctly
 * 
 * BONUS (OPTIONAL):
 * □ Bonus method completed with creative implementation
 * □ Shows initiative in organizing variables nicely
 * 
 * COMMON STUDENT MISTAKES TO WATCH FOR:
 * ❌ Forgetting 'f' suffix on float literals (e.g., 5.5f not 5.5)
 * ❌ Using int for decimal values (should be float)
 * ❌ Not making variables public (won't show in Inspector)
 * ❌ Inconsistent variable naming conventions
 */