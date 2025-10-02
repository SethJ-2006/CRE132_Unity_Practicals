# Session 6: Advanced Object-Oriented Programming

## Session Overview

**Duration**: 120-150 minutes  
**W3Schools Topics**: Inheritance, Polymorphism, Abstract Classes  
**Unity Concepts**: Advanced object hierarchies, flexible game systems, professional architecture  
**OOP Unit**: Part 2 of 2 (Completes OOP unit started in Session 5)

## Learning Objectives

By the end of this session, students will:
1. ✅ **Build on Session 5**: Transform basic Enemy class into inheritance hierarchy
2. ✅ Implement inheritance relationships with base classes and derived classes
3. ✅ Use polymorphism to treat different objects through common interfaces
4. ✅ Create and implement abstract classes that enforce child class contracts
5. ✅ Override virtual methods for specialized behavior in derived classes
6. ✅ Apply constructor chaining with base() calls from Session 5 knowledge
7. ✅ Design professional game systems using advanced OOP principles
8. ✅ **Complete OOP Mastery**: Integrate all concepts for flexible, scalable code

## Scripts Included

### 1. `InheritanceBasics.cs`
**Purpose**: Complete enemy hierarchy system building on Session 5's Enemy foundation  
**Key Features**:
- Base Enemy class from Session 5 enhanced for inheritance
- Zombie, Robot, and Wizard classes inheriting common functionality
- Protected member usage that students learned in Session 5
- Virtual and override method patterns for specialized behavior
- Constructor chaining using base() calls
- **Direct Session 5 Connection**: Uses same Enemy class structure students already know

### 2. `PolymorphismExample.cs`
**Purpose**: Battle simulation demonstrating polymorphism and same-interface-different-behavior  
**Key Features**:
- Enemy array containing different types (Zombie, Robot, Wizard)
- Polymorphic method calls showing specialized behaviors
- Runtime type identification and casting
- Professional game development pattern demonstrations
- Static methods working with inheritance hierarchies (Session 5 static knowledge)
- **Session 5 Integration**: Uses static vs instance concepts for polymorphic processing

### 3. `AbstractClassDemo.cs`
**Purpose**: Weapon system using abstract classes to enforce implementation contracts  
**Key Features**:
- Abstract Weapon base class with required method contracts
- Sword, Bow, and MagicStaff implementations with unique behaviors
- Abstract vs virtual method differences
- Constructor patterns in abstract base classes
- Template method pattern for consistent game behavior
- **Session 5 Foundation**: Uses constructor overloading and access modifier patterns

## Advanced OOP Unit Integration

### **Seamless Progression from Session 5**:
- **Same Enemy class** that students created in Session 5 becomes the inheritance base
- **Protected members** from Session 5 are now accessible to child classes
- **Constructor knowledge** from Session 5 enables understanding of base() calls
- **Static vs instance** concepts support polymorphic utility methods
- **Access modifiers** ensure proper encapsulation in inheritance hierarchies
## Teaching Sequence

### Phase 1: Inheritance Foundation - Building on Session 5 (30 minutes)
**Using `InheritanceBasics.cs` - Evolving Session 5's Enemy Class:**

1. **Recap Session 5 Enemy Class (Review: 5 minutes)**:
   ```csharp
   // "Remember this Enemy class from Session 5?"
   public class Enemy
   {
       protected string name;      // Protected = child classes can access
       protected int health;
       protected int damage;
       
       public Enemy(string enemyName, int enemyHealth, int enemyDamage)
       {
           name = enemyName;
           health = enemyHealth;
           damage = enemyDamage;
       }
       
       public virtual void Attack()  // Virtual = child classes can override
       {
           Debug.Log($"{name} performs a basic attack for {damage} damage!");
       }
   }
   ```

2. **The Problem Without Inheritance (10 minutes)**:
   ```csharp
   // ❌ WITHOUT INHERITANCE - Lots of repeated code
   public class Zombie
   {
       // Copy all Enemy code...
       private string name;     // Duplicate!
       private int health;      // Duplicate!
       private int damage;      // Duplicate!
       
       public void Attack() { /* duplicate logic */ }
       public void TakeDamage(int damage) { /* duplicate logic */ }
       // ... 50 lines of duplicated code
       
       public void Shamble() { /* Zombie-specific */ }
   }
   
   public class Robot
   {
       // Copy all Enemy code AGAIN...
       private string name;     // Duplicate AGAIN!
       private int health;      // Duplicate AGAIN!
       // ... Another 50 lines of duplicated code
       
       public void ScanArea() { /* Robot-specific */ }
   }
   ```

