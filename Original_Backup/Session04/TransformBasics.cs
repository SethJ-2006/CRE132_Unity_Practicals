using UnityEngine;

/// <summary>
/// Demonstrates Unity Transform component basics for positioning, rotating, and scaling GameObjects
/// This script shows how to manipulate object transforms through code
/// </summary>
public class TransformBasics : MonoBehaviour
{
    [Header("=== POSITION SETTINGS ===")]
    public Vector3 targetPosition = new Vector3(5f, 3f, 0f);
    public float moveSpeed = 2f;
    public bool enableMovement = true;
    
    [Header("=== ROTATION SETTINGS ===")]
    public float rotationSpeed = 45f; // degrees per second
    public Vector3 rotationAxis = Vector3.forward; // Z-axis for 2D rotation
    public bool enableRotation = false;
    
    [Header("=== SCALE SETTINGS ===")]
    public Vector3 targetScale = new Vector3(2f, 2f, 1f);
    public float scaleSpeed = 1f;
    public bool enableScaling = false;
    
    [Header("=== CURRENT TRANSFORM VALUES (READ-ONLY) ===")]
    [SerializeField] private Vector3 currentPosition;
    [SerializeField] private Vector3 currentRotation;
    [SerializeField] private Vector3 currentScale;
    [SerializeField] private float distanceToTarget;
    
    // Store original values
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    
    void Start()
    {
        Debug.Log("=== TRANSFORM BASICS DEMONSTRATION ===");
        Debug.Log("Learning how to manipulate Unity Transform components");
        
        // Store original transform values
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;
        
        Debug.Log($"Original Position: {originalPosition}");
        Debug.Log($"Original Rotation: {originalRotation.eulerAngles}");
        Debug.Log($"Original Scale: {originalScale}");
        
        // Demonstrate different transform concepts
        DemonstrateTransformProperties();
        DemonstrateVectorOperations();
        DemonstrateWorldVsLocalSpace();
    }    
    void Update()
    {
        // Update current transform values for Inspector display
        currentPosition = transform.position;
        currentRotation = transform.rotation.eulerAngles;
        currentScale = transform.localScale;
        distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        
        // Apply movement if enabled
        if (enableMovement)
        {
            ApplyMovement();
        }
        
        // Apply rotation if enabled
        if (enableRotation)
        {
            ApplyRotation();
        }
        
        // Apply scaling if enabled
        if (enableScaling)
        {
            ApplyScaling();
        }
        
        // Reset position if it gets too far from origin
        if (Vector3.Distance(transform.position, Vector3.zero) > 20f)
        {
            Debug.Log("Object too far from origin - resetting position");
            transform.position = originalPosition;
        }
    }
    
    /// <summary>
    /// Demonstrates basic transform properties and access methods
    /// </summary>
    private void DemonstrateTransformProperties()
    {
        Debug.Log("\n--- TRANSFORM PROPERTIES ---");
        
        // Position properties
        Debug.Log($"World Position: {transform.position}");
        Debug.Log($"Local Position: {transform.localPosition}");
        
        // Rotation properties
        Debug.Log($"World Rotation (Quaternion): {transform.rotation}");
        Debug.Log($"World Rotation (Euler): {transform.rotation.eulerAngles}");
        Debug.Log($"Local Rotation (Euler): {transform.localRotation.eulerAngles}");
        
        // Scale properties
        Debug.Log($"Local Scale: {transform.localScale}");
        Debug.Log($"Lossy Scale (world scale): {transform.lossyScale}");
        
        // Hierarchy properties
        Debug.Log($"Parent: {(transform.parent != null ? transform.parent.name : "None")}");
        Debug.Log($"Child count: {transform.childCount}");
    }    
    /// <summary>
    /// Demonstrates Vector3 operations useful for transforms
    /// </summary>
    private void DemonstrateVectorOperations()
    {
        Debug.Log("\n--- VECTOR3 OPERATIONS ---");
        
        Vector3 pointA = new Vector3(0f, 0f, 0f);
        Vector3 pointB = new Vector3(3f, 4f, 0f);
        
        // Distance calculation
        float distance = Vector3.Distance(pointA, pointB);
        Debug.Log($"Distance between {pointA} and {pointB}: {distance}");
        
        // Direction calculation
        Vector3 direction = (pointB - pointA).normalized;
        Debug.Log($"Direction from A to B: {direction}");
        
        // Magnitude (length) of vector
        Vector3 velocity = new Vector3(3f, 4f, 0f);
        Debug.Log($"Velocity {velocity} has magnitude: {velocity.magnitude}");
        
        // Common direction vectors
        Debug.Log($"Vector3.right: {Vector3.right}");
        Debug.Log($"Vector3.up: {Vector3.up}");
        Debug.Log($"Vector3.forward: {Vector3.forward}");
        
        // Vector operations
        Vector3 scaled = velocity * 2f;
        Vector3 sum = pointA + velocity;
        Debug.Log($"Scaled velocity: {scaled}");
        Debug.Log($"Point A + velocity: {sum}");
    }
    
