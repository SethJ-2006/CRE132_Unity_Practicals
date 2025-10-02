using UnityEngine;

/// <summary>
/// Session 06A Student Exercise: Inheritance & Virtual Methods
/// 
/// LEARNING OBJECTIVES:
/// - Create inheritance hierarchies with base and derived classes
/// - Use virtual methods and override keyword
/// - Understand is-a relationships in OOP
/// - Apply inheritance to practical game scenarios
/// 
/// INSTRUCTIONS:
/// 1. Complete all TODO sections in order
/// 2. Test each section using the Inspector checkboxes
/// 3. Use Debug.Log to verify your implementations
/// 4. Master inheritance before moving to Session 06B
/// </summary>
public class Session06A_StudentExercise : MonoBehaviour
{
    [Header("=== EXERCISE TESTING ===")]
    [SerializeField] private bool testVehicleHierarchy = false;
    [SerializeField] private bool testCharacterBasics = false;
    [SerializeField] private bool testVirtualMethods = false;
    [SerializeField] private bool runInheritanceChallenge = false;
    
    [Header("=== EXERCISE VALIDATION ===")]
    [SerializeField] private bool runValidation = false;
    
    void Start()
    {
        Debug.Log("=== SESSION 06A: INHERITANCE & VIRTUAL METHODS ===");
        Debug.Log("Complete the TODO sections below and test using the checkboxes!");
        Debug.Log("This session focuses on INHERITANCE - Session 06B will cover abstract classes.\n");
    }
    
    void Update()
    {
        if (testVehicleHierarchy)
        {
            testVehicleHierarchy = false;
            TestVehicleHierarchy();
        }
        
        if (testCharacterBasics)
        {
            testCharacterBasics = false;
            TestCharacterBasics();
        }
        
        if (testVirtualMethods)
        {
            testVirtualMethods = false;
            TestVirtualMethods();
        }
        
        if (runInheritanceChallenge)
        {
            runInheritanceChallenge = false;
            RunInheritanceChallenge();
        }
        
        if (runValidation)
        {
            runValidation = false;
            ValidateExercise();
        }
    }
    
    #region Exercise 1: Vehicle Inheritance Hierarchy
    
    /// <summary>
    /// Exercise 1: Create a simple vehicle inheritance system
    /// Focus: Basic inheritance syntax and relationships
    /// </summary>
    private void TestVehicleHierarchy()
    {
        Debug.Log("\n=== EXERCISE 1: VEHICLE INHERITANCE ===");
        
        // TODO 1.1: Create instances of different vehicle types
        // GOAL: Practice creating objects from inherited classes
        // Uncomment these lines when you've completed the Vehicle classes below:
        
        /*
        Car myCar = new Car("Honda Civic", 150);
        Motorcycle myBike = new Motorcycle("Harley Davidson", 120);
        
        Debug.Log("--- Vehicle Information ---");
        myCar.DisplayInfo();
        myBike.DisplayInfo();
        
        Debug.Log("\n--- Vehicle Actions ---");
        myCar.StartEngine();
        myBike.StartEngine();
        */
        
        Debug.Log("TODO: Complete the Vehicle classes below, then uncomment the test code!");
    }
    
    #endregion
    
    #region Exercise 2: Character Basics (Simplified)
    
    /// <summary>
    /// Exercise 2: Create basic character classes with inheritance
    /// Focus: Constructor inheritance and basic overrides
    /// </summary>
    private void TestCharacterBasics()
    {
        Debug.Log("\n=== EXERCISE 2: CHARACTER BASICS ===");
        
        // TODO 2.1: Create simple character instances
        // GOAL: Practice inheritance with constructors
        // Uncomment when Character classes are completed:
        
        /*
        Warrior knight = new Warrior("Sir Lancelot", 100);
        Mage wizard = new Mage("Merlin", 80);
        
        Debug.Log("--- Character Information ---");
        knight.DisplayInfo();
        wizard.DisplayInfo();
        
        Debug.Log("\n--- Basic Actions ---");
        knight.Attack();
        wizard.Attack();
        */
        
        Debug.Log("TODO: Complete the Character classes below!");
    }
    
    #endregion
    
    #region Exercise 3: Virtual Methods Practice
    
