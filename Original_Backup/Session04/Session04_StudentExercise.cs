using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Session 04 Student Exercise: Collections & Movement
/// Complete the TODO sections to practice arrays, lists, transforms, and movement
/// 
/// INSTRUCTIONS:
/// 1. Read each TODO comment carefully
/// 2. Write the requested code in the marked sections
/// 3. Test your code by pressing Play and checking the Console
/// 4. For movement exercises, watch the object move in Scene view
/// 5. All TODOs must be completed for full marks
/// </summary>
public class Session04_StudentExercise : MonoBehaviour
{
    [Header("=== STUDENT CONFIGURATION ===")]
    public string studentName = "Enter Your Name Here";
    public int[] testScores = {85, 92, 78, 96, 88};
    public List<string> favouriteGames = new List<string> {"Unity", "Minecraft"};
    
    [Header("=== MOVEMENT SETTINGS ===")]
    public float movementSpeed = 3f;
    public bool enableMovement = false;
    public Vector3 targetPosition = new Vector3(5f, 0f, 0f);
    
    [Header("=== RESULTS (DO NOT MODIFY) ===")]
    [SerializeField] private int highestScore;
    [SerializeField] private float averageScore;
    [SerializeField] private int totalGames;
    [SerializeField] private Vector3 currentPosition;
    [SerializeField] private bool exercisesComplete;
    
    // Private variables for exercises
    private Vector3 startPosition;
    private List<Vector3> waypointList;
    private int[] numbersArray;
    
    void Start()
    {
        Debug.Log("=== SESSION 04 STUDENT EXERCISE ===");
        Debug.Log($"Student: {studentName}");
        Debug.Log("Complete all TODO sections and test your movement!\n");
        
        // Store starting position for movement exercises
        startPosition = transform.position;
        
        // Call exercise methods
        ExerciseA_ArrayBasics();
        ExerciseB_ListOperations();
        ExerciseC_TransformBasics();
        ExerciseD_CreateMovementSystem();
        ExerciseE_AdvancedCollections();
        ExerciseF_CombinedChallenge();
        
        // Final results
        DisplayFinalResults();
    }    
    void Update()
    {
        // Update current position for Inspector display
        currentPosition = transform.position;
        
        // Handle movement if enabled (for movement exercises)
        if (enableMovement)
        {
            // This will be implemented in Exercise D
            HandleBasicMovement();
        }
    }
    
    /// <summary>
    /// EXERCISE A: Array Basics
    /// DIFFICULTY: ⭐ Beginner
    /// </summary>
    private void ExerciseA_ArrayBasics()
    {
        Debug.Log("--- EXERCISE A: Array Basics ---");
        
        // TODO A1: Create an array called 'numbersArray' with values: 10, 25, 30, 15, 40
        // TODO A1: Store it in the private variable at the top of this class
        // HINT: numbersArray = new int[] {10, 25, 30, 15, 40};
        
        // YOUR CODE HERE:
        
        
        // TODO A2: Use a for loop to print all values in testScores array
        // TODO A2: Also find the highest score and store it in highestScore variable
        // HINT: Use a for loop and compare each score to find the maximum
        
        // YOUR CODE HERE:
        
        
        // TODO A3: Calculate the average of testScores and store in averageScore
        // HINT: Add all scores together, then divide by the array length
        
        // YOUR CODE HERE:
        
        
        Debug.Log($"Array exercise complete. Highest: {highestScore}, Average: {averageScore:F1}\n");
    }    
    /// <summary>
    /// EXERCISE B: List Operations
    /// DIFFICULTY: ⭐⭐ Intermediate
    /// </summary>
    private void ExerciseB_ListOperations()
    {
        Debug.Log("--- EXERCISE B: List Operations ---");
        
        // TODO B1: Add three more games to the favouriteGames list
        // TODO B1: Use the Add() method to add: "Zelda", "Mario", "Tetris"
        // HINT: favouriteGames.Add("GameName");
        
        // YOUR CODE HERE:
        
        
        // TODO B2: Print all games in the favouriteGames list using a foreach loop
        // TODO B2: Format: "Game X: GameName" where X is the number
        
        // YOUR CODE HERE:
        
        
        // TODO B3: Remove "Unity" from the list (if it exists)
        // TODO B3: Then add "Pokemon" at the beginning of the list (index 0)
        // HINT: Use Remove() and Insert() methods
        
        // YOUR CODE HERE:
        
        
        // TODO B4: Update totalGames with the current count of games in the list
        
        // YOUR CODE HERE:
        
        
        Debug.Log($"List exercise complete. Total games: {totalGames}\n");
    }    
    /// <summary>
    /// EXERCISE C: Transform Basics
    /// DIFFICULTY: ⭐⭐ Intermediate
    /// </summary>
    private void ExerciseC_TransformBasics()
    {
        Debug.Log("--- EXERCISE C: Transform Basics ---");
        
        // TODO C1: Print the current position, rotation, and scale of this GameObject
        // HINT: Use transform.position, transform.rotation.eulerAngles, transform.localScale
        
        // YOUR CODE HERE:
        
        
        // TODO C2: Move this object 2 units to the right using transform.position
        // HINT: transform.position += Vector3.right * 2f;
        
        // YOUR CODE HERE:
        
        
        // TODO C3: Scale this object to be 1.5 times bigger in X and Y (keep Z at 1)
        // HINT: transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        
        // YOUR CODE HERE:
        
        
        // TODO C4: Calculate the distance from current position to targetPosition
        // TODO C4: Print the result using Vector3.Distance()
        
        // YOUR CODE HERE:
        
        
        Debug.Log("Transform exercise complete\n");
    }    
    /// <summary>
    /// EXERCISE D: Create Movement System
    /// DIFFICULTY: ⭐⭐⭐ Advanced
    /// </summary>
    private void ExerciseD_CreateMovementSystem()
    {
        Debug.Log("--- EXERCISE D: Create Movement System ---");
        
        // TODO D1: Create the HandleBasicMovement() method below this method
        // TODO D1: The method should move the object towards targetPosition using Vector3.MoveTowards
        // TODO D1: Use movementSpeed and Time.deltaTime for smooth movement
        // TODO D1: When object reaches target (distance < 0.1f), set a new random target
        
        Debug.Log("Movement system created. Set enableMovement to true to test it!");
        Debug.Log("Watch the Scene view to see the object move!\n");
    }
    
