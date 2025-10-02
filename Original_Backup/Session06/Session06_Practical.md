# Session 06: Advanced Object-Oriented Programming

## 🎯 **Learning Objectives**

By the end of this session, you will understand:
- **Inheritance** - Creating specialised classes from base classes
- **Polymorphism** - Same interface, different implementations
- **Virtual and Override Methods** - Customisable behaviour in child classes
- **Abstract Classes** - Defining contracts that must be implemented
- **Method Overriding** - Replacing parent class functionality
- **Advanced Game Hierarchies** - Professional game development patterns

## 📋 **Session Overview**

This session builds directly upon Session 05's OOP fundamentals. You'll learn how to create sophisticated class hierarchies that mirror real game development practices, such as having a base `Enemy` class with specialised implementations like `Zombie`, `Robot`, and `Wizard`.

### **What You'll Build:**
- A complete enemy hierarchy system with different types of enemies
- A weapon system with various weapon behaviours
- A character progression system with different character classes
- Interactive demonstrations showing polymorphism in action

## 🔧 **Unity Setup Instructions**

### **Step 1: Scene Preparation**
1. **Create a new scene**: `File > New Scene > 2D (URP)`
2. **Save the scene**: `File > Save As` → `Session06_AdvancedOOP`
3. **Save location**: `Assets/_Game/Scenes/Session06_AdvancedOOP.unity`

### **Step 2: GameObjects Setup**
1. **Create empty GameObjects** for each script:
   - Right-click in Hierarchy → `Create Empty`
   - Name them: `InheritanceDemo`, `PolymorphismDemo`, `AbstractClassDemo`, `StudentExercise`