    /// <summary>
    /// Exercise 3: Practice with virtual and override methods
    /// Focus: Understanding method overriding behavior
    /// </summary>
    private void TestVirtualMethods()
    {
        Debug.Log("\n=== EXERCISE 3: VIRTUAL METHODS ===");
        
        // TODO 3.1: Test virtual method behavior
        // GOAL: See how override changes method behavior
        // Uncomment when virtual methods are implemented:
        
        /*
        Animal genericAnimal = new Animal("Generic");
        Dog myDog = new Dog("Buddy");
        Cat myCat = new Cat("Whiskers");
        
        Debug.Log("--- Virtual Method Demonstration ---");
        genericAnimal.MakeSound();
        myDog.MakeSound();
        myCat.MakeSound();
        
        // Polymorphism preview - all are Animals but behave differently
        Animal[] pets = { genericAnimal, myDog, myCat };
        Debug.Log("\n--- Polymorphism Preview ---");
        foreach (Animal pet in pets)
        {
            pet.MakeSound(); // Each calls their own override!
        }
        */
        
        Debug.Log("TODO: Complete the Animal class system with virtual methods!");
    }
    
    #endregion
    
    #region Exercise 4: Inheritance Challenge
    
    /// <summary>
    /// Exercise 4: Create your own inheritance system
    /// Focus: Applying inheritance to a practical game scenario
    /// </summary>
    private void RunInheritanceChallenge()
    {
        Debug.Log("\n=== EXERCISE 4: INHERITANCE CHALLENGE ===");
        
        Debug.Log("TODO: Create your own weapon inheritance system!");
        Debug.Log("Requirements:");
        Debug.Log("1. Base class: Weapon (name, damage, virtual Attack method)");
        Debug.Log("2. Derived classes: Sword, Bow, Staff");
        Debug.Log("3. Each weapon should override Attack() with unique behavior");
        Debug.Log("4. Test all three weapon types");
        Debug.Log("\nThis demonstrates inheritance, virtual methods, and polymorphism basics!");
    }
    
    #endregion
    
    #region Exercise Validation System
    
    [ContextMenu("Validate My Work")]
    public void ValidateExercise()
    {
        Debug.Log("=== SESSION 06A VALIDATION ===");
        int completedTasks = 0;
        int totalTasks = 4;
        
        // Basic validation checks
        if (CheckInheritanceStructure())
        {
            Debug.Log("✓ Inheritance structure looks good");
            completedTasks++;
        }
        else
        {
            Debug.LogWarning("❌ Inheritance classes need work");
        }
        
        // Display final score
        float percentage = (float)completedTasks / totalTasks * 100f;
        Debug.Log($"Exercise completion: {completedTasks}/{totalTasks} ({percentage:F0}%)");
        
        if (percentage >= 80f)
            Debug.Log("🎉 Excellent! Ready for Session 06B (Abstract Classes)!");
        else if (percentage >= 60f)
            Debug.Log("👍 Good progress! Complete the remaining exercises.");
        else
            Debug.Log("📚 Keep working on the inheritance concepts!");
    }
    
    private bool CheckInheritanceStructure()
    {
        // Students should implement actual validation logic here
        return true; // Placeholder
    }
    
    #endregion
}

#region TODO: Complete These Class Definitions

// TODO 1.2: Create the Vehicle base class
// GOAL: Create a simple base class that other vehicles can inherit from
// NEEDED: 
// - Base class called "Vehicle"
// - Properties: string name, int maxSpeed
// - Constructor that takes name and maxSpeed
// - Virtual method: void StartEngine() - prints "Starting [name] engine..."
// - Method: void DisplayInfo() - prints name and max speed

// EXAMPLE:
/*
public class Vehicle
{
    protected string name;
    protected int maxSpeed;
    
    public Vehicle(string vehicleName, int speed)
    {
        name = vehicleName;
        maxSpeed = speed;
    }
    
    public virtual void StartEngine()
    {
        Debug.Log($"Starting {name} engine...");
    }
    
    public void DisplayInfo()
    {
        Debug.Log($"Vehicle: {name}, Max Speed: {maxSpeed} mph");
    }
}
*/

// TODO 1.3: Create the Car class that inherits from Vehicle
// GOAL: Practice basic inheritance syntax
// NEEDED:
// - Car class inherits from Vehicle
// - Constructor that calls base constructor
// - Override StartEngine() to print something car-specific

// TODO 1.4: Create the Motorcycle class that inherits from Vehicle
// GOAL: Practice inheritance with different derived class
// NEEDED:
// - Motorcycle class inherits from Vehicle  
// - Constructor that calls base constructor
// - Override StartEngine() to print something motorcycle-specific

// TODO 2.2: Create simple Character class system
// GOAL: Practice inheritance with different domain (game characters)
// NEEDED:
// - Base class "Character" with name, health
// - Derived classes "Warrior" and "Mage"
// - Virtual Attack() method that each class overrides differently

// TODO 3.2: Create Animal class system for virtual method practice  
// GOAL: Clear demonstration of virtual and override keywords
// NEEDED:
// - Base class "Animal" with virtual MakeSound() method
// - Derived classes "Dog" and "Cat" that override MakeSound()
// - Show how same method call produces different results

#endregion