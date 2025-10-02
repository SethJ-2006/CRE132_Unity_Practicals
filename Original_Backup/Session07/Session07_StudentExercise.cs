using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Session 07 Student Exercise: Interfaces & Game Management
/// 
/// LEARNING OBJECTIVES:
/// - Create and implement interfaces for game entities
/// - Use switch statements for complex conditional logic
/// - Build a complete game state management system
/// - Combine interfaces with inheritance from previous sessions
/// - Create professional game architecture patterns
/// 
/// INSTRUCTIONS:
/// 1. Complete all TODO sections in order
/// 2. Test each section before moving to the next
/// 3. Use Debug.Log to verify your implementations
/// 4. Check the Console window for output and errors
/// 5. Use the Inspector checkboxes to test your work
/// </summary>
public class Session07_StudentExercise : MonoBehaviour
{
    [Header("Student Exercise Controls")]
    [SerializeField] private bool testInventorySystem = false;
    [SerializeField] private bool testCombatInterfaces = false;
    [SerializeField] private bool testSwitchLogic = false;
    [SerializeField] private bool testGameManager = false;
    [SerializeField] private bool runFinalChallenge = false;
    
    void Start()
    {
        Debug.Log("=== SESSION 07 STUDENT EXERCISE ===");
        Debug.Log("Complete the TODO sections below and test using the checkboxes!");
    }
    
    void Update()
    {
        if (testInventorySystem)
        {
            testInventorySystem = false;
            TestInventorySystem();
        }
        
        if (testCombatInterfaces)
        {
            testCombatInterfaces = false;
            TestCombatInterfaces();
        }
        
        if (testSwitchLogic)
        {
            testSwitchLogic = false;
            TestSwitchLogic();
        }
        
        if (testGameManager)
        {
            testGameManager = false;
            TestGameManager();
        }
        
        if (runFinalChallenge)
        {
            runFinalChallenge = false;
            RunFinalChallenge();
        }
    }
    
    #region Exercise 1: Inventory System with Interfaces
    
    /// <summary>
    /// Exercise 1: Create an inventory system using interfaces
    /// TODO: Complete the interface definitions and implementations below
    /// </summary>
    private void TestInventorySystem()
    {
        Debug.Log("\n=== EXERCISE 1: INVENTORY SYSTEM ===");
        
        // TODO 1.1: Uncomment and test when interfaces are completed
        /*
        List<ICollectable> inventory = new List<ICollectable>
        {
            new Coin(50),
            new HealthPotion(25),
            new MagicScroll("Fireball", 30),
            new Key("Gold Key"),
            new Gem("Ruby", 100)
        };
        
        Debug.Log("--- Collecting Items ---");
        foreach (ICollectable item in inventory)
        {
            item.Collect();
        }
        
        Debug.Log("\n--- Using Useable Items ---");
        foreach (ICollectable item in inventory)
        {
            if (item is IUseable useableItem)
            {
                useableItem.Use();
            }
        }
        
        Debug.Log("\n--- Checking Valuable Items ---");
        foreach (ICollectable item in inventory)
        {
            if (item is IValuable valuableItem)
            {
                Debug.Log("Item value: " + valuableItem.GetValue() + " gold");
            }
        }
        */
        
        Debug.Log("TODO: Complete the inventory interfaces and item classes!");
    }
    
    #endregion
    
    #region Exercise 2: Combat System with Multiple Interfaces
    
    /// <summary>
    /// Exercise 2: Create a combat system using multiple interfaces
    /// TODO: Complete the combat interfaces and character implementations
    /// </summary>
    private void TestCombatInterfaces()
    {
        Debug.Log("\n=== EXERCISE 2: COMBAT INTERFACES ===");
        
        // TODO 2.1: Uncomment when combat classes are completed
        /*
        List<IFighter> combatants = new List<IFighter>
        {
            new Knight("Sir Lancelot", 120, 30),
            new Wizard("Merlin", 80, 40, 150),
            new Archer("Robin Hood", 100, 25, 40),
            new Monster("Dragon", 300, 50)
        };
        
        Debug.Log("--- Combat Round 1: Everyone Attacks ---");
        foreach (IFighter fighter in combatants)
        {
            fighter.Attack();
        }
        
        Debug.Log("\n--- Healing Phase ---");
        foreach (IFighter fighter in combatants)
        {
            if (fighter is IHealer healer)
            {
                healer.Heal(20);
            }
        }
        
        Debug.Log("\n--- Magic Phase ---");
        foreach (IFighter fighter in combatants)
        {
            if (fighter is IMagicUser mage)
            {
                mage.CastSpell("Magic Missile");
            }
        }
        */
        
        Debug.Log("TODO: Complete the combat interface system!");
    }
    
