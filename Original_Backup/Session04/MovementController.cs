using UnityEngine;

/// <summary>
/// Demonstrates practical movement patterns for 2D games using Unity's Input system
/// This script shows different movement styles commonly used in game development
/// </summary>
public class MovementController : MonoBehaviour
{
    [Header("=== MOVEMENT SETTINGS ===")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public bool enableInput = true;
    
    [Header("=== MOVEMENT TYPE ===")]
    public MovementType currentMovementType = MovementType.WASD;
    
    [Header("=== BOUNDARIES ===")]
    public bool enableBoundaries = true;
    public Vector2 minBounds = new Vector2(-10f, -5f);
    public Vector2 maxBounds = new Vector2(10f, 5f);
    
    [Header("=== SPECIAL MOVEMENT ===")]
    public bool enableCircularMotion = false;
    public float circularRadius = 3f;
    public float circularSpeed = 2f;
    
    [Header("=== CURRENT STATUS (READ-ONLY) ===")]
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float currentSpeed;
    [SerializeField] private bool isMoving;
    [SerializeField] private string lastInput;
    
    // Enum for different movement types
    public enum MovementType
    {
        WASD,           // Standard WASD movement
        ArrowKeys,      // Arrow key movement
        MouseFollow,    // Follow mouse cursor
        Circular,       // Circular motion pattern
        Patrol          // Patrol between waypoints
    }
    
    // Private variables
    private Vector3 startPosition;
    private Vector3[] patrolPoints;
    private int currentPatrolIndex = 0;
    private Vector3 circularCenter;
    
    void Start()
    {
        Debug.Log("=== MOVEMENT CONTROLLER DEMONSTRATION ===");
        Debug.Log("Learning different movement patterns for 2D games");
        
        // Store starting position
        startPosition = transform.position;
        circularCenter = startPosition;
        
        // Set up patrol points
        SetupPatrolPoints();
        
        // Display movement instructions
        DisplayMovementInstructions();
    }    
    void Update()
    {
        if (!enableInput) return;
        
        // Apply movement based on selected type
        switch (currentMovementType)
        {
            case MovementType.WASD:
                HandleWASDMovement();
                break;
            case MovementType.ArrowKeys:
                HandleArrowKeyMovement();
                break;
            case MovementType.MouseFollow:
                HandleMouseFollowMovement();
                break;
            case MovementType.Circular:
                HandleCircularMovement();
                break;
            case MovementType.Patrol:
                HandlePatrolMovement();
                break;
        }
        
        // Apply boundaries if enabled
        if (enableBoundaries)
        {
            ApplyBoundaries();
        }
        
        // Update status variables for Inspector
        UpdateStatusVariables();
        
        // Check for movement type switching
        HandleMovementTypeSwitching();
    }
    
    /// <summary>
    /// Handles WASD key movement (W=up, A=left, S=down, D=right)
    /// </summary>
    private void HandleWASDMovement()
    {
        Vector3 movement = Vector3.zero;
        
        // Get input for each direction
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.up;
            lastInput = "W (Up)";
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;
            lastInput = "S (Down)";
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
            lastInput = "A (Left)";
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
            lastInput = "D (Right)";
        }
        
        // Normalize diagonal movement so it's not faster
        movement = movement.normalized;
        
        // Apply movement
        transform.position += movement * moveSpeed * Time.deltaTime;
        velocity = movement * moveSpeed;
    }    
    /// <summary>
    /// Handles arrow key movement (alternative to WASD)
    /// </summary>
    private void HandleArrowKeyMovement()
    {
        // Use Unity's built-in Input.GetAxis for smooth movement
        float horizontal = Input.GetAxis("Horizontal"); // Left/Right arrows or A/D
        float vertical = Input.GetAxis("Vertical");     // Up/Down arrows or W/S
        
        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        movement = movement.normalized; // Prevent faster diagonal movement
        
        transform.position += movement * moveSpeed * Time.deltaTime;
        velocity = movement * moveSpeed;
        
        if (movement != Vector3.zero)
        {
            lastInput = $"Axis Input: ({horizontal:F1}, {vertical:F1})";
        }
    }
    
    /// <summary>
    /// Makes the object follow the mouse cursor
    /// </summary>
    private void HandleMouseFollowMovement()
    {
        // Convert mouse position from screen space to world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Keep Z at 0 for 2D
        
        // Move towards mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        velocity = direction * moveSpeed;
        lastInput = $"Mouse: {mousePosition}";
        
        // Optional: Stop when close to mouse
        if (Vector3.Distance(transform.position, mousePosition) < 0.5f)
        {
            velocity = Vector3.zero;
        }
    }
    
    /// <summary>
    /// Creates circular motion around a center point
    /// </summary>
    private void HandleCircularMovement()
    {
        float angle = Time.time * circularSpeed;
        Vector3 offset = new Vector3(
            Mathf.Cos(angle) * circularRadius,
            Mathf.Sin(angle) * circularRadius,
            0f
        );
        
        Vector3 targetPosition = circularCenter + offset;
        Vector3 direction = (targetPosition - transform.position).normalized;
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        velocity = direction * moveSpeed;
        lastInput = $"Circular: Angle {angle * Mathf.Rad2Deg:F0}°";
    }    
    /// <summary>
    /// Patrols between predefined waypoints
    /// </summary>
    private void HandlePatrolMovement()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;
        
