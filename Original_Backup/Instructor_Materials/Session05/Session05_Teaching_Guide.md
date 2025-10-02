# Session 5: Object-Oriented Programming (OOP) Basics

## Session Overview

**Duration**: 110-140 minutes  
**W3Schools Topics**: Classes, Objects, Constructors, Access Modifiers  
**Unity Concepts**: Object lifecycle, data encapsulation, component patterns  
**OOP Unit**: Part 1 of 2 (Session 6: Advanced OOP completes the unit)

## Learning Objectives

By the end of this session, students will:
1. ✅ Understand classes as blueprints and objects as instances with independent data
2. ✅ Create custom classes with fields, properties, and methods for game entities
3. ✅ Implement constructors for object initialization (default, parameterized, overloaded)
4. ✅ Apply access modifiers (public, private, protected) for data security and encapsulation
5. ✅ Distinguish between static and instance members and use each appropriately
6. ✅ Design object-oriented game systems (enemies, weapons, characters)
7. ✅ **Prepare for Session 6**: Understand base class concepts that enable inheritance

## Scripts Included

### 1. `ClassBasics.cs`
**Purpose**: Fundamental class/object concepts with Enemy and Weapon system demonstrations  
**Key Features**:
- Class definition as blueprints for creating objects
- Object instantiation and independent data storage
- Multiple objects from same class with different values
- Method calling on different object instances
- Unity integration patterns for game objects
- **Session 6 Preparation**: Base Enemy class that will become parent class

### 2. `AccessModifiers.cs`
**Purpose**: Data encapsulation and security with secure vs insecure design patterns  
**Key Features**:
- Public, private, and protected access levels
- Data validation through private fields and public methods
- Secure vs insecure design pattern comparisons
- Property patterns for controlled data access
- Security benefits in multiplayer and collaborative development
- **Session 6 Preparation**: Protected members that child classes can access

### 3. `ConstructorExamples.cs`
**Purpose**: Multiple constructor patterns, overloading, and Unity initialization techniques  
**Key Features**:
- Default constructors with standard initialization
- Parameterized constructors for custom object creation
- Constructor overloading with different parameter sets
- Constructor chaining and validation patterns
- Unity-specific initialization (MonoBehaviour limitations)
- **Session 6 Preparation**: Base class constructors that child classes will call

### 4. `StaticVsInstance.cs`
**Purpose**: Clear demonstrations of static vs instance members with game management examples  
**Key Features**:
- Static members shared across all instances (counters, utilities)
- Instance members unique to each object (individual data, behavior)
- Static methods for utility functions and global operations
- Performance and memory implications of each approach
- Game development patterns using both static and instance
- **Session 6 Preparation**: Static methods that work with inheritance hierarchies
## Teaching Sequence

### Phase 1: Classes and Objects Foundation (25 minutes)
**Using `ClassBasics.cs` - Setting up for Session 6 Inheritance:**

1. **Create Unity Scene Setup**:
   - New scene: `05_OOP_Basics`
   - Create GameObject: "Session05Manager"
   - Attach ClassBasics.cs script
   - **CRITICAL**: Show Inspector organization with [Header] attributes

2. **Class as Blueprint Concept**:
   ```csharp
   // Class = Blueprint (like a house blueprint)
   public class Enemy
   {
       // Fields = Data that each enemy stores
       public string enemyName;
       public int health;
       public int damage;
       
       // Methods = Actions that each enemy can perform
       public void Attack()
       {
           Debug.Log($"{enemyName} attacks for {damage} damage!");
       }
       
       public void TakeDamage(int damageAmount)
       {
           health -= damageAmount;
           Debug.Log($"{enemyName} health now: {health}");
       }
   }
   ```