    #endregion
    
    #region Exercise 3: Switch Statement Logic
    
    /// <summary>
    /// Exercise 3: Implement complex switch statement logic
    /// TODO: Complete the switch statement implementations
    /// </summary>
    private void TestSwitchLogic()
    {
        Debug.Log("\n=== EXERCISE 3: SWITCH STATEMENTS ===");
        
        // TODO 3.1: Complete the difficulty system
        TestDifficultySystem();
        
        // TODO 3.2: Complete the quest system
        TestQuestSystem();
        
        // TODO 3.3: Complete the item type system
        TestItemTypeSystem();
    }
    
    private void TestDifficultySystem()
    {
        Debug.Log("--- Difficulty System Test ---");
        
        // TODO: Test different difficulty levels
        DifficultyLevel[] difficulties = { DifficultyLevel.Easy, DifficultyLevel.Normal, DifficultyLevel.Hard, DifficultyLevel.Nightmare };
        
        foreach (DifficultyLevel difficulty in difficulties)
        {
            ProcessDifficulty(difficulty);
        }
    }
    
    private void TestQuestSystem()
    {
        Debug.Log("--- Quest System Test ---");
        
        // TODO: Test different quest types
        QuestType[] quests = { QuestType.KillEnemies, QuestType.CollectItems, QuestType.DeliverMessage, QuestType.Explore };
        
        foreach (QuestType quest in quests)
        {
            ProcessQuest(quest);
        }
    }
    
    private void TestItemTypeSystem()
    {
        Debug.Log("--- Item Type System Test ---");
        
        // TODO: Test different item types
        string[] items = { "sword", "potion", "key", "scroll", "gold", "unknown" };
        
        foreach (string item in items)
        {
            ProcessItemType(item);
        }
    }
    
    #endregion
    
    #region Exercise 4: Game Management System
    
    /// <summary>
    /// Exercise 4: Create a comprehensive game management system
    /// TODO: Complete the mini-game manager
    /// </summary>
    private void TestGameManager()
    {
        Debug.Log("\n=== EXERCISE 4: GAME MANAGEMENT ===");
        
        // TODO 4.1: Test the mini-game manager
        Debug.Log("TODO: Implement MiniGameManager class and test state transitions!");
    }
    
    #endregion
    
    #region Exercise 5: Final Challenge
    
    /// <summary>
    /// Exercise 5: Final Challenge - Complete RPG System
    /// TODO: Create a comprehensive RPG system combining all concepts
    /// </summary>
    private void RunFinalChallenge()
    {
        Debug.Log("\n=== FINAL CHALLENGE: COMPLETE RPG SYSTEM ===");
        
        Debug.Log("TODO: Create a complete RPG system that demonstrates:");
        Debug.Log("- Multiple interfaces working together");
        Debug.Log("- Complex switch statement logic");
        Debug.Log("- Professional state management");
        Debug.Log("- Integration with previous OOP concepts");
        Debug.Log("- Realistic game development patterns");
    }
    
    #endregion
    
    /// <summary>
    /// TODO 3.1: Complete the ProcessDifficulty method
    /// REQUIREMENTS:
    /// - Use switch statement to handle each difficulty level
    /// - Easy: "Enemies deal 50% damage, player gets 2x health"
    /// - Normal: "Standard gameplay experience"
    /// - Hard: "Enemies deal 150% damage, resources are scarce"
    /// - Nightmare: "Enemies deal 200% damage, permadeath enabled"
    /// - Include default case for unknown difficulty
    /// </summary>
    private void ProcessDifficulty(DifficultyLevel difficulty)
    {
        // TODO: Implement switch statement for difficulty processing
        
        Debug.Log("TODO: Complete ProcessDifficulty switch statement");
    }