3. **Inheritance Solution - DRY Principle (15 minutes)**:
   ```csharp
   // ✅ WITH INHERITANCE - Write once, use everywhere
   public class Zombie : Enemy  // "Zombie IS AN Enemy"
   {
       // Automatically gets: name, health, damage, Attack(), TakeDamage()
       // From Session 5: protected members are accessible!
       
       // Constructor must call base class constructor
       public Zombie(string zombieName) : base(zombieName, 60, 8)
       {
           Debug.Log($"Created zombie: {zombieName}");
       }
       
       // Override parent method for specialized behavior
       public override void Attack()
       {
           Debug.Log($"{name} shambles forward and bites for {damage} damage!");
       }
       
       // Add zombie-specific behavior
       public void Shamble()
       {
           Debug.Log($"{name} shambles around aimlessly...");
       }
   }
   
   public class Robot : Enemy
   {
       public Robot(string robotName) : base(robotName, 100, 15)
       {
           Debug.Log($"Robot {robotName} systems online");
       }
       
       public override void Attack()
       {
           Debug.Log($"{name} fires laser beams for {damage} damage!");
       }
       
       public void ScanArea()
       {
           Debug.Log($"{name} scanning area for threats...");
       }
   }
   
   public class Wizard : Enemy
   {
       private int mana = 50;  // Wizard-specific field
       
       public Wizard(string wizardName) : base(wizardName, 40, 20)
       {
           Debug.Log($"Wizard {wizardName} begins channeling magic");
       }
       
       public override void Attack()
       {
           if (mana >= 10)
           {
               mana -= 10;
               Debug.Log($"{name} casts fireball for {damage} magic damage! Mana: {mana}");
           }
           else
           {
               Debug.Log($"{name} is out of mana and uses staff for {damage/2} damage");
           }
       }
   }
   ```

4. **Inheritance Benefits Demonstration**:
   ```csharp
   void Start()
   {
       // Create different enemy types
       Zombie goblinZombie = new Zombie("Undead Goblin");
       Robot securityBot = new Robot("Security-X1");
       Wizard darkMage = new Wizard("Morgoth");
       
       // All have Enemy functionality automatically
       goblinZombie.Attack();  // "Undead Goblin shambles forward and bites..."
       securityBot.Attack();   // "Security-X1 fires laser beams..."
       darkMage.Attack();      // "Morgoth casts fireball..."
       
       // Plus their specialized methods
       goblinZombie.Shamble();
       securityBot.ScanArea();
   }
   ```

5. **Session 5 Connection Points**:
   - **Protected members**: "Remember protected from Session 5? Now child classes can use them!"
   - **Constructor chaining**: "We use base() just like this() from Session 5 constructor chaining"
   - **Virtual methods**: "Virtual means 'child classes can customize this' - just like we planned!"


### Phase 2: Polymorphism - Same Interface, Different Behaviors (30 minutes)
**Using `PolymorphismExample.cs` - Integration with Sessions 4 & 5:**

1. **The Power of Treating Different Objects the Same Way (10 minutes)**:
   ```csharp
   // Session 4: We learned about arrays and lists
   // Session 5: We learned about objects and classes
   // Session 6: Now we combine them with POLYMORPHISM!
   
   void Start()
   {
       // Create array of different enemy types (Session 4 arrays)
       Enemy[] enemies = new Enemy[3];  // Base class array
       
       // Store different derived types in same array
       enemies[0] = new Zombie("Undead Goblin");    // Zombie IS AN Enemy
       enemies[1] = new Robot("Security-X1");       // Robot IS AN Enemy  
       enemies[2] = new Wizard("Dark Mage");        // Wizard IS AN Enemy
       
       // Process all enemies the same way - but each behaves differently!
       for (int i = 0; i < enemies.Length; i++)
       {
           enemies[i].Attack();  // Calls appropriate override method
       }
       
       /* Output:
        * "Undead Goblin shambles forward and bites for 8 damage!"
        * "Security-X1 fires laser beams for 15 damage!"
        * "Dark Mage casts fireball for 20 magic damage!"
        */
   }
   ```