3. **Object Instantiation - Multiple Independent Instances**:
   ```csharp
   void Start()
   {
       // Create multiple enemies from same blueprint
       Enemy goblin = new Enemy();
       goblin.enemyName = "Goblin";
       goblin.health = 50;
       goblin.damage = 15;
       
       Enemy dragon = new Enemy();
       dragon.enemyName = "Dragon";
       dragon.health = 200;
       dragon.damage = 45;
       
       // Each object has independent data!
       goblin.Attack();    // "Goblin attacks for 15 damage!"
       dragon.Attack();    // "Dragon attacks for 45 damage!"
   }
   ```

4. **Why Objects Matter in Game Development**:
   ```csharp
   // Imagine managing 100 enemies without objects:
   string[] enemyNames = new string[100];
   int[] enemyHealth = new int[100];
   int[] enemyDamage = new int[100];
   // This gets messy FAST!
   
   // With objects:
   Enemy[] enemies = new Enemy[100];  // Clean, organized, scalable
   ```

5. **💡 Session 6 Bridge Introduction**:
   - "This Enemy class will become our 'base class' in Session 6"
   - "We'll learn how to create Zombie, Robot, and Wizard enemies that share this foundation"
   - "The methods we write here will be inherited by specialized enemy types"

### Phase 2: Access Modifiers and Data Security (25 minutes)
**Using `AccessModifiers.cs` - Preparing for Inheritance Protection:**

1. **The Problem with Public Everything**:
   ```csharp
   // ❌ INSECURE - Anyone can break our game!
   public class PlayerStats
   {
       public int health = 100;
       public int money = 50;
       public int experience = 0;
   }
   
   // Somewhere else in code (could be by accident or malicious):
   player.health = -999;      // Player is dead!
   player.money = 999999;     // Player is rich!
   player.experience = -50;   // Negative experience breaks level system!
   ```

2. **Secure Design with Private Fields**:
   ```csharp
   // ✅ SECURE - Controlled access only
   public class SecurePlayerStats
   {
       private int health = 100;        // Can't be accessed directly
       private int money = 50;
       private int experience = 0;
       
       // Public methods provide controlled access
       public void TakeDamage(int damage)
       {
           if (damage > 0 && health > 0)  // Validation!
           {
               health -= damage;
               if (health < 0) health = 0;  // Never go below 0
           }
       }
       
       public void AddExperience(int exp)
       {
           if (exp > 0)  // Only positive experience allowed
           {
               experience += exp;
           }
       }
   }
   ```

3. **Access Modifier Rules**:
   ```csharp
   public class AccessExample
   {
       public int publicData;        // Anyone can access
       private int privateData;      // Only this class can access
       protected int protectedData;  // This class + child classes (Session 6!)
       
       public void PublicMethod()    { /* Anyone can call */ }
       private void PrivateMethod()  { /* Only internal use */ }
       protected void ProtectedMethod() { /* Child classes too (Session 6!) */ }
   }
   ```

4. **💡 Session 6 Bridge - Protected Members**:
   - "Protected members are special - they're like private, but child classes can use them"
   - "In Session 6, when we create Zombie and Robot enemies, they'll inherit from Enemy"
   - "Protected fields in Enemy will be accessible to Zombie and Robot, but not to other classes"


### Phase 3: Constructor Patterns and Object Initialization (30 minutes)
**Using `ConstructorExamples.cs` - Foundation for Inheritance Constructors:**

1. **Default Constructor - Basic Object Creation**:
   ```csharp
   public class GameCharacter
   {
       public string name;
       public int level;
       public float health;
       
       // Default constructor - called automatically
       public GameCharacter()
       {
           name = "Unknown";
           level = 1;
           health = 100f;
           Debug.Log("Created default character");
       }
   }
   
   // Usage:
   GameCharacter hero = new GameCharacter();  // Uses default constructor
   ```

2. **Parameterized Constructor - Custom Initialization**:
   ```csharp
   public class GameCharacter
   {
       public string name;
       public int level;
       public float health;
       
       // Custom constructor with parameters
       public GameCharacter(string characterName, int startLevel)
       {
           name = characterName;
           level = startLevel;
           health = 100f + (startLevel * 20f);  // Higher level = more health
           Debug.Log($"Created {name} at level {level} with {health} health");
       }
   }
   
   // Usage:
   GameCharacter wizard = new GameCharacter("Gandalf", 10);
   GameCharacter warrior = new GameCharacter("Conan", 5);
   ```

