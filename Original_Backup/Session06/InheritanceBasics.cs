using UnityEngine;

/// <summary>
/// Demonstrates inheritance with a complete enemy hierarchy system.
/// Shows how child classes inherit properties and methods from parent classes.
/// </summary>
public class InheritanceBasics : MonoBehaviour
{
    [Header("Enemy Hierarchy Demonstration")]
    [SerializeField] private bool testInheritance = false;
    
    void Start()
    {
        Debug.Log("=== INHERITANCE BASICS DEMONSTRATION ===");
        DemonstrateInheritance();
    }
    
    void Update()
    {
        if (testInheritance)
        {
            testInheritance = false;
            DemonstrateInheritance();
        }
    }
    
    private void DemonstrateInheritance()
    {
        Debug.Log("\n--- Creating Different Enemy Types ---");
        
        // Create different types of enemies
        Zombie zombie = new Zombie("Undead Walker", 50, 15);
        Robot robot = new Robot("Battle Droid", 80, 25);
        Wizard wizard = new Wizard("Dark Mage", 60, 30, 100);
        
        // All enemies can attack, but each has unique behaviour
        zombie.Attack();
        robot.Attack();
        wizard.Attack();
        
        // All enemies inherit the same basic methods
        Debug.Log("\n--- Shared Inherited Methods ---");
        zombie.TakeDamage(20);
        robot.TakeDamage(30);
        wizard.TakeDamage(25);
        
        // But each can have unique methods too
        Debug.Log("\n--- Unique Methods ---");
        zombie.Shamble();
        robot.ScanForTargets();
        wizard.CastSpell();
    }
}

/// <summary>
/// Base Enemy class - parent for all enemy types
/// </summary>
public class Enemy
{
    public string enemyName;
    public int health;
    public int damage;
    
    // Constructor
    public Enemy(string name, int hp, int dmg)
    {
        enemyName = name;
        health = hp;
        damage = dmg;
        Debug.Log("Created enemy: " + enemyName + " (HP: " + health + ", DMG: " + damage + ")");
    }
    
    // Virtual method - can be overridden by child classes
    public virtual void Attack()
    {
        Debug.Log(enemyName + " performs a basic attack for " + damage + " damage!");
    }
    
    // Regular method - inherited by all child classes
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log(enemyName + " takes " + damageAmount + " damage! HP: " + health);
        
        if (health <= 0)
        {
            Debug.Log(enemyName + " has been defeated!");
        }
    }
}

/// <summary>
/// Zombie class - inherits from Enemy
/// </summary>
public class Zombie : Enemy
{
    // Constructor - calls parent constructor
    public Zombie(string name, int hp, int dmg) : base(name, hp, dmg)
    {
        // Zombie-specific initialization can go here
    }
    
    // Override the Attack method with zombie-specific behaviour
    public override void Attack()
    {
        Debug.Log(enemyName + " shambles forward and bites for " + damage + " damage! *GROAN*");
    }
    
    // Unique zombie method
    public void Shamble()
    {
        Debug.Log(enemyName + " shambles slowly towards its target...");
    }
}

/// <summary>
/// Robot class - inherits from Enemy
/// </summary>
public class Robot : Enemy
{
    public Robot(string name, int hp, int dmg) : base(name, hp, dmg)
    {
    }
    
    public override void Attack()
    {
        Debug.Log(enemyName + " fires high-energy laser beams for " + damage + " damage! *ZAP*");
    }
    
    public void ScanForTargets()
    {
        Debug.Log(enemyName + " activates target scanning protocols... BEEP BEEP");
    }
}

/// <summary>
/// Wizard class - inherits from Enemy with additional magic properties
/// </summary>
public class Wizard : Enemy
{
    public int mana;
    
    public Wizard(string name, int hp, int dmg, int mp) : base(name, hp, dmg)
    {
        mana = mp;
        Debug.Log("Wizard " + enemyName + " has " + mana + " mana points!");
    }
    
    public override void Attack()
    {
        if (mana >= 20)
        {
            mana -= 20;
            Debug.Log(enemyName + " casts a magic missile for " + damage + " damage! *SPARKLE* (Mana: " + mana + ")");
        }
        else
        {
            Debug.Log(enemyName + " is out of mana and strikes with staff for " + (damage / 2) + " damage!");
        }
    }
    
    public void CastSpell()
    {
        if (mana >= 30)
        {
            mana -= 30;
            Debug.Log(enemyName + " casts a powerful spell! The air crackles with magic! (Mana: " + mana + ")");
        }
        else
        {
            Debug.Log(enemyName + " cannot cast spell - insufficient mana (" + mana + "/30)");
        }
    }
}