2. **Polymorphism with Lists (Session 4 Integration)**:
   ```csharp
   // Dynamic enemy management using Session 4's List knowledge
   List<Enemy> activeEnemies = new List<Enemy>();
   
   // Add different enemy types to same list
   activeEnemies.Add(new Zombie("Zombie Guard"));
   activeEnemies.Add(new Robot("Patrol Bot"));
   activeEnemies.Add(new Wizard("Ice Wizard"));
   
   // Process entire list polymorphically
   foreach (Enemy enemy in activeEnemies)
   {
       enemy.Attack();  // Each enemy attacks in their own way
   }
   
   // Add new enemy type dynamically
   activeEnemies.Add(new Zombie("Zombie Mage"));  // List grows (Session 4)
   ```

3. **Advanced Polymorphic Patterns (10 minutes)**:
   ```csharp
   // Battle simulation using polymorphism
   public static void ProcessBattleTurn(Enemy attacker, Enemy defender)
   {
       // Static method from Session 5 working with any enemy type
       Debug.Log($"=== BATTLE TURN ===");
       
       attacker.Attack();  // Polymorphic call - behavior depends on actual type
       
       int damage = attacker.GetDamage();  // Virtual method call
       defender.TakeDamage(damage);        // Inherited method
       
       if (defender.GetHealth() <= 0)
       {
           Debug.Log($"{defender.GetName()} has been defeated!");
       }
   }
   
   // Can call with any combination of enemy types
   ProcessBattleTurn(zombie, robot);    // Zombie attacks Robot
   ProcessBattleTurn(wizard, zombie);   // Wizard attacks Zombie
   ProcessBattleTurn(robot, wizard);    // Robot attacks Wizard
   ```

4. **Type Checking and Casting (10 minutes)**:
   ```csharp
   // Sometimes you need to access specific functionality
   foreach (Enemy enemy in enemies)
   {
       // Polymorphic call works for all
       enemy.Attack();
       
       // Type-specific calls require checking
       if (enemy is Zombie zombie)  // Modern C# pattern matching
       {
           zombie.Shamble();  // Only zombies can shamble
       }
       else if (enemy is Robot robot)
       {
           robot.ScanArea();  // Only robots can scan
       }
       else if (enemy is Wizard wizard)
       {
           // Wizard-specific behavior could go here
       }
   }
   ```

5. **Polymorphism Benefits in Game Development**:
   ```csharp
   // One method handles ALL enemy types - past, present, and future
   public static void SpawnRandomEnemies(int count)
   {
       List<Enemy> spawned = new List<Enemy>();  // Session 4 List
       
       for (int i = 0; i < count; i++)  // Session 3 for loop
       {
           Enemy newEnemy;
           
           // Session 2 conditional logic + Session 6 polymorphism
           switch (Random.Range(0, 3))
           {
               case 0: newEnemy = new Zombie($"Zombie{i}"); break;
               case 1: newEnemy = new Robot($"Robot{i}"); break;
               default: newEnemy = new Wizard($"Wizard{i}"); break;
           }
           
           spawned.Add(newEnemy);  // Session 4 List.Add()
       }
       
       // Process all spawned enemies uniformly
       foreach (Enemy enemy in spawned)  // Session 3 foreach
       {
           enemy.Attack();  // Session 6 polymorphism - each behaves uniquely
       }
   }
   ```

### Phase 3: Abstract Classes - Enforcing Contracts (25 minutes)
**Using `AbstractClassDemo.cs` - Professional Design Patterns:**

1. **The Problem: Inconsistent Implementation (5 minutes)**:
   ```csharp
   // What if we want ALL weapons to have certain methods?
   public class Sword
   {
       public void Attack() { /* sword attack */ }
       // Oops - forgot to implement Repair() method
   }
   
   public class Bow  
   {
       public void Attack() { /* bow attack */ }
       public void Repair() { /* bow repair */ }
       // Good - has both methods
   }
   
   // Problem: Inconsistent interface - some weapons missing methods!
   ```

2. **Abstract Class Solution - Enforced Contracts (15 minutes)**:
   ```csharp
   // Abstract class = cannot be instantiated directly
   public abstract class Weapon
   {
       // Regular fields and methods work normally
       protected string weaponName;
       protected int durability = 100;
       
       // Constructor from Session 5 knowledge
       public Weapon(string name)
       {
           weaponName = name;
           Debug.Log($"Weapon {name} created");
       }
       
       // Abstract method = child classes MUST implement
       public abstract void Attack();
       public abstract void Reload();
       
       // Virtual method = child classes CAN override (optional)
       public virtual void Repair()
       {
           durability = 100;
           Debug.Log($"{weaponName} repaired to full durability");
       }
       
       // Regular method = all child classes inherit (Session 5)
       public void DisplayInfo()
       {
           Debug.Log($"Weapon: {weaponName}, Durability: {durability}");
       }
   }
   ```