3. **Constructor Overloading - Multiple Creation Options**:
   ```csharp
   public class Weapon
   {
       public string weaponName;
       public int damage;
       public float durability;
       
       // Constructor 1: Name only (default stats)
       public Weapon(string name)
       {
           weaponName = name;
           damage = 10;
           durability = 100f;
       }
       
       // Constructor 2: Name and damage (default durability)
       public Weapon(string name, int weaponDamage)
       {
           weaponName = name;
           damage = weaponDamage;
           durability = 100f;
       }
       
       // Constructor 3: Full customization
       public Weapon(string name, int weaponDamage, float weaponDurability)
       {
           weaponName = name;
           damage = weaponDamage;
           durability = weaponDurability;
       }
   }
   
   // Different ways to create weapons:
   Weapon basicSword = new Weapon("Iron Sword");
   Weapon magicSword = new Weapon("Magic Sword", 25);
   Weapon legendSword = new Weapon("Excalibur", 50, 999f);
   ```

4. **Constructor Chaining - DRY Principle**:
   ```csharp
   public class Spaceship
   {
       public string shipName;
       public int crew;
       public float fuel;
       public bool hasShields;
       
       // Most detailed constructor
       public Spaceship(string name, int crewSize, float fuelAmount, bool shields)
       {
           shipName = name;
           crew = crewSize;
           fuel = fuelAmount;
           hasShields = shields;
           Debug.Log($"Spaceship {name} constructed with full specs");
       }
       
       // Simpler constructor calls the detailed one
       public Spaceship(string name, int crewSize) : this(name, crewSize, 100f, true)
       {
           // Calls the 4-parameter constructor with defaults
       }
       
       // Basic constructor
       public Spaceship(string name) : this(name, 1, 100f, false)
       {
           // Calls the 4-parameter constructor with different defaults
       }
   }
   ```

5. **💡 Session 6 Bridge - Base Class Constructors**:
   - "In Session 6, when we create Zombie : Enemy, the Zombie constructor will call Enemy's constructor"
   - "We use `base()` to call the parent class constructor - just like `this()` calls our own constructors"
   - "This ensures the base Enemy data is properly initialized before adding Zombie-specific data"

### Phase 4: Static vs Instance Members (20 minutes)
**Using `StaticVsInstance.cs` - Understanding Shared vs Individual Data:**

1. **Instance Members - Individual Object Data**:
   ```csharp
   public class Player
   {
       // Instance fields - each player has their own copy
       public string playerName;
       public int playerScore;
       public float playerHealth;
       
       // Instance method - works with this specific player's data
       public void DisplayPlayerInfo()
       {
           Debug.Log($"Player: {playerName}, Score: {playerScore}, Health: {playerHealth}");
       }
   }
   
   // Each player object has independent data
   Player alice = new Player();
   alice.playerName = "Alice";
   alice.playerScore = 1500;
   
   Player bob = new Player();
   bob.playerName = "Bob";
   bob.playerScore = 2300;  // Different from Alice's score
   ```

2. **Static Members - Shared Across All Objects**:
   ```csharp
   public class GameManager
   {
       // Static fields - shared by all instances
       public static int totalPlayersOnline = 0;
       public static string currentLevel = "Level 1";
       public static bool gameIsPaused = false;
       
       // Instance fields - each GameManager has its own
       public string managerName;
       
       // Static method - doesn't need an object to call
       public static void PauseGame()
       {
           gameIsPaused = true;
           Debug.Log("Game paused for all players");
       }
       
       // Instance method - needs an object to call
       public void ReportStatus()
       {
           Debug.Log($"Manager {managerName} reports: {totalPlayersOnline} players online");
       }
   }
   
   // Static members accessed through class name, not object
   GameManager.totalPlayersOnline = 5;
   GameManager.PauseGame();  // No object needed!
   
   // Instance members need an object
   GameManager manager1 = new GameManager();
   manager1.managerName = "Server Manager";
   manager1.ReportStatus();  // Uses object data
   ```