        Vector3 targetPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPoint - transform.position).normalized;
        
        // Move towards current patrol point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        velocity = direction * moveSpeed;
        
        // Check if we've reached the current patrol point
        if (Vector3.Distance(transform.position, targetPoint) < 0.2f)
        {
            // Move to next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            lastInput = $"Patrol Point {currentPatrolIndex + 1}";
            Debug.Log($"Reached patrol point, moving to point {currentPatrolIndex + 1}");
        }
    }
    
    /// <summary>
    /// Keeps the object within defined boundaries
    /// </summary>
    private void ApplyBoundaries()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);
        transform.position = pos;
    }
    
    /// <summary>
    /// Updates status variables displayed in the Inspector
    /// </summary>
    private void UpdateStatusVariables()
    {
        currentSpeed = velocity.magnitude;
        isMoving = currentSpeed > 0.1f;
        
        // Clear last input if no movement
        if (!isMoving && currentMovementType != MovementType.Circular)
        {
            lastInput = "No Input";
        }
    }
    
    /// <summary>
    /// Allows switching movement types with number keys
    /// </summary>
    private void HandleMovementTypeSwitching()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentMovementType = MovementType.WASD;
            Debug.Log("Switched to WASD movement");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentMovementType = MovementType.ArrowKeys;
            Debug.Log("Switched to Arrow Keys movement");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentMovementType = MovementType.MouseFollow;
            Debug.Log("Switched to Mouse Follow movement");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentMovementType = MovementType.Circular;
            circularCenter = transform.position; // Reset center to current position
            Debug.Log("Switched to Circular movement");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentMovementType = MovementType.Patrol;
            Debug.Log("Switched to Patrol movement");
        }
    }    
    /// <summary>
    /// Sets up patrol waypoints for patrol movement
    /// </summary>
    private void SetupPatrolPoints()
    {
        patrolPoints = new Vector3[]
        {
            startPosition + Vector3.left * 3f,
            startPosition + Vector3.up * 2f,
            startPosition + Vector3.right * 3f,
            startPosition + Vector3.down * 2f
        };
        
        Debug.Log($"Set up {patrolPoints.Length} patrol points around starting position");
    }
    
    /// <summary>
    /// Displays movement instructions in the console
    /// </summary>
    private void DisplayMovementInstructions()
    {
        Debug.Log("\n--- MOVEMENT INSTRUCTIONS ---");
        Debug.Log("Press number keys to switch movement types:");
        Debug.Log("1 - WASD Movement (W=up, A=left, S=down, D=right)");
        Debug.Log("2 - Arrow Keys Movement (smooth analog input)");
        Debug.Log("3 - Mouse Follow (object follows mouse cursor)");
        Debug.Log("4 - Circular Motion (orbits around center point)");
        Debug.Log("5 - Patrol Movement (moves between waypoints)");
        Debug.Log("\nCurrent movement type: " + currentMovementType);
        Debug.Log("Enable Input: " + enableInput);
        Debug.Log("Movement Speed: " + moveSpeed);
    }
    
    /// <summary>
    /// Resets object to starting position and settings
    /// </summary>
    [ContextMenu("Reset to Start Position")]
    public void ResetToStartPosition()
    {
        transform.position = startPosition;
        velocity = Vector3.zero;
        currentPatrolIndex = 0;
        circularCenter = startPosition;
        Debug.Log("Reset to starting position: " + startPosition);
    }
    
    /// <summary>
    /// Toggles input enable/disable
    /// </summary>
    [ContextMenu("Toggle Input")]
    public void ToggleInput()
    {
        enableInput = !enableInput;
        Debug.Log("Input " + (enableInput ? "enabled" : "disabled"));
        
        if (!enableInput)
        {
            velocity = Vector3.zero;
            lastInput = "Input Disabled";
        }
    }
    
    /// <summary>
    /// Visualizes boundaries and patrol points in the Scene view
    /// </summary>
    void OnDrawGizmos()
    {
        // Draw boundaries
        if (enableBoundaries)
        {
            Gizmos.color = Color.yellow;
            Vector3 center = new Vector3((minBounds.x + maxBounds.x) / 2f, (minBounds.y + maxBounds.y) / 2f, 0f);
            Vector3 size = new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 0f);
            Gizmos.DrawWireCube(center, size);
        }
        
        // Draw patrol points
        if (patrolPoints != null)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                Gizmos.DrawWireSphere(patrolPoints[i], 0.3f);
                
                // Draw lines between patrol points
                if (i < patrolPoints.Length - 1)
                {
                    Gizmos.DrawLine(patrolPoints[i], patrolPoints[i + 1]);
                }
                else
                {
                    Gizmos.DrawLine(patrolPoints[i], patrolPoints[0]); // Connect last to first
                }
            }
        }
        
        // Draw circular motion radius for circular movement
        if (currentMovementType == MovementType.Circular && Application.isPlaying)
        {
            Gizmos.color = Color.blue;
            // Draw circle using line segments
            int segments = 32;
            Vector3 prevPoint = circularCenter + Vector3.right * circularRadius;
            for (int i = 1; i <= segments; i++)
            {
                float angle = (i * 360f / segments) * Mathf.Deg2Rad;
                Vector3 point = circularCenter + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * circularRadius;
                Gizmos.DrawLine(prevPoint, point);
                prevPoint = point;
            }
        }
    }
}