3. **Implementing Abstract Classes (5 minutes)**:
   ```csharp
   public class Sword : Weapon
   {
       public Sword(string name) : base(name) { }  // Session 5 constructor chaining
       
       // MUST implement abstract methods
       public override void Attack()
       {
           durability -= 2;
           Debug.Log($"{weaponName} slashes for heavy damage!");
       }
       
       public override void Reload()
       {
           Debug.Log($"{weaponName} doesn't need reloading - it's a sword!");
       }
       
       // CAN override virtual methods
       public override void Repair()
       {
           base.Repair();  // Call parent implementation
           Debug.Log($"{weaponName} blade sharpened to razor edge!");
       }
   }
   
   public class Bow : Weapon
   {
       private int arrows = 30;
       
       public Bow(string name) : base(name) { }
       
       public override void Attack()
       {
           if (arrows > 0)
           {
               arrows--;
               durability -= 1;
               Debug.Log($"{weaponName} fires arrow! Arrows remaining: {arrows}");
           }
           else
           {
               Debug.Log($"{weaponName} is out of arrows!");
           }
       }
       
       public override void Reload()
       {
           arrows = 30;
           Debug.Log($"{weaponName} quiver refilled with arrows");
       }
   }
   
   public class MagicStaff : Weapon
   {
       private int mana = 100;
       
       public MagicStaff(string name) : base(name) { }
       
       public override void Attack()
       {
           if (mana >= 10)
           {
               mana -= 10;
               Debug.Log($"{weaponName} casts magical projectile! Mana: {mana}");
           }
           else
           {
               Debug.Log($"{weaponName} needs mana to cast spells!");
           }
       }
       
       public override void Reload()
       {
           mana = 100;
           Debug.Log($"{weaponName} mana fully restored");
       }
   }
   ```


### Phase 4: Integration - Complete OOP Unit Mastery (20 minutes)

1. **Bringing It All Together - Sessions 5 & 6 Combined**:
   ```csharp
   // Complete game system using all OOP concepts
   public class GameBattleSystem
   {
       // Session 4: Collections for managing objects
       private static List<Enemy> allEnemies = new List<Enemy>();
       private static List<Weapon> availableWeapons = new List<Weapon>();
       
       // Session 5: Static members for global management
       public static int totalBattles = 0;
       
       public static void InitializeGame()
       {
           // Session 6: Polymorphic object creation
           allEnemies.Add(new Zombie("Guard Zombie"));
           allEnemies.Add(new Robot("Patrol Droid"));
           allEnemies.Add(new Wizard("Battle Mage"));
           
           // Session 6: Abstract class implementations
           availableWeapons.Add(new Sword("Iron Blade"));
           availableWeapons.Add(new Bow("Elven Longbow"));
           availableWeapons.Add(new MagicStaff("Staff of Power"));
       }
       
       public static void SimulateBattle()
       {
           totalBattles++;  // Session 5: Static counter
           
           Debug.Log($"=== BATTLE {totalBattles} BEGINS ===");
           
           // Session 6: Polymorphism - treat all enemies the same
           foreach (Enemy enemy in allEnemies)
           {
               enemy.Attack();  // Each enemy type behaves differently
           }
           
           // Session 6: Abstract classes - guaranteed interface
           foreach (Weapon weapon in availableWeapons)
           {
               weapon.Attack();  // Each weapon type attacks differently
               weapon.Reload();  // All weapons must implement reload
           }
           
           Debug.Log("=== BATTLE COMPLETE ===");
       }
   }
   ```

2. **Professional Game Development Patterns**:
   ```csharp
   // Factory pattern using inheritance (advanced)
   public static class EnemyFactory
   {
       public static Enemy CreateEnemy(string type, string name)
       {
           // Session 2: Switch statements + Session 6: Polymorphism
           switch (type.ToLower())  // Session 3: String methods
           {
               case "zombie": return new Zombie(name);
               case "robot": return new Robot(name);
               case "wizard": return new Wizard(name);
               default: return new Zombie(name);  // Default fallback
           }
       }
       
       // Create multiple enemies using Session 3: Loops
       public static List<Enemy> CreateEnemySquad(int count)
       {
           List<Enemy> squad = new List<Enemy>();  // Session 4: Lists
           string[] types = {"zombie", "robot", "wizard"};  // Session 4: Arrays
           
           for (int i = 0; i < count; i++)  // Session 3: For loops
           {
               string randomType = types[Random.Range(0, types.Length)];
               Enemy newEnemy = CreateEnemy(randomType, $"Enemy{i}");
               squad.Add(newEnemy);
           }
           
           return squad;
       }
   }
   ```

