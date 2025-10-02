using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Session 06 Student Exercise: Advanced Object-Oriented Programming
/// 
/// LEARNING OBJECTIVES:
/// - Create inheritance hierarchies with base and derived classes
/// - Implement polymorphism with virtual and override methods
/// - Use abstract classes to define contracts
/// - Build practical game systems using advanced OOP concepts
/// 
/// INSTRUCTIONS:
/// 1. Complete all TODO sections in order
/// 2. Test each section before moving to the next
/// 3. Use Debug.Log to verify your implementations
/// 4. Check the Console window for output and errors
/// 5. Use the Inspector checkboxes to test your work
/// </summary>
public class Session06_StudentExercise : MonoBehaviour
{
    [Header("Student Exercise Controls")]
    [SerializeField] private bool testVehicleHierarchy = false;
    [SerializeField] private bool testCharacterClasses = false;
    [SerializeField] private bool testShapeSystem = false;
    [SerializeField] private bool runFinalChallenge = false;
    
    void Start()
    {
        Debug.Log("=== SESSION 06 STUDENT EXERCISE ===");
        Debug.Log("Complete the TODO sections below and test using the checkboxes!");
    }
    
    void Update()
    {
        if (testVehicleHierarchy)
        {
            testVehicleHierarchy = false;
            TestVehicleHierarchy();
        }
        
        if (testCharacterClasses)
        {
            testCharacterClasses = false;
            TestCharacterClasses();
        }
        
        if (testShapeSystem)
        {
            testShapeSystem = false;
            TestShapeSystem();
        }
        
        if (runFinalChallenge)
        {
            runFinalChallenge = false;
            RunFinalChallenge();
        }
    }
    
    #region Exercise 1: Vehicle Inheritance Hierarchy
    
    /// <summary>
    /// Exercise 1: Create a vehicle inheritance system
    /// TODO: Complete the Vehicle base class and derived classes below
    /// </summary>
    private void TestVehicleHierarchy()
    {
        Debug.Log("\n=== EXERCISE 1: VEHICLE HIERARCHY ===");
        
        // TODO 1.1: Create instances of different vehicle types
        // Uncomment these lines when you've completed the classes below:
        
        /*
        Car sportsCar = new Car("Sports Car", 200, 4);
        Motorcycle bike = new Motorcycle("Racing Bike", 180, true);
        Truck deliveryTruck = new Truck("Delivery Truck", 120, 5000);
        
        Debug.Log("--- Vehicle Information ---");
        sportsCar.DisplayInfo();
        bike.DisplayInfo();
        deliveryTruck.DisplayInfo();
        
        Debug.Log("\n--- Vehicle Actions ---");
        sportsCar.StartEngine();
        bike.StartEngine();
        deliveryTruck.StartEngine();
        
        Debug.Log("\n--- Special Actions ---");
        sportsCar.Accelerate();
        bike.Wheelie();
        deliveryTruck.LoadCargo();
        */
        
        Debug.Log("TODO: Uncomment the code above after completing the Vehicle classes!");
    }
    
    #endregion
    
    #region Exercise 2: Character Class System
    
    /// <summary>
    /// Exercise 2: Create a character class system with polymorphism
    /// TODO: Complete the GameCharacter base class and derived classes
    /// </summary>
    private void TestCharacterClasses()
    {
        Debug.Log("\n=== EXERCISE 2: CHARACTER CLASSES ===");
        
        // TODO 2.1: Create instances of different character classes
        // Uncomment when classes are completed:
        
        /*
        List<GameCharacter> party = new List<GameCharacter>
        {
            new Warrior("Thorin", 100, 25),
            new Mage("Gandalf", 80, 35, 120),
            new Archer("Legolas", 90, 20, 50)
        };
        
        Debug.Log("--- Party Formation ---");
        foreach (GameCharacter character in party)
        {
            character.DisplayStats();
        }
        
        Debug.Log("\n--- Combat Round ---");
        foreach (GameCharacter character in party)
        {
            character.Attack(); // Polymorphism in action!
        }
        
        Debug.Log("\n--- Special Abilities ---");
        // TODO 2.2: Add code to test unique methods for each character type
        */
        
        Debug.Log("TODO: Complete the GameCharacter class hierarchy!");
    }
    
    #endregion
    
    #region Exercise 3: Abstract Shape System
    
    /// <summary>
    /// Exercise 3: Create an abstract shape system
    /// TODO: Complete the abstract Shape class and concrete implementations
    /// </summary>
    private void TestShapeSystem()
    {
        Debug.Log("\n=== EXERCISE 3: ABSTRACT SHAPES ===");
        
        // TODO 3.1: Create different shapes and test abstract methods
        // Uncomment when Shape classes are completed:
        
        /*
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5.0f),
            new Rectangle(4.0f, 6.0f),
            new Triangle(3.0f, 4.0f, 5.0f)
        };
        
        Debug.Log("--- Shape Calculations ---");
        foreach (Shape shape in shapes)
        {
            shape.DisplayInfo();
            Debug.Log("Area: " + shape.CalculateArea().ToString("F2"));
            Debug.Log("Perimeter: " + shape.CalculatePerimeter().ToString("F2"));
            Debug.Log(""); // Empty line for readability
        }
        */
        
        Debug.Log("TODO: Complete the abstract Shape class and implementations!");
    }
    