3. **When to Use Static vs Instance**:
   ```csharp
   // ✅ USE STATIC FOR:
   public class Utilities
   {
       public static float CalculateDistance(Vector3 a, Vector3 b)  // Pure calculation
       public static int RandomRange(int min, int max)              // Utility function
       public static int totalEnemiesKilled = 0;                   // Global counter
   }
   
   // ✅ USE INSTANCE FOR:
   public class Enemy
   {
       public string enemyName;     // Each enemy has different name
       public int health;           // Each enemy has different health
       public void Attack() { }     // Each enemy attacks individually
   }
   ```

4. **💡 Session 6 Bridge - Static Methods with Inheritance**:
   - "Static methods don't participate in inheritance - they belong to the specific class"
   - "But static methods can work with inherited objects using polymorphism"
   - "In Session 6, we'll see how static utility methods can process arrays of different enemy types"


### Phase 5: Integration and Real-World Game Systems (15 minutes)

1. **Combining All OOP Concepts in Game Development**:
   ```csharp
   // Complete enemy management system using all Session 5 concepts
   public class EnemyManager
   {
       // Static members for global management
       public static int totalEnemiesDefeated = 0;
       public static List<Enemy> allActiveEnemies = new List<Enemy>();
       
       // Static method for spawning enemies
       public static Enemy SpawnEnemy(string type, Vector3 position)
       {
           Enemy newEnemy;
           
           // Use different constructors based on enemy type
           switch (type)
           {
               case "weak":
                   newEnemy = new Enemy("Goblin", 30, 5);
                   break;
               case "strong":
                   newEnemy = new Enemy("Orc", 80, 15);
                   break;
               default:
                   newEnemy = new Enemy();  // Default constructor
                   break;
           }
           
           allActiveEnemies.Add(newEnemy);
           return newEnemy;
       }
   }
   
   public class Enemy
   {
       // Private fields for security (encapsulation)
       private string name;
       private int health;
       private int damage;
       
       // Constructors for flexible creation
       public Enemy() : this("Unknown", 50, 10) { }
       
       public Enemy(string enemyName, int enemyHealth, int enemyDamage)
       {
           name = enemyName;
           health = enemyHealth;
           damage = enemyDamage;
       }
       
       // Public methods for controlled interaction
       public void Attack(Player target)
       {
           target.TakeDamage(damage);
           Debug.Log($"{name} attacks {target.GetName()} for {damage} damage!");
       }
       
       public bool TakeDamage(int damageAmount)
       {
           health -= damageAmount;
           if (health <= 0)
           {
               Die();
               return true;  // Enemy died
           }
           return false;  // Enemy survived
       }
       
       private void Die()
       {
           EnemyManager.totalEnemiesDefeated++;  // Update static counter
           EnemyManager.allActiveEnemies.Remove(this);
           Debug.Log($"{name} has been defeated!");
       }
   }
   ```

### Phase 6: Student Exercise and Session 6 Preparation (25 minutes)

**Student Challenges using `Session05_StudentExercise.cs`:**

1. **Class Creation Mastery**:
   - Design Character class with name, level, health, and experience
   - Implement proper access modifiers for data security
   - Create methods for leveling up and taking damage

2. **Constructor Implementation**:
   - Write default constructor with standard starting values
   - Add parameterized constructor for custom character creation
   - Implement constructor overloading for different creation options

3. **Access Control Practice**:
   - Convert public fields to private with validation methods
   - Implement secure money and inventory systems
   - Design proper getter/setter patterns

4. **Static vs Instance Application**:
   - Create utility methods for game calculations
   - Implement global counters and statistics tracking
   - Design systems that combine static and instance members