### Phase 5: Student Exercise and OOP Unit Completion (25 minutes)

**Student Challenges using `Session06_StudentExercise.cs`:**

1. **Vehicle Inheritance System**:
   - Create base Vehicle class with speed, fuel, and name
   - Implement Car, Motorcycle, and Truck derived classes
   - Override StartEngine() method for each vehicle type
   - Use polymorphism to manage fleet of different vehicles

2. **Character Class Hierarchy**:
   - Design base Character class with health, name, and level
   - Create Warrior, Mage, and Archer specialized classes
   - Implement unique abilities for each character type
   - Build battle system using polymorphic character interactions

3. **Abstract Shape System**:
   - Create abstract Shape base class with CalculateArea() method
   - Implement Circle, Rectangle, and Triangle derived classes
   - Use polymorphism to calculate total area of mixed shapes
   - Demonstrate professional mathematical object design

4. **Complete Game Integration Challenge**:
   - Combine Sessions 4, 5, and 6 concepts
   - Build inventory system using Lists (Session 4)
   - Create item class hierarchy with constructors (Session 5)
   - Use abstract base classes for consistent interfaces (Session 6)
   - Implement polymorphic item processing

### OOP Unit Achievement Celebration (10 minutes)

**What Students Have Mastered:**

1. **Session 5 Foundation** ✅:
   - Classes and objects as blueprints and instances
   - Constructors for flexible object creation
   - Access modifiers for secure, professional code
   - Static vs instance members for appropriate design

2. **Session 6 Advanced Concepts** ✅:
   - Inheritance for code reuse and specialization
   - Polymorphism for flexible, extensible systems
   - Abstract classes for enforced contracts
   - Professional object-oriented design patterns

3. **Integrated Skills** ✅:
   - **Sessions 1-3**: Programming fundamentals (variables, loops, methods)
   - **Session 4**: Collections for data management (arrays, lists)
   - **Sessions 5-6**: Object-oriented programming mastery
   - **Professional readiness**: Industry-standard coding practices

**Real-World Applications Students Can Now Build:**
- Complex game character systems with inheritance hierarchies
- Flexible enemy AI with polymorphic behaviors
- Modular weapon and item systems using abstract classes
- Scalable game architectures that are easy to extend and maintain

**Industry Skills Achieved:**
- Object-oriented design and implementation
- Code reusability and maintainability principles
- Professional software architecture patterns
- Team development practices with proper encapsulation


## Common Student Questions & Answers

**Q: When should I use inheritance vs just copying code?**  
A: Use inheritance when you have an "IS A" relationship. Zombie IS A Enemy, Car IS A Vehicle. If you find yourself copying the same methods and fields, inheritance eliminates that duplication and makes changes easier.

**Q: What's the difference between abstract and virtual methods?**  
A: **Abstract**: Child classes MUST implement (no choice). **Virtual**: Child classes CAN override (optional). Use abstract when every child needs custom behavior, virtual when some might want to customize.

**Q: Why can't I create an instance of an abstract class?**  
A: Abstract classes are incomplete - they have methods without implementations. You can only create instances of complete classes. Think of abstract classes as templates that require finishing touches.

**Q: How does polymorphism actually work under the hood?**  
A: When you call `enemy.Attack()` on an Enemy reference, C# checks the actual object type at runtime and calls the appropriate override method. This is called "dynamic dispatch" or "late binding."

**Q: Can I inherit from multiple classes like I can implement multiple interfaces?**  
A: C# only allows single inheritance from classes (to avoid complexity), but you can implement multiple interfaces. This is called the "diamond problem" solution.

**Q: When should I use `base.MethodName()` in overrides?**  
A: When you want to EXTEND parent behavior, not REPLACE it. Call `base.Method()` first to do the parent logic, then add your child-specific logic.

**Q: How do I know if I should make a method virtual?**  
A: Ask: "Might child classes want to customize this behavior?" If yes, make it virtual. If all children should behave identically, keep it non-virtual.

