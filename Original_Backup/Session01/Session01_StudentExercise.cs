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
    // TODO: Create a public string variable for your first name
    // TODO: Create a public string variable for your student ID
    // TODO: Create a public int variable for your age
    
    [Header("=== GAME CHARACTER STATS ===")]
    // TODO: Create public variables for a game character:
    // - Character name (string)
    // - Health points (int) - set to 100
    // - Movement speed (float) - set to 5.5f
    // - Is character alive (bool) - set to true
    // - Character class letter grade (char) - set to 'A'
    
    [Header("=== CONSTANTS ===")]
    // TODO: Create a const int for MAX_LEVEL with value 50
    // TODO: Create a readonly string for GAME_VERSION set to "1.0"
    
    #endregion
    
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
        TestTypeConversion();
        DisplayFinalResults();
    }
    
    #endregion
    
    #region Methods to Complete
    
    /// <summary>
    /// TODO: Complete this method to display your student information
    /// Use Debug.Log to show your name, student ID, and age
    /// </summary>
    void DisplayStudentInfo()
    {
        Debug.Log("--- Student Information ---");
        
        // TODO: Use Debug.Log to display your first name
        // Example: Debug.Log("Student Name: " + yourNameVariable);
        
        // TODO: Use Debug.Log to display your student ID
        
        // TODO: Use Debug.Log to display your age
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
        
        // TODO: Display character grade
        
        // TODO: Display MAX_LEVEL constant
        
        // TODO: Display GAME_VERSION readonly variable
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
    /// TODO: Complete this method to practice type conversion
    /// Convert between different data types
    /// </summary>
    void TestTypeConversion()
    {
        Debug.Log("--- Type Conversion ---");
        
        // TODO: Convert your age (int) to a string and display it
        // string ageAsString = yourAge.ToString();
        // Debug.Log("Age as string: " + ageAsString);
        
        // TODO: Convert your movement speed (float) to an int (this will lose decimal places)
        // int speedAsInt = (int)yourMovementSpeed;
        // Debug.Log("Speed as int: " + speedAsInt);
        
        // TODO: Convert the string "25" to an int using Convert.ToInt32()
        string numberString = "25";
        // int convertedNumber = Convert.ToInt32(numberString);
        // Debug.Log("Converted string to int: " + convertedNumber);
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
 * INTERMEDIATE UNDERSTANDING:
 * □ Proper use of public vs private variables
 * □ Correct type conversion demonstrated
 * □ Good variable naming conventions used
 * □ Comments added to explain their code
 * 
 * ADVANCED UNDERSTANDING:
 * □ Bonus method completed with creative implementation
 * □ Uses string interpolation ($"text {variable}")
 * □ Demonstrates understanding of constants vs readonly
 * □ Shows initiative in variable organisation
 * 
 * COMMON STUDENT MISTAKES TO WATCH FOR:
 * ❌ Forgetting 'f' suffix on float literals
 * ❌ Using int for decimal values (should be float)
 * ❌ Mixing up single quotes (char) vs double quotes (string)
 * ❌ Not making variables public (won't show in Inspector)
 * ❌ Inconsistent variable naming conventions
 */