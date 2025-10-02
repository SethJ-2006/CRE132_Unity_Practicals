using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Demonstrates List management in C# and their practical applications in game development
/// This script shows dynamic collections that can grow and shrink during runtime
/// </summary>
public class ListManagement : MonoBehaviour
{
    [Header("=== INITIAL LIST DATA ===")]
    public List<string> playerInventory = new List<string> {"Health Potion", "Rusty Sword"};
    public List<int> enemyHealthValues = new List<int> {100, 150, 200, 80, 120};
    public List<float> projectileSpeeds = new List<float>();
    
    [Header("=== DYNAMIC CONTENT ===")]
    public List<Vector3> waypointPositions = new List<Vector3>();
    public List<Color> availableColours = new List<Color>();
    
    [Header("=== RESULTS (READ-ONLY) ===")]
    [SerializeField] private int totalItems;
    [SerializeField] private int activeEnemies;
    [SerializeField] private string lastAddedItem;
    [SerializeField] private bool inventoryFull;
    
    void Start()
    {
        Debug.Log("=== LIST MANAGEMENT DEMONSTRATION ===");
        Debug.Log("Learning how Lists work and their dynamic capabilities");
        
        // Initialize some lists with starting data
        InitializeLists();
        
        // Demonstrate different list concepts
        ListCreationAndInitialization();
        AddingAndRemovingElements();
        ListSearchingAndContains();
        PracticalGameExamples();
        ListModificationMethods();
        ListCapacityAndPerformance();
    }
    