2. **Attach scripts** (we'll create these next):
   - `InheritanceDemo` ← `InheritanceBasics.cs`
   - `PolymorphismDemo` ← `PolymorphismExample.cs`
   - `AbstractClassDemo` ← `AbstractClassDemo.cs`
   - `StudentExercise` ← `Session06_StudentExercise.cs`

## 📖 **Core Concepts Explained**

### **🏗️ Inheritance Hierarchy**

Think of inheritance like a family tree of classes:

```csharp
// Parent class (base class)
public class Enemy
{
    public string enemyName;
    public int health;
    public int damage;
    
    public virtual void Attack() // virtual = can be overridden
    {
        Debug.Log(enemyName + " attacks for " + damage + " damage!");
    }
}

// Child classes (derived classes)
public class Zombie : Enemy  // Zombie inherits from Enemy
{
    public override void Attack() // override = replace parent behaviour
    {
        Debug.Log(enemyName + " shambles forward and bites for " + damage + " damage!");
    }
}

public class Robot : Enemy
{
    public override void Attack()
    {
        Debug.Log(enemyName + " fires laser beams for " + damage + " damage!");
    }
}
```

**Key Points:**
- `Zombie` **inherits** all properties (`enemyName`, `health`, `damage`) from `Enemy`
- `Zombie` **overrides** the `Attack()` method with specialised behaviour
- `virtual` methods in parent class **can be** overridden
- `override` methods in child class **replace** parent functionality

### **🎭 Polymorphism in Action**

Polymorphism means "many forms" - same method name, different behaviours:

```csharp
// Create different enemy types
Enemy zombie = new Zombie();
Enemy robot = new Robot();

// Same method call, different behaviour!
zombie.Attack(); // Output: "shambles forward and bites..."
robot.Attack();  // Output: "fires laser beams..."
```

### **📐 Abstract Classes**

Abstract classes define a template that **must** be implemented by child classes:

```csharp
public abstract class Weapon  // abstract = cannot be instantiated directly
{
    public string weaponName;
    public int damage;
    
    // Abstract method = MUST be implemented by child classes
    public abstract void UseWeapon();
    
    // Regular method = inherited by all child classes
    public void DisplayInfo()
    {
        Debug.Log("Weapon: " + weaponName + " | Damage: " + damage);
    }
}

public class Sword : Weapon
{
    public override void UseWeapon() // MUST implement this
    {
        Debug.Log("Swings " + weaponName + " for " + damage + " slashing damage!");
    }
}
```

## 💻 **Practical Implementation**

### **Example 1: Enemy Inheritance System**

Create `InheritanceBasics.cs`:

```csharp
using UnityEngine;

/// <summary>
/// Demonstrates inheritance with a complete enemy hierarchy system.
/// Shows how child classes inherit properties and methods from parent classes.
/// </summary>
public class InheritanceBasics : MonoBehaviour
{
    [Header("Enemy Hierarchy Demonstration")]
    [SerializeField] private bool testInheritance = false;
    
    void Start()
    {
        Debug.Log("=== INHERITANCE BASICS DEMONSTRATION ===");
        DemonstrateInheritance();
    }
    
    void Update()
    {
        if (testInheritance)
        {
            testInheritance = false;
            DemonstrateInheritance();
        }
    }
    
    private void DemonstrateInheritance()
    {
        Debug.Log("\n--- Creating Different Enemy Types ---");
        
        // Create different types of enemies
        Zombie zombie = new Zombie("Undead Walker", 50, 15);
        Robot robot = new Robot("Battle Droid", 80, 25);
        Wizard wizard = new Wizard("Dark Mage", 60, 30, 100);
        
        // All enemies can attack, but each has unique behaviour
        zombie.Attack();
        robot.Attack();
        wizard.Attack();
        
        // All enemies inherit the same basic methods
        Debug.Log("\n--- Shared Inherited Methods ---");
        zombie.TakeDamage(20);
        robot.TakeDamage(30);
        wizard.TakeDamage(25);
        
        // But each can have unique methods too
        Debug.Log("\n--- Unique Methods ---");
        zombie.Shamble();
        robot.ScanForTargets();
        wizard.CastSpell();
    }
}

/// <summary>
/// Base Enemy class - parent for all enemy types
/// </summary>
public class Enemy
{
    public string enemyName;
    public int health;
    public int damage;
    
    // Constructor
    public Enemy(string name, int hp, int dmg)
    {
        enemyName = name;
        health = hp;
        damage = dmg;
        Debug.Log("Created enemy: " + enemyName + " (HP: " + health + ", DMG: " + damage + ")");
    }
    
    // Virtual method - can be overridden by child classes
    public virtual void Attack()
    {
        Debug.Log(enemyName + " performs a basic attack for " + damage + " damage!");
    }
    
    // Regular method - inherited by all child classes
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log(enemyName + " takes " + damageAmount + " damage! HP: " + health);
        
        if (health <= 0)
        {
            Debug.Log(enemyName + " has been defeated!");
        }
    }
}

/// <summary>
/// Zombie class - inherits from Enemy
/// </summary>
public class Zombie : Enemy
{
    // Constructor - calls parent constructor
    public Zombie(string name, int hp, int dmg) : base(name, hp, dmg)
    {
        // Zombie-specific initialization can go here
    }
    
    // Override the Attack method with zombie-specific behaviour
    public override void Attack()
    {
        Debug.Log(enemyName + " shambles forward and bites for " + damage + " damage! *GROAN*");
    }
    
    // Unique zombie method
    public void Shamble()
    {
        Debug.Log(enemyName + " shambles slowly towards its target...");
    }
}

/// <summary>
/// Robot class - inherits from Enemy
/// </summary>
public class Robot : Enemy
{
    public Robot(string name, int hp, int dmg) : base(name, hp, dmg)
    {
    }
    
    public override void Attack()
    {
        Debug.Log(enemyName + " fires high-energy laser beams for " + damage + " damage! *ZAP*");
    }
    
    public void ScanForTargets()
    {
        Debug.Log(enemyName + " activates target scanning protocols... BEEP BEEP");
    }
}

/// <summary>
/// Wizard class - inherits from Enemy with additional magic properties
/// </summary>
public class Wizard : Enemy
{
    public int mana;
    
    public Wizard(string name, int hp, int dmg, int mp) : base(name, hp, dmg)
    {
        mana = mp;
        Debug.Log("Wizard " + enemyName + " has " + mana + " mana points!");
    }
    
    public override void Attack()
    {
        if (mana >= 20)
        {
            mana -= 20;
            Debug.Log(enemyName + " casts a magic missile for " + damage + " damage! *SPARKLE* (Mana: " + mana + ")");
        }
        else
        {
            Debug.Log(enemyName + " is out of mana and strikes with staff for " + (damage / 2) + " damage!");
        }
    }
    
    public void CastSpell()
    {
        if (mana >= 30)
        {
            mana -= 30;
            Debug.Log(enemyName + " casts a powerful spell! The air crackles with magic! (Mana: " + mana + ")");
        }
        else
        {
            Debug.Log(enemyName + " cannot cast spell - insufficient mana (" + mana + "/30)");
        }
    }
}
```

### **Example 2: Polymorphism Demonstration**

Create `PolymorphismExample.cs`:

```csharp
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Demonstrates polymorphism - same interface, different implementations.
/// Shows how the same method call can produce different behaviour.
/// </summary>
public class PolymorphismExample : MonoBehaviour
{
    [Header("Polymorphism Demonstration")]
    [SerializeField] private bool testPolymorphism = false;
    [SerializeField] private bool battleSimulation = false;
    
    void Start()
    {
        Debug.Log("=== POLYMORPHISM DEMONSTRATION ===");
        DemonstratePolymorphism();
    }
    
    void Update()
    {
        if (testPolymorphism)
        {
            testPolymorphism = false;
            DemonstratePolymorphism();
        }
        
        if (battleSimulation)
        {
            battleSimulation = false;
            RunBattleSimulation();
        }
    }
    
    private void DemonstratePolymorphism()
    {
        Debug.Log("\n--- Polymorphism: Same Method, Different Behaviour ---");
        
        // Create a list of enemies - all different types, but treated the same
        List<Enemy> enemyArmy = new List<Enemy>
        {
            new Zombie("Zombie Brute", 60, 18),
            new Robot("War Machine", 90, 28),
            new Wizard("Necromancer", 70, 35, 120),
            new Zombie("Zombie Runner", 40, 12),
            new Robot("Scout Bot", 50, 15)
        };
        
        // Polymorphism in action - same method call, different behaviour for each
        Debug.Log("\n--- All Enemies Attack (Polymorphism) ---");
        foreach (Enemy enemy in enemyArmy)
        {
            enemy.Attack(); // Each enemy attacks differently!
        }
        
        // Same with taking damage
        Debug.Log("\n--- All Enemies Take Damage (Shared Behaviour) ---");
        foreach (Enemy enemy in enemyArmy)
        {
            enemy.TakeDamage(10); // Same method, same behaviour
        }
    }
    
    private void RunBattleSimulation()
    {
        Debug.Log("\n=== BATTLE SIMULATION ===");
        
        // Create two opposing forces
        List<Enemy> playerTeam = new List<Enemy>
        {
            new Robot("Ally Bot", 80, 25),
            new Wizard("Battle Mage", 60, 30, 100)
        };
        
        List<Enemy> enemyTeam = new List<Enemy>
        {
            new Zombie("Undead Warrior", 70, 20),
            new Robot("Enemy Droid", 75, 22)
        };
        
        Debug.Log("--- Round 1: Player Team Attacks ---");
        foreach (Enemy ally in playerTeam)
        {
            ally.Attack();
        }
        
        Debug.Log("\n--- Round 1: Enemy Counter-Attack ---");
        foreach (Enemy enemy in enemyTeam)
        {
            enemy.Attack();
        }
        
        Debug.Log("\n--- Battle Results: Everyone Takes Damage ---");
        foreach (Enemy ally in playerTeam)
        {
            ally.TakeDamage(20);
        }
        foreach (Enemy enemy in enemyTeam)
        {
            enemy.TakeDamage(25);
        }
    }
}
```

## 🎮 **Interactive Testing**

### **In Unity Editor:**
1. **Press Play** to see automatic demonstrations
2. **Check the Console** (`Window > General > Console`) for detailed output
3. **Use Inspector checkboxes** to trigger demonstrations:
   - `Test Inheritance` - Shows how different enemies inherit and override methods
   - `Test Polymorphism` - Shows same method calls producing different behaviour
   - `Battle Simulation` - Interactive battle using polymorphism

### **Key Things to Notice:**
- **Same method names** (`Attack()`) produce **different output** for each enemy type
- **Inherited properties** (`health`, `damage`) work the same for all enemies
- **Constructor chaining** with `: base()` calls parent constructor
- **Method overriding** with `virtual` and `override` keywords

## 🔍 **Common Mistakes & Troubleshooting**

### **Inheritance Issues:**
- **Error**: "Does not contain a constructor that takes X arguments"
  - **Solution**: Use `: base(parameters)` in child constructor
- **Error**: "Cannot override because method is not virtual"
  - **Solution**: Add `virtual` to parent method, `override` to child method

### **Polymorphism Issues:**
- **Problem**: All enemies behave the same
  - **Solution**: Make sure you're using `override` in child classes
- **Problem**: Cannot add different enemy types to same list
  - **Solution**: Use `List<Enemy>` (parent type) not `List<Zombie>`

### **Testing Tips:**
- **Use Debug.Log extensively** to see what's happening
- **Check Console for errors** - red messages need fixing
- **Test one concept at a time** - don't try everything at once

## 🏆 **Next Steps**

After completing this session:
1. **Understand inheritance hierarchy** - parent/child relationships
2. **Recognise polymorphism** - same interface, different implementations
3. **Use virtual/override effectively** - customising behaviour in child classes
4. **Ready for Session 07** - Interfaces and Advanced Management Systems

## 📚 **Professional Development Notes**

This session teaches concepts used in **all professional game engines**:
- **Unity**: Component inheritance, MonoBehaviour hierarchy
- **Unreal**: Blueprint inheritance, C++ class hierarchies  
- **Godot**: Node inheritance, script inheritance
- **Game Industry**: Core OOP design patterns used everywhere

Understanding inheritance and polymorphism is **essential** for:
- Creating flexible, maintainable code
- Working with existing game engine frameworks
- Building scalable game systems
- Collaborating with other developers

---

**🎓 Ready to Practice?** Open `Session06_StudentExercise.cs` and complete the TODO sections!

**Next Session Preview**: Session 07 will cover Interfaces, Switch Statements, and Game State Management - the final pieces for creating complete game systems.

---

*Session 06 - Advanced Object-Oriented Programming*  
*CRE132 Game Development Fundamentals*  
*Northern Irish University - AI and Games Department*