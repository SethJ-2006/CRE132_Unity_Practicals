using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Demonstrates abstract classes and methods.
/// Abstract classes define contracts that must be implemented by child classes.
/// </summary>
public class AbstractClassDemo : MonoBehaviour
{
    [Header("Abstract Class Demonstration")]
    [SerializeField] private bool testAbstractClasses = false;
    [SerializeField] private bool weaponShowcase = false;
    
    void Start()
    {
        Debug.Log("=== ABSTRACT CLASS DEMONSTRATION ===");
        DemonstrateAbstractClasses();
    }
    
    void Update()
    {
        if (testAbstractClasses)
        {
            testAbstractClasses = false;
            DemonstrateAbstractClasses();
        }
        
        if (weaponShowcase)
        {
            weaponShowcase = false;
            WeaponShowcase();
        }
    }
    
    private void DemonstrateAbstractClasses()
    {
        Debug.Log("\n--- Abstract Classes: Enforcing Implementation ---");
        
        // Cannot create abstract class directly: Weapon weapon = new Weapon(); // ERROR!
        // But can create concrete implementations:
        
        Sword ironSword = new Sword("Iron Sword", 25, 1.2f);
        Bow elfBow = new Bow("Elven Bow", 20, 2.0f, 30);
        MagicStaff fireStaff = new MagicStaff("Fire Staff", 35, 0.8f, 50);
        
        // All weapons can use shared methods (from abstract parent)
        Debug.Log("\n--- Shared Methods (Inherited from Abstract Parent) ---");
        ironSword.DisplayInfo();
        elfBow.DisplayInfo();
        fireStaff.DisplayInfo();
        
        // All weapons MUST implement abstract methods (but differently)
        Debug.Log("\n--- Abstract Methods (Must Be Implemented) ---");
        ironSword.UseWeapon();
        elfBow.UseWeapon();
        fireStaff.UseWeapon();
        
        // Unique methods for each weapon type
        Debug.Log("\n--- Unique Methods ---");
        ironSword.Sharpen();
        elfBow.AimCarefully();
        fireStaff.ChannelMagic();
    }
    
    private void WeaponShowcase()
    {
        Debug.Log("\n=== WEAPON SHOWCASE BATTLE ===");
        
        // Create weapon arsenal
        List<Weapon> weaponArsenal = new List<Weapon>
        {
            new Sword("Legendary Blade", 45, 1.5f),
            new Bow("Dragon Bow", 35, 2.2f, 50),
            new MagicStaff("Staff of Power", 55, 1.0f, 80),
            new Sword("Rusty Sword", 15, 0.8f),
            new Bow("Simple Bow", 18, 1.8f, 20)
        };
        
        Debug.Log("--- Weapon Arsenal Information ---");
        foreach (Weapon weapon in weaponArsenal)
        {
            weapon.DisplayInfo(); // Shared method
        }
        
        Debug.Log("\n--- Battle Sequence: All Weapons Fire! ---");
        foreach (Weapon weapon in weaponArsenal)
        {
            weapon.UseWeapon(); // Abstract method - different for each type
        }
        
        Debug.Log("\n--- Maintenance Check ---");
        foreach (Weapon weapon in weaponArsenal)
        {
            weapon.CheckCondition(); // Virtual method with default implementation
        }
    }
}

/// <summary>
/// Abstract Weapon class - cannot be instantiated directly.
/// Defines the contract that all weapons must follow.
/// </summary>
public abstract class Weapon
{
    protected string weaponName;    // protected = accessible by child classes
    protected int baseDamage;
    protected float attackSpeed;
    
    // Constructor for abstract class
    public Weapon(string name, int damage, float speed)
    {
        weaponName = name;
        baseDamage = damage;
        attackSpeed = speed;
        Debug.Log("Weapon created: " + weaponName);
    }
    
    // Abstract method - MUST be implemented by child classes
    public abstract void UseWeapon();
    
    // Regular method - inherited by all child classes
    public void DisplayInfo()
    {
        Debug.Log("Weapon: " + weaponName + " | Damage: " + baseDamage + " | Speed: " + attackSpeed);
    }
    
    // Virtual method - can be overridden but has default implementation
    public virtual void CheckCondition()
    {
        Debug.Log(weaponName + " is in working condition.");
    }
}

/// <summary>
/// Sword class - concrete implementation of abstract Weapon
/// </summary>
public class Sword : Weapon
{
    private float sharpness = 1.0f;
    
    public Sword(string name, int damage, float speed) : base(name, damage, speed)
    {
    }
    
    // MUST implement abstract method
    public override void UseWeapon()
    {
        int totalDamage = Mathf.RoundToInt(baseDamage * sharpness);
        Debug.Log(weaponName + " slashes for " + totalDamage + " damage! *CLANG*");
    }
    
    // Unique sword method
    public void Sharpen()
    {
        sharpness = Mathf.Min(sharpness + 0.2f, 2.0f);
        Debug.Log(weaponName + " has been sharpened! Sharpness: " + sharpness.ToString("F1"));
    }
    
    public override void CheckCondition()
    {
        if (sharpness < 0.5f)
        {
            Debug.Log(weaponName + " is getting dull and needs sharpening.");
        }
        else
        {
            base.CheckCondition(); // Call parent method
        }
    }
}

/// <summary>
/// Bow class - concrete implementation of abstract Weapon
/// </summary>
public class Bow : Weapon
{
    private int arrowCount;
    
    public Bow(string name, int damage, float speed, int arrows) : base(name, damage, speed)
    {
        arrowCount = arrows;
    }
    
    public override void UseWeapon()
    {
        if (arrowCount > 0)
        {
            arrowCount--;
            Debug.Log(weaponName + " fires an arrow for " + baseDamage + " damage! *WHOOSH* (Arrows: " + arrowCount + ")");
        }
        else
        {
            Debug.Log(weaponName + " is out of arrows! Cannot attack!");
        }
    }
    
    public void AimCarefully()
    {
        Debug.Log("Taking careful aim with " + weaponName + "... *draw string*");
    }
    
    public override void CheckCondition()
    {
        if (arrowCount <= 5)
        {
            Debug.Log(weaponName + " is running low on arrows (" + arrowCount + " remaining).");
        }
        else
        {
            base.CheckCondition();
        }
    }
}

/// <summary>
/// MagicStaff class - concrete implementation of abstract Weapon
/// </summary>
public class MagicStaff : Weapon
{
    private int magicPower;
    
    public MagicStaff(string name, int damage, float speed, int power) : base(name, damage, speed)
    {
        magicPower = power;
    }
    
    public override void UseWeapon()
    {
        if (magicPower >= 10)
        {
            magicPower -= 10;
            int magicDamage = baseDamage + (magicPower / 5);
            Debug.Log(weaponName + " casts a spell for " + magicDamage + " magic damage! *SPARKLE* (Power: " + magicPower + ")");
        }
        else
        {
            Debug.Log(weaponName + " is out of magic power! Striking with staff for " + (baseDamage / 2) + " damage.");
        }
    }
    
    public void ChannelMagic()
    {
        magicPower = Mathf.Min(magicPower + 15, 100);
        Debug.Log("Channelling magic into " + weaponName + "... Power: " + magicPower + "/100");
    }
    
    public override void CheckCondition()
    {
        if (magicPower < 20)
        {
            Debug.Log(weaponName + " needs magic recharging (Power: " + magicPower + "/100).");
        }
        else
        {
            base.CheckCondition();
        }
    }
}