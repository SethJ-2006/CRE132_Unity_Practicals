# Session 05: Object-Oriented Programming (OOP) Basics

## 🎯 **Learning Objectives**

By the end of this session, you will understand:
- **Classes and Objects**: Creating blueprints and instances for game entities
- **Constructors**: Initialising objects with specific starting values
- **Access Modifiers**: Controlling what parts of your code can access class members
- **Instance vs Static**: Understanding when data belongs to objects vs the class itself
- **Practical Applications**: Creating reusable game components and systems

## 🧱 **What is Object-Oriented Programming?**

Think of OOP like designing cars:
- **Class**: The blueprint/design for a car (defines what all cars have)
- **Object**: An actual car built from that blueprint (your specific Honda, my Toyota)
- **Properties**: Things cars have (colour, speed, fuel level)
- **Methods**: Things cars can do (start, accelerate, brake)

In Unity, **everything is an object**! GameObjects, Transform components, your scripts - they're all objects created from classes.

## 🚀 **Unity Setup**

### **Create a New Scene:**
1. **File > New Scene > 2D (URP)**
2. **Save as**: `Session05_OOP_Scene`
3. **Add to Build Settings** if prompted

### **Prepare GameObjects:**
1. **Create empty GameObjects** for testing:
   - `Player GameObject` (Rename empty GameObject)
   - `Enemy GameObject` (Create another empty)
   - `Weapon System` (Create a third empty)

### **Console Window:**
- Open **Window > General > Console**
- Click **Clear on Play** for clean testing
- Keep this open throughout the session

## 📚 **Core OOP Concepts**

### **1. Classes and Objects**

A **class** is a blueprint that defines:
- **Fields** (variables/data)
- **Properties** (controlled access to data)  
- **Methods** (functions/behaviour)
- **Constructors** (initialisation logic)

```csharp
// Class = Blueprint
public class Player 
{
    // Fields = Data the class stores
    public string playerName;
    public int health;
    public float speed;
    
    // Constructor = How to create the object
    public Player(string name, int startingHealth)
    {
        playerName = name;
        health = startingHealth;
        speed = 5.0f;
    }
    
    // Methods = What the object can do
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(playerName + " now has " + health + " health");
    }
}
```

```csharp
// Creating Objects = Using the blueprint
Player hero = new Player("Link", 100);     // Object 1
Player villain = new Player("Ganon", 200); // Object 2

// Each object has its own data
hero.TakeDamage(30);     // Link now has 70 health
villain.TakeDamage(50);  // Ganon now has 150 health
```

### **2. Access Modifiers**

Control **who can access** your class members:

```csharp
public class BankAccount
{
    public string accountName;      // Anyone can read/change
    private float balance;          // Only this class can access
    protected int accountNumber;    // This class and derived classes
    
    // Public method to safely access private data
    public float GetBalance()
    {
        return balance;  // Only this class can access balance directly
    }
    
    public void Deposit(float amount)
    {
        if (amount > 0)
            balance += amount;  // Safe deposit
    }
}
```

**Why Use Private?**
- **Security**: Prevent invalid values
- **Flexibility**: Change internal code without breaking other scripts
- **Debugging**: Control exactly how data is modified

### **3. Constructors**

**Constructors** run when objects are created:

```csharp
public class Weapon
{
    public string weaponName;
    public int damage;
    public float fireRate;
    
    // Default Constructor (no parameters)
    public Weapon()
    {
        weaponName = "Basic Sword";
        damage = 10;
        fireRate = 1.0f;
    }
    
    // Parameterised Constructor
    public Weapon(string name, int weaponDamage, float rate)
    {
        weaponName = name;
        damage = weaponDamage;
        fireRate = rate;
    }
}
```

```csharp
// Using constructors
Weapon basicWeapon = new Weapon();                           // Uses default
Weapon customWeapon = new Weapon("Fire Sword", 25, 2.0f);   // Uses parameterised
```

### **4. Instance vs Static**

- **Instance**: Each object has its own copy
- **Static**: Shared by ALL objects of the class

```csharp
public class Enemy
{
    // Instance members - each enemy has their own
    public int health;
    public Vector3 position;
    
    // Static members - shared by ALL enemies
    public static int totalEnemiesAlive = 0;
    public static int maxEnemies = 10;
    
    public Enemy()
    {
        health = 50;
        totalEnemiesAlive++;  // Increment shared counter
    }
    
    // Static method - can be called without creating an object
    public static bool CanSpawnEnemy()
    {
        return totalEnemiesAlive < maxEnemies;
    }
}
```