    // TODO D2: Create the HandleBasicMovement method here:
    // HINT: Method signature should be: private void HandleBasicMovement()
    // HINT: Use Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    // HINT: Use Vector3.Distance() to check if target is reached
    // HINT: Create new random target with: new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
    
    // YOUR METHOD HERE:
    private void HandleBasicMovement()
    {
        // Move towards target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        
        // Check if target is reached
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Create new random target
            targetPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
        }
    }
    
    
    /// <summary>
    /// EXERCISE E: Advanced Collections
    /// DIFFICULTY: ⭐⭐⭐ Advanced
    /// </summary>
    private void ExerciseE_AdvancedCollections()
    {
        Debug.Log("--- EXERCISE E: Advanced Collections ---");
        
        // TODO E1: Create a List<Vector3> called waypointList and store it in the private variable
        // TODO E1: Add 4 waypoints: (-3,2,0), (3,2,0), (3,-2,0), (-3,-2,0)
        
        // YOUR CODE HERE:
        
        
        // TODO E2: Use a for loop to print all waypoints with their index numbers
        // TODO E2: Format: "Waypoint 1: (x, y, z)"
        
        // YOUR CODE HERE:
        
        
        // TODO E3: Find the waypoint closest to the current transform position
        // TODO E3: Print which waypoint it is and the distance to it
        // HINT: Use Vector3.Distance() and compare all waypoints
        
        // YOUR CODE HERE:
        
        
        Debug.Log("Advanced collections exercise complete\n");
    }    
    /// <summary>
    /// EXERCISE F: Combined Challenge - Put it all together!
    /// DIFFICULTY: ⭐⭐⭐⭐ Expert
    /// </summary>
    private void ExerciseF_CombinedChallenge()
    {
        Debug.Log("--- EXERCISE F: Combined Challenge ---");
        
        // TODO F1: Create a method called "ProcessScoreArray" that:
        //          - Takes an int[] parameter called "scores"
        //          - Returns the average as a float
        //          - Prints each score that is above the average
        //          - Call this method with your numbersArray
        
        // YOUR METHOD CALL HERE:
        
        
        // TODO F2: Create a method called "ManageGameList" that:
        //          - Takes a List<string> parameter called "games"
        //          - Removes any games with less than 5 characters
        //          - Adds "Cyberpunk" to the list if it's not already there
        //          - Returns the count of remaining games
        //          - Call this method with favouriteGames
        
        // YOUR METHOD CALL HERE:
        
        
        // TODO F3: Create a method called "CreateMovementPath" that:
        //          - Takes no parameters
        //          - Creates and returns a List<Vector3> with 5 random positions
        //          - Each position should be within range (-10 to 10, -5 to 5, 0)
        //          - Print each position as it's created
        
        // YOUR METHOD CALL HERE:
        
        
        Debug.Log("Combined challenge complete!\n");
    }
    
    // TODO F4: Create your three methods here:
    // Remember to include proper parameter types and return types!
    
    // ProcessScoreArray method:
    
    
    // ManageGameList method:
    
    
    // CreateMovementPath method:
    
    
    /// <summary>
    /// Displays final results and checks completion status
    /// </summary>
    private void DisplayFinalResults()
    {
        Debug.Log("=== FINAL RESULTS ===");
        
        // Check basic completion
        bool arraysComplete = (highestScore > 0 && averageScore > 0);
        bool listsComplete = (totalGames > 2);
        bool transformComplete = (Vector3.Distance(transform.position, startPosition) > 1f);
        
        exercisesComplete = arraysComplete && listsComplete && transformComplete;
        
        Debug.Log($"Highest Test Score: {highestScore}");
        Debug.Log($"Average Test Score: {averageScore:F1}");
        Debug.Log($"Total Favourite Games: {totalGames}");
        Debug.Log($"Current Position: {currentPosition}");
        Debug.Log($"Moved from Start: {Vector3.Distance(currentPosition, startPosition):F1} units");
        Debug.Log($"Basic Exercises Complete: {exercisesComplete}");
        
        if (exercisesComplete)
        {
            Debug.Log("🎉 Excellent work! You've mastered the basics!");
            Debug.Log("💡 Try enabling movement and watch your object move!");
        }
        else
        {
            Debug.Log("❌ Some exercises need completion. Check the TODO sections above.");
        }
        
        Debug.Log("\n📚 WHAT YOU'VE LEARNED:");
        Debug.Log("• How to create and manipulate arrays");
        Debug.Log("• How to work with dynamic Lists");
        Debug.Log("• Unity Transform component for positioning objects");
        Debug.Log("• Basic movement systems using Vector3");
        Debug.Log("• Combining collections with Unity GameObjects");
    }
    
    // TODO BONUS: Create any additional methods you want to experiment with!
    // Ideas: Method to find nearest waypoint, method to create circular positions,
    // method to sort an array, method to remove duplicates from a list
}