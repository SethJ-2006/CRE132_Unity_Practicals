using UnityEngine;

/// <summary>
/// Demonstrates fundamental class and object concepts in Unity.
/// Shows how to create classes, instantiate objects, and work with class members.
/// 
/// Learning Goals:
/// - Understand the difference between classes (blueprints) and objects (instances)
/// - Learn how to create multiple objects from the same class
/// - See how each object maintains its own data
/// - Practice calling methods on different objects
/// </summary>
public class ClassBasics : MonoBehaviour
{
    [Header("Class Demonstration Settings")]
    [Tooltip("How often to run automatic demonstrations")]
    public float demonstrationInterval = 3.0f;
    
    [Header("Object Management")]
    [Tooltip("Track created objects for demonstration")]
    public int totalObjectsCreated = 0;
    
    // Timer for automatic demonstration
    private float nextDemoTime;
    
    /// <summary>
    /// Simple Enemy class to demonstrate OOP basics.
    /// This is a blueprint that defines what all enemies have and can do.
    /// </summary>
    public class Enemy
    {
        // Fields - data that each enemy object will have
        public string enemyName;
        public int health;
        public int damage;
        public float speed;
        public bool isAlive;
        
        // Default constructor - creates enemy with standard values
        public Enemy()
        {
            enemyName = "Basic Enemy";
            health = 50;
            damage = 10;
            speed = 2.0f;
            isAlive = true;
        }
        
        // Parameterised constructor - creates enemy with custom values
        public Enemy(string name, int hp, int attackDamage, float moveSpeed)
        {
            enemyName = name;
            health = hp;
            damage = attackDamage;
            speed = moveSpeed;
            isAlive = true;
        }
        
        // Method - something the enemy can do
        public void TakeDamage(int damageAmount)
        {
            if (!isAlive) 
            {
                Debug.Log($"{enemyName} is already dead!");
                return;
            }
            
            health -= damageAmount;
            Debug.Log($"{enemyName} took {damageAmount} damage. Health: {health}");
            
            if (health <= 0)
            {
                Die();
            }
        }
        
        // Method - enemy dies
        public void Die()
        {
            isAlive = false;
            health = 0;
            Debug.Log($"💀 {enemyName} has been defeated!");
        }
        
        // Method - enemy attacks (returns damage dealt)
        public int Attack()
        {
            if (!isAlive)
            {
                Debug.Log($"{enemyName} cannot attack - it's dead!");
                return 0;
            }
            
            Debug.Log($"⚔️ {enemyName} attacks for {damage} damage!");
            return damage;
        }
        
        // Method - get enemy status information
        public string GetStatus()
        {
            string status = isAlive ? "ALIVE" : "DEAD";
            return $"{enemyName}: {health}HP, {damage} ATK, {speed} SPD [{status}]";
        }
    }
    
    /// <summary>
    /// Weapon class to demonstrate another practical OOP example
    /// </summary>
    public class Weapon
    {
        public string weaponName;
        public int damage;
        public float fireRate;
        public int durability;
        public bool isBroken;
        
        // Constructor with all parameters
        public Weapon(string name, int weaponDamage, float rate, int startingDurability)
        {
            weaponName = name;
            damage = weaponDamage;
            fireRate = rate;
            durability = startingDurability;
            isBroken = false;
        }
        
        // Method to use the weapon
        public int UseWeapon()
        {
            if (isBroken)
            {
                Debug.Log($"💥 {weaponName} is broken and cannot be used!");
                return 0;
            }
            
            durability--;
            Debug.Log($"🗡️ {weaponName} used! Durability: {durability}/{durability + 1}");
            
            if (durability <= 0)
            {
                BreakWeapon();
            }
            
            return damage;
        }
        
        // Method to break the weapon
        private void BreakWeapon()
        {
            isBroken = true;
            Debug.Log($"💔 {weaponName} has broken!");
        }
        
        // Method to repair the weapon
        public void Repair(int repairAmount)
        {
            if (!isBroken && durability >= 100)
            {
                Debug.Log($"{weaponName} is already in perfect condition!");
                return;
            }
            
            durability += repairAmount;
            if (durability > 100) durability = 100;
            
            if (isBroken && durability > 0)
            {
                isBroken = false;
                Debug.Log($"🔧 {weaponName} has been repaired! Durability: {durability}");
            }
        }
        