    #endregion
    
    #region Exercise 4: Final Challenge
    
    /// <summary>
    /// Exercise 4: Final Challenge - Comprehensive OOP System
    /// TODO: Create a complete game system combining all concepts
    /// </summary>
    private void RunFinalChallenge()
    {
        Debug.Log("\n=== FINAL CHALLENGE: COMPLETE GAME SYSTEM ===");
        
        // TODO 4.1: Implement a complete RPG battle system
        // This should combine inheritance, polymorphism, and abstract classes
        
        Debug.Log("TODO: Create a comprehensive battle system that demonstrates all OOP concepts!");
        Debug.Log("Suggested features:");
        Debug.Log("- Hero and Enemy hierarchies with different types");
        Debug.Log("- Weapon/Spell system with abstract base classes");
        Debug.Log("- Battle mechanics using polymorphism");
        Debug.Log("- Status effects and special abilities");
    }
    
    #endregion
}

// =============================================================================
// TODO SECTION: COMPLETE THE CLASSES BELOW
// =============================================================================

#region TODO 1: Vehicle Hierarchy

/// <summary>
/// TODO 1.1: Complete the Vehicle base class
/// REQUIREMENTS:
/// - Properties: vehicleName (string), maxSpeed (int)
/// - Constructor that initializes both properties
/// - Virtual StartEngine() method that prints a generic message
/// - DisplayInfo() method that shows vehicle information
/// </summary>
public class Vehicle
{
    // TODO: Add properties for vehicleName and maxSpeed
    
    // TODO: Add constructor that takes name and speed parameters
    
    // TODO: Add virtual StartEngine() method
    
    // TODO: Add DisplayInfo() method
}

/// <summary>
/// TODO 1.2: Complete the Car class that inherits from Vehicle
/// REQUIREMENTS:
/// - Additional property: numberOfDoors (int)
/// - Constructor that calls base constructor
/// - Override StartEngine() with car-specific message
/// - Add Accelerate() method unique to cars
/// </summary>
public class Car : Vehicle
{
    // TODO: Add numberOfDoors property
    
    // TODO: Add constructor that calls base constructor
    
    // TODO: Override StartEngine() method
    
    // TODO: Add Accelerate() method
}

/// <summary>
/// TODO 1.3: Complete the Motorcycle class that inherits from Vehicle
/// REQUIREMENTS:
/// - Additional property: hasSidecar (bool)
/// - Constructor that calls base constructor
/// - Override StartEngine() with motorcycle-specific message
/// - Add Wheelie() method unique to motorcycles
/// </summary>
public class Motorcycle : Vehicle
{
    // TODO: Add hasSidecar property
    
    // TODO: Add constructor that calls base constructor
    
    // TODO: Override StartEngine() method
    
    // TODO: Add Wheelie() method
}

/// <summary>
/// TODO 1.4: Complete the Truck class that inherits from Vehicle
/// REQUIREMENTS:
/// - Additional property: cargoCapacity (int)
/// - Constructor that calls base constructor
/// - Override StartEngine() with truck-specific message
/// - Add LoadCargo() method unique to trucks
/// </summary>
public class Truck : Vehicle
{
    // TODO: Add cargoCapacity property
    
    // TODO: Add constructor that calls base constructor
    
    // TODO: Override StartEngine() method
    
    // TODO: Add LoadCargo() method
}

#endregion

#region TODO 2: Character Class System

/// <summary>
/// TODO 2.1: Complete the GameCharacter base class
/// REQUIREMENTS:
/// - Properties: characterName (string), health (int), damage (int)
/// - Constructor that initializes all properties
/// - Virtual Attack() method that prints basic attack message
/// - DisplayStats() method that shows character information
/// - TakeDamage(int) method that reduces health
/// </summary>
public class GameCharacter
{
    // TODO: Add properties for characterName, health, and damage
    
    // TODO: Add constructor
    
    // TODO: Add virtual Attack() method
    
    // TODO: Add DisplayStats() method
    
    // TODO: Add TakeDamage() method
}

/// <summary>
/// TODO 2.2: Complete the Warrior class
/// REQUIREMENTS:
/// - Inherits from GameCharacter
/// - Constructor that calls base constructor
/// - Override Attack() with warrior-specific combat
/// - Add unique ShieldBlock() method
/// </summary>
public class Warrior : GameCharacter
{
    // TODO: Add constructor
    
    // TODO: Override Attack() method
    
    // TODO: Add ShieldBlock() method
}

/// <summary>
/// TODO 2.3: Complete the Mage class
/// REQUIREMENTS:
/// - Inherits from GameCharacter
/// - Additional property: mana (int)
/// - Constructor that calls base constructor and sets mana
/// - Override Attack() with spell-casting (check mana)
/// - Add unique CastSpell() method
/// </summary>
public class Mage : GameCharacter
{
    // TODO: Add mana property
    