```csharp
// Using static members
if (Enemy.CanSpawnEnemy())  // Call without creating an enemy
{
    Enemy newEnemy = new Enemy();  // This increments totalEnemiesAlive
}

Debug.Log("Enemies alive: " + Enemy.totalEnemiesAlive);  // Access static data
```

## 🎮 **Practical Examples**

### **Example 1: Player Character Class**

```csharp
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Player Statistics")]
    public string characterName;
    public int maxHealth;
    public float moveSpeed;
    
    [Header("Current State")]
    public int currentHealth;
    public bool isAlive;
    
    // Private fields (only this class can access)
    private int experience;
    private int level;
    
    // Constructor-like initialization in Unity
    void Start()
    {
        InitializePlayer("Hero", 100, 5.0f);
    }
    
    // Custom initialization method (like a constructor)
    public void InitializePlayer(string name, int health, float speed)
    {
        characterName = name;
        maxHealth = health;
        currentHealth = health;
        moveSpeed = speed;
        isAlive = true;
        experience = 0;
        level = 1;
        
        Debug.Log($"Player {characterName} initialized with {currentHealth} health");
    }
    
    // Public methods (other scripts can call these)
    public void TakeDamage(int damage)
    {
        if (!isAlive) return;
        
        currentHealth -= damage;
        Debug.Log($"{characterName} took {damage} damage. Health: {currentHealth}");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Heal(int healAmount)
    {
        if (!isAlive) return;
        
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        Debug.Log($"{characterName} healed for {healAmount}. Health: {currentHealth}");
    }
    
    // Private method (only this class can call this)
    private void Die()
    {
        isAlive = false;
        currentHealth = 0;
        Debug.Log($"{characterName} has died!");
    }
    
    // Public method to safely add experience
    public void GainExperience(int exp)
    {
        experience += exp;
        Debug.Log($"{characterName} gained {exp} experience. Total: {experience}");
        
        CheckLevelUp();
    }
    
    // Private method for internal logic
    private void CheckLevelUp()
    {
        int experienceNeeded = level * 100;
        if (experience >= experienceNeeded)
        {
            level++;
            experience -= experienceNeeded;
            maxHealth += 20;
            currentHealth = maxHealth;  // Full heal on level up
            Debug.Log($"{characterName} leveled up to level {level}!");
        }
    }
    
    // Public method to get private data safely
    public int GetLevel()
    {
        return level;
    }
    
    public int GetExperience()
    {
        return experience;
    }
}
```

### **Example 2: Weapon System**