        // Method to get weapon information
        public string GetInfo()
        {
            string condition = isBroken ? "BROKEN" : "WORKING";
            return $"{weaponName}: {damage} DMG, {fireRate} Fire Rate, {durability} DUR [{condition}]";
        }
    }
    
    void Start()
    {
        Debug.Log("=== CLASS BASICS DEMONSTRATION STARTED ===");
        Debug.Log("This script demonstrates fundamental OOP concepts: classes, objects, and methods");
        Debug.Log("Watch the Console to see how multiple objects work independently!");
        Debug.Log("");
        
        // Initial demonstration
        DemonstrateBasicClasses();
        
        // Set up timer for ongoing demonstrations
        nextDemoTime = Time.time + demonstrationInterval;
    }
    
    void Update()
    {
        // Run demonstration periodically
        if (Time.time >= nextDemoTime)
        {
            RunInteractiveDemo();
            nextDemoTime = Time.time + demonstrationInterval;
        }
        
        // Manual demonstrations with keyboard input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DemonstrateBasicClasses();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DemonstrateMultipleObjects();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DemonstrateWeaponSystem();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DemonstrateCombatScenario();
        }
    }
    
    /// <summary>
    /// Demonstrates creating objects from classes and calling their methods
    /// </summary>
    void DemonstrateBasicClasses()
    {
        Debug.Log("--- BASIC CLASS DEMONSTRATION ---");
        
        // Creating objects from the Enemy class (using the blueprint)
        Enemy goblin = new Enemy();  // Uses default constructor
        Enemy dragon = new Enemy("Fire Dragon", 200, 50, 1.5f);  // Uses parameterised constructor
        
        totalObjectsCreated += 2;
        
        // Each object has its own data
        Debug.Log("Created two enemy objects:");
        Debug.Log($"Object 1: {goblin.GetStatus()}");
        Debug.Log($"Object 2: {dragon.GetStatus()}");
        
        // Each object can perform actions independently
        Debug.Log("\\nTesting independent object behaviour:");
        goblin.TakeDamage(20);  // Only affects the goblin object
        dragon.TakeDamage(30);  // Only affects the dragon object
        
        Debug.Log("After taking damage:");
        Debug.Log($"Goblin: {goblin.GetStatus()}");
        Debug.Log($"Dragon: {dragon.GetStatus()}");
        
        Debug.Log($"Total objects created so far: {totalObjectsCreated}");
        Debug.Log("");
    }
    
    /// <summary>
    /// Shows how multiple objects of the same class work independently
    /// </summary>
    void DemonstrateMultipleObjects()
    {
        Debug.Log("--- MULTIPLE OBJECTS DEMONSTRATION ---");
        
        // Create an army of enemies
        Enemy[] enemies = new Enemy[4];
        enemies[0] = new Enemy("Goblin Scout", 30, 8, 3.0f);
        enemies[1] = new Enemy("Orc Warrior", 80, 15, 2.0f);
        enemies[2] = new Enemy("Skeleton Archer", 40, 12, 2.5f);
        enemies[3] = new Enemy("Troll Berserker", 120, 25, 1.0f);
        
        totalObjectsCreated += 4;
        
        Debug.Log("Created enemy army:");
        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log($"Enemy {i + 1}: {enemies[i].GetStatus()}");
        }
        
        // Simulate combat - each enemy takes different damage
        Debug.Log("\\nSimulating area-of-effect attack (20 damage to all):");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].TakeDamage(20);
        }
        
        // Show results - notice how each object maintained its own state
        Debug.Log("\\nAfter AoE attack:");
        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log($"Enemy {i + 1}: {enemies[i].GetStatus()}");
        }
        
        Debug.Log($"Total objects created so far: {totalObjectsCreated}");
        Debug.Log("");
    }
    
    /// <summary>
    /// Demonstrates the Weapon class and object interactions
    /// </summary>
    void DemonstrateWeaponSystem()
    {
        Debug.Log("--- WEAPON SYSTEM DEMONSTRATION ---");
        
        // Create different weapon objects
        Weapon sword = new Weapon("Iron Sword", 25, 1.5f, 50);
        Weapon bow = new Weapon("Elven Bow", 20, 2.0f, 30);
        Weapon hammer = new Weapon("War Hammer", 40, 0.8f, 80);
        
        totalObjectsCreated += 3;
        
        Debug.Log("Created weapon arsenal:");
        Debug.Log($"Weapon 1: {sword.GetInfo()}");
        Debug.Log($"Weapon 2: {bow.GetInfo()}");
        Debug.Log($"Weapon 3: {hammer.GetInfo()}");
        
        // Use weapons - each tracks its own durability
        Debug.Log("\\nUsing weapons in combat:");
        
        for (int i = 0; i < 3; i++)
        {
            Debug.Log($"\\nCombat Round {i + 1}:");
            sword.UseWeapon();
            bow.UseWeapon();
            hammer.UseWeapon();
        }
        
        // Show current weapon states
        Debug.Log("\\nWeapon conditions after combat:");
        Debug.Log($"Sword: {sword.GetInfo()}");
        Debug.Log($"Bow: {bow.GetInfo()}");
        Debug.Log($"Hammer: {hammer.GetInfo()}");
        
        // Repair weapons
        Debug.Log("\\nRepairing weapons:");
        sword.Repair(10);
        bow.Repair(20);
        hammer.Repair(5);
        
        Debug.Log($"Total objects created so far: {totalObjectsCreated}");
        Debug.Log("");
    }
    
    /// <summary>
    /// Combines enemies and weapons in a realistic combat scenario
    /// </summary>
    void DemonstrateCombatScenario()
    {
        Debug.Log("--- COMPLETE COMBAT SCENARIO ---");
        
        // Create participants
        Enemy boss = new Enemy("Shadow Lord", 150, 30, 1.2f);
        Weapon playerWeapon = new Weapon("Legendary Blade", 35, 1.8f, 25);
        
        totalObjectsCreated += 2;
        
        Debug.Log("Combat participants:");
        Debug.Log($"Enemy: {boss.GetStatus()}");
        Debug.Log($"Player Weapon: {playerWeapon.GetInfo()}");
        
        // Simulate turn-based combat
        Debug.Log("\\n🥊 COMBAT BEGINS!");
        int turn = 1;
        
        while (boss.isAlive && !playerWeapon.isBroken && turn <= 8)
        {
            Debug.Log($"\\n--- Turn {turn} ---");
            
            // Player attacks
            int playerDamage = playerWeapon.UseWeapon();
            if (playerDamage > 0)
            {
                boss.TakeDamage(playerDamage);
            }
            
            // Boss counter-attacks (if still alive)
            if (boss.isAlive)
            {
                int bossDamage = boss.Attack();
                Debug.Log($"Player takes {bossDamage} damage from {boss.enemyName}!");
            }
            
            // Show status
            Debug.Log($"Status - Enemy: {boss.health}HP, Weapon: {playerWeapon.durability} DUR");
            
            turn++;
        }
        
        // Combat results
        Debug.Log("\\n🏁 COMBAT ENDED!");
        if (!boss.isAlive)
        {
            Debug.Log("🎉 Player wins! Boss defeated!");
        }
        else if (playerWeapon.isBroken)
        {
            Debug.Log("💔 Player's weapon broke! Boss wins!");
        }
        else
        {
            Debug.Log("⏰ Combat timed out - it's a draw!");
        }
        
        Debug.Log($"Final Status - Enemy: {boss.GetStatus()}");
        Debug.Log($"Final Status - Weapon: {playerWeapon.GetInfo()}");
        Debug.Log($"Total objects created so far: {totalObjectsCreated}");
        Debug.Log("");
    }
    
    /// <summary>
    /// Interactive demo that runs periodically
    /// </summary>
    void RunInteractiveDemo()
    {
        Debug.Log("🔄 Auto-Demo: Creating and testing new objects...");
        
        // Create random enemy
        string[] names = { "Goblin", "Orc", "Skeleton", "Spider", "Wolf" };
        string randomName = names[Random.Range(0, names.Length)];
        
        Enemy randomEnemy = new Enemy(randomName, Random.Range(30, 100), Random.Range(10, 25), Random.Range(1.0f, 3.0f));
        totalObjectsCreated++;
        
        Debug.Log($"Created: {randomEnemy.GetStatus()}");
        
        // Test the enemy
        randomEnemy.TakeDamage(Random.Range(15, 40));
        Debug.Log($"After damage: {randomEnemy.GetStatus()}");
        
        Debug.Log($"Running objects demonstration. Total created: {totalObjectsCreated}");
        Debug.Log("Press 1, 2, 3, or 4 for manual demonstrations!");
        Debug.Log("");
    }
    
    /// <summary>
    /// Called when component is added or reset in editor
    /// </summary>
    void Reset()
    {
        demonstrationInterval = 3.0f;
        totalObjectsCreated = 0;
    }
}