# Session 7: Interfaces & Game Management

## Session Overview

**Duration**: 130-160 minutes  
**W3Schools Topics**: Interface, Switch Statements, Exception Handling  
**Unity Concepts**: Game state management, professional architecture, modular systems  
**Course Position**: Advanced concepts building on completed OOP Unit (Sessions 5-6)

## Learning Objectives

By the end of this session, students will:
1. ✅ **Build on OOP Unit**: Extend inheritance concepts with interface contracts
2. ✅ Understand interfaces as multiple inheritance alternative for flexible design
3. ✅ Implement multiple interfaces in single classes for complex behaviors
4. ✅ Use switch statements for elegant conditional logic and state processing
5. ✅ Create professional game state management systems
6. ✅ Apply interface-based design patterns for modular game architecture
7. ✅ Integrate interfaces with inheritance for maximum flexibility
8. ✅ **Professional Architecture**: Build industry-standard game management systems

## Scripts Included

### 1. `InterfaceBasics.cs`
**Purpose**: Interface implementation with game entities building on Sessions 5-6 OOP knowledge  
**Key Features**:
- Interface contracts (IAttackable, IDamageable, IUpgradeable, IHealable)
- Multiple interface implementation in single classes
- Interface vs inheritance comparison using familiar enemy examples
- Polymorphism through interfaces extending Session 6 concepts
- Professional design patterns combining interfaces with inheritance
- **OOP Integration**: Uses Enemy classes from Sessions 5-6 as interface implementors

