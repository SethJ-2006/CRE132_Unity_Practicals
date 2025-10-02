using UnityEngine;

/// <summary>
/// Demonstrates all mathematical operators in C# and Unity
/// This script shows arithmetic operations, assignment operators, and practical calculations
/// </summary>
public class MathOperators : MonoBehaviour
{
    [Header("=== BASIC NUMBERS FOR CALCULATIONS ===")]
    public float numberA = 15f;
    public float numberB = 4f;
    public int scoreA = 1250;
    public int scoreB = 300;
    
    [Header("=== GAME STATISTICS ===")]
    public int playerHealth = 100;
    public int damageDealt = 25;
    public float movementSpeed = 5.5f;
    public float speedMultiplier = 1.8f;
    
    [Header("=== CALCULATION RESULTS (READ-ONLY) ===")]
    [SerializeField] private float additionResult;
    [SerializeField] private float subtractionResult;
    [SerializeField] private float multiplicationResult;
    [SerializeField] private float divisionResult;
    [SerializeField] private int moduloResult;
    
    void Start()
    {
        Debug.Log("=== MATH OPERATORS DEMONSTRATION ===");
        Debug.Log("Starting calculations with numberA=" + numberA + " and numberB=" + numberB);
        
        // Perform all mathematical operations
        DemonstrateBasicOperators();
        DemonstrateAssignmentOperators();
        DemonstratePracticalExamples();
        DemonstrateModuloOperator();
    }
    
    void Update()
    {
        // Update calculations every frame so Inspector shows live results
        PerformLiveCalculations();
    }
    
    /// <summary>
    /// Shows the five basic mathematical operators
    /// </summary>
    void DemonstrateBasicOperators()
    {
        Debug.Log("\n--- BASIC MATHEMATICAL OPERATORS ---");
        
        // Addition
        additionResult = numberA + numberB;
        Debug.Log($"Addition: {numberA} + {numberB} = {additionResult}");
        
        // Subtraction
        subtractionResult = numberA - numberB;
        Debug.Log($"Subtraction: {numberA} - {numberB} = {subtractionResult}");
        
        // Multiplication
        multiplicationResult = numberA * numberB;
        Debug.Log($"Multiplication: {numberA} * {numberB} = {multiplicationResult}");
        
        // Division (with safety check)
        if (numberB != 0)
        {
            divisionResult = numberA / numberB;
            Debug.Log($"Division: {numberA} / {numberB} = {divisionResult}");
        }
        else
        {
            Debug.Log("Cannot divide by zero!");
        }
        
        // Modulo (remainder)
        int wholeA = Mathf.RoundToInt(numberA);  // Convert to int for modulo
        int wholeB = Mathf.RoundToInt(numberB);
        if (wholeB != 0)
        {
            moduloResult = wholeA % wholeB;
            Debug.Log($"Modulo: {wholeA} % {wholeB} = {moduloResult}");
        }
    }
    
    /// <summary>
    /// Shows assignment operators (+=, -=, *=, /=)
    /// </summary>
    void DemonstrateAssignmentOperators()
    {
        Debug.Log("\n--- ASSIGNMENT OPERATORS ---");
        
        int testValue = 100;
        Debug.Log("Starting with testValue = " + testValue);
        
        // Add and assign
        testValue += 50;  // Same as: testValue = testValue + 50;
        Debug.Log("After += 50: testValue = " + testValue);
        
        // Subtract and assign
        testValue -= 30;  // Same as: testValue = testValue - 30;
        Debug.Log("After -= 30: testValue = " + testValue);
        
        // Multiply and assign
        testValue *= 2;   // Same as: testValue = testValue * 2;
        Debug.Log("After *= 2: testValue = " + testValue);
        
        // Divide and assign
        testValue /= 4;   // Same as: testValue = testValue / 4;
        Debug.Log("After /= 4: testValue = " + testValue);
    }
    
    /// <summary>
    /// Shows practical game development calculations
    /// </summary>
    void DemonstratePracticalExamples()
    {
        Debug.Log("\n--- PRACTICAL GAME CALCULATIONS ---");
        
        // Health calculations
        int currentHealth = playerHealth;
        currentHealth -= damageDealt;
        Debug.Log($"Player took {damageDealt} damage. Health: {playerHealth} -> {currentHealth}");
        
        // Speed calculations
        float boostedSpeed = movementSpeed * speedMultiplier;
        Debug.Log($"Speed boost applied: {movementSpeed} * {speedMultiplier} = {boostedSpeed}");
        
        // Score calculations
        int totalScore = scoreA + scoreB;
        int scoreDifference = scoreA - scoreB;
        Debug.Log($"Total score: {scoreA} + {scoreB} = {totalScore}");
        Debug.Log($"Score difference: {scoreA} - {scoreB} = {scoreDifference}");
        
        // Percentage calculations
        float healthPercentage = (currentHealth / (float)playerHealth) * 100f;
        Debug.Log($"Health percentage: {healthPercentage:F1}%");
    }
    
    /// <summary>
    /// Demonstrates the modulo operator with practical examples
    /// </summary>
    void DemonstrateModuloOperator()
    {
        Debug.Log("\n--- MODULO OPERATOR EXAMPLES ---");
        
        // Even/odd checking
        for (int i = 1; i <= 5; i++)
        {
            int remainder = i % 2;
            string evenOdd = (remainder == 0) ? "even" : "odd";
            Debug.Log($"{i} % 2 = {remainder} -> {i} is {evenOdd}");
        }
        
        // Wrapping numbers (useful for cycling through options)
        Debug.Log("\nCycling through 4 options using modulo:");
        for (int i = 0; i < 10; i++)
        {
            int wrappedValue = i % 4;  // Always gives 0, 1, 2, or 3
            Debug.Log($"Option {i} wraps to: {wrappedValue}");
        }
    }
    
    /// <summary>
    /// Updates calculations in real-time for Inspector display
    /// </summary>
    void PerformLiveCalculations()
    {
        // Update results so they show in Inspector
        additionResult = numberA + numberB;
        subtractionResult = numberA - numberB;
        multiplicationResult = numberA * numberB;
        
        if (numberB != 0)
        {
            divisionResult = numberA / numberB;
        }
        
        int wholeA = Mathf.RoundToInt(numberA);
        int wholeB = Mathf.RoundToInt(numberB);
        if (wholeB != 0)
        {
            moduloResult = wholeA % wholeB;
        }
    }
}