    // TODO: Add constructor
    
    // TODO: Override Attack() method (check mana)
    
    // TODO: Add CastSpell() method
}

/// <summary>
/// TODO 2.4: Complete the Archer class
/// REQUIREMENTS:
/// - Inherits from GameCharacter
/// - Additional property: arrowCount (int)
/// - Constructor that calls base constructor and sets arrows
/// - Override Attack() with bow shooting (check arrows)
/// - Add unique AimShot() method for critical hits
/// </summary>
public class Archer : GameCharacter
{
    // TODO: Add arrowCount property
    
    // TODO: Add constructor
    
    // TODO: Override Attack() method (check arrows)
    
    // TODO: Add AimShot() method
}

#endregion

#region TODO 3: Abstract Shape System

/// <summary>
/// TODO 3.1: Complete the abstract Shape class
/// REQUIREMENTS:
/// - Abstract class (cannot be instantiated)
/// - Property: shapeName (string)
/// - Constructor that sets shapeName
/// - Abstract method: CalculateArea() returns float
/// - Abstract method: CalculatePerimeter() returns float
/// - Regular method: DisplayInfo() that prints shape name
/// </summary>
public abstract class Shape
{
    // TODO: Add shapeName property
    
    // TODO: Add constructor
    
    // TODO: Add abstract CalculateArea() method
    
    // TODO: Add abstract CalculatePerimeter() method
    
    // TODO: Add DisplayInfo() method
}

/// <summary>
/// TODO 3.2: Complete the Circle class
/// REQUIREMENTS:
/// - Inherits from Shape
/// - Property: radius (float)
/// - Constructor that sets radius and calls base with "Circle"
/// - Implement CalculateArea(): π × radius²
/// - Implement CalculatePerimeter(): 2 × π × radius
/// Use Mathf.PI for π value
/// </summary>
public class Circle : Shape
{
    // TODO: Add radius property
    
    // TODO: Add constructor
    
    // TODO: Implement CalculateArea()
    
    // TODO: Implement CalculatePerimeter()
}

/// <summary>
/// TODO 3.3: Complete the Rectangle class
/// REQUIREMENTS:
/// - Inherits from Shape
/// - Properties: width (float), height (float)
/// - Constructor that sets dimensions and calls base with "Rectangle"
/// - Implement CalculateArea(): width × height
/// - Implement CalculatePerimeter(): 2 × (width + height)
/// </summary>
public class Rectangle : Shape
{
    // TODO: Add width and height properties
    
    // TODO: Add constructor
    
    // TODO: Implement CalculateArea()
    
    // TODO: Implement CalculatePerimeter()
}

/// <summary>
/// TODO 3.4: Complete the Triangle class
/// REQUIREMENTS:
/// - Inherits from Shape
/// - Properties: sideA, sideB, sideC (float)
/// - Constructor that sets all sides and calls base with "Triangle"
/// - Implement CalculateArea(): Use Heron's formula
/// - Implement CalculatePerimeter(): sideA + sideB + sideC
/// 
/// Heron's formula: Area = √(s(s-a)(s-b)(s-c)) where s = perimeter/2
/// Use Mathf.Sqrt() for square root
/// </summary>
public class Triangle : Shape
{
    // TODO: Add sideA, sideB, sideC properties
    
    // TODO: Add constructor
    
    // TODO: Implement CalculateArea() using Heron's formula
    
    // TODO: Implement CalculatePerimeter()
}

#endregion

// =============================================================================
// COMPLETION CHECKLIST:
// =============================================================================
/*
EXERCISE 1 - VEHICLE HIERARCHY:
□ Vehicle base class with properties and methods
□ Car class inherits from Vehicle with override and unique methods
□ Motorcycle class inherits from Vehicle with override and unique methods  
□ Truck class inherits from Vehicle with override and unique methods
□ Test by checking "Test Vehicle Hierarchy" in Inspector

EXERCISE 2 - CHARACTER CLASSES:
□ GameCharacter base class with combat system
□ Warrior class with shield blocking ability
□ Mage class with mana system for spells
□ Archer class with arrow management
□ Test by checking "Test Character Classes" in Inspector

EXERCISE 3 - ABSTRACT SHAPES:
□ Abstract Shape class with abstract methods
□ Circle class implementing area and perimeter calculations
□ Rectangle class implementing area and perimeter calculations
□ Triangle class implementing area and perimeter with Heron's formula
□ Test by checking "Test Shape System" in Inspector

EXERCISE 4 - FINAL CHALLENGE:
□ Design comprehensive game system combining all concepts
□ Use inheritance for different entity types
□ Use polymorphism for varied behaviours
□ Use abstract classes for enforcing implementations
□ Test by checking "Run Final Challenge" in Inspector

ADVANCED CHALLENGE (OPTIONAL):
□ Add interface implementations (preview of Session 07)
□ Create complex battle system with status effects
□ Implement factory pattern for creating objects
□ Add serialization for saving/loading game data
*/