### 2. `SwitchStatementDemo.cs`
**Purpose**: Switch statement mastery vs if-else chains with modern C# features  
**Key Features**:
- Switch statements vs if-else performance and readability comparisons
- Input handling using switch statements for complex control schemes
- Switch expressions (modern C#) for concise conditional logic
- State processing and game difficulty management
- Pattern matching and advanced switch features
- **Sessions Integration**: Uses conditional logic knowledge from Session 2

### 3. `GameStateManager.cs`
**Purpose**: Professional state management system with Unity integration  
**Key Features**:
- State machine implementation (MainMenu, Loading, Playing, Paused, GameOver)
- State transitions with validation and event handling
- Unity integration with scene management and UI
- Professional game architecture patterns
- Modular system design using interfaces and state patterns
- **Course Integration**: Combines all previous sessions' concepts into professional system
## Teaching Sequence

### Phase 1: Interface Foundations - Extending OOP Unit Knowledge (35 minutes)
**Using `InterfaceBasics.cs` - Building on Sessions 5-6 OOP Mastery:**

1. **Recap OOP Unit Achievement (Review: 5 minutes)**:
   ```csharp
   // "Remember our Enemy hierarchy from Sessions 5-6?"
   public class Enemy  // Base class from Session 5
   {
       protected string name;
       protected int health;
       public virtual void Attack() { /* base implementation */ }
   }
   
   public class Zombie : Enemy  // Inheritance from Session 6
   {
       public override void Attack() { /* zombie-specific attack */ }
   }
   
   public class Robot : Enemy
   {
       public override void Attack() { /* robot-specific attack */ }
   }
   ```

2. **The Limitation of Single Inheritance (10 minutes)**:
   ```csharp
   // Problem: What if we want different capabilities across different classes?
   
   // ❌ LIMITATION - Can only inherit from ONE class
   public class Medic : Enemy  // Already inheriting from Enemy
   {
       // How do we make Medic also healable?
       // How do we make Medic also upgradeable?
       // We can't inherit from Healer AND Upgradeable classes!
   }
   
   // ❌ COPYING CODE - Without interfaces, we'd copy methods everywhere
   public class Player
   {
       public void Heal() { /* healing code */ }
       public void Upgrade() { /* upgrade code */ }
   }
   
   public class Medic  
   {
       public void Heal() { /* SAME healing code - duplication! */ }
       public void Upgrade() { /* SAME upgrade code - duplication! */ }
   }
   ```

3. **Interface Solution - Multiple Contracts (15 minutes)**:
   ```csharp
   // Interface = Contract (what you PROMISE to be able to do)
   public interface IAttackable
   {
       void Attack(GameObject target);
       int GetAttackDamage();
   }
   
   public interface IDamageable
   {
       void TakeDamage(int damage);
       bool IsAlive();
       int GetCurrentHealth();
   }
   
   public interface IHealable
   {
       void Heal(IDamageable target);
       int GetHealingPower();
   }
   
   public interface IUpgradeable
   {
       void Upgrade(string upgradeType);
       bool CanUpgrade();
   }
   
   // ✅ SOLUTION - Implement multiple interfaces!
   public class Medic : Enemy, IHealable, IUpgradeable  // Inheritance + Interfaces
   {
       // Inherited from Enemy: name, health, Attack()
       
       // Must implement IHealable contract
       public void Heal(IDamageable target)
       {
           int healAmount = 25;
           target.TakeDamage(-healAmount);  // Negative damage = healing
           Debug.Log($"{name} heals target for {healAmount} points");
       }
       
       public int GetHealingPower() { return 25; }
       
       // Must implement IUpgradeable contract
       public void Upgrade(string upgradeType)
       {
           switch (upgradeType)  // Session 7 switch statement!
           {
               case "healing":
                   // Upgrade healing power
                   break;
               case "armor":
                   // Upgrade defense
                   break;
           }
       }
       
       public bool CanUpgrade() { return true; }
   }
   ```

4. **Interface Polymorphism - Beyond Inheritance (5 minutes)**:
   ```csharp
   // Sessions 5-6: Polymorphism through inheritance
   Enemy[] enemies = { new Zombie("Z1"), new Robot("R1") };
   
   // Session 7: Polymorphism through interfaces
   IHealable[] healers = { new Medic("Medic1"), new Priest("Priest1"), new Potion("HealthPotion") };
   
   // Different classes, same interface contract
   foreach (IHealable healer in healers)
   {
       healer.Heal(someTarget);  // Each healer heals differently!
   }
   
   // Can even combine inheritance and interface polymorphism
   List<IAttackable> attackers = new List<IAttackable>();
   attackers.Add(new Zombie("Z1"));    // Zombie : Enemy, IAttackable
   attackers.Add(new Turret("T1"));    // Turret : IAttackable (no Enemy inheritance)
   attackers.Add(new Trap("Spike"));   // Trap : IAttackable (completely different hierarchy)
   ```

### Phase 2: Multiple Interface Implementation and Design Patterns (25 minutes)
**Advanced Interface Usage:**

1. **Complex Interface Combinations (10 minutes)**:
   ```csharp
   // Realistic game entity with multiple capabilities
   public class Player : IAttackable, IDamageable, IHealable, IUpgradeable
   {
       private int health = 100;
       private int attackPower = 20;
       private int healingPower = 15;
       
       // IAttackable implementation
       public void Attack(GameObject target)
       {
           IDamageable damageable = target.GetComponent<IDamageable>();
           if (damageable != null)
           {
               damageable.TakeDamage(GetAttackDamage());
           }
       }
       
       public int GetAttackDamage() { return attackPower; }
       
       // IDamageable implementation
       public void TakeDamage(int damage)
       {
           health -= damage;
           if (health < 0) health = 0;
           Debug.Log($"Player health: {health}");
       }
       
       public bool IsAlive() { return health > 0; }
       public int GetCurrentHealth() { return health; }
       
       // IHealable implementation
       public void Heal(IDamageable target)
       {
           // Negative damage = healing
           target.TakeDamage(-healingPower);
       }
       
       public int GetHealingPower() { return healingPower; }
       
       // IUpgradeable implementation
       public void Upgrade(string upgradeType)
       {
           switch (upgradeType)  // Modern switch statement
           {
               case "attack":
                   attackPower += 5;
                   break;
               case "healing":
                   healingPower += 3;
                   break;
               case "health":
                   health += 20;
                   break;
           }
       }
       
       public bool CanUpgrade() { return true; }
   }
   ```

2. **Interface Segregation Principle (10 minutes)**:
   ```csharp
   // ❌ BAD - Fat interface (forces unnecessary implementations)
   public interface IBadGameEntity
   {
       void Attack();
       void TakeDamage(int damage);
       void Heal();
       void Upgrade();
       void Fly();
       void Swim();
       void Cast();
       // Not every entity needs ALL of these!
   }
   
   // ✅ GOOD - Segregated interfaces (implement only what you need)
   public interface IAttackable { void Attack(); }
   public interface IDamageable { void TakeDamage(int damage); }
   public interface IHealable { void Heal(); }
   public interface IUpgradeable { void Upgrade(); }
   public interface IFlying { void Fly(); }
   public interface ISwimming { void Swim(); }
   public interface IMagical { void Cast(); }
   
   // Implementations choose only relevant interfaces
   public class Fish : IDamageable, ISwimming { /* only what fish need */ }
   public class Bird : IDamageable, IFlying { /* only what birds need */ }
   public class Wizard : IAttackable, IDamageable, IMagical { /* only what wizards need */ }
   ```

3. **Professional Unity Integration (5 minutes)**:
   ```csharp
   // Unity component system using interfaces
   public class CombatController : MonoBehaviour
   {
       void Update()
       {
           if (Input.GetKeyDown(KeyCode.Space))
           {
               // Find all attackable entities
               IAttackable[] attackers = FindObjectsOfType<MonoBehaviour>()
                   .OfType<IAttackable>()
                   .ToArray();
               
               foreach (IAttackable attacker in attackers)
               {
                   attacker.Attack(this.gameObject);
               }
           }
       }
   }
   ```


### Phase 3: Switch Statement Mastery (25 minutes)
**Using `SwitchStatementDemo.cs` - Building on Session 2 Conditional Logic:**

1. **Recall Session 2 If-Else Chains (5 minutes)**:
   ```csharp
   // Session 2: We learned if-else statements
   public void ProcessInput(KeyCode key)
   {
       if (key == KeyCode.W)
           MoveUp();
       else if (key == KeyCode.A)
           MoveLeft();
       else if (key == KeyCode.S)
           MoveDown();
       else if (key == KeyCode.D)
           MoveRight();
       else if (key == KeyCode.Space)
           Attack();
       else if (key == KeyCode.E)
           Interact();
       else
           Debug.Log("Unknown key");
   }
   ```

2. **Switch Statement Elegance (10 minutes)**:
   ```csharp
   // Session 7: Switch statements are cleaner for multiple conditions
   public void ProcessInput(KeyCode key)
   {
       switch (key)
       {
           case KeyCode.W:
               MoveUp();
               break;
           case KeyCode.A:
               MoveLeft();
               break;
           case KeyCode.S:
               MoveDown();
               break;
           case KeyCode.D:
               MoveRight();
               break;
           case KeyCode.Space:
               Attack();
               break;
           case KeyCode.E:
               Interact();
               break;
           default:
               Debug.Log("Unknown key");
               break;
       }
   }
   
   // Modern C# Switch Expressions (even more concise)
   public string GetMovementDirection(KeyCode key) => key switch
   {
       KeyCode.W => "Up",
       KeyCode.A => "Left", 
       KeyCode.S => "Down",
       KeyCode.D => "Right",
       _ => "None"  // Default case
   };
   ```

3. **Advanced Switch Patterns (10 minutes)**:
   ```csharp
   // Switch with multiple values
   public void ProcessGameInput(KeyCode key)
   {
       switch (key)
       {
           case KeyCode.W:
           case KeyCode.UpArrow:
               MoveUp();
               break;
               
           case KeyCode.A:
           case KeyCode.LeftArrow:
               MoveLeft();
               break;
               
           case KeyCode.Escape:
           case KeyCode.P:
               TogglePause();
               break;
       }
   }
   
   // Switch with complex conditions
   public void ProcessCombatAction(string action, bool hasWeapon, int mana)
   {
       switch (action)
       {
           case "attack" when hasWeapon:
               PerformMeleeAttack();
               break;
               
           case "attack" when !hasWeapon:
               PerformUnarmedAttack();
               break;
               
           case "cast" when mana >= 10:
               CastSpell();
               break;
               
           case "cast" when mana < 10:
               Debug.Log("Not enough mana!");
               break;
               
           default:
               Debug.Log("Invalid action");
               break;
       }
   }
   
   // Interface-based switch (combining with Phase 2)
   public void ProcessEntity(object entity)
   {
       switch (entity)
       {
           case IAttackable attacker:
               attacker.Attack(target);
               break;
               
           case IHealable healer:
               healer.Heal(target);
               break;
               
           case IUpgradeable upgradeable when upgradeable.CanUpgrade():
               upgradeable.Upgrade("basic");
               break;
               
           default:
               Debug.Log("Entity cannot perform actions");
               break;
       }
   }
   ```

### Phase 4: Professional Game State Management (35 minutes)
**Using `GameStateManager.cs` - Complete System Architecture:**

1. **Game State Enumeration and Management (15 minutes)**:
   ```csharp
   // Define all possible game states
   public enum GameState
   {
       MainMenu,
       Loading,
       Playing,
       Paused,
       GameOver,
       Settings,
       Credits
   }
   
   public class GameStateManager : MonoBehaviour
   {
       // Session 5: Static singleton pattern for global access
       public static GameStateManager Instance { get; private set; }
       
       // Current state tracking
       private GameState currentState = GameState.MainMenu;
       private GameState previousState = GameState.MainMenu;
       
       // Unity lifecycle integration
       void Awake()
       {
           // Singleton pattern ensuring only one GameStateManager
           if (Instance != null && Instance != this)
           {
               Destroy(gameObject);
               return;
           }
           
           Instance = this;
           DontDestroyOnLoad(gameObject);  // Persist across scenes
       }
       
       void Start()
       {
           ChangeState(GameState.MainMenu);
       }
       
       void Update()
       {
           // State-specific update logic
           switch (currentState)
           {
               case GameState.Playing:
                   UpdateGameplay();
                   break;
                   
               case GameState.Paused:
                   UpdatePauseMenu();
                   break;
                   
               case GameState.MainMenu:
                   UpdateMainMenu();
                   break;
           }
       }
   }
   ```

2. **State Transitions with Validation (10 minutes)**:
   ```csharp
   public class GameStateManager : MonoBehaviour
   {
       // Safe state changing with validation
       public bool ChangeState(GameState newState)
       {
           if (!IsValidTransition(currentState, newState))
           {
               Debug.LogWarning($"Invalid transition from {currentState} to {newState}");
               return false;
           }
           
           // Exit current state
           ExitState(currentState);
           
           // Update state tracking
           previousState = currentState;
           currentState = newState;
           
           // Enter new state
           EnterState(newState);
           
           Debug.Log($"State changed: {previousState} → {currentState}");
           return true;
       }
       
       private bool IsValidTransition(GameState from, GameState to)
       {
           // Define valid state transitions
           return (from, to) switch
           {
               (GameState.MainMenu, GameState.Loading) => true,
               (GameState.MainMenu, GameState.Settings) => true,
               (GameState.MainMenu, GameState.Credits) => true,
               
               (GameState.Loading, GameState.Playing) => true,
               
               (GameState.Playing, GameState.Paused) => true,
               (GameState.Playing, GameState.GameOver) => true,
               
               (GameState.Paused, GameState.Playing) => true,
               (GameState.Paused, GameState.MainMenu) => true,
               
               (GameState.GameOver, GameState.MainMenu) => true,
               (GameState.GameOver, GameState.Loading) => true,  // Restart
               
               (GameState.Settings, GameState.MainMenu) => true,
               (GameState.Credits, GameState.MainMenu) => true,
               
               _ => false  // All other transitions invalid
           };
       }
   }
   ```

3. **State-Specific Behavior Implementation (10 minutes)**:
   ```csharp
   private void EnterState(GameState state)
   {
       switch (state)
       {
           case GameState.MainMenu:
               Time.timeScale = 1f;  // Normal time
               // Show main menu UI
               // Hide game UI
               break;
               
           case GameState.Loading:
               // Show loading screen
               // Start loading assets
               break;
               
           case GameState.Playing:
               Time.timeScale = 1f;  // Normal time
               // Hide all menus
               // Show game UI
               // Resume game logic
               break;
               
           case GameState.Paused:
               Time.timeScale = 0f;  // Freeze time
               // Show pause menu
               // Save game state
               break;
               
           case GameState.GameOver:
               // Show game over screen
               // Calculate final score
               // Save high scores
               break;
       }
   }
   
   private void ExitState(GameState state)
   {
       switch (state)
       {
           case GameState.MainMenu:
               // Hide main menu
               break;
               
           case GameState.Playing:
               // Pause background music
               // Save current progress
               break;
               
           case GameState.Paused:
               Time.timeScale = 1f;  // Resume time
               break;
       }
   }
   
   // State-specific update methods
   private void UpdateGameplay()
   {
       // Handle pause input
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           ChangeState(GameState.Paused);
       }
       
       // Check win/lose conditions
       if (PlayerHealth <= 0)
       {
           ChangeState(GameState.GameOver);
       }
   }
   
   private void UpdatePauseMenu()
   {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           ChangeState(GameState.Playing);  // Resume
       }
   }
   
   private void UpdateMainMenu()
   {
       if (Input.GetKeyDown(KeyCode.Return))
       {
           ChangeState(GameState.Loading);  // Start game
       }
   }
   ```


### Phase 5: Advanced Integration - All Concepts Combined (20 minutes)

1. **Complete Game System Architecture (15 minutes)**:
   ```csharp
   // Combining interfaces, inheritance, and state management
   public class CompleteGameSystem : MonoBehaviour
   {
       // Sessions 4-6: Collections and OOP for entity management
       private List<IAttackable> activeAttackers = new List<IAttackable>();
       private List<IDamageable> damageable = new List<IDamageable>();
       
       // Session 7: Interface-based system registration
       public void RegisterEntity(MonoBehaviour entity)
       {
           // Switch statement with interface checking
           switch (entity)
           {
               case IAttackable attacker:
                   activeAttackers.Add(attacker);
                   Debug.Log($"Registered attacker: {entity.name}");
                   break;
                   
               case IDamageable target:
                   damageableEntities.Add(target);
                   Debug.Log($"Registered damageable: {entity.name}");
                   break;
           }
           
           // Can implement multiple interfaces
           if (entity is IHealable healer)
           {
               healers.Add(healer);
           }
           
           if (entity is IUpgradeable upgradeable)
           {
               upgradeableEntities.Add(upgradeable);
           }
       }
       
       // Process all entities based on current game state
       void Update()
       {
           switch (GameStateManager.Instance.CurrentState)
           {
               case GameState.Playing:
                   ProcessGameplayEntities();
                   break;
                   
               case GameState.Paused:
                   // No entity processing during pause
                   break;
                   
               case GameState.GameOver:
                   ProcessGameOverEntities();
                   break;
           }
       }
       
       private void ProcessGameplayEntities()
       {
           // Auto-attack system using interfaces
           foreach (IAttackable attacker in activeAttackers)
           {
               if (damageableEntities.Count > 0)
               {
                   IDamageable target = damageableEntities[0];  // Simple targeting
                   attacker.Attack(target as GameObject);
               }
           }
           
           // Auto-healing system
           foreach (IHealable healer in healers)
           {
               foreach (IDamageable target in damageableEntities)
               {
                   if (!target.IsAlive())
                   {
                       healer.Heal(target);
                       break;
                   }
               }
           }
       }
   }
   
   // Complete entity example using all concepts
   public class AdvancedPlayer : MonoBehaviour, IAttackable, IDamageable, IHealable, IUpgradeable
   {
       // Session 5: Private fields with public methods
       [SerializeField] private int health = 100;
       [SerializeField] private int maxHealth = 100;
       [SerializeField] private int attackPower = 25;
       [SerializeField] private int healingPower = 20;
       
       // Interface implementations with state management awareness
       public void Attack(GameObject target)
       {
           if (GameStateManager.Instance.CurrentState != GameState.Playing)
               return;  // Can't attack when not playing
           
           IDamageable damageable = target.GetComponent<IDamageable>();
           damageable?.TakeDamage(GetAttackDamage());
       }
       
       public int GetAttackDamage()
       {
           // Switch-based damage calculation
           return GameStateManager.Instance.GetDifficulty() switch
           {
               "Easy" => attackPower,
               "Normal" => (int)(attackPower * 1.2f),
               "Hard" => (int)(attackPower * 1.5f),
               _ => attackPower
           };
       }
       
       public void TakeDamage(int damage)
       {
           health -= damage;
           health = Mathf.Clamp(health, 0, maxHealth);
           
           if (!IsAlive())
           {
               GameStateManager.Instance.ChangeState(GameState.GameOver);
           }
       }
       
       public bool IsAlive() => health > 0;
       public int GetCurrentHealth() => health;
       
       public void Heal(IDamageable target)
       {
           target.TakeDamage(-healingPower);  // Negative damage = healing
       }
       
       public int GetHealingPower() => healingPower;
       
       public void Upgrade(string upgradeType)
       {
           switch (upgradeType)
           {
               case "health":
                   maxHealth += 20;
                   health = maxHealth;  // Full heal on upgrade
                   break;
               case "attack":
                   attackPower += 5;
                   break;
               case "healing":
                   healingPower += 5;
                   break;
           }
       }
       
       public bool CanUpgrade() => true;
   }
   ```

2. **Professional Architecture Benefits (5 minutes)**:
   - **Modularity**: Systems work independently through interface contracts
   - **Extensibility**: Add new entity types without modifying existing systems
   - **Testability**: Mock interfaces for unit testing
   - **Team Development**: Different developers can work on systems implementing same interfaces
   - **Performance**: Interface-based systems can be optimized independently

### Phase 6: Student Exercise and Professional Practice (20 minutes)

**Student Challenges using `Session07_StudentExercise.cs`:**

1. **Interface Design Challenge**:
   - Create inventory system interfaces (ICollectable, IUseable, IValuable)
   - Implement different item types (Weapon, Potion, Treasure)
   - Use polymorphism to process mixed item collections

2. **Combat System Architecture**:
   - Design combat interfaces (IFighter, IHealable, IMagicUser)
   - Create character classes implementing multiple interfaces
   - Build turn-based combat using interface contracts

3. **Switch Statement Mastery**:
   - Implement complex input handling with modern switch patterns
   - Create difficulty processing system using switch expressions
   - Build quest system with switch-based state processing

4. **Complete Game Manager Integration**:
   - Extend GameStateManager with custom states
   - Implement state-specific behavior for different game modes
   - Create save/load system that respects game states

### **🎯 Session 7 Professional Achievement**

**What Students Have Mastered:**

1. **Interface Mastery** ✅:
   - Interface contracts and multiple implementation
   - Polymorphism through interfaces vs inheritance
   - Professional design patterns and architecture

2. **Switch Statement Expertise** ✅:
   - Modern switch statements and expressions
   - Pattern matching and conditional logic
   - Performance benefits over if-else chains

3. **Game State Management** ✅:
   - Professional state machine implementation
   - State transition validation and management
   - Unity integration with scene and time management

4. **Advanced Architecture Skills** ✅:
   - Modular system design using interfaces
   - Separation of concerns and single responsibility
   - Industry-standard game development patterns

**Professional Readiness Achieved:**
- Can design and implement complex game systems
- Understands professional software architecture patterns
- Ready for team development with clear interface contracts
- Prepared for advanced topics in Session 8 (final integration)


## Common Student Questions & Answers

**Q: What's the difference between interfaces and abstract classes from Session 6?**  
A: **Interfaces** define WHAT you can do (contracts), **abstract classes** provide SOME implementation you can build on. Use interfaces for "CAN DO" relationships (IAttackable), abstract classes for "IS A" relationships with shared code.

**Q: Can a class implement multiple interfaces but only inherit from one class?**  
A: Yes! That's the power of interfaces. You can inherit from one base class (Session 6) AND implement many interfaces (Session 7): `class Player : Character, IAttackable, IHealable, IUpgradeable`

**Q: When should I use switch statements instead of if-else?**  
A: Use **switch** when checking the same variable against multiple specific values. It's more readable, faster, and the compiler can optimize it better. Use **if-else** for complex conditions and ranges.

**Q: Why are interfaces better than just copying methods between classes?**  
A: Interfaces provide **contracts** - they guarantee methods exist without copying code. You can treat different classes the same way, change implementations without breaking other code, and test systems independently.

**Q: How do I know what interfaces to create for my game?**  
A: Look for **common behaviors** across different classes. If multiple different things can "attack," create IAttackable. If multiple things can "take damage," create IDamageable. Think about verbs (actions) classes perform.

**Q: Can interfaces have fields like classes do?**  
A: No, interfaces can only have method signatures, properties, and events. They can't have fields or implementation (except default interface methods in C# 8+). Keep data in implementing classes.

**Q: What's the point of game state management? Can't I just use booleans?**  
A: State machines prevent **invalid states** and make transitions explicit. Instead of `bool isPaused, isGameOver, isLoading` (8 possible combinations!), you have one clear state with controlled transitions.

**Q: How do I handle states that need to remember previous states?**  
A: Store `previousState` like in our GameStateManager. This lets you implement "go back" functionality and context-sensitive transitions.

## Assessment Checkpoints

### Advanced Programming Mastery Check:
- [ ] Can explain interface contracts vs inheritance relationships
- [ ] Implements multiple interfaces correctly in single classes
- [ ] Uses switch statements appropriately for conditional logic
- [ ] Creates professional state management systems
- [ ] Understands when to use interfaces vs abstract classes vs inheritance
- [ ] Demonstrates interface-based polymorphism

### Professional Architecture Skills Check:
- [ ] Designs modular systems using interface contracts
- [ ] Implements separation of concerns in game systems
- [ ] Creates extensible architectures that support new features
- [ ] Uses appropriate design patterns (State, Strategy, Observer basics)
- [ ] Writes code that follows professional standards and is team-ready

### Integration Mastery Check (All Sessions 1-7):
- [ ] Combines interface design with inheritance hierarchies from Sessions 5-6
- [ ] Uses collections (Session 4) to manage interface-based polymorphic objects
- [ ] Applies loops and methods (Session 3) in state management systems
- [ ] Integrates conditional logic (Session 2) with modern switch statements
- [ ] Demonstrates complete understanding of professional game development patterns

### Unity Professional Integration Check:
- [ ] Integrates interface systems with Unity component architecture
- [ ] Uses state management with Unity scene and time management
- [ ] Implements professional singleton patterns for global game management
- [ ] Creates systems that work across multiple Unity scenes
- [ ] Demonstrates understanding of Unity-specific architectural considerations

## Extension Activities

For students who finish early:

1. **Advanced Interface Patterns**:
   - Implement Command pattern using interfaces for undo/redo systems
   - Create Observer pattern for event-driven game systems
   - Design Strategy pattern for different AI behaviors

2. **Complex State Management**:
   - Implement hierarchical state machines (nested states)
   - Create state history and replay systems
   - Design conditional state transitions based on game data

3. **Professional Architecture Patterns**:
   - Build plugin system using interfaces for modular gameplay
   - Create dependency injection patterns for testable code
   - Implement facade pattern for complex system interaction

4. **Advanced Switch Statement Usage**:
   - Use switch expressions for functional programming patterns
   - Implement pattern matching with object deconstruction
   - Create state transition tables using switch statements

5. **Complete Game System Integration**:
   - Build comprehensive game framework combining all session concepts
   - Create modular component system using interfaces and inheritance
   - Design data-driven game systems using interfaces for configuration


## Troubleshooting Common Issues

### **Interface Implementation Errors**

**Error: "'ClassName' does not implement interface member 'InterfaceName.MethodName'"**  
→ **Cause**: Class declares interface implementation but missing required methods  
→ **Solution**: Implement ALL interface methods with exact signatures
```csharp
// ❌ WRONG - missing required methods
public class Player : IAttackable
{
    // ERROR - Attack() method missing
}

// ✅ CORRECT - implement all interface methods
public class Player : IAttackable
{
    public void Attack(GameObject target) { /* implementation */ }
    public int GetAttackDamage() { /* implementation */ }
}
```

**Error: "'ClassName' already defines a member called 'MethodName'"**  
→ **Cause**: Multiple interfaces with same method name or interface method conflicts with existing method  
→ **Solution**: Use explicit interface implementation
```csharp
public interface IAttackable { void Attack(); }
public interface IDefendable { void Attack(); }  // Same method name!

public class Fighter : IAttackable, IDefendable
{
    // Explicit interface implementation
    void IAttackable.Attack() { /* offensive attack */ }
    void IDefendable.Attack() { /* defensive counter-attack */ }
}
```

### **Switch Statement Problems**

**Error: "Control cannot fall through from one case label to another"**  
→ **Cause**: Missing break statement in switch case  
→ **Solution**: Always include break, return, or goto in each case
```csharp
// ❌ WRONG - missing break statements
switch (gameState)
{
    case GameState.Playing:
        UpdateGame();
        // ERROR - no break!
    case GameState.Paused:
        UpdatePause();
        break;
}

// ✅ CORRECT - proper break statements
switch (gameState)
{
    case GameState.Playing:
        UpdateGame();
        break;  // Required!
    case GameState.Paused:
        UpdatePause();
        break;
}
```

**Error: "A switch expression does not handle all possible values"**  
→ **Cause**: Modern switch expressions missing default case or enum values  
→ **Solution**: Add default case or handle all enum values
```csharp
// ❌ WRONG - missing default case
string GetStateDescription(GameState state) => state switch
{
    GameState.Playing => "Game Active",
    GameState.Paused => "Game Paused"
    // ERROR - missing other enum values and default
};

// ✅ CORRECT - handle all cases
string GetStateDescription(GameState state) => state switch
{
    GameState.Playing => "Game Active",
    GameState.Paused => "Game Paused",
    GameState.MainMenu => "In Menu",
    GameState.GameOver => "Game Finished",
    _ => "Unknown State"  // Default case
};
```

### **State Management Issues**

**Problem: State machine gets stuck in invalid states**  
→ **Cause**: State transition validation not comprehensive enough  
→ **Solution**: Implement thorough validation and error recovery
```csharp
public bool ChangeState(GameState newState)
{
    if (!IsValidTransition(currentState, newState))
    {
        Debug.LogError($"Invalid transition: {currentState} → {newState}");
        // Recovery: return to safe state
        ForceState(GameState.MainMenu);
        return false;
    }
    // ... proceed with valid transition
}

private void ForceState(GameState safeState)
{
    Debug.LogWarning($"Force transitioning to safe state: {safeState}");
    currentState = safeState;
    EnterState(safeState);
}
```

**Problem: State changes not reflected in Unity Inspector**  
→ **Cause**: State variables not serialized or Inspector not updating  
→ **Solution**: Use [SerializeField] and force Inspector updates
```csharp
[SerializeField] private GameState currentState = GameState.MainMenu;  // Visible in Inspector

#if UNITY_EDITOR
void OnValidate()  // Called when Inspector values change
{
    UnityEditor.EditorApplication.delayCall += () => 
    {
        if (this != null) UnityEditor.EditorUtility.SetDirty(this);
    };
}
#endif
```

### **Interface Polymorphism Confusion**

**Problem: Interface casting fails at runtime**  
→ **Cause**: Object doesn't actually implement expected interface  
→ **Solution**: Use safe casting with is/as operators
```csharp
// ❌ DANGEROUS - can throw InvalidCastException
IAttackable attacker = (IAttackable)gameObject.GetComponent<MonoBehaviour>();

// ✅ SAFE - check before casting
if (gameObject.GetComponent<MonoBehaviour>() is IAttackable attacker)
{
    attacker.Attack(target);
}

// ✅ ALSO SAFE - null check with as operator
IAttackable attacker = gameObject.GetComponent<MonoBehaviour>() as IAttackable;
if (attacker != null)
{
    attacker.Attack(target);
}
```

### **Unity-Specific Interface Issues**

**Problem: Unity serialization doesn't work with interface references**  
→ **Cause**: Unity serializer doesn't support interface types directly  
→ **Solution**: Use MonoBehaviour references and GetComponent<>()
```csharp
// ❌ WRONG - Unity can't serialize interface references
[SerializeField] private IAttackable attackableEntity;  // Won't show in Inspector

// ✅ CORRECT - serialize MonoBehaviour, cast at runtime
[SerializeField] private MonoBehaviour attackableObject;

void Start()
{
    if (attackableObject is IAttackable attacker)
    {
        // Use attacker interface
    }
}
```

**Problem: FindObjectsOfType doesn't work with interfaces**  
→ **Cause**: Unity's FindObjectsOfType only works with MonoBehaviour types  
→ **Solution**: Find MonoBehaviours then filter by interface
```csharp
// ❌ WRONG - FindObjectsOfType doesn't work with interfaces
IAttackable[] attackers = FindObjectsOfType<IAttackable>();  // Doesn't work

// ✅ CORRECT - find MonoBehaviours then filter
IAttackable[] attackers = FindObjectsOfType<MonoBehaviour>()
    .OfType<IAttackable>()
    .ToArray();
```


## Unity/Visual Studio Code Integration Notes

### **Session 7 Specific Workflow**

1. **Interface Development Process**:
   - **Design interfaces first**: Plan contracts before implementing classes
   - **Use IntelliSense**: VS Code shows interface requirements and auto-implements
   - **Visual validation**: Red squiggles immediately show missing interface implementations
   - **Multiple interface support**: IntelliSense handles complex interface combinations

2. **Visual Studio Code Advanced Features**:
   - **Interface navigation**: Go to Definition works with interface contracts
   - **Implementation assistance**: Right-click → "Implement Interface" auto-generates method stubs
   - **Switch statement support**: IntelliSense suggests switch cases for enums
   - **Error detection**: Immediate feedback for interface contract violations

3. **Unity Inspector with Advanced Patterns**:
   - **State visualization**: [SerializeField] GameState shows current state in Inspector
   - **Interface references**: Use MonoBehaviour references, cast to interfaces at runtime
   - **Singleton patterns**: DontDestroyOnLoad objects persist across scene transitions
   - **Performance monitoring**: Profile interface-based polymorphic calls

### **Professional Development Workflow**

1. **Team Development Considerations**:
   - **Interface contracts**: Define interfaces first for team coordination
   - **Modular development**: Different developers can implement same interfaces independently
   - **Testing strategies**: Mock interfaces for unit testing complex systems
   - **Documentation**: Interface contracts serve as system documentation

2. **Debugging Complex Systems**:
   - **State visualization**: Use Debug.Log for state transitions and validation
   - **Interface type checking**: Use debugger to verify interface implementations
   - **Polymorphic debugging**: Watch variables show actual object types vs interface types
   - **State machine visualization**: Consider state machine debugging tools for complex systems

## Next Session Preview - Session 8: Data & Final Project

**Capstone Integration:**
- **File I/O and data persistence**: Save/load systems using all previous concepts
- **Complete mini-game project**: Integration of Sessions 1-7 into professional game
- **Advanced data structures**: Dictionaries and complex data management
- **Professional deployment**: Complete game systems ready for production

**Final Skills Achievement:**
- **Complete C# mastery**: From variables to advanced architecture patterns
- **Professional game development**: Industry-standard practices and patterns
- **Portfolio-ready projects**: Demonstrable skills for employment opportunities
- **Advanced Unity integration**: Professional-level Unity development capabilities

---

## Files in This Session
- `InterfaceBasics.cs` - Interface contracts and multiple implementation patterns
- `SwitchStatementDemo.cs` - Switch statement mastery with modern C# features
- `GameStateManager.cs` - Professional state management system with Unity integration
- `Session07_StudentExercise.cs` - Comprehensive interface and state management practice
- `Session07_Teaching_Guide.md` - This instructor guide

**Unity Scene**: `07_Interfaces_Management.unity`  
**Estimated Total Teaching Time**: 130-160 minutes  
**Prerequisites**: Sessions 1-6 (Complete programming foundation + OOP unit)  
**Prepares For**: Session 8 (Final integration and professional project completion)

---

## Teaching Tips for Success

### **Critical Session 7 Concepts to Emphasise**

1. **Interface Mental Model**:
   - **Contracts analogy**: "Interface = what you promise to be able to do"
   - **Multiple capabilities**: One class can sign multiple contracts (interfaces)
   - **Flexibility demonstration**: Show same interface implemented very differently
   - **Professional importance**: Emphasize this is how large teams coordinate

2. **State Management Importance**:
   - **Start with chaos**: Show game with boolean state flags getting confused
   - **Introduce order**: State machine prevents invalid combinations
   - **Professional patterns**: This is how AAA games manage complex systems
   - **Unity integration**: Show how it connects to scene management and UI

3. **Switch Statement Evolution**:
   - **From Session 2**: Build on if-else knowledge students already have
   - **Readability focus**: Multiple conditions become much clearer
   - **Modern features**: Show how C# keeps improving with new syntax
   - **Performance benefits**: Explain compiler optimizations

### **Advanced Concept Accessibility**

1. **Interface Complexity Management**:
   - **Start simple**: Single interface with one method
   - **Build gradually**: Add more methods, then multiple interfaces
   - **Show problems first**: Demonstrate limitations of inheritance alone
   - **Reveal solutions**: Interfaces solve the multiple inheritance problem elegantly

2. **State Machine Visualization**:
   - **Draw diagrams**: Visual state transitions on whiteboard/screen
   - **Interactive demonstration**: Change states in Unity and show effects
   - **Error demonstration**: Show what happens with invalid transitions
   - **Professional context**: Explain how this scales to complex games

### **Student Engagement Strategies**

1. **Interface Design Challenges**:
   - "Design interfaces for a complete RPG system"
   - "Create modular inventory system using only interfaces"
   - "Build plugin architecture for different weapon types"

2. **State Management Games**:
   - "Create the most robust pause system possible"
   - "Design state machine for complex menu navigation"
   - "Build game that gracefully handles any transition attempt"

3. **Real-World Connection**:
   - "This is how Unity's component system works internally"
   - "Professional games use these exact patterns for mod support"
   - "Interface-based design enables automated testing in studios"

### **Assessment Focus Points**

- **Architectural thinking**: Does student design systems that are extensible and maintainable?
- **Interface appropriateness**: Can student identify when interfaces are better than inheritance?
- **State management understanding**: Does student create robust systems that handle edge cases?
- **Professional readiness**: Is student code ready for team development and production use?

### **Course Progression Recognition**

**Major Achievement Milestone**: With Session 7 complete, students have achieved:
- **Complete programming fundamentals** (Sessions 1-4)
- **Professional object-oriented design** (Sessions 5-6)
- **Advanced architecture patterns** (Session 7)
- **Ready for capstone integration** (Session 8)

Students now possess professional-level programming skills and are prepared for the final integration session that will demonstrate their complete mastery of modern C# game development.

### **Session 7 Success Indicators**

- Students can explain when to use interfaces vs inheritance vs composition
- Students create modular systems that multiple team members could work on
- Students implement professional state management that handles edge cases gracefully  
- Students combine all previous session concepts into cohesive architectural patterns
- Students demonstrate understanding of professional software development practices

**Session 7 establishes students as competent professional developers ready for advanced project work and team collaboration.**

