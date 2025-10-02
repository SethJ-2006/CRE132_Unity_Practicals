# Session 07: Interfaces & Game Management

## 🎯 **Learning Objectives**

By the end of this session, you will understand:
- **Interfaces** - Defining contracts that multiple classes can implement
- **Multiple Interface Implementation** - Classes implementing several interfaces
- **Switch Statements** - Elegant conditional logic for complex scenarios
- **Game State Management** - Professional game architecture patterns
- **Advanced Design Patterns** - Combining interfaces with inheritance
- **Professional Game Systems** - Industry-standard management approaches

## 📋 **Session Overview**

This session introduces interfaces - one of the most powerful tools in professional game development. You'll learn how interfaces solve problems that inheritance alone cannot, and how to build sophisticated game management systems that handle multiple states, user input, and complex interactions.

### **What You'll Build:**
- A complete interface system for game entities (attackable, damageable, upgradeable)
- A comprehensive game state manager handling menu, playing, paused, and game over states
- A switch-statement-based input system for complex controls
- Interactive demonstrations showing interfaces vs inheritance
- A complete mini-game integrating all concepts

## 🔧 **Unity Setup Instructions**

### **Step 1: Scene Preparation**
1. **Create a new scene**: `File > New Scene > 2D (URP)`
2. **Save the scene**: `File > Save As` → `Session07_InterfacesManagement`
3. **Save location**: `Assets/_Game/Scenes/Session07_InterfacesManagement.unity`

### **Step 2: GameObjects Setup**
1. **Create empty GameObjects** for each script:
   - Right-click in Hierarchy → `Create Empty`
   - Name them: `InterfaceDemo`, `SwitchStatements`, `GameStateManager`, `StudentExercise`