**Q: Is inheritance always better than composition?**  
A: No! Use inheritance for "IS A" relationships, composition for "HAS A" relationships. A Car HAS A Engine (composition), but a SportsCar IS A Car (inheritance).

## Assessment Checkpoints

### OOP Unit Mastery Check (Sessions 5-6 Combined):
- [ ] Can create base classes suitable for inheritance (Session 5 foundation)
- [ ] Implements derived classes with proper constructor chaining using base()
- [ ] Uses access modifiers correctly (public, private, protected) for inheritance
- [ ] Demonstrates polymorphism with arrays/lists of base class references
- [ ] Creates and implements abstract classes with required method contracts
- [ ] Overrides virtual methods appropriately for specialized behavior

### Advanced OOP Skills Check:
- [ ] Designs inheritance hierarchies that follow "IS A" relationships
- [ ] Uses polymorphism to write flexible, extensible code
- [ ] Applies abstract classes to enforce consistent interfaces
- [ ] Combines inheritance with composition for complex object relationships
- [ ] Implements factory patterns for object creation
- [ ] Demonstrates understanding of when to use inheritance vs composition

### Professional Development Check:
- [ ] Follows object-oriented design principles (SOLID basics)
- [ ] Creates classes with single responsibility and clear interfaces
- [ ] Uses proper naming conventions for base and derived classes
- [ ] Implements proper error handling in inheritance hierarchies
- [ ] Designs systems that are easy to extend with new derived classes

### Integration Skills Check (All Sessions 1-6):
- [ ] Combines collections (Session 4) with inheritance for object management
- [ ] Uses loops and methods (Session 3) with polymorphic object processing
- [ ] Applies conditional logic (Session 2) with object type checking and casting
- [ ] Integrates all fundamental concepts into coherent object-oriented systems

## Extension Activities

For students who finish early:

1. **Advanced Inheritance Patterns**:
   - Implement multiple levels of inheritance (Vehicle → Car → SportsCar)
   - Create mixin-like behavior using interfaces and composition
   - Design template method patterns with abstract base classes

2. **Professional Design Patterns**:
   - Implement Strategy pattern using abstract classes
   - Create Factory and Abstract Factory patterns for object creation
   - Design Observer pattern for event-driven game systems

3. **Complex Game Systems**:
   - Build complete RPG character system with multiple inheritance levels
   - Create modular weapon enhancement system using composition and inheritance
   - Design AI behavior trees using abstract command classes

4. **Performance and Architecture**:
   - Compare inheritance vs composition performance in large systems
   - Implement object pooling for inherited game objects
   - Design plugin architectures using abstract base classes

5. **Unity-Specific Advanced Patterns**:
   - Create custom Unity component hierarchies
   - Implement ScriptableObject inheritance for data-driven design
   - Build modular gameplay systems using abstract MonoBehaviour base classes


## Troubleshooting Common Issues

### **Inheritance and Polymorphism Errors**

**Error: "'BaseClass' does not contain a constructor that takes 0 arguments"**  
→ **Cause**: Derived class constructor not calling base class constructor with required parameters  
→ **Solution**: Use base() to call appropriate parent constructor
```csharp
// ❌ WRONG - base class needs parameters
public class Zombie : Enemy
{
    public Zombie(string name)  // ERROR - Enemy constructor needs parameters
    {
        // No base() call - tries to use default Enemy constructor that doesn't exist
    }
}

// ✅ CORRECT - Call base constructor
public class Zombie : Enemy
{
    public Zombie(string name) : base(name, 60, 8)  // Call Enemy(string, int, int)
    {
        // Now initialization works correctly
    }
}
```

**Error: "Cannot access protected member through a type; the member must be accessed through an instance"**  
→ **Cause**: Trying to access protected static members incorrectly  
→ **Solution**: Access protected members through instance, not type name

**Error: "'MethodName' cannot be sealed because it is not an override"**  
→ **Cause**: Using sealed keyword on non-virtual methods  
→ **Solution**: Only use sealed on override methods to prevent further overriding

### **Abstract Class Problems**

**Error: "Cannot create an instance of the abstract class or interface"**  
→ **Cause**: Trying to instantiate abstract class directly  
→ **Solution**: Create instances of derived classes instead
```csharp
// ❌ WRONG - can't instantiate abstract class
Weapon weapon = new Weapon("Test");  // ERROR

// ✅ CORRECT - instantiate derived class
Weapon sword = new Sword("Iron Blade");  // OK
```

