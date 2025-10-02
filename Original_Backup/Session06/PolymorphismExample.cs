using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Demonstrates polymorphism - same interface, different implementations.
/// Shows how the same method call can produce different behaviour.
/// </summary>
public class PolymorphismExample : MonoBehaviour
{
    [Header("Polymorphism Demonstration")]
    [SerializeField] private bool testPolymorphism = false;
    [SerializeField] private bool battleSimulation = false;
    
    void Start()
    {
        Debug.Log("=== POLYMORPHISM DEMONSTRATION ===");
        DemonstratePolymorphism();
    }
    
    void Update()
    {
        if (testPolymorphism)
        {
            testPolymorphism = false;
            DemonstratePolymorphism();
        }
        
        if (battleSimulation)
        {
            battleSimulation = false;
            RunBattleSimulation();
        }
    }
    
    private void DemonstratePolymorphism()
    {
        Debug.Log("\n--- Polymorphism: Same Method, Different Behaviour ---");
        
        // Create a list of enemies - all different types, but treated the same
        List<Enemy> enemyArmy = new List<Enemy>
        {
            new Zombie("Zombie Brute", 60, 18),
            new Robot("War Machine", 90, 28),
            new Wizard("Necromancer", 70, 35, 120),
            new Zombie("Zombie Runner", 40, 12),
            new Robot("Scout Bot", 50, 15)
        };
        
        // Polymorphism in action - same method call, different behaviour for each
        Debug.Log("\n--- All Enemies Attack (Polymorphism) ---");
        foreach (Enemy enemy in enemyArmy)
        {
            enemy.Attack(); // Each enemy attacks differently!
        }
        
        // Same with taking damage
        Debug.Log("\n--- All Enemies Take Damage (Shared Behaviour) ---");
        foreach (Enemy enemy in enemyArmy)
        {
            enemy.TakeDamage(10); // Same method, same behaviour
        }
    }
    
    private void RunBattleSimulation()
    {
        Debug.Log("\n=== BATTLE SIMULATION ===");
        
        // Create two opposing forces
        List<Enemy> playerTeam = new List<Enemy>
        {
            new Robot("Ally Bot", 80, 25),
            new Wizard("Battle Mage", 60, 30, 100)
        };
        
        List<Enemy> enemyTeam = new List<Enemy>
        {
            new Zombie("Undead Warrior", 70, 20),
            new Robot("Enemy Droid", 75, 22)
        };
        
        Debug.Log("--- Round 1: Player Team Attacks ---");
        foreach (Enemy ally in playerTeam)
        {
            ally.Attack();
        }
        
        Debug.Log("\n--- Round 1: Enemy Counter-Attack ---");
        foreach (Enemy enemy in enemyTeam)
        {
            enemy.Attack();
        }
        
        Debug.Log("\n--- Battle Results: Everyone Takes Damage ---");
        foreach (Enemy ally in playerTeam)
        {
            ally.TakeDamage(20);
        }
        foreach (Enemy enemy in enemyTeam)
        {
            enemy.TakeDamage(25);
        }
    }
}