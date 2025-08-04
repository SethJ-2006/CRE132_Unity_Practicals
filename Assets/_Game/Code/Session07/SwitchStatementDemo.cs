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
        
        // Modern C# switch expressions
        DemonstrateModernSwitchExpressions();
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
        float speed;
        
        // Traditional switch statement
        switch (action)
        {
            case PlayerAction.Idle:
                speed = 0f;
                break;
            case PlayerAction.Walking:
                speed = 3f;
                break;
            case PlayerAction.Running:
                speed = 8f;
                break;
            case PlayerAction.Jumping:
                speed = 2f; // Reduced speed while jumping
                break;
            case PlayerAction.Attacking:
                speed = 1f; // Slow while attacking
                break;
            case PlayerAction.Defending:
                speed = 1.5f; // Slow while defending
                break;
            default:
                speed = 0f;
                break;
        }
        
        Debug.Log("Movement speed for " + action + ": " + speed + " units/second");
    }
    
    private void DemonstrateModernSwitchExpressions()
    {
        Debug.Log("\n--- Modern C# Switch Expressions ---");
        
        // Modern switch expression (C# 8.0+)
        string actionDescription = currentAction switch
        {
            PlayerAction.Idle => "Player is resting and recovering",
            PlayerAction.Walking => "Player moves at a steady pace",
            PlayerAction.Running => "Player is moving quickly",
            PlayerAction.Jumping => "Player is airborne",
            PlayerAction.Attacking => "Player is in combat stance",
            PlayerAction.Defending => "Player is blocking attacks",
            _ => "Unknown action" // Default case
        };
        
        Debug.Log("Switch expression result: " + actionDescription);
        
        // Multiple conditions in one case
        string movementType = currentAction switch
        {
            PlayerAction.Walking or PlayerAction.Running => "Ground movement",
            PlayerAction.Jumping => "Aerial movement",
            PlayerAction.Attacking or PlayerAction.Defending => "Combat action",
            _ => "Stationary"
        };
        
        Debug.Log("Movement classification: " + movementType);
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
                case 'q':
                case 'Q':
                    Debug.Log("Quit key pressed!");
                    break;
                case 'p':
                case 'P':
                    Debug.Log("Pause key pressed!");
                    break;
            }
        }
        
        // Handle multiple key combinations
        if (Input.GetKey(KeyCode.LeftControl))
        {
            switch (true)
            {
                case bool _ when Input.GetKeyDown(KeyCode.S):
                    Debug.Log("Save game (Ctrl+S)");
                    break;
                case bool _ when Input.GetKeyDown(KeyCode.L):
                    Debug.Log("Load game (Ctrl+L)");
                    break;
                case bool _ when Input.GetKeyDown(KeyCode.N):
                    Debug.Log("New game (Ctrl+N)");
                    break;
            }
        }
    }
    
    // Demonstration of switch with different data types
    private void DemonstrateDifferentSwitchTypes()
    {
        Debug.Log("\n--- Switch with Different Data Types ---");
        
        // String switch
        string command = "attack";
        switch (command.ToLower())
        {
            case "attack":
            case "fight":
                Debug.Log("Initiating combat!");
                break;
            case "defend":
            case "block":
                Debug.Log("Raising defenses!");
                break;
            case "run":
            case "flee":
                Debug.Log("Retreating from battle!");
                break;
            default:
                Debug.Log("Unknown command: " + command);
                break;
        }
        
        // Integer switch
        int level = 5;
        switch (level)
        {
            case 1:
                Debug.Log("Beginner level");
                break;
            case 2:
            case 3:
            case 4:
                Debug.Log("Intermediate level");
                break;
            case 5:
            case 6:
            case 7:
                Debug.Log("Advanced level");
                break;
            case int n when n >= 8:
                Debug.Log("Expert level");
                break;
            default:
                Debug.Log("Invalid level");
                break;
        }
        
        // Character switch
        char grade = 'A';
        switch (grade)
        {
            case 'A':
                Debug.Log("Excellent performance!");
                break;
            case 'B':
                Debug.Log("Good work!");
                break;
            case 'C':
                Debug.Log("Average performance.");
                break;
            case 'D':
            case 'F':
                Debug.Log("Needs improvement.");
                break;
            default:
                Debug.Log("Invalid grade: " + grade);
                break;
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