**Error: "'DerivedClass' does not implement abstract member 'AbstractMethod'"**  
→ **Cause**: Derived class missing implementation of required abstract methods  
→ **Solution**: Implement ALL abstract methods in derived class
```csharp
public abstract class Weapon
{
    public abstract void Attack();  // Must be implemented
    public abstract void Reload();  // Must be implemented
}

public class Sword : Weapon
{
    public override void Attack() { /* implementation */ }  // Required
    public override void Reload() { /* implementation */ }  // Required
}
```

### **Virtual Method and Override Issues**

**Error: "'MethodName' hides inherited member. Use the new keyword if hiding was intended"**  
→ **Cause**: Method signature matches parent but missing override keyword  
→ **Solution**: Add override keyword or use new if intentionally hiding
```csharp
// ❌ WRONG - missing override keyword
public class Zombie : Enemy
{
    public void Attack()  // WARNING - hides Enemy.Attack()
    {
        // This creates a new method, doesn't override
    }
}

// ✅ CORRECT - use override
public class Zombie : Enemy
{
    public override void Attack()  // Properly overrides parent method
    {
        // This replaces parent implementation
    }
}
```

**Error: "'MethodName' cannot override inherited member because it is not marked virtual, abstract, or override"**  
→ **Cause**: Trying to override non-virtual method  
→ **Solution**: Make base method virtual or use new keyword for method hiding

### **Polymorphism and Casting Errors**

**Error: "Unable to cast object of type 'DerivedClass' to type 'OtherDerivedClass'"**  
→ **Cause**: Invalid cast between sibling classes in inheritance hierarchy  
→ **Solution**: Use proper type checking before casting
```csharp
// ❌ DANGEROUS - might fail at runtime
Zombie zombie = (Zombie)enemy;  // Fails if enemy is actually a Robot

// ✅ SAFE - check type first
if (enemy is Zombie zombie)
{
    zombie.Shamble();  // Only executes if enemy is actually a Zombie
}
```

### **Unity-Specific OOP Issues**

**Problem: Inherited MonoBehaviour classes not working as expected**  
→ **Cause**: Unity serialization issues with inheritance  
→ **Solution**: Understand Unity's component serialization limitations
```csharp
// Be careful with complex inheritance in MonoBehaviour
public abstract class BaseController : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;  // SerializeField for inherited access
}

public class PlayerController : BaseController
{
    // Can access speed field from parent
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
```

**Problem: Polymorphic references not showing in Inspector**  
→ **Cause**: Unity Inspector shows actual component type, not interface type  
→ **Solution**: Use component references and GetComponent<>() for polymorphic access


## Unity/Visual Studio Code Integration Notes

### **OOP Unit Completion Workflow**

1. **Advanced Code Organization**:
   - **Namespace organization**: Group related classes in folders and namespaces
   - **File naming conventions**: BaseClassName.cs, DerivedClassName.cs
   - **IntelliSense mastery**: VS Code shows inheritance relationships and available overrides
   - **Code navigation**: Use Go to Definition to trace inheritance hierarchies

2. **Visual Studio Code Advanced OOP Features**:
   - **Inheritance visualization**: VS Code shows class hierarchy in symbol explorer
   - **Override suggestions**: IntelliSense suggests available virtual methods to override
   - **Abstract method enforcement**: Red squiggles immediately show missing implementations
   - **Polymorphic type checking**: IntelliSense aware of runtime vs compile-time types

3. **Unity Inspector with Inheritance**:
   - **Component inheritance**: Derived MonoBehaviour classes show inherited fields
   - **Polymorphic references**: Inspector shows actual component type, not base type
   - **Serialization considerations**: Understand which inherited members serialize
   - **Performance monitoring**: Profile inherited vs composed object performance

### **OOP Unit Integration Assessment**

1. **Session 5 → Session 6 Continuity Verification**:
   - Students can explain how Session 5's protected members enable Session 6's inheritance
   - Constructor knowledge from Session 5 directly supports base() calls in Session 6
   - Access modifiers from Session 5 make complete sense in inheritance context
   - Static vs instance concepts support polymorphic utility method design

2. **Cross-Session Integration Mastery**:
   - **Sessions 1-3**: Fundamental programming skills integrated into object methods
   - **Session 4**: Collections used for managing polymorphic object arrays and lists
   - **Sessions 5-6**: Complete object-oriented programming mastery achieved
   - **Professional readiness**: Students can design and implement complex game systems

## Next Session Preview - Session 7: Interfaces & Management

