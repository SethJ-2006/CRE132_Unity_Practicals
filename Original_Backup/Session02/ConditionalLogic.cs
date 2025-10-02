using UnityEngine;

/// <summary>
/// Demonstrates conditional logic, comparison operators, and boolean logic
/// Shows practical if/else statements and decision-making in games
/// </summary>
public class ConditionalLogic : MonoBehaviour
{
    [Header("=== PLAYER STATS FOR TESTING ===")]
    public int playerHealth = 75;
    public int playerLevel = 8;
    public int playerScore = 1250;
    public float playerSpeed = 5.5f;
    public int playerAmmo = 15;
    
    [Header("=== GAME CONDITIONS ===")]
    public bool hasKey = true;
    public bool doorIsLocked = true;
    public bool isGamePaused = false;
    public bool isGodMode = false;
    public string difficulty = "Medium";  // Easy, Medium, Hard
    
    [Header("=== THRESHOLDS AND LIMITS ===")]
    public int lowHealthThreshold = 25;
    public int highScoreThreshold = 1000;
    public int maxLevel = 20;
    public int lowAmmoWarning = 10;
    
    [Header("=== COMPARISON RESULTS (READ-ONLY) ===")]
    [SerializeField] private string healthStatus;
    [SerializeField] private string levelProgress;
    [SerializeField] private string scoreRating;
    [SerializeField] private bool canEnterBossArea;
    [SerializeField] private bool needsAmmoRefill;
    
    void Start()
    {
        Debug.Log("=== CONDITIONAL LOGIC DEMONSTRATION ===");
        Debug.Log("This script demonstrates if/else statements and boolean logic");
        
        // Run all conditional logic demonstrations
        DemonstrateBasicConditions();
        DemonstrateComparisonOperators();
        DemonstrateLogicalOperators();
        DemonstrateNestedConditions();
        DemonstratePracticalGameLogic();
    }
    