    /// <summary>
    /// TODO 3.2: Complete the ProcessQuest method
    /// REQUIREMENTS:
    /// - Use switch statement to handle each quest type
    /// - KillEnemies: "Eliminate 10 monsters for 500 XP reward"
    /// - CollectItems: "Gather 5 rare herbs for 300 XP reward"
    /// - DeliverMessage: "Take this message to the next town for 200 XP reward"
    /// - Explore: "Discover 3 new areas for 400 XP reward"
    /// - Boss: "Defeat the dungeon boss for 1000 XP reward"
    /// - Include default case and calculate total XP
    /// </summary>
    private void ProcessQuest(QuestType questType)
    {
        // TODO: Implement switch statement for quest processing
        
        Debug.Log("TODO: Complete ProcessQuest switch statement");
    }

    /// <summary>
    /// TODO 3.3: Complete the ProcessItemType method
    /// REQUIREMENTS:
    /// - Use switch statement with string input
    /// - Handle: "sword", "potion", "key", "scroll", "gold"
    /// - Each item type should have different handling
    /// - Use multiple cases for similar items (e.g., "weapon", "sword", "axe" all = weapon)
    /// - Include default case for unknown items
    /// - Make case-insensitive using ToLower()
    /// </summary>
    private void ProcessItemType(string itemType)
    {
        // TODO: Implement switch statement for item type processing
        
        Debug.Log("TODO: Complete ProcessItemType switch statement");
    }
}

// =============================================================================
// TODO SECTION: COMPLETE THE INTERFACES AND CLASSES BELOW
// =============================================================================

#region TODO 1: Inventory System Interfaces

/// <summary>
/// TODO 1.1: Complete the ICollectable interface
/// REQUIREMENTS:
/// - Method: Collect() - handles collecting the item
/// - Property: ItemName (string) - gets the name of the item
/// - Property: Description (string) - gets item description
/// </summary>
public interface ICollectable
{
    // TODO: Add Collect() method
    
    // TODO: Add ItemName property
    
    // TODO: Add Description property
}

/// <summary>
/// TODO 1.2: Complete the IUseable interface
/// REQUIREMENTS:
/// - Method: Use() - handles using the item
/// - Method: CanUse() - returns bool if item can be used
/// - Property: UsesRemaining (int) - gets remaining uses
/// </summary>
public interface IUseable
{
    // TODO: Add Use() method
    
    // TODO: Add CanUse() method
    
    // TODO: Add UsesRemaining property
}

/// <summary>
/// TODO 1.3: Complete the IValuable interface
/// REQUIREMENTS:
/// - Method: GetValue() - returns int value in gold
/// - Method: SetValue(int) - sets the item's value
/// - Property: Rarity (string) - gets item rarity (Common, Rare, Epic, Legendary)
/// </summary>
public interface IValuable
{
    // TODO: Add GetValue() method
    
    // TODO: Add SetValue(int) method
    
    // TODO: Add Rarity property
}

/// <summary>
/// TODO 1.4: Complete the Coin class
/// REQUIREMENTS:
/// - Implements ICollectable and IValuable
/// - Constructor takes value (int)
/// - Collect() method adds coins to player inventory
/// - Proper implementation of all interface methods
/// </summary>
public class Coin : ICollectable, IValuable
{
    // TODO: Add private fields for value and other properties
    
    // TODO: Add constructor
    
    // TODO: Implement ICollectable interface methods
    
    // TODO: Implement IValuable interface methods
}

/// <summary>
/// TODO 1.5: Complete the HealthPotion class
/// REQUIREMENTS:
/// - Implements ICollectable, IUseable, and IValuable
/// - Constructor takes healing amount (int)
/// - Use() method heals player
/// - Can only be used once (single-use item)
/// - Has appropriate value based on healing amount
/// </summary>
public class HealthPotion : ICollectable, IUseable, IValuable
{
    // TODO: Add private fields
    
    // TODO: Add constructor
    
    // TODO: Implement all interface methods
}

/// <summary>
/// TODO 1.6: Complete the MagicScroll class
/// REQUIREMENTS:
/// - Implements ICollectable, IUseable, and IValuable
/// - Constructor takes spell name (string) and damage (int)
/// - Use() method casts the spell
/// - Can be used multiple times (3 uses per scroll)
/// - Value based on damage and rarity
/// </summary>
public class MagicScroll : ICollectable, IUseable, IValuable
{
    // TODO: Add private fields
    
