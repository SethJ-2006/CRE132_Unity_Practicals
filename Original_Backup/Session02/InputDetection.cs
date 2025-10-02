using UnityEngine;

/// <summary>
/// Demonstrates Unity's input system for keyboard and mouse detection
/// Shows different types of input detection and their practical uses
/// </summary>
public class InputDetection : MonoBehaviour
{
    [Header("=== INPUT FEEDBACK SETTINGS ===")]
    public bool showMovementMessages = true;
    public bool showMousePosition = false;
    public float messageDelay = 0.5f;  // Delay between repeated messages
    
    [Header("=== PLAYER STATISTICS ===")]
    public int jumpCount = 0;
    public int totalClicks = 0;
    public float timePlayingSeconds = 0f;
    
    [Header("=== CURRENT INPUT STATE (READ-ONLY) ===")]
    [SerializeField] private bool spacePressed;
    [SerializeField] private bool wPressed;
    [SerializeField] private bool aPressed;
    [SerializeField] private bool sPressed;
    [SerializeField] private bool dPressed;
    [SerializeField] private Vector3 currentMousePosition;
    
    // Private variables for timing
    private float lastMessageTime;
    private bool wasMovingLastFrame;
    
    void Start()
    {
        Debug.Log("=== INPUT DETECTION DEMONSTRATION ===");
        Debug.Log("Try these inputs:");
        Debug.Log("- SPACE: Jump (single press)");
        Debug.Log("- W,A,S,D: Movement (hold down)");
        Debug.Log("- MOUSE: Left, right, and middle click");
        Debug.Log("- ESC: Pause game");
        Debug.Log("- ENTER: Confirm action");
        
        lastMessageTime = Time.time;
    }
    
    void Update()
    {
        // Update timing
        timePlayingSeconds += Time.deltaTime;
        
        // Check all different types of input
        CheckSinglePressInputs();
        CheckHeldInputs();
        CheckMouseInput();
        CheckSpecialKeys();
        
        // Update Inspector display
        UpdateInputStateDisplay();
    }
    
    /// <summary>
    /// Checks for single-press inputs (GetKeyDown)
    /// These fire once when the key is first pressed
    /// </summary>
    void CheckSinglePressInputs()
    {
        // Jump input - fires once per press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;
            Debug.Log($"JUMP! (Total jumps: {jumpCount})");
        }
        
        // Action keys
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("ENTER pressed - Action confirmed!");
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPE pressed - Game paused!");
        }
        
        // Number keys for quick actions
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 pressed - Weapon slot 1 selected");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2 pressed - Weapon slot 2 selected");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 pressed - Weapon slot 3 selected");
        }
    }
    
    /// <summary>
    /// Checks for held inputs (GetKey)
    /// These fire continuously while the key is held down
    /// </summary>
    void CheckHeldInputs()
    {
        bool isMoving = false;
        string movementDirection = "";
        
        // Movement keys - fire while held
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            movementDirection += "Forward ";
        }
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            movementDirection += "Left ";
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            movementDirection += "Backward ";
        }
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            movementDirection += "Right ";
        }
        
        // Only show movement messages with delay to avoid spam
        if (isMoving && showMovementMessages)
        {
            if (Time.time - lastMessageTime > messageDelay)
            {
                Debug.Log("Moving: " + movementDirection.Trim());
                lastMessageTime = Time.time;
            }
        }
        
        // Show when movement starts or stops
        if (isMoving != wasMovingLastFrame)
        {
            if (isMoving)
            {
                Debug.Log("Started moving: " + movementDirection.Trim());
            }
            else
            {
                Debug.Log("Stopped moving");
            }
        }
        
        wasMovingLastFrame = isMoving;
    }
    
    /// <summary>
    /// Checks for mouse input and position
    /// </summary>
    void CheckMouseInput()
    {
        // Mouse button clicks
        if (Input.GetMouseButtonDown(0))  // Left click
        {
            totalClicks++;
            Vector3 mousePos = Input.mousePosition;
            Debug.Log($"LEFT CLICK at position: {mousePos} (Total clicks: {totalClicks})");
        }
        
        if (Input.GetMouseButtonDown(1))  // Right click
        {
            totalClicks++;
            Debug.Log($"RIGHT CLICK (Total clicks: {totalClicks})");
        }
        
        if (Input.GetMouseButtonDown(2))  // Middle click
        {
            totalClicks++;
            Debug.Log($"MIDDLE CLICK (Total clicks: {totalClicks})");
        }
        
        // Mouse position tracking
        currentMousePosition = Input.mousePosition;
        
        if (showMousePosition && Time.time - lastMessageTime > messageDelay * 2)
        {
            Debug.Log($"Mouse position: {currentMousePosition}");
            lastMessageTime = Time.time;
        }
    }
    
    /// <summary>
    /// Checks for special keys and combinations
    /// </summary>
    void CheckSpecialKeys()
    {
        // Arrow keys
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("UP ARROW - Navigate menu up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("DOWN ARROW - Navigate menu down");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("LEFT ARROW - Navigate menu left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("RIGHT ARROW - Navigate menu right");
        }
        
        // Function keys
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("F1 - Help menu opened");
        }
        
        // Key combinations (hold multiple keys)
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SHIFT + SPACE - Special jump!");
        }
        
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("CTRL + S - Game saved!");
        }
    }
    
    /// <summary>
    /// Updates the Inspector display with current input states
    /// </summary>
    void UpdateInputStateDisplay()
    {
        // Update current input states for Inspector
        spacePressed = Input.GetKey(KeyCode.Space);
        wPressed = Input.GetKey(KeyCode.W);
        aPressed = Input.GetKey(KeyCode.A);
        sPressed = Input.GetKey(KeyCode.S);
        dPressed = Input.GetKey(KeyCode.D);
        currentMousePosition = Input.mousePosition;
    }
    
    /// <summary>
    /// Shows input statistics in the Console
    /// Called when this component is enabled
    /// </summary>
    void OnEnable()
    {
        Debug.Log("\n--- INPUT DETECTION READY ---");
        Debug.Log("This script demonstrates:");
        Debug.Log("• GetKeyDown() - Single press detection");
        Debug.Log("• GetKey() - Held key detection");
        Debug.Log("• GetKeyUp() - Key release detection");
        Debug.Log("• Mouse button detection and position");
        Debug.Log("• Key combinations");
    }
    
    /// <summary>
    /// Shows final statistics when component is disabled
    /// </summary>
    void OnDisable()
    {
        Debug.Log($"\n--- INPUT SESSION COMPLETE ---");
        Debug.Log($"Total jumps: {jumpCount}");
        Debug.Log($"Total clicks: {totalClicks}");
        Debug.Log($"Time playing: {timePlayingSeconds:F1} seconds");
    }
}