    /// <summary>
    /// Demonstrates the difference between world and local space
    /// </summary>
    private void DemonstrateWorldVsLocalSpace()
    {
        Debug.Log("\n--- WORLD VS LOCAL SPACE ---");
        
        // World space - absolute position in the scene
        Debug.Log($"World position: {transform.position}");
        Debug.Log("World position is absolute coordinates in the scene");
        
        // Local space - position relative to parent
        Debug.Log($"Local position: {transform.localPosition}");
        Debug.Log("Local position is relative to parent (or world if no parent)");
        
        // Transform directions
        Debug.Log($"Transform.right (local right): {transform.right}");
        Debug.Log($"Transform.up (local up): {transform.up}");
        Debug.Log($"Transform.forward (local forward): {transform.forward}");
        
        // These direction vectors change based on the object's rotation
        Debug.Log("These directions rotate with the object!");
    }    
    /// <summary>
    /// Applies movement towards the target position
    /// </summary>
    private void ApplyMovement()
    {
        // Method 1: Move towards target using MoveTowards
        // This provides constant speed movement
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        // Uncomment below to try different movement methods:
        
        // Method 2: Lerp (Linear Interpolation) - smooth but slows down near target
        // transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        // Method 3: Direct addition - constant velocity
        // Vector3 direction = (targetPosition - transform.position).normalized;
        // transform.position += direction * moveSpeed * Time.deltaTime;
        
        // Check if we've reached the target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Set a new random target
            targetPosition = new Vector3(
                Random.Range(-8f, 8f),
                Random.Range(-4f, 4f),
                0f
            );
            Debug.Log($"Reached target! New target: {targetPosition}");
        }
    }
    
    /// <summary>
    /// Applies continuous rotation to the object
    /// </summary>
    private void ApplyRotation()
    {
        // Rotate around the specified axis
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        
        // Alternative rotation methods:
        
        // Method 1: Set rotation directly
        // float angle = Time.time * rotationSpeed;
        // transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        // Method 2: Rotate towards a target rotation
        // Quaternion targetRot = Quaternion.Euler(0f, 0f, 90f);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }    
    /// <summary>
    /// Applies scaling animation to the object
    /// </summary>
    private void ApplyScaling()
    {
        // Animate scale using sine wave for smooth pulsing effect
        float scaleMultiplier = 1f + Mathf.Sin(Time.time * scaleSpeed) * 0.5f;
        Vector3 animatedScale = originalScale * scaleMultiplier;
        transform.localScale = animatedScale;
        
        // Alternative scaling methods:
        
        // Method 1: Scale towards target
        // transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
        
        // Method 2: Lerp scaling
        // transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
        
        // Method 3: Uniform scaling
        // float uniformScale = 1f + Mathf.PingPong(Time.time * scaleSpeed, 1f);
        // transform.localScale = Vector3.one * uniformScale;
    }
    
    /// <summary>
    /// Resets the transform to its original values
    /// Call this method from the Inspector or other scripts
    /// </summary>
    [ContextMenu("Reset Transform")]
    public void ResetTransform()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;
        
        Debug.Log("Transform reset to original values");
    }
    
    /// <summary>
    /// Demonstrates transform manipulation methods for game development
    /// </summary>
    [ContextMenu("Demo Transform Operations")]
    public void DemoTransformOperations()
    {
        Debug.Log("\n--- TRANSFORM OPERATIONS DEMO ---");
        
        // Translate (move) relative to current position
        transform.Translate(Vector3.right * 2f);
        Debug.Log("Moved 2 units to the right");
        
        // Rotate relative to current rotation
        transform.Rotate(Vector3.forward * 45f);
        Debug.Log("Rotated 45 degrees around Z-axis");
        
        // Scale relative to current scale
        transform.localScale *= 1.5f;
        Debug.Log("Scaled by 1.5x");
        
        // Look at a target (useful for AI, cameras, turrets)
        Vector3 lookTarget = new Vector3(5f, 5f, 0f);
        Vector3 direction = (lookTarget - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            Debug.Log($"Looking towards: {lookTarget}");
        }
    }
    
    /// <summary>
    /// Provides helpful tips about Transform usage in the console
    /// </summary>
    void OnValidate()
    {
        // This runs when values are changed in the Inspector
        if (Application.isPlaying)
        {
            Debug.Log("🎯 TRANSFORM TIPS:");
            Debug.Log("• Use Time.deltaTime for frame-rate independent movement");
            Debug.Log("• transform.position is world space, transform.localPosition is relative to parent");
            Debug.Log("• Vector3.MoveTowards provides constant speed, Lerp provides smooth slowdown");
            Debug.Log("• transform.Rotate() rotates relative, setting transform.rotation is absolute");
            Debug.Log("• Use Quaternion for rotations, Euler angles for display only");
        }
    }
}