2. **Attach scripts** (we'll create these next):
   - `InterfaceDemo` ← `InterfaceBasics.cs`
   - `SwitchStatements` ← `SwitchStatementDemo.cs`
   - `GameStateManager` ← `GameStateManager.cs`
   - `StudentExercise` ← `Session07_StudentExercise.cs`

## 📖 **Core Concepts Explained**

### **🔌 Interfaces: The Contract System**

Think of interfaces as **contracts** that classes agree to follow:

```csharp
// Interface = contract (what you MUST be able to do)
public interface IAttackable
{
    void Attack(GameObject target);
    int GetAttackDamage();
}

// Interface = contract (what you MUST be able to do)
public interface IDamageable  
{
    void TakeDamage(int damage);
    bool IsAlive();
}

// Classes can implement multiple interfaces
public class Player : MonoBehaviour, IAttackable, IDamageable
{
    // MUST implement ALL interface methods
    public void Attack(GameObject target) { /* implementation */ }
    public int GetAttackDamage() { /* implementation */ }
    public void TakeDamage(int damage) { /* implementation */ }
    public bool IsAlive() { /* implementation */ }
}
```

**Key Interface Benefits:**
- **Multiple "Inheritance"** - Class can implement many interfaces
- **Flexible Design** - Different classes can share same interface
- **Polymorphism** - Use interface type to handle different classes
- **Testability** - Easy to create mock implementations

### **🔄 Interfaces vs Inheritance**

| **Inheritance** | **Interfaces** |
|----------------|----------------|
| "IS-A" relationship | "CAN-DO" relationship |
| Single inheritance only | Multiple interfaces |
| Shares implementation | Defines contract only |
| `class Dog : Animal` | `class Dog : IRunnable, IBarkable` |

### **🎮 Switch Statements: Elegant Logic**

Switch statements handle multiple conditions more elegantly than long if-else chains:

```csharp
// OLD WAY: Long if-else chain
if (gameState == GameState.Menu)
{
    HandleMenuInput();
}
else if (gameState == GameState.Playing)
{
    HandleGameplayInput();
}
else if (gameState == GameState.Paused)
{
    HandlePauseInput();
}
// ... many more conditions

// NEW WAY: Switch statement
switch (gameState)
{
    case GameState.Menu:
        HandleMenuInput();
        break;
    case GameState.Playing:
        HandleGameplayInput();
        break;
    case GameState.Paused:
        HandlePauseInput();
        break;
    case GameState.GameOver:
        HandleGameOverInput();
        break;
    default:
        Debug.LogError("Unknown game state!");
        break;
}
```

### **🏗️ Game State Management**

Professional games use state machines to manage different game phases:

```csharp
public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver,
    Loading
}

public class GameStateManager : MonoBehaviour
{
    private GameState currentState = GameState.MainMenu;
    
    public void ChangeState(GameState newState)
    {
        ExitCurrentState();
        currentState = newState;
        EnterNewState();
    }
    
    private void EnterNewState()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                Time.timeScale = 1f;
                // Show menu UI
                break;
            case GameState.Playing:
                Time.timeScale = 1f;
                // Hide UI, enable player input
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                // Show pause menu
                break;
        }
    }
}
```

## 💻 **Practical Implementation**

### **Example 1: Interface System**

Create `InterfaceBasics.cs`:

```csharp
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Demonstrates interfaces and how they solve problems inheritance cannot.
/// Shows multiple interface implementation and polymorphism.
/// </summary>
public class InterfaceBasics : MonoBehaviour
{
    [Header("Interface Demonstration")]
    [SerializeField] private bool testInterfaces = false;
    [SerializeField] private bool testPolymorphism = false;
    [SerializeField] private bool testMultipleInterfaces = false;
    
    void Start()
    {
        Debug.Log("=== INTERFACE BASICS DEMONSTRATION ===");
        DemonstrateInterfaces();
    }
    
    void Update()
    {
        if (testInterfaces)
        {
            testInterfaces = false;
            DemonstrateInterfaces();
        }
        
        if (testPolymorphism)
        {
            testPolymorphism = false;
            DemonstrateInterfacePolymorphism();
        }
        
        if (testMultipleInterfaces)
        {
            testMultipleInterfaces = false;
            DemonstrateMultipleInterfaces();
        }
    }
    
    private void DemonstrateInterfaces()
    {
        Debug.Log("\n--- Interface Implementation ---");
        
        // Create different types that implement same interfaces
        GamePlayer player = new GamePlayer("Hero", 100, 25);
        GameEnemy orc = new GameEnemy("Orc Warrior", 80, 20);
        Building tower = new Building("Watch Tower", 200);
        
        // All implement IDamageable - can take damage
        Debug.Log("\n--- All Entities Can Take Damage (IDamageable) ---");
        player.TakeDamage(15);
        orc.TakeDamage(25);
        tower.TakeDamage(30);
        
        // Only some implement IAttackable - can attack
        Debug.Log("\n--- Only Some Can Attack (IAttackable) ---");
        player.Attack();
        orc.Attack();
        // tower.Attack(); // ERROR! Building doesn't implement IAttackable
        
        Debug.Log("\n--- Check Who's Still Alive ---");
        Debug.Log("Player alive: " + player.IsAlive());
        Debug.Log("Orc alive: " + orc.IsAlive());
        Debug.Log("Tower alive: " + tower.IsAlive());
    }
    
    private void DemonstrateInterfacePolymorphism()
    {
        Debug.Log("\n=== INTERFACE POLYMORPHISM ===");
        
        // Create list of different types using interface
        List<IDamageable> allDamageableThings = new List<IDamageable>
        {
            new GamePlayer("Warrior", 120, 30),
            new GameEnemy("Goblin", 60, 15),
            new Building("Castle Wall", 300),
            new GameEnemy("Dragon", 500, 80),
            new Building("Wooden Gate", 150)
        };
        
        Debug.Log("--- Damage All Entities (Interface Polymorphism) ---");
        foreach (IDamageable entity in allDamageableThings)
        {
            entity.TakeDamage(50); // Same interface, different implementations!
        }
        
        Debug.Log("\n--- Survival Check ---");
        foreach (IDamageable entity in allDamageableThings)
        {
            Debug.Log("Entity alive: " + entity.IsAlive());
        }
    }
    
    private void DemonstrateMultipleInterfaces()
    {
        Debug.Log("\n=== MULTIPLE INTERFACE IMPLEMENTATION ===");
        
        // Create advanced entities that implement multiple interfaces
        AdvancedPlayer player = new AdvancedPlayer("Champion", 150, 35);
        AdvancedEnemy boss = new AdvancedEnemy("Boss Monster", 400, 60);
        
        Debug.Log("--- Multiple Interface Capabilities ---");
        
        // IAttackable capabilities
        player.Attack();
        boss.Attack();
        
        // IDamageable capabilities
        player.TakeDamage(40);
        boss.TakeDamage(80);
        
        // IUpgradeable capabilities (only advanced entities have this)
        player.Upgrade();
        boss.Upgrade();
        
        // IHealable capabilities (only player has this)
        player.Heal(20);
        // boss.Heal(20); // ERROR! Boss doesn't implement IHealable
    }
}

// =============================================================================
// INTERFACE DEFINITIONS
// =============================================================================

/// <summary>
/// Interface for entities that can take damage
/// </summary>
public interface IDamageable
{
    void TakeDamage(int damage);
    bool IsAlive();
    int GetCurrentHealth();
}

/// <summary>
/// Interface for entities that can attack
/// </summary>
public interface IAttackable
{
    void Attack();
    int GetAttackDamage();
}

/// <summary>
/// Interface for entities that can be upgraded
/// </summary>
public interface IUpgradeable
{
    void Upgrade();
    int GetUpgradeLevel();
}

/// <summary>
/// Interface for entities that can heal
/// </summary>
public interface IHealable
{
    void Heal(int amount);
    int GetMaxHealth();
}

// =============================================================================
// BASIC IMPLEMENTATIONS
// =============================================================================

/// <summary>
/// Player class implementing basic interfaces
/// </summary>
public class GamePlayer : IDamageable, IAttackable
{
    private string playerName;
    private int health;
    private int maxHealth;
    private int damage;
    
    public GamePlayer(string name, int hp, int dmg)
    {
        playerName = name;
        health = hp;
        maxHealth = hp;
        damage = dmg;
        Debug.Log("Created player: " + playerName + " (HP: " + health + ", DMG: " + damage + ")");
    }
    
    // IDamageable implementation
    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
        Debug.Log(playerName + " takes " + damage + " damage! HP: " + health + "/" + maxHealth);
    }
    
    public bool IsAlive()
    {
        return health > 0;
    }
    
    public int GetCurrentHealth()
    {
        return health;
    }
    
    // IAttackable implementation
    public void Attack()
    {
        Debug.Log(playerName + " swings sword for " + damage + " damage! *SLASH*");
    }
    
    public int GetAttackDamage()
    {
        return damage;
    }
}

/// <summary>
/// Enemy class implementing basic interfaces
/// </summary>
public class GameEnemy : IDamageable, IAttackable
{
    private string enemyName;
    private int health;
    private int maxHealth;
    private int damage;
    
    public GameEnemy(string name, int hp, int dmg)
    {
        enemyName = name;
        health = hp;
        maxHealth = hp;
        damage = dmg;
        Debug.Log("Created enemy: " + enemyName + " (HP: " + health + ", DMG: " + damage + ")");
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
        Debug.Log(enemyName + " takes " + damage + " damage! HP: " + health + "/" + maxHealth);
    }
    
    public bool IsAlive()
    {
        return health > 0;
    }
    
    public int GetCurrentHealth()
    {
        return health;
    }
    
    public void Attack()
    {
        Debug.Log(enemyName + " attacks with claws for " + damage + " damage! *ROAR*");
    }
    
    public int GetAttackDamage()
    {
        return damage;
    }
}

/// <summary>
/// Building class - only damageable, cannot attack
/// </summary>
public class Building : IDamageable
{
    private string buildingName;
    private int health;
    private int maxHealth;
    
    public Building(string name, int hp)
    {
        buildingName = name;
        health = hp;
        maxHealth = hp;
        Debug.Log("Built structure: " + buildingName + " (HP: " + health + ")");
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
        Debug.Log(buildingName + " takes " + damage + " structural damage! HP: " + health + "/" + maxHealth);
        
        if (!IsAlive())
        {
            Debug.Log(buildingName + " has been destroyed! *CRASH*");
        }
    }
    
    public bool IsAlive()
    {
        return health > 0;
    }
    
    public int GetCurrentHealth()
    {
        return health;
    }
}

// =============================================================================
// ADVANCED IMPLEMENTATIONS (MULTIPLE INTERFACES)
// =============================================================================

/// <summary>
/// Advanced player implementing multiple interfaces
/// </summary>
public class AdvancedPlayer : IDamageable, IAttackable, IUpgradeable, IHealable
{
    private string playerName;
    private int health;
    private int maxHealth;
    private int damage;
    private int upgradeLevel = 1;
    
    public AdvancedPlayer(string name, int hp, int dmg)
    {
        playerName = name;
        health = hp;
        maxHealth = hp;
        damage = dmg;
        Debug.Log("Created advanced player: " + playerName + " (Level " + upgradeLevel + ")");
    }
    
    // IDamageable implementation
    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
        Debug.Log(playerName + " takes " + damage + " damage! HP: " + health + "/" + maxHealth);
    }
    
    public bool IsAlive() => health > 0;
    public int GetCurrentHealth() => health;
    
    // IAttackable implementation
    public void Attack()
    {
        int totalDamage = damage * upgradeLevel;
        Debug.Log(playerName + " performs enhanced attack for " + totalDamage + " damage! (Level " + upgradeLevel + ")");
    }
    
    public int GetAttackDamage() => damage * upgradeLevel;
    
    // IUpgradeable implementation
    public void Upgrade()
    {
        upgradeLevel++;
        maxHealth += 20;
        health = maxHealth; // Full heal on upgrade
        damage += 10;
        Debug.Log(playerName + " upgraded to level " + upgradeLevel + "! New stats - HP: " + maxHealth + ", DMG: " + damage);
    }
    
    public int GetUpgradeLevel() => upgradeLevel;
    
    // IHealable implementation
    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        Debug.Log(playerName + " heals for " + amount + " HP! Current: " + health + "/" + maxHealth);
    }
    
    public int GetMaxHealth() => maxHealth;
}

/// <summary>
/// Advanced enemy with upgrade capabilities
/// </summary>
public class AdvancedEnemy : IDamageable, IAttackable, IUpgradeable
{
    private string enemyName;
    private int health;
    private int maxHealth;
    private int damage;
    private int upgradeLevel = 1;
    
    public AdvancedEnemy(string name, int hp, int dmg)
    {
        enemyName = name;
        health = hp;
        maxHealth = hp;
        damage = dmg;
        Debug.Log("Spawned advanced enemy: " + enemyName + " (Level " + upgradeLevel + ")");
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
        Debug.Log(enemyName + " takes " + damage + " damage! HP: " + health + "/" + maxHealth);
    }
    
    public bool IsAlive() => health > 0;
    public int GetCurrentHealth() => health;
    
    public void Attack()
    {
        int totalDamage = damage + (upgradeLevel * 5);
        Debug.Log(enemyName + " unleashes enhanced attack for " + totalDamage + " damage! (Level " + upgradeLevel + ")");
    }
    
    public int GetAttackDamage() => damage + (upgradeLevel * 5);
    
    public void Upgrade()
    {
        upgradeLevel++;
        maxHealth += 50;
        health = maxHealth;
        damage += 15;
        Debug.Log(enemyName + " evolves to level " + upgradeLevel + "! New stats - HP: " + maxHealth + ", DMG: " + damage);
    }
    
    public int GetUpgradeLevel() => upgradeLevel;
}
```

This is getting quite long. Let me continue with the remaining demonstration scripts and then the student exercise. I'll break this into manageable chunks.



### **Example 2: Switch Statement Demonstration**

Create `SwitchStatementDemo.cs`:

```csharp
using UnityEngine;

/// <summary>
/// Demonstrates switch statements for elegant conditional logic.
/// Shows input handling, state management, and complex decision making.
/// </summary>
public class SwitchStatementDemo : MonoBehaviour
{
    [Header("Switch Statement Demo")]
    [SerializeField] private bool testBasicSwitch = false;
    [SerializeField] private bool testInputSwitch = false;
    [SerializeField] private bool testComplexSwitch = false;
    
    // Enums for switch demonstrations
    public enum WeatherType { Sunny, Rainy, Snowy, Stormy, Foggy }
    public enum PlayerAction { Idle, Walking, Running, Jumping, Attacking, Defending }
    
    [Header("Current States")]
    [SerializeField] private WeatherType currentWeather = WeatherType.Sunny;
    [SerializeField] private PlayerAction currentAction = PlayerAction.Idle;
    
    void Start()
    {
        Debug.Log("=== SWITCH STATEMENT DEMONSTRATION ===");
        BasicSwitchDemo();
    }
    
    void Update()
    {
        if (testBasicSwitch)
        {
            testBasicSwitch = false;
            BasicSwitchDemo();
        }
        
        if (testInputSwitch)
        {
            testInputSwitch = false;
            InputSwitchDemo();
        }
        
        if (testComplexSwitch)
        {
            testComplexSwitch = false;
            ComplexSwitchDemo();
        }
        
        // Real-time input handling with switch
        HandleRealtimeInput();
    }
    
    private void BasicSwitchDemo()
    {
        Debug.Log("\n--- Basic Switch vs If-Else Comparison ---");
        
        // OLD WAY: Multiple if-else statements
        Debug.Log("IF-ELSE APPROACH:");
        if (currentWeather == WeatherType.Sunny)
        {
            Debug.Log("Perfect weather for outdoor activities!");
        }
        else if (currentWeather == WeatherType.Rainy)
        {
            Debug.Log("Better stay inside and read a book.");
        }
        else if (currentWeather == WeatherType.Snowy)
        {
            Debug.Log("Time for snowball fights!");
        }
        else if (currentWeather == WeatherType.Stormy)
        {
            Debug.Log("Stay safe indoors during the storm.");
        }
        else if (currentWeather == WeatherType.Foggy)
        {
            Debug.Log("Drive carefully in this fog.");
        }
        
        // NEW WAY: Switch statement (cleaner and faster)
        Debug.Log("\nSWITCH STATEMENT APPROACH:");
        switch (currentWeather)
        {
            case WeatherType.Sunny:
                Debug.Log("Perfect weather for outdoor activities!");
                break;
            case WeatherType.Rainy:
                Debug.Log("Better stay inside and read a book.");
                break;
            case WeatherType.Snowy:
                Debug.Log("Time for snowball fights!");
                break;
            case WeatherType.Stormy:
                Debug.Log("Stay safe indoors during the storm.");
                break;
            case WeatherType.Foggy:
                Debug.Log("Drive carefully in this fog.");
                break;
            default:
                Debug.Log("Unknown weather type!");
                break;
        }
    }
    
    private void InputSwitchDemo()
    {
        Debug.Log("\n--- Input Handling with Switch Statements ---");
        
        // Simulate different key presses
        KeyCode[] testKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space, KeyCode.LeftShift };
        
        foreach (KeyCode key in testKeys)
        {
            HandleKeyInput(key);
        }
    }
    
    private void HandleKeyInput(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                Debug.Log("Moving forward!");
                currentAction = PlayerAction.Walking;
                break;
            case KeyCode.A:
                Debug.Log("Moving left!");
                currentAction = PlayerAction.Walking;
                break;
            case KeyCode.S:
                Debug.Log("Moving backward!");
                currentAction = PlayerAction.Walking;
                break;
            case KeyCode.D:
                Debug.Log("Moving right!");
                currentAction = PlayerAction.Walking;
                break;
            case KeyCode.Space:
                Debug.Log("Jumping!");
                currentAction = PlayerAction.Jumping;
                break;
            case KeyCode.LeftShift:
                Debug.Log("Running fast!");
                currentAction = PlayerAction.Running;
                break;
            case KeyCode.LeftControl:
                Debug.Log("Defending!");
                currentAction = PlayerAction.Defending;
                break;
            case KeyCode.Mouse0:
                Debug.Log("Attacking!");
                currentAction = PlayerAction.Attacking;
                break;
            default:
                Debug.Log("Unknown key: " + key);
                currentAction = PlayerAction.Idle;
                break;
        }
    }
    
    private void ComplexSwitchDemo()
    {
        Debug.Log("\n--- Complex Switch Logic ---");
        
        // Switch with multiple cases and complex logic
        ProcessPlayerAction(currentAction);
        
        // Switch with calculations
        CalculateMovementSpeed(currentAction);
    }
    
    private void ProcessPlayerAction(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.Idle:
                Debug.Log("Player is standing still, recovering stamina.");
                break;
                
            case PlayerAction.Walking:
                Debug.Log("Player is walking at normal pace.");
                ConsumeStamina(1);
                break;
                
            case PlayerAction.Running:
                Debug.Log("Player is running quickly!");
                ConsumeStamina(3);
                break;
                
            case PlayerAction.Jumping:
                Debug.Log("Player jumps high into the air!");
                ConsumeStamina(5);
                break;
                
            case PlayerAction.Attacking:
                Debug.Log("Player performs a powerful attack!");
                ConsumeStamina(4);
                DealDamage(25);
                break;
                
            case PlayerAction.Defending:
                Debug.Log("Player raises shield to block incoming attacks.");
                ConsumeStamina(2);
                break;
                
            default:
                Debug.LogError("Unknown player action: " + action);
                break;
        }
    }
    
    private void CalculateMovementSpeed(PlayerAction action)
    {
        float speed = action switch
        {
            PlayerAction.Idle => 0f,
            PlayerAction.Walking => 3f,
            PlayerAction.Running => 8f,
            PlayerAction.Jumping => 2f, // Reduced speed while jumping
            PlayerAction.Attacking => 1f, // Slow while attacking
            PlayerAction.Defending => 1.5f, // Slow while defending
            _ => 0f // Default case
        };
        
        Debug.Log("Movement speed for " + action + ": " + speed + " units/second");
    }
    
    private void HandleRealtimeInput()
    {
        // Real-time input handling - only process if keys are actually pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Switched to weapon slot 1!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Switched to weapon slot 2!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Switched to weapon slot 3!");
        }
        
        // Better way using switch with input detection
        if (Input.inputString.Length > 0)
        {
            char inputChar = Input.inputString[0];
            switch (inputChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                    int slotNumber = int.Parse(inputChar.ToString());
                    Debug.Log("Quick-switched to slot " + slotNumber + "!");
                    break;
            }
        }
    }
    
    // Helper methods for demonstration
    private void ConsumeStamina(int amount)
    {
        Debug.Log("Stamina consumed: " + amount + " points.");
    }
    
    private void DealDamage(int damage)
    {
        Debug.Log("Dealing " + damage + " damage to target!");
    }
}
```

### **Example 3: Game State Management**

Create `GameStateManager.cs`:

```csharp
using UnityEngine;

/// <summary>
/// Professional game state management system.
/// Handles different game phases: Menu, Playing, Paused, Game Over.
/// </summary>
public class GameStateManager : MonoBehaviour
{
    [Header("Game State Management")]
    [SerializeField] private GameState currentState = GameState.MainMenu;
    [SerializeField] private bool testStateTransitions = false;
    [SerializeField] private bool simulateGameplay = false;
    
    // Game state tracking
    private float gameTime = 0f;
    private int score = 0;
    private int lives = 3;
    
    void Start()
    {
        Debug.Log("=== GAME STATE MANAGER INITIALIZED ===");
        InitializeGame();
    }
    
    void Update()
    {
        if (testStateTransitions)
        {
            testStateTransitions = false;
            TestAllStateTransitions();
        }
        
        if (simulateGameplay)
        {
            simulateGameplay = false;
            SimulateCompleteGameSession();
        }
        
        // Update current state
        UpdateCurrentState();
        
        // Handle input based on current state
        HandleStateInput();
    }
    
    #region State Management Core
    
    /// <summary>
    /// Changes to a new game state with proper enter/exit handling
    /// </summary>
    public void ChangeState(GameState newState)
    {
        if (currentState == newState)
        {
            Debug.Log("Already in state: " + newState);
            return;
        }
        
        GameState previousState = currentState;
        
        // Exit current state
        ExitState(currentState);
        
        // Change state
        currentState = newState;
        
        // Enter new state
        EnterState(newState);
        
        Debug.Log("State transition: " + previousState + " → " + newState);
    }
    
    private void EnterState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                Debug.Log("=== ENTERING MAIN MENU ===");
                Time.timeScale = 1f;
                // In real game: Show menu UI, play menu music
                Debug.Log("Main menu displayed. Press 'P' to start playing!");
                break;
                
            case GameState.Playing:
                Debug.Log("=== STARTING GAME ===");
                Time.timeScale = 1f;
                gameTime = 0f;
                // In real game: Hide menu, enable player controls, start gameplay
                Debug.Log("Game started! Use WASD to move, ESC to pause.");
                break;
                
            case GameState.Paused:
                Debug.Log("=== GAME PAUSED ===");
                Time.timeScale = 0f; // Stop time
                // In real game: Show pause menu, disable player input
                Debug.Log("Game paused. Press ESC to resume, Q to quit.");
                break;
                
            case GameState.GameOver:
                Debug.Log("=== GAME OVER ===");
                Time.timeScale = 1f;
                // In real game: Show game over screen, final score
                Debug.Log("Final Score: " + score + " | Time Played: " + gameTime.ToString("F1") + "s");
                Debug.Log("Press R to restart, M for main menu.");
                break;
                
            case GameState.Loading:
                Debug.Log("=== LOADING ===");
                Time.timeScale = 1f;
                // In real game: Show loading screen, load assets
                Debug.Log("Loading game assets...");
                break;
                
            default:
                Debug.LogError("Unknown game state: " + state);
                break;
        }
    }
    
    private void ExitState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                Debug.Log("Leaving main menu...");
                // In real game: Hide menu UI, stop menu music
                break;
                
            case GameState.Playing:
                Debug.Log("Stopping gameplay...");
                // In real game: Save game state, disable controls
                break;
                
            case GameState.Paused:
                Debug.Log("Unpausing game...");
                // In real game: Hide pause menu, re-enable controls
                break;
                
            case GameState.GameOver:
                Debug.Log("Leaving game over screen...");
                // In real game: Clear final score, reset game variables
                ResetGameData();
                break;
                
            case GameState.Loading:
                Debug.Log("Loading complete.");
                break;
        }
    }
    
    private void UpdateCurrentState()
    {
        switch (currentState)
        {
            case GameState.Playing:
                // Update game time and score
                gameTime += Time.deltaTime;
                score += Mathf.RoundToInt(Time.deltaTime * 10); // 10 points per second
                break;
                
            case GameState.Loading:
                // Simulate loading progress
                static float loadingTime = 0f;
                loadingTime += Time.deltaTime;
                if (loadingTime >= 2f) // 2 second loading time
                {
                    loadingTime = 0f;
                    ChangeState(GameState.Playing);
                }
                break;
        }
    }
    
    #endregion
    
    #region Input Handling
    
    private void HandleStateInput()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                HandleMainMenuInput();
                break;
                
            case GameState.Playing:
                HandleGameplayInput();
                break;
                
            case GameState.Paused:
                HandlePauseInput();
                break;
                
            case GameState.GameOver:
                HandleGameOverInput();
                break;
        }
    }
    
    private void HandleMainMenuInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeState(GameState.Loading);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quitting game...");
            // Application.Quit(); // Uncomment in build
        }
    }
    
    private void HandleGameplayInput()
    {
        // Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState(GameState.Paused);
        }
        
        // Simulate player movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // In real game: Move player
            // Debug.Log("Player moving..."); // Too much output
        }
        
        // Simulate losing a life
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoseLife();
        }
    }
    
    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState(GameState.Playing);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(GameState.MainMenu);
        }
    }
    
    private void HandleGameOverInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(GameState.Loading); // Restart game
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeState(GameState.MainMenu);
        }
    }
    
    #endregion
    
    #region Game Logic
    
    private void InitializeGame()
    {
        ResetGameData();
        ChangeState(GameState.MainMenu);
    }
    
    private void ResetGameData()
    {
        gameTime = 0f;
        score = 0;
        lives = 3;
        Debug.Log("Game data reset. Lives: " + lives);
    }
    
    private void LoseLife()
    {
        lives--;
        Debug.Log("Life lost! Remaining lives: " + lives);
        
        if (lives <= 0)
        {
            ChangeState(GameState.GameOver);
        }
    }
    
    #endregion
    
    #region Testing Methods
    
    private void TestAllStateTransitions()
    {
        Debug.Log("\n=== TESTING ALL STATE TRANSITIONS ===");
        
        // Test each state transition
        ChangeState(GameState.MainMenu);
        ChangeState(GameState.Loading);
        ChangeState(GameState.Playing);
        ChangeState(GameState.Paused);
        ChangeState(GameState.Playing);
        ChangeState(GameState.GameOver);
        ChangeState(GameState.MainMenu);
        
        Debug.Log("State transition testing complete!");
    }
    
    private void SimulateCompleteGameSession()
    {
        Debug.Log("\n=== SIMULATING COMPLETE GAME SESSION ===");
        
        // Start game session
        ChangeState(GameState.MainMenu);
        
        // Start playing
        ChangeState(GameState.Loading);
        ChangeState(GameState.Playing);
        
        // Simulate some gameplay time
        gameTime = 45f;
        score = 1250;
        
        // Pause game
        ChangeState(GameState.Paused);
        ChangeState(GameState.Playing);
        
        // Lose all lives and end game
        lives = 1;
        LoseLife();
        
        Debug.Log("Complete game session simulation finished!");
    }
    
    #endregion
}

/// <summary>
/// Enum defining all possible game states
/// </summary>
public enum GameState
{
    MainMenu,
    Loading,
    Playing,
    Paused,
    GameOver
}
```

## 🎮 **Interactive Testing**

### **In Unity Editor:**
1. **Press Play** to see automatic demonstrations
2. **Check the Console** (`Window > General > Console`) for detailed output
3. **Use Inspector checkboxes** to trigger specific tests:
   - `Test Interfaces` - Shows interface implementation and polymorphism
   - `Test Switch Statements` - Demonstrates switch vs if-else logic
   - `Test State Transitions` - Shows game state management

### **Real-time Controls (when Playing):**
- **P** - Start game from main menu
- **ESC** - Pause/unpause game
- **WASD** - Simulate player movement
- **L** - Lose a life (when playing)
- **R** - Restart game (when game over)
- **M** - Return to main menu
- **Q** - Quit game

## 🔍 **Common Mistakes & Troubleshooting**

### **Interface Issues:**
- **Error**: "Class doesn't implement interface member"
  - **Solution**: Implement ALL methods defined in the interface
- **Error**: "Cannot convert type"
  - **Solution**: Make sure class implements the interface you're trying to use

### **Switch Statement Problems:**
- **Missing break statements** → Each case needs `break;` or code continues to next case
- **No default case** → Always include `default:` to handle unexpected values
- **Wrong data type** → Switch only works with certain types (int, enum, char, string)

### **State Management Issues:**
- **States getting stuck** → Always call `ExitState()` before `EnterState()`
- **Time.timeScale problems** → Remember to reset to 1f when unpausing
- **Missing state transitions** → Check all possible paths between states

## 🏆 **Professional Development Notes**

### **Interface Benefits in Game Development:**
- **Unity Components** - MonoBehaviour, ICollisionHandler, IPointerClickHandler
- **Design Patterns** - Strategy, Observer, Command patterns all use interfaces
- **Testing** - Mock objects for unit testing
- **Plugin Systems** - Define contracts for third-party extensions

### **State Management in Real Games:**
- **Menu Systems** - Main menu, options, credits, pause menu
- **Gameplay States** - Playing, cutscene, dialogue, inventory
- **Loading States** - Level loading, asset streaming, save/load
- **Network States** - Connecting, connected, disconnected

### **Switch Statement Performance:**
- **Faster than if-else chains** - Compiler optimizes with jump tables
- **Better readability** - Clear structure for multiple conditions
- **Maintainability** - Easy to add new cases
- **Type safety** - Compiler ensures all enum values are handled

## 📚 **Advanced Concepts Preview**

### **Interface Inheritance:**
```csharp
public interface IMoveable
{
    void Move();
}

public interface IFlyable : IMoveable // Interface inheriting from interface
{
    void Fly();
    float GetAltitude();
}
```

### **Generic Interfaces:**
```csharp
public interface IDamageable<T>
{
    void TakeDamage(T damageInfo);
}
```

### **State Machine Patterns:**
- **Hierarchical States** - Sub-states within main states
- **State History** - Remember previous states for complex transitions
- **Parallel States** - Multiple active states simultaneously

---

**🎓 Ready to Practice?** Open `Session07_StudentExercise.cs` and complete the TODO sections!

**Next Session Preview**: Session 08 will cover File I/O, Data Persistence, and creating a Complete Final Project that integrates all learned concepts.

---

*Session 07 - Interfaces & Game Management*  
*CRE132 Game Development Fundamentals*  
*Northern Irish University - AI and Games Department*