### 💡 **Session 6 Bridge Building** (CRITICAL 10 minutes)

**Setting Up Advanced OOP Expectations:**

1. **Preview Session 6 Concepts**:
   ```csharp
   // "In Session 6, we'll take this Enemy class and extend it:"
   public class Enemy  // This becomes the BASE CLASS
   {
       protected string name;    // Protected so child classes can access
       protected int health;
       protected int damage;
       
       public virtual void Attack()  // Virtual = child classes can override
       {
           Debug.Log($"{name} performs a basic attack!");
       }
   }
   
   // Session 6: We'll create these specialized classes
   public class Zombie : Enemy  // INHERITANCE
   {
       public override void Attack()  // OVERRIDE parent method
       {
           Debug.Log($"{name} shambles forward and bites!");
       }
   }
   
   public class Robot : Enemy
   {
       public override void Attack()
       {
           Debug.Log($"{name} fires laser beams!");
       }
   }
   ```

2. **Why Inheritance Matters**:
   - "Instead of copying Enemy code into Zombie, Robot, Wizard classes..."
   - "We'll INHERIT the common functionality and ADD specialized behavior"
   - "One change to Enemy class automatically updates ALL enemy types"
   - "This is how professional games manage hundreds of different enemies efficiently"

3. **What Students Will Be Able to Do After Session 6**:
   - Create complex class hierarchies (Vehicle → Car, Truck, Motorcycle)
   - Use polymorphism to treat different objects the same way
   - Build flexible game systems that are easy to extend
   - Write professional-quality code that follows industry standards

4. **Session Continuity Message**:
   - "Everything we learned today becomes MORE powerful in Session 6"
   - "The Enemy class we built today will become the parent of 3 different enemy types"
   - "Your constructor knowledge will help you understand base() calls"
   - "Protected access modifiers will finally make complete sense"


## Common Student Questions & Answers

**Q: What's the difference between a class and an object?**  
A: A **class** is like a blueprint or recipe (defines what an Enemy should have). An **object** is the actual thing you create from that blueprint (a specific Goblin enemy with 50 health). You can make many objects from one class!

**Q: Why should I make fields private instead of public? It's more work!**  
A: Think of it like a bank vault. You don't want anyone to directly access your money - they should go through proper channels. Private fields with public methods let you control HOW data is changed and validate it's correct.

**Q: When do I use static vs instance members?**  
A: Use **static** for things shared by ALL objects (total score, game settings, utility functions). Use **instance** for things unique to EACH object (player name, individual health, personal inventory).

**Q: Why do constructors not have return types?**  
A: Constructors always "return" a new object - that's their only job! They can't return anything else, so C# doesn't require (or allow) you to specify a return type.

**Q: Can I have both static and instance members in the same class?**  
A: Absolutely! A Player class might have static totalPlayers (shared) and instance playerName (individual). Just remember: static methods can't directly access instance data.

**Q: What happens if I don't write a constructor?**  
A: C# creates a default constructor automatically that sets everything to default values (0, null, false). But if you write ANY constructor, C# stops creating the automatic one.

**Q: Why use `this()` constructor chaining?**  
A: It prevents code duplication! Instead of writing the same initialization code in multiple constructors, you write it once in the most detailed constructor and have simpler ones call it.

**Q: In Session 6, will all this become more complicated?**  
A: Actually, inheritance makes things SIMPLER! Instead of writing separate Zombie, Robot, and Wizard classes from scratch, you'll inherit from Enemy and only add the differences. Less code, more power!

## Assessment Checkpoints

### Knowledge Check (Throughout Session):
- [ ] Can explain the difference between classes (blueprints) and objects (instances)
- [ ] Understands why private fields are more secure than public fields
- [ ] Knows when to use static vs instance members appropriately
- [ ] Can identify different constructor types and their purposes
- [ ] Understands object lifecycle and memory management concepts
- [ ] Recognizes inheritance preparation concepts (protected members, virtual methods)

