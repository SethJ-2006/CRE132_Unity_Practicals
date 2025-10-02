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