```csharp
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("Weapon Configuration")]
    public string weaponName;
    public int baseDamage;
    public float fireRate;
    public int maxAmmo;
    
    [Header("Current State")]
    public int currentAmmo;
    public bool canFire;
    
    // Private timing variables
    private float lastFireTime;
    private bool isReloading;
    
    // Static weapon statistics (shared across all weapons)
    public static int totalShotsFired = 0;
    public static int totalReloads = 0;
    
    void Start()
    {
        InitializeWeapon("Plasma Rifle", 25, 2.0f, 30);
    }
    
    // Initialization with parameters (constructor-like)
    public void InitializeWeapon(string name, int damage, float rate, int ammo)
    {
        weaponName = name;
        baseDamage = damage;
        fireRate = rate;
        maxAmmo = ammo;
        currentAmmo = maxAmmo;
        canFire = true;
        isReloading = false;
        
        Debug.Log($"Weapon {weaponName} ready! Damage: {baseDamage}, Ammo: {currentAmmo}");
    }
    
    void Update()
    {
        // Check for firing input
        if (Input.GetKeyDown(KeyCode.Space) && CanFireWeapon())
        {
            FireWeapon();
        }
        
        // Check for reload input
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < maxAmmo)
        {
            StartReload();
        }
    }
    
    // Private method to check if weapon can fire
    private bool CanFireWeapon()
    {
        bool cooldownReady = Time.time >= lastFireTime + (1.0f / fireRate);
        return canFire && !isReloading && currentAmmo > 0 && cooldownReady;
    }
    
    // Public method to fire the weapon
    public void FireWeapon()
    {
        if (!CanFireWeapon()) return;
        
        currentAmmo--;
        lastFireTime = Time.time;
        totalShotsFired++;  // Update static counter
        
        Debug.Log($"{weaponName} fired! Damage: {baseDamage}, Ammo remaining: {currentAmmo}");
        Debug.Log($"Total shots fired by all weapons: {totalShotsFired}");
        
        if (currentAmmo <= 0)
        {
            Debug.Log($"{weaponName} is out of ammo! Press R to reload.");
        }
    }
    
    // Private method to handle reloading
    private void StartReload()
    {
        isReloading = true;
        canFire = false;
        totalReloads++;  // Update static counter
        
        Debug.Log($"Reloading {weaponName}... Total reloads: {totalReloads}");
        
        // Simulate reload time
        Invoke("CompleteReload", 2.0f);
    }
    
    // Private method called after reload delay
    private void CompleteReload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
        canFire = true;
        
        Debug.Log($"{weaponName} reloaded! Ammo: {currentAmmo}");
    }
    
    // Static method to get global weapon statistics
    public static void PrintGlobalWeaponStats()
    {
        Debug.Log($"=== GLOBAL WEAPON STATISTICS ===");
        Debug.Log($"Total shots fired by all weapons: {totalShotsFired}");
        Debug.Log($"Total reloads by all weapons: {totalReloads}");
    }
    
    // Public method to get weapon information
    public string GetWeaponInfo()
    {
        return $"{weaponName}: {currentAmmo}/{maxAmmo} ammo, {baseDamage} damage";
    }
}
```

## 🛠️ **Step-by-Step Implementation**

### **Step 1: Create the Scripts**

1. **In Unity**: Right-click in Session05 folder → **Create > C# Script**
2. **Name**: `PlayerCharacter`
3. **Double-click** to open in VS Code
4. **Replace all code** with the PlayerCharacter example above
5. **Save**: `Ctrl+S`

### **Step 2: Attach and Test**

1. **Select** your Player GameObject
2. **Add Component** → search for "Player Character"
3. **Press Play**
4. **Watch Console** for initialization messages

### **Step 3: Test Player Methods**

Create a simple test script:

```csharp
using UnityEngine;

public class PlayerTester : MonoBehaviour
{
    public PlayerCharacter player;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.TakeDamage(20);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.Heal(15);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.GainExperience(50);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log($"Player Level: {player.GetLevel()}, Experience: {player.GetExperience()}");
        }
    }
}
```

**Test Instructions:**
- **1 Key**: Deal 20 damage
- **2 Key**: Heal 15 points
- **3 Key**: Gain 50 experience  
- **4 Key**: Show level and experience

## 🎯 **Key OOP Benefits in Games**

### **1. Code Reusability**
```csharp
// Create multiple enemies with same class
Enemy goblin = new Enemy("Goblin", 30);
Enemy orc = new Enemy("Orc", 60);
Enemy dragon = new Enemy("Dragon", 200);
```

### **2. Data Protection**
```csharp
// Player health cannot be directly modified incorrectly
player.health = -50;           // Don't do this!
player.TakeDamage(50);        // Do this instead - has safety checks
```

### **3. Organised Code**
- Each class has a **single responsibility**
- Related data and methods are **grouped together**
- Easy to **find and modify** specific functionality

### **4. Scalability**
- Add new features without breaking existing code
- Create variations by extending base classes
- Manage complex systems with clear interfaces

## 🐛 **Common Issues & Troubleshooting**

### **Issue: "Cannot create instance of MonoBehaviour"**
**Problem**: Trying to use `new` with MonoBehaviour classes
```csharp
// DON'T DO THIS with MonoBehaviour
PlayerCharacter player = new PlayerCharacter();  // ERROR!
```

**Solution**: MonoBehaviour objects are created by attaching to GameObjects
```csharp
// DO THIS instead
GameObject playerObj = new GameObject("Player");
PlayerCharacter player = playerObj.AddComponent<PlayerCharacter>();
```

### **Issue: "NullReferenceException"**
**Problem**: Trying to use an object that hasn't been created
```csharp
PlayerCharacter player;  // This is null!
player.TakeDamage(10);   // ERROR - player is null
```