    // TODO: Add constructor
    
    // TODO: Implement all interface methods
}

/// <summary>
/// TODO 1.7: Complete the Key class
/// REQUIREMENTS:
/// - Implements ICollectable only (keys are not useable or valuable in traditional sense)
/// - Constructor takes key name (string)
/// - Collect() method adds to key ring
/// - Special handling for key collection
/// </summary>
public class Key : ICollectable
{
    // TODO: Add private fields
    
    // TODO: Add constructor
    
    // TODO: Implement ICollectable interface
}

/// <summary>
/// TODO 1.8: Complete the Gem class
/// REQUIREMENTS:
/// - Implements ICollectable and IValuable
/// - Constructor takes gem type (string) and base value (int)
/// - High-value items with different rarities
/// - Collect() method with special gem handling
/// </summary>
public class Gem : ICollectable, IValuable
{
    // TODO: Add private fields
    
    // TODO: Add constructor
    
    // TODO: Implement all interface methods
}

#endregion

#region TODO 2: Combat System Interfaces

/// <summary>
/// TODO 2.1: Complete the IFighter interface
/// REQUIREMENTS:
/// - Method: Attack() - performs basic attack
/// - Method: TakeDamage(int) - receives damage
/// - Method: IsAlive() - returns bool if alive
/// - Property: Health (int) - current health
/// - Property: MaxHealth (int) - maximum health
/// - Property: AttackDamage (int) - base attack damage
/// </summary>
public interface IFighter
{
    // TODO: Add Attack() method
    
    // TODO: Add TakeDamage(int) method
    
    // TODO: Add IsAlive() method
    
    // TODO: Add Health property
    
    // TODO: Add MaxHealth property
    
    // TODO: Add AttackDamage property
}

/// <summary>
/// TODO 2.2: Complete the IHealer interface
/// REQUIREMENTS:
/// - Method: Heal(int) - heals for specified amount
/// - Method: GetHealingPower() - returns int healing strength
/// - Property: CanHeal (bool) - whether entity can heal
/// </summary>
public interface IHealer
{
    // TODO: Add Heal(int) method
    
    // TODO: Add GetHealingPower() method
    
    // TODO: Add CanHeal property
}

/// <summary>
/// TODO 2.3: Complete the IMagicUser interface
/// REQUIREMENTS:
/// - Method: CastSpell(string) - casts named spell
/// - Method: HasMana(int) - returns bool if enough mana
/// - Property: Mana (int) - current mana
/// - Property: MaxMana (int) - maximum mana
/// </summary>
public interface IMagicUser
{
    // TODO: Add CastSpell(string) method
    
    // TODO: Add HasMana(int) method
    
    // TODO: Add Mana property
    
    // TODO: Add MaxMana property
}

/// <summary>
/// TODO 2.4: Complete the Knight class
/// REQUIREMENTS:
/// - Implements IFighter and IHealer
/// - Constructor takes name, health, and damage
/// - Special "Shield Block" ability
/// - Can heal self with "First Aid" ability
/// </summary>
public class Knight : IFighter, IHealer
{
    // TODO: Add private fields
    
    // TODO: Add constructor
    
    // TODO: Implement IFighter interface
    
    // TODO: Implement IHealer interface
    
    // TODO: Add ShieldBlock() method
    
    // Temporary stub implementations to satisfy compiler
    public void Heal(int amount) { Debug.Log("TODO: Implement Heal"); }
    public int GetHealingPower() { return 0; }
    public bool CanHeal => true;
    public int GetMaxHealth() { return 0; }
}

/// <summary>
/// TODO 2.5: Complete the Wizard class
/// REQUIREMENTS:
/// - Implements IFighter, IHealer, and IMagicUser
/// - Constructor takes name, health, damage, and mana
/// - Can cast various spells using mana
/// - Can heal others and self
/// - Lower physical damage but high magic damage
/// </summary>
public class WizardFighter : IFighter, IHealer, IMagicUser
{
    // TODO: Add private fields
    
    // TODO: Add constructor
    
    // TODO: Implement all interfaces
    
    // Temporary stub implementations to satisfy compiler
    public void Heal(int amount) { Debug.Log("TODO: Implement Heal"); }
    public int GetHealingPower() { return 0; }
    public bool CanHeal => true;
    public int GetMaxHealth() { return 0; }
}