**Building on OOP Unit Foundation:**
- **Interfaces extend inheritance**: Multiple contracts vs single parent class
- **Game state management**: Professional architecture patterns using OOP principles
- **Switch statements**: Advanced pattern matching for object type processing
- **System integration**: Combining all previous concepts into professional game architecture

**Advanced Architecture Skills:**
- **Interface-based design**: Flexible contracts for game system communication
- **Professional state management**: Menu systems, game states, scene transitions
- **Modular system design**: Plugin architectures using interfaces and abstract classes
- **Industry-standard patterns**: Command, Observer, State Machine implementations

---

## Files in This Session
- `InheritanceBasics.cs` - Complete enemy hierarchy building on Session 5 foundation
- `PolymorphismExample.cs` - Battle simulation with polymorphic behaviors and collections
- `AbstractClassDemo.cs` - Professional weapon system using abstract classes and contracts
- `Session06_StudentExercise.cs` - Comprehensive OOP unit completion exercises
- `Session06_Teaching_Guide.md` - This instructor guide

**Unity Scene**: `06_Advanced_OOP.unity` (continues from Session 5 scene)  
**Estimated Total Teaching Time**: 120-150 minutes  
**Prerequisites**: Sessions 1-5 (Complete programming foundation + OOP basics)  
**Completes**: OOP Unit (Sessions 5-6) - Students now have professional OOP skills
**Prepares For**: Session 7 (Interfaces, state management, advanced architecture)

---

## Teaching Tips for Success

### **OOP Unit Completion Strategy**

1. **Celebration and Achievement Recognition**:
   - **Emphasize accomplishment**: Students now have professional-level OOP skills
   - **Show progression**: From simple variables (Session 1) to complex inheritance hierarchies
   - **Real-world applications**: These are the same patterns used in AAA game development
   - **Industry readiness**: Students can now read and write professional C# codebases

2. **Seamless Session 5-6 Integration**:
   - **Constant references**: "Remember from Session 5 when we created the Enemy class?"
   - **Building metaphors**: "We built the foundation in Session 5, now we're adding specialized rooms"
   - **Progressive complexity**: Each concept builds naturally on previous knowledge
   - **Success validation**: Students see their Session 5 knowledge enabling Session 6 mastery

3. **Advanced Concept Accessibility**:
   - **Start with familiar**: Transform Session 5's Enemy class into inheritance hierarchy
   - **Visual demonstrations**: Show polymorphism with actual different behaviors in Unity
   - **Practical applications**: Every concept demonstrated with real game development examples
   - **Error prevention**: Emphasize common mistakes and how to avoid them

### **Critical Session 6 Teaching Moments**

1. **Inheritance "Aha!" Moment**:
   - Show copying 50 lines of Enemy code into Zombie, Robot, Wizard classes
   - Then show inheritance doing the same thing with 5 lines per class
   - Students immediately understand the power and elegance

2. **Polymorphism Magic**:
   - Create array of Enemy references containing different derived types
   - Call Attack() in a loop - watch different behaviors appear
   - Students see how one line of code can handle unlimited enemy types

3. **Abstract Class Purpose**:
   - Start with inconsistent weapon implementations (some missing methods)
   - Show how abstract class prevents compilation until all methods implemented
   - Students understand contracts and professional interface design

### **Student Engagement Strategies (OOP Unit)**

1. **Progressive Building**:
   - Session 5: "Build a simple Enemy class"
   - Session 6: "Now let's create 3 specialized enemy types without copying code"
   - Students experience the journey from basic to advanced

2. **Competitive Elements**:
   - "Design the most flexible character class hierarchy"
   - "Create weapon system that's easiest to extend with new weapons"
   - "Build enemy AI that can be enhanced without modifying existing code"

3. **Real-World Connection**:
   - "This is how World of Warcraft manages hundreds of different creatures"
   - "Unity's component system uses these exact inheritance patterns"
   - "Professional developers use abstract classes for plugin architectures"

### **Assessment Focus Points (OOP Unit Complete)**

- **Conceptual mastery**: Does student understand inheritance as specialization?
- **Design thinking**: Can student identify appropriate inheritance hierarchies?
- **Professional readiness**: Does student write code that follows industry standards?
- **Integration skills**: Can student combine OOP with all previous programming concepts?

**With Sessions 5-6 complete, students have achieved professional-level object-oriented programming mastery and are ready for advanced software architecture concepts in Sessions 7-8.**