**Solution**: Always initialize objects before using them
```csharp
PlayerCharacter player = FindObjectOfType<PlayerCharacter>();
if (player != null)
{
    player.TakeDamage(10);  // Safe to use
}
```

### **Issue: Static vs Instance Confusion**
**Problem**: Trying to access instance members on the class
```csharp
Enemy.health = 50;  // ERROR - health is instance, not static
```

**Solution**: Create object first, or make member static if appropriate
```csharp
Enemy enemy = new Enemy();
enemy.health = 50;     // Correct - health belongs to the instance

// OR if it should be static:
Enemy.totalEnemies++;  // Correct - totalEnemies is static
```

### **Issue: Constructor Errors**
**Problem**: Not providing required constructor parameters
```csharp
Weapon weapon = new Weapon();  // ERROR if no default constructor
```

**Solution**: Provide all required parameters or create default constructor
```csharp
Weapon weapon = new Weapon("Sword", 15, 1.5f);  // Provide parameters
```

## 📝 **Best Practices**

### **1. Naming Conventions**
```csharp
public class PlayerCharacter     // Classes: PascalCase
{
    public int maxHealth;        // Public fields: camelCase
    private float moveSpeed;     // Private fields: camelCase
    
    public void TakeDamage()     // Methods: PascalCase
    {
        // Code here
    }
}
```

### **2. Access Modifier Guidelines**
- **public**: Only for data/methods other scripts need to access
- **private**: Default choice - keep internals hidden
- **protected**: When you plan to create derived classes later

### **3. Constructor Design**
```csharp
// Good: Clear, required parameters
public Weapon(string name, int damage)
{
    weaponName = name;
    this.damage = damage;      // 'this' clarifies we mean the field
    
    // Set sensible defaults for optional data
    fireRate = 1.0f;
    maxAmmo = 30;
}
```

### **4. Method Design**
```csharp
// Good: Clear purpose, good naming, error checking
public bool TakeDamage(int damageAmount)
{
    if (damageAmount <= 0 || !isAlive) 
        return false;
    
    currentHealth -= damageAmount;
    
    if (currentHealth <= 0)
    {
        Die();
    }
    
    return true;  // Damage was successfully applied
}
```

## 🏆 **Session Summary**

You've learned the fundamental concepts of Object-Oriented Programming:

### **Classes and Objects**
- **Classes** are blueprints that define structure and behaviour
- **Objects** are instances created from classes
- Each object has its own data while sharing the same methods

### **Access Modifiers**
- **public**: Accessible from anywhere (use sparingly)
- **private**: Only accessible within the same class (preferred default)
- **protected**: Accessible within class and derived classes

### **Constructors**
- Special methods that run when objects are created
- Initialize object data to valid starting states
- Can have multiple constructors with different parameters

### **Instance vs Static**
- **Instance members**: Each object has its own copy
- **Static members**: Shared by all objects of the class
- Use static for global counters, utility methods, and shared data

### **Benefits of OOP**
- **Organisation**: Related data and methods grouped together
- **Reusability**: Create multiple objects from same class
- **Protection**: Control access to data with access modifiers
- **Maintainability**: Changes to class affect all instances consistently

## 🎮 **Game Development Applications**

OOP is essential for:
- **Player systems**: Health, inventory, abilities
- **Enemy AI**: Behaviour, stats, pathfinding  
- **Weapon systems**: Damage, ammunition, upgrades
- **Game managers**: Score, level progression, save data
- **UI components**: Menus, HUD elements, dialogs

## ⏭️ **Next Session Preview**

**Session 06: Advanced OOP** will cover:
- **Inheritance**: Creating specialized classes from base classes
- **Polymorphism**: Same interface, different implementations
- **Virtual methods**: Methods that can be overridden
- **Abstract classes**: Classes that can't be instantiated directly
- **Game system hierarchies**: Player types, enemy variants, weapon categories

---

## 🎯 **Ready for the Student Exercise?**

Open `Session05_StudentExercise.cs` and complete the TODO sections to practice everything you've learned about Object-Oriented Programming basics!

Remember: OOP helps you write **organised, reusable, and maintainable** code. These concepts will be fundamental to all your future game development projects.

---

*Session 05 - Object-Oriented Programming Basics*  
*CRE132 Game Development Fundamentals*  
*Northern Irish University - AI and Games Department*