/// <summary>
/// TODO 2.6: Complete the Archer class
/// REQUIREMENTS:
/// - Implements IFighter
/// - Constructor takes name, health, damage, and arrow count
/// - Ranged attacks that consume arrows
/// - Special "Precise Shot" ability for critical hits
/// - Cannot heal (no IHealer implementation)
/// </summary>
public class ArcherFighter : IFighter
{
    // TODO: Add private fields (include arrow count)
    
    // TODO: Add constructor
    
    // TODO: Implement IFighter interface
    
    // TODO: Add PreciseShot() method
}

/// <summary>
/// TODO 2.7: Complete the Monster class
/// REQUIREMENTS:
/// - Implements IFighter only
/// - Constructor takes name, health, and damage
/// - Savage attacks with random damage variation
/// - Cannot heal or use magic
/// - Different attack messages based on monster type
/// </summary>
public class Monster : IFighter
{
    // TODO: Add private fields
    
    // TODO: Add constructor
    
    // TODO: Implement IFighter interface
    
    // TODO: Add special monster abilities
}

#endregion

#region TODO 3: Switch Statement Logic

// Enums for switch demonstrations
public enum DifficultyLevel { Easy, Normal, Hard, Nightmare }
public enum QuestType { KillEnemies, CollectItems, DeliverMessage, Explore, Boss }



#endregion

#region TODO 4: Game Management System

/// <summary>
/// TODO 4.1: Complete the MiniGameManager class
/// REQUIREMENTS:
/// - Similar to GameStateManager but simpler
/// - States: Menu, Playing, Paused, GameOver
/// - Switch-based state handling
/// - Input handling for each state
/// - Score and lives tracking
/// - State transition methods
/// </summary>
public class MiniGameManager : MonoBehaviour
{
    // TODO: Add enum for game states
    
    // TODO: Add private fields for state, score, lives, etc.
    
    // TODO: Add state change method using switch
    
    // TODO: Add input handling method using switch
    
    // TODO: Add game logic methods
}

#endregion

// =============================================================================
// COMPLETION CHECKLIST:
// =============================================================================
/*
EXERCISE 1 - INVENTORY SYSTEM:
□ ICollectable interface with Collect(), ItemName, Description
□ IUseable interface with Use(), CanUse(), UsesRemaining
□ IValuable interface with GetValue(), SetValue(), Rarity
□ Coin class implementing ICollectable and IValuable
□ HealthPotion class implementing all three interfaces
□ MagicScroll class with multi-use functionality
□ Key class with special collection handling
□ Gem class with rarity system
□ Test by checking "Test Inventory System" in Inspector

EXERCISE 2 - COMBAT INTERFACES:
□ IFighter interface with combat methods
□ IHealer interface with healing capabilities
□ IMagicUser interface with mana and spell system
□ Knight class with shield abilities and healing
□ Wizard class implementing all three interfaces
□ Archer class with arrow management
□ Monster class with savage attack variations
□ Test by checking "Test Combat Interfaces" in Inspector

EXERCISE 3 - SWITCH STATEMENTS:
□ ProcessDifficulty method with difficulty-based game modifications
□ ProcessQuest method with XP calculations and quest descriptions
□ ProcessItemType method with string-based item handling
□ Proper use of break statements and default cases
□ Case-insensitive string handling
□ Test by checking "Test Switch Logic" in Inspector

EXERCISE 4 - GAME MANAGEMENT:
□ MiniGameManager class with state enum
□ Switch-based state transitions
□ Input handling for each game state
□ Score and lives management
□ Professional game state architecture
□ Test by checking "Test Game Manager" in Inspector

EXERCISE 5 - FINAL CHALLENGE:
□ Integration of all concepts into cohesive system
□ Multiple interfaces working together
□ Complex state management with switch logic
□ Professional game development patterns
□ Creative implementation combining inheritance and interfaces
□ Test by checking "Run Final Challenge" in Inspector

ADVANCED CHALLENGES (OPTIONAL):
□ Add interface inheritance (e.g., IAdvancedFighter : IFighter)
□ Implement generic interfaces for type safety
□ Create factory patterns using interfaces
□ Add observer pattern with interface notifications
□ Integrate with Unity's built-in interfaces (IPointerClickHandler, etc.)
*/