    void Update()
    {
        // Update conditions in real-time for Inspector display
        UpdateConditionalResults();
        
        // Check for input to trigger additional demonstrations
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("\n--- LIVE CONDITION CHECK ---");
            CheckAllConditions();
        }
    }
    
    /// <summary>
    /// Shows basic if, if-else, and if-else if structures
    /// </summary>
    void DemonstrateBasicConditions()
    {
        Debug.Log("\n--- BASIC IF STATEMENTS ---");
        
        // Simple if statement
        if (playerHealth > 0)
        {
            Debug.Log("✓ Player is alive!");
        }
        
        // If-else statement
        if (playerScore >= highScoreThreshold)
        {
            Debug.Log("✓ High score achieved!");
        }
        else
        {
            Debug.Log("Keep trying to reach high score!");
        }
        
        // If-else if-else chain
        if (playerHealth > 75)
        {
            Debug.Log("Health Status: Excellent");
        }
        else if (playerHealth > 50)
        {
            Debug.Log("Health Status: Good");
        }
        else if (playerHealth > lowHealthThreshold)
        {
            Debug.Log("Health Status: Warning");
        }
        else
        {
            Debug.Log("Health Status: Critical!");
        }
    }
    
    /// <summary>
    /// Demonstrates all comparison operators
    /// </summary>
    void DemonstrateComparisonOperators()
    {
        Debug.Log("\n--- COMPARISON OPERATORS ---");
        
        // Equal to (==)
        if (difficulty == "Medium")
        {
            Debug.Log("✓ Difficulty is set to Medium");
        }
        
        // Not equal to (!=)
        if (playerHealth != 0)
        {
            Debug.Log("✓ Player is not dead (health ≠ 0)");
        }
        
        // Greater than (>)
        if (playerLevel > 5)
        {
            Debug.Log($"✓ Player is experienced (level {playerLevel} > 5)");
        }
        
        // Less than (<)
        if (playerAmmo < lowAmmoWarning)
        {
            Debug.Log($"⚠ Low ammo warning! ({playerAmmo} < {lowAmmoWarning})");
        }
        
        // Greater than or equal (>=)
        if (playerScore >= 1000)
        {
            Debug.Log($"✓ Eligible for bonus (score {playerScore} >= 1000)");
        }
        
        // Less than or equal (<=)
        if (playerLevel <= maxLevel)
        {
            Debug.Log($"✓ Level within limit ({playerLevel} <= {maxLevel})");
        }
    }
    
    /// <summary>
    /// Shows logical operators (&&, ||, !)
    /// </summary>
    void DemonstrateLogicalOperators()
    {
        Debug.Log("\n--- LOGICAL OPERATORS ---");
        
        // AND operator (&&) - both conditions must be true
        if (hasKey && doorIsLocked)
        {
            Debug.Log("✓ Can unlock door (have key AND door is locked)");
        }
        
        if (playerHealth > 50 && playerAmmo > 5)
        {
            Debug.Log("✓ Ready for combat (healthy AND armed)");
        }
        
        // OR operator (||) - at least one condition must be true
        if (playerHealth <= 0 || isGamePaused)
        {
            Debug.Log("⚠ Game should stop (player dead OR game paused)");
        }
        else
        {
            Debug.Log("✓ Game continues (player alive AND not paused)");
        }
        
        if (playerLevel >= 10 || isGodMode)
        {
            Debug.Log("✓ Can access advanced features (high level OR god mode)");
        }
        
        // NOT operator (!) - reverses the boolean value
        if (!isGamePaused)
        {
            Debug.Log("✓ Game is running (NOT paused)");
        }
        
        if (!hasKey)
        {
            Debug.Log("⚠ Cannot unlock doors (does NOT have key)");
        }
        else
        {
            Debug.Log("✓ Has key for unlocking doors");
        }
    }
    
    /// <summary>
    /// Shows nested if statements and complex conditions
    /// </summary>
    void DemonstrateNestedConditions()
    {
        Debug.Log("\n--- NESTED CONDITIONS ---");
        
        // Nested if statements
        if (playerHealth > 0)
        {
            Debug.Log("Player is alive, checking combat readiness...");
            
            if (playerAmmo > 0)
            {
                Debug.Log("  ✓ Has ammunition");
                
                if (playerAmmo >= 20)
                {
                    Debug.Log("    ✓ Fully stocked!");
                }
                else if (playerAmmo >= 10)
                {
                    Debug.Log("    - Moderate ammo supply");
                }
                else
                {
                    Debug.Log("    ⚠ Running low on ammo");
                }
            }
            else
            {
                Debug.Log("  ✗ No ammunition - find ammo!");
            }
        }
        else
        {
            Debug.Log("Player is dead - cannot fight");
        }
        
        // Complex combined conditions
        if ((playerLevel >= 5 && playerHealth > 30) || isGodMode)
        {
            if (hasKey || playerLevel >= 10)
            {
                Debug.Log("✓ Can enter special area (experienced + healthy + access)");
            }
            else
            {
                Debug.Log("⚠ Need key or higher level for special area");
            }
        }
    }
    
    /// <summary>
    /// Shows practical game logic examples
    /// </summary>
    void DemonstratePracticalGameLogic()
    {
        Debug.Log("\n--- PRACTICAL GAME LOGIC ---");
        
        // Difficulty-based logic
        if (difficulty == "Easy")
        {
            Debug.Log("Easy mode: Extra health and damage reduction active");
        }
        else if (difficulty == "Medium")
        {
            Debug.Log("Medium mode: Balanced gameplay");
        }
        else if (difficulty == "Hard")
        {
            Debug.Log("Hard mode: Reduced health and increased enemy damage");
        }
        else
        {
            Debug.Log("Unknown difficulty setting - defaulting to Medium");
        }
        
        // Player progression logic
        if (playerLevel < 5)
        {
            Debug.Log("Beginner player - tutorial tips enabled");
        }
        else if (playerLevel < 15)
        {
            Debug.Log("Intermediate player - advanced features unlocked");
        }
        else
        {
            Debug.Log("Expert player - all content available");
        }
        
        // Resource management
        CheckResourceLevels();
        
        // Action availability
        CheckAvailableActions();
    }
    
    /// <summary>
    /// Checks resource levels and provides warnings
    /// </summary>
    void CheckResourceLevels()
    {
        Debug.Log("\n  Resource Status Check:");
        
        // Health check
        if (playerHealth <= 0)
        {
            Debug.Log("  💀 CRITICAL: Player is dead!");
        }
        else if (playerHealth <= lowHealthThreshold)
        {
            Debug.Log($"  ❤️ WARNING: Low health ({playerHealth})");
        }
        else if (playerHealth < 50)
        {
            Debug.Log($"  💛 CAUTION: Moderate health ({playerHealth})");
        }
        else
        {
            Debug.Log($"  💚 OK: Healthy ({playerHealth})");
        }
        
        // Ammo check
        if (playerAmmo <= 0)
        {
            Debug.Log("  🔫 CRITICAL: No ammunition!");
        }
        else if (playerAmmo <= lowAmmoWarning)
        {
            Debug.Log($"  ⚠️ WARNING: Low ammo ({playerAmmo})");
        }
        else
        {
            Debug.Log($"  ✅ OK: Sufficient ammo ({playerAmmo})");
        }
    }
    
    /// <summary>
    /// Determines what actions the player can perform
    /// </summary>
    void CheckAvailableActions()
    {
        Debug.Log("\n  Available Actions:");
        
        // Combat actions
        if (playerHealth > 0 && playerAmmo > 0)
        {
            Debug.Log("  ⚔️ Can attack enemies");
        }
        
        // Movement actions
        if (playerHealth > 0)
        {
            Debug.Log("  🏃 Can move around");
            
            if (playerSpeed > 5f)
            {
                Debug.Log("  💨 Can run quickly");
            }
        }
        
        // Interaction actions
        if (hasKey && doorIsLocked)
        {
            Debug.Log("  🔑 Can unlock doors");
        }
        
        // Special actions
        if (playerLevel >= 10 || isGodMode)
        {
            Debug.Log("  ⭐ Can use special abilities");
        }
        
        if (playerScore >= highScoreThreshold)
        {
            Debug.Log("  🏆 Can access bonus content");
        }
    }
    
    /// <summary>
    /// Updates the Inspector display with current condition results
    /// </summary>
    void UpdateConditionalResults()
    {
        // Health status
        if (playerHealth > 75)
            healthStatus = "Excellent";
        else if (playerHealth > 50)
            healthStatus = "Good";
        else if (playerHealth > lowHealthThreshold)
            healthStatus = "Warning";
        else
            healthStatus = "Critical";
        
        // Level progress
        float levelPercentage = (playerLevel / (float)maxLevel) * 100f;
        levelProgress = $"{levelPercentage:F0}% (Level {playerLevel}/{maxLevel})";
        
        // Score rating
        if (playerScore >= highScoreThreshold * 2)
            scoreRating = "Excellent";
        else if (playerScore >= highScoreThreshold)
            scoreRating = "High Score";
        else
            scoreRating = "Keep Trying";
        
        // Boss area access
        canEnterBossArea = (playerLevel >= 8 && playerHealth > 50) || isGodMode;
        
        // Ammo status
        needsAmmoRefill = playerAmmo <= lowAmmoWarning;
    }
    
    /// <summary>
    /// Performs a comprehensive check of all conditions (triggered by C key)
    /// </summary>
    void CheckAllConditions()
    {
        Debug.Log($"Player Status Summary:");
        Debug.Log($"  Health: {playerHealth} ({healthStatus})");
        Debug.Log($"  Level: {playerLevel} ({levelProgress})");
        Debug.Log($"  Score: {playerScore} ({scoreRating})");
        Debug.Log($"  Ammo: {playerAmmo} {(needsAmmoRefill ? "(LOW)" : "(OK)")}");
        Debug.Log($"  Boss Area Access: {(canEnterBossArea ? "YES" : "NO")}");
        Debug.Log($"  Has Key: {hasKey}");
        Debug.Log($"  God Mode: {isGodMode}");
        Debug.Log($"  Difficulty: {difficulty}");
    }
}