### Practical Check (End of Session):
- [ ] Successfully creates custom classes with fields, properties, and methods
- [ ] Implements multiple constructor types with appropriate validation
- [ ] Uses access modifiers correctly for data security and encapsulation
- [ ] Demonstrates static vs instance member usage in game scenarios
- [ ] Creates multiple objects from same class with independent data
- [ ] Designs object-oriented systems suitable for extension (Session 6 preparation)

### OOP Unit Preparation Check:
- [ ] Creates base classes that could serve as parent classes for inheritance
- [ ] Uses protected members appropriately for future child class access
- [ ] Implements virtual methods that could be overridden in derived classes
- [ ] Understands constructor patterns that will support base class initialization
- [ ] Demonstrates understanding of object composition and relationships

### Professional Design Check:
- [ ] Follows naming conventions (PascalCase for classes, camelCase for fields)
- [ ] Includes appropriate validation in public methods
- [ ] Creates classes with single responsibility principle
- [ ] Uses composition over complex inheritance where appropriate
- [ ] Implements proper error handling and defensive programming practices

## Extension Activities

For students who finish early:

1. **Advanced Constructor Patterns**:
   - Implement copy constructors that create objects from existing objects
   - Create factory methods for complex object creation
   - Design builder patterns for step-by-step object construction

2. **Complex Object Relationships**:
   - Create Player class that owns multiple Weapon objects
   - Design Team class that manages multiple Player objects
   - Build hierarchical systems (Army → Squad → Soldier)

3. **Static Utility Systems**:
   - Build MathUtils class with game calculation methods
   - Create StringHelper class for text processing
   - Design FileManager class for save/load operations

4. **Security and Validation**:
   - Implement comprehensive input validation in all public methods
   - Create secure authentication systems using private data
   - Design audit logging for all data modifications

5. **Session 6 Preview Challenges**:
   - Create Vehicle base class ready for Car/Truck/Motorcycle inheritance
   - Design Shape base class that calculates area (prepare for polymorphism)
   - Build Weapon system ready for Sword/Bow/Staff specialization


## Troubleshooting Common Issues

### **Class and Object Creation Errors**

**Error: "'ClassName' does not contain a constructor that takes 0 arguments"**  
→ **Cause**: Created parameterized constructor but no default constructor  
→ **Solution**: Add default constructor or use parameterized constructor
```csharp
// ❌ This breaks default construction
public class Enemy
{
    public Enemy(string name) { /* ... */ }  // Only parameterized constructor
}
Enemy e = new Enemy();  // ERROR - no default constructor!

// ✅ Fix: Add default constructor
public class Enemy
{
    public Enemy() { /* default values */ }       // Default constructor
    public Enemy(string name) { /* ... */ }       // Parameterized constructor
}
```

**Error: "A field initializer cannot reference the non-static field"**  
→ **Cause**: Trying to initialize field with instance data  
→ **Solution**: Initialize in constructor instead
```csharp
// ❌ WRONG
public class Player
{
    public int health = 100;
    public int maxHealth = health;  // ERROR - can't reference health here
}

// ✅ CORRECT
public class Player
{
    public int health;
    public int maxHealth;
    
    public Player()
    {
        health = 100;
        maxHealth = health;  // OK in constructor
    }
}
```

### **Access Modifier Problems**

**Error: "'ClassName.MemberName' is inaccessible due to its protection level"**  
→ **Cause**: Trying to access private/protected members from outside class  
→ **Solution**: Use public methods or change access level appropriately
```csharp
public class Enemy
{
    private int health = 100;  // Private field
}

// ❌ WRONG
Enemy enemy = new Enemy();
enemy.health = 50;  // ERROR - can't access private field

// ✅ CORRECT - Add public method
public class Enemy
{
    private int health = 100;
    
    public void SetHealth(int newHealth)
    {
        if (newHealth > 0) health = newHealth;  // Validation!
    }
}
```

### **Static vs Instance Confusion**