    /// <summary>
    /// Initialize lists with some starting data
    /// </summary>
    private void InitializeLists()
    {
        // Add some initial projectile speeds
        projectileSpeeds.AddRange(new float[] {5f, 8f, 12f, 15f});
        
        // Add some waypoint positions
        waypointPositions.Add(new Vector3(-5f, 0f, 0f));
        waypointPositions.Add(new Vector3(0f, 5f, 0f));
        waypointPositions.Add(new Vector3(5f, 0f, 0f));
        waypointPositions.Add(new Vector3(0f, -5f, 0f));
        
        // Add some colours
        availableColours.AddRange(new Color[] {Color.red, Color.blue, Color.green, Color.yellow});
    }    
    /// <summary>
    /// Demonstrates different ways to create and initialize lists
    /// </summary>
    private void ListCreationAndInitialization()
    {
        Debug.Log("\n--- LIST CREATION AND INITIALIZATION ---");
        
        // Different ways to create lists
        List<string> emptyList = new List<string>();                    // Empty list
        List<int> numbersWithCapacity = new List<int>(10);            // Empty list with initial capacity
        List<string> prefilledList = new List<string> {"Item1", "Item2"}; // List with initial values
        
        Debug.Log($"Empty list count: {emptyList.Count}");
        Debug.Log($"List with capacity count: {numbersWithCapacity.Count}");
        Debug.Log($"Prefilled list count: {prefilledList.Count}");
        
        // Display current inventory
        Debug.Log("\nCurrent inventory contents:");
        for (int i = 0; i < playerInventory.Count; i++)
        {
            Debug.Log($"  {i + 1}. {playerInventory[i]}");
        }
        
        totalItems = playerInventory.Count;
        Debug.Log($"Total items in inventory: {totalItems}");
        
        // Show enemy health values
        Debug.Log("\nEnemy health values:");
        foreach (int health in enemyHealthValues)
        {
            Debug.Log($"  Enemy health: {health}");
        }
        
        activeEnemies = enemyHealthValues.Count;
        Debug.Log($"Active enemies: {activeEnemies}");
    }    
    /// <summary>
    /// Demonstrates adding and removing elements from lists
    /// </summary>
    private void AddingAndRemovingElements()
    {
        Debug.Log("\n--- ADDING AND REMOVING ELEMENTS ---");
        
        // Adding single items
        Debug.Log("Adding items to inventory:");
        playerInventory.Add("Magic Shield");
        playerInventory.Add("Fire Spell Scroll");
        playerInventory.Add("Healing Crystal");
        
        lastAddedItem = playerInventory[playerInventory.Count - 1];
        Debug.Log($"Last added item: {lastAddedItem}");
        
        // Insert at specific position
        playerInventory.Insert(1, "Lucky Charm"); // Insert at index 1
        Debug.Log("Inserted 'Lucky Charm' at position 2");
        
        // Adding multiple items at once
        List<string> newItems = new List<string> {"Mana Potion", "Teleport Scroll"};
        playerInventory.AddRange(newItems);
        Debug.Log($"Added {newItems.Count} items using AddRange");
        
        // Display updated inventory
        Debug.Log("\nUpdated inventory:");
        for (int i = 0; i < playerInventory.Count; i++)
        {
            Debug.Log($"  {i + 1}. {playerInventory[i]}");
        }
        
        // Removing items
        Debug.Log("\nRemoving items:");
        bool removed = playerInventory.Remove("Rusty Sword"); // Remove by value
        Debug.Log($"Removed 'Rusty Sword': {removed}");
        
        if (playerInventory.Count > 2)
        {
            string removedItem = playerInventory[2];
            playerInventory.RemoveAt(2); // Remove by index
            Debug.Log($"Removed item at index 2: {removedItem}");
        }
        
        // Check inventory limits
        int maxInventorySize = 10;
        inventoryFull = playerInventory.Count >= maxInventorySize;
        Debug.Log($"Inventory full: {inventoryFull} (Size: {playerInventory.Count}/{maxInventorySize})");
        
        totalItems = playerInventory.Count;
    }    
    /// <summary>
    /// Demonstrates searching and checking contents of lists
    /// </summary>
    private void ListSearchingAndContains()
    {
        Debug.Log("\n--- LIST SEARCHING AND CONTAINS ---");
        
        // Check if list contains specific items
        string searchItem = "Health Potion";
        bool hasHealthPotion = playerInventory.Contains(searchItem);
        Debug.Log($"Player has {searchItem}: {hasHealthPotion}");
        
        // Find index of specific item
        int potionIndex = playerInventory.IndexOf(searchItem);
        if (potionIndex >= 0)
        {
            Debug.Log($"Found {searchItem} at index: {potionIndex}");
        }
        else
        {
            Debug.Log($"{searchItem} not found in inventory");
        }
        
        // Find all items containing specific text
        Debug.Log("\nItems containing 'Potion':");
        foreach (string item in playerInventory)
        {
            if (item.ToLower().Contains("potion"))
            {
                Debug.Log($"  Found: {item}");
            }
        }
        
        // Check enemy health ranges
        Debug.Log("\nEnemies with health over 100:");
        for (int i = 0; i < enemyHealthValues.Count; i++)
        {
            if (enemyHealthValues[i] > 100)
            {
                Debug.Log($"  Enemy {i + 1}: {enemyHealthValues[i]} health");
            }
        }
        
        // Find minimum and maximum values
        if (enemyHealthValues.Count > 0)
        {
            int minHealth = enemyHealthValues[0];
            int maxHealth = enemyHealthValues[0];
            
            foreach (int health in enemyHealthValues)
            {
                if (health < minHealth) minHealth = health;
                if (health > maxHealth) maxHealth = health;
            }
            
            Debug.Log($"Enemy health range: {minHealth} - {maxHealth}");
        }
    }    
    /// <summary>
    /// Demonstrates practical game development applications of lists
    /// </summary>
    private void PracticalGameExamples()
    {
        Debug.Log("\n--- PRACTICAL GAME EXAMPLES ---");
        
        // Example 1: Dynamic enemy spawning system
        Debug.Log("Dynamic enemy spawning:");
        List<string> activeEnemyTypes = new List<string>();
        
        // Spawn enemies based on player level
        int playerLevel = 5;
        if (playerLevel >= 1) activeEnemyTypes.Add("Goblin");
        if (playerLevel >= 3) activeEnemyTypes.Add("Orc");
        if (playerLevel >= 5) activeEnemyTypes.Add("Dragon");
        if (playerLevel >= 8) activeEnemyTypes.Add("Boss");
        
        Debug.Log($"Available enemies for level {playerLevel}:");
        foreach (string enemy in activeEnemyTypes)
        {
            Debug.Log($"  - {enemy}");
        }
        
        // Example 2: Quest management system
        Debug.Log("\nQuest management:");
        List<string> activeQuests = new List<string>
        {
            "Collect 10 herbs",
            "Defeat the cave troll",
            "Find the lost artifact"
        };
        
        // Complete a quest
        string completedQuest = "Collect 10 herbs";
        if (activeQuests.Remove(completedQuest))
        {
            Debug.Log($"Quest completed: {completedQuest}");
        }
        
        // Add new quest
        activeQuests.Add("Return to village elder");
        Debug.Log($"Remaining quests: {activeQuests.Count}");
        
        // Example 3: Projectile management
        Debug.Log("\nProjectile system:");
        List<Vector3> bulletPositions = new List<Vector3>();
        
        // Fire projectiles
        for (int i = 0; i < 3; i++)
        {
            Vector3 startPos = new Vector3(i * 2f, 0f, 0f);
            bulletPositions.Add(startPos);
            Debug.Log($"Bullet {i + 1} fired from: {startPos}");
        }
        
        // Remove bullets that are off-screen (simulate)
        bulletPositions.RemoveAll(pos => pos.x > 10f);
        Debug.Log($"Bullets remaining: {bulletPositions.Count}");
    }    
    /// <summary>
    /// Demonstrates various list modification methods
    /// </summary>
    private void ListModificationMethods()
    {
        Debug.Log("\n--- LIST MODIFICATION METHODS ---");
        
        // Create a test list for demonstrations
        List<int> numbers = new List<int> {5, 2, 8, 1, 9, 3, 7};
        Debug.Log("Original numbers: [" + string.Join(", ", numbers) + "]");
        
        // Sort the list
        numbers.Sort();
        Debug.Log("After sorting: [" + string.Join(", ", numbers) + "]");
        
        // Reverse the list
        numbers.Reverse();
        Debug.Log("After reversing: [" + string.Join(", ", numbers) + "]");
        
        // Clear all elements
        List<int> testList = new List<int>(numbers); // Create copy
        testList.Clear();
        Debug.Log($"After clearing: Count = {testList.Count}");
        
        // Working with waypoints
        Debug.Log("\nWaypoint management:");
        Debug.Log($"Total waypoints: {waypointPositions.Count}");
        
        // Add a new waypoint
        waypointPositions.Add(new Vector3(10f, 10f, 0f));
        Debug.Log("Added waypoint at (10, 10, 0)");
        
        // Remove waypoints outside a certain range
        Vector3 center = Vector3.zero;
        float maxDistance = 8f;
        
        for (int i = waypointPositions.Count - 1; i >= 0; i--)
        {
            float distance = Vector3.Distance(waypointPositions[i], center);
            if (distance > maxDistance)
            {
                Debug.Log($"Removing waypoint {waypointPositions[i]} (distance: {distance:F1})");
                waypointPositions.RemoveAt(i);
            }
        }
        
        Debug.Log($"Waypoints after cleanup: {waypointPositions.Count}");
    }    
    /// <summary>
    /// Demonstrates list capacity and performance considerations
    /// </summary>
    private void ListCapacityAndPerformance()
    {
        Debug.Log("\n--- LIST CAPACITY AND PERFORMANCE ---");
        
        // Create list with specific capacity
        List<float> performanceTest = new List<float>(100); // Initial capacity of 100
        Debug.Log($"New list capacity: {performanceTest.Capacity}, Count: {performanceTest.Count}");
        
        // Add elements and watch capacity grow
        for (int i = 0; i < 15; i++)
        {
            performanceTest.Add(i * 1.5f);
        }
        Debug.Log($"After adding 15 elements - Capacity: {performanceTest.Capacity}, Count: {performanceTest.Count}");
        
        // Demonstrate ToArray conversion
        float[] speedArray = projectileSpeeds.ToArray();
        Debug.Log($"Converted List to Array - Array length: {speedArray.Length}");
        
        // Demonstrate efficient operations
        Debug.Log("\nEfficient list operations:");
        
        // Finding elements efficiently
        string targetItem = "Health Potion";
        int itemIndex = playerInventory.FindIndex(item => item.Contains("Health"));
        if (itemIndex >= 0)
        {
            Debug.Log($"Found health-related item at index {itemIndex}: {playerInventory[itemIndex]}");
        }
        
        // Count elements meeting criteria
        int potionCount = 0;
        foreach (string item in playerInventory)
        {
            if (item.ToLower().Contains("potion"))
            {
                potionCount++;
            }
        }
        Debug.Log($"Total potions in inventory: {potionCount}");
        
        // Memory management tip
        if (performanceTest.Capacity > performanceTest.Count * 2)
        {
            performanceTest.TrimExcess(); // Reduce capacity to actual count
            Debug.Log($"After TrimExcess - Capacity: {performanceTest.Capacity}");
        }
        
        Debug.Log("\n🎯 LIST TIPS:");
        Debug.Log("• Lists can grow and shrink dynamically unlike arrays");
        Debug.Log("• Use Add() to append, Insert() to add at specific position");
        Debug.Log("• Contains() and IndexOf() help find elements");
        Debug.Log("• RemoveAll() can remove multiple elements efficiently");
        Debug.Log("• Consider initial capacity for better performance");
        Debug.Log("• Lists are perfect for game inventories, enemy lists, projectiles");
    }
}