**Error: "An object reference is required for the non-static field, method, or property"**  
→ **Cause**: Trying to access instance member from static context  
→ **Solution**: Create instance or make member static
```csharp
public class GameManager
{
    public int playerCount = 0;  // Instance field
    
    public static void UpdatePlayers()
    {
        playerCount++;  // ERROR - static method can't access instance field
    }
}

// ✅ Fix Option 1: Make field static
public static int playerCount = 0;

// ✅ Fix Option 2: Use instance
GameManager manager = new GameManager();
manager.playerCount++;
```

**Error: "Cannot access non-static member through static reference"**  
→ **Cause**: Using class name to access instance members  
→ **Solution**: Create object instance or make member static

### **Constructor Problems**

**Error: "Constructor 'ClassName' cannot call itself"**  
→ **Cause**: Constructor chaining creates circular reference  
→ **Solution**: Fix chaining to avoid infinite loops
```csharp
// ❌ INFINITE LOOP
public Enemy() : this("Default") { }
public Enemy(string name) : this() { }  // Calls first constructor - infinite loop!

// ✅ CORRECT CHAINING
public Enemy() : this("Default", 100) { }  // Chain to most detailed
public Enemy(string name) : this(name, 100) { }
public Enemy(string name, int health) { /* actual initialization */ }
```

### **Unity-Specific OOP Issues**

**Problem: MonoBehaviour constructors don't work as expected**  
→ **Cause**: Unity creates MonoBehaviour objects, not your constructors  
→ **Solution**: Use Awake() or Start() for initialization
```csharp
// ❌ WRONG - Unity ignores this constructor
public class PlayerController : MonoBehaviour
{
    public PlayerController(string name)  // Unity won't call this!
    {
        // This never runs!
    }
}

// ✅ CORRECT - Use Unity lifecycle methods
public class PlayerController : MonoBehaviour
{
    void Awake()
    {
        // Initialize here - Unity calls this automatically
    }
}
```

**Problem: Static members reset unexpectedly**  
→ **Cause**: Domain reloading in Unity Editor  
→ **Solution**: Understand Editor vs Build behavior, use [RuntimeInitializeOnLoadMethod]


## Unity/Visual Studio Code Integration Notes

### **Session 5 Specific Workflow**

1. **OOP Development Process**:
   - **Design first**: Sketch class relationships on paper/whiteboard before coding
   - **Start simple**: Basic class with public fields, then add constructors and access modifiers
   - **Test incrementally**: Create objects in Start() method, verify with Debug.Log
   - **Refactor gradually**: Convert public fields to private with validation methods

2. **Visual Studio Code OOP Support**:
   - **IntelliSense for classes**: Auto-completion shows available constructors
   - **Access modifier highlighting**: Different colors for public/private/protected
   - **Constructor parameter hints**: VS Code shows required parameters as you type
   - **Error detection**: Red squiggles for access modifier violations and constructor errors

3. **Unity Inspector Integration**:
   - **Public fields appear**: Only public or [SerializeField] private fields show
   - **Constructor limitations**: Unity creates MonoBehaviour objects, bypassing constructors
   - **Static field persistence**: Static members survive play mode but reset on script recompilation
   - **Object reference tracking**: Unity shows when objects reference each other

### **OOP Unit Preparation**

1. **Session 5 → Session 6 Continuity**:
   - **Same project/scene**: Continue in same Unity scene for familiarity
   - **Evolving examples**: Enemy class from Session 5 becomes base class in Session 6
   - **Consistent terminology**: Use same variable names and method patterns
   - **Building complexity**: Each session adds concepts rather than starting over

2. **Testing OOP Concepts**:
   - **Multiple object creation**: Create several instances to prove independence
   - **Method calling**: Test public methods on different objects
   - **Access validation**: Try accessing private members to show errors
   - **Constructor testing**: Use different constructors to verify behavior

## Next Session Preview - Session 6: Advanced OOP

**Building on Session 5 Foundation:**
- **Enemy class becomes base class** for Zombie, Robot, Wizard inheritance
- **Protected members** from Session 5 become accessible to child classes  
- **Virtual methods** allow child classes to customize parent behavior
- **Polymorphism** lets us treat different enemy types the same way

**What Students Will Gain:**
- **Professional code organization** using inheritance hierarchies
- **Flexible game systems** that are easy to extend with new content
- **Advanced debugging skills** for complex object relationships
- **Industry-standard patterns** used throughout game development

---

## Files in This Session
- `ClassBasics.cs` - Fundamental class/object concepts with game entity demonstrations
- `AccessModifiers.cs` - Data encapsulation and security with practical design patterns
- `ConstructorExamples.cs` - Multiple constructor patterns and Unity initialization techniques
- `StaticVsInstance.cs` - Clear demonstrations of static vs instance members
- `Session05_StudentExercise.cs` - Comprehensive student practice preparing for Session 6
- `Session05_Teaching_Guide.md` - This instructor guide

**Unity Scene**: `05_OOP_Basics.unity`  
**Estimated Total Teaching Time**: 110-140 minutes  
**Prerequisites**: Sessions 1-4 (Variables, operators, loops, methods, collections)  
**Prepares For**: Session 6 (Inheritance, polymorphism, abstract classes)

---

## Teaching Tips for Success

### **Critical Session 5 Concepts to Emphasise**

1. **Classes as Blueprints Mental Model**:
   - **Use real-world analogies**: House blueprints → houses, cookie cutters → cookies
   - **Show independence**: Create multiple objects, modify one, show others unchanged
   - **Emphasize reusability**: One class definition creates unlimited objects

2. **Access Modifier Security Focus**:
   - **Start with insecure example**: Show how public fields can be broken
   - **Demonstrate the problem**: Let students "hack" each other's games
   - **Reveal the solution**: Private fields with validation methods
   - **Make it personal**: "Protect your player's progress from accidental bugs"

3. **Constructor Flexibility**:
   - **Show the pain first**: Creating objects with many separate assignments
   - **Introduce constructors as solution**: One line object creation with validation
   - **Build complexity gradually**: Default → parameterized → overloaded → chaining

### **OOP Unit Strategy (Sessions 5-6)**

1. **Consistent Examples Throughout**:
   - **Enemy system** carries from Session 5 basic class to Session 6 inheritance
   - **Weapon system** shows constructor patterns in Session 5, abstract classes in Session 6
   - **Same terminology** and variable names maintain continuity

2. **Session 6 Preparation Emphasis**:
   - **Plant inheritance seeds**: "This Enemy class will become a parent class"
   - **Explain protected purpose**: "Protected is for family members - child classes"
   - **Preview virtual methods**: "Virtual means child classes can customize behavior"

3. **Difficulty Pacing**:
   - **Session 5**: Focus on individual class mastery and object creation
   - **Session 6**: Focus on relationships between classes and specialized behavior
   - **Smooth transition**: Session 5 concepts directly enable Session 6 concepts

### **Student Engagement Strategies**

1. **Object Creation Games**:
   - "Create an army of different enemies with different stats"
   - "Design a weapon shop with different creation options"
   - "Build a character creator with validation rules"

2. **Security Challenges**:
   - "Try to break each other's player stats systems"
   - "Design the most secure bank account class"
   - "Create a game where cheating is impossible"

3. **Constructor Competitions**:
   - "Who can create the most flexible object creation system?"
   - "Design a class with the clearest constructor overloads"
   - "Build the best default value system"

### **Assessment Focus Points**

- **Conceptual understanding**: Does student understand class vs object distinction?
- **Security awareness**: Does student default to private fields with public methods?
- **Design thinking**: Does student create classes that could extend into inheritance?
- **Professional practices**: Does student follow naming conventions and validation patterns?

**Session 5 prepares students to excel in Session 6 by establishing solid OOP foundations that inheritance and polymorphism will build upon naturally.**

