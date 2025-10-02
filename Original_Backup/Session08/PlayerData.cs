using System;
using System.Collections.Generic;

/// <summary>
/// Data class representing player information for save/load operations
/// Uses [Serializable] attribute to enable JSON serialisation
/// </summary>
[Serializable]
public class PlayerData
{
    // Basic player information
    public string playerName;
    public int level;
    public float experience;
    public int health;
    public int maxHealth;
    
    // Game progress
    public int currentScore;
    public int highScore;
    public float playtime; // in seconds
    
    // Player position (for save/load location)
    public float positionX;
    public float positionY;
    public float positionZ;
    
    // Inventory system
    public List<string> inventory;
    public List<int> inventoryQuantities;
    
    // Achievement system
    public List<string> unlockedAchievements;
    
    // Game settings
    public float musicVolume;
    public float soundVolume;
    public bool fullscreenMode;
    
    // Timestamps
    public string lastSaveTime;
    public string firstPlayTime;

    /// <summary>
    /// Constructor with default values
    /// </summary>
    public PlayerData()
    {
        playerName = "New Player";
        level = 1;
        experience = 0f;
        health = 100;
        maxHealth = 100;
        currentScore = 0;
        highScore = 0;
        playtime = 0f;
        
        positionX = 0f;
        positionY = 0f;
        positionZ = 0f;
        
        inventory = new List<string>();
        inventoryQuantities = new List<int>();
        unlockedAchievements = new List<string>();
        
        musicVolume = 0.8f;
        soundVolume = 0.8f;
        fullscreenMode = true;
        
        lastSaveTime = DateTime.Now.ToString();
        firstPlayTime = DateTime.Now.ToString();
    }

    /// <summary>
    /// Add item to inventory with quantity
    /// </summary>
    public void AddToInventory(string item, int quantity = 1)
    {
        int existingIndex = inventory.IndexOf(item);
        if (existingIndex >= 0)
        {
            // Item already exists, increase quantity
            inventoryQuantities[existingIndex] += quantity;
        }
        else
        {
            // New item, add to lists
            inventory.Add(item);
            inventoryQuantities.Add(quantity);
        }
    }

    /// <summary>
    /// Remove item from inventory
    /// </summary>
    public bool RemoveFromInventory(string item, int quantity = 1)
    {
        int existingIndex = inventory.IndexOf(item);
        if (existingIndex >= 0)
        {
            inventoryQuantities[existingIndex] -= quantity;
            
            // Remove completely if quantity reaches 0 or below
            if (inventoryQuantities[existingIndex] <= 0)
            {
                inventory.RemoveAt(existingIndex);
                inventoryQuantities.RemoveAt(existingIndex);
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Unlock an achievement if not already unlocked
    /// </summary>
    public bool UnlockAchievement(string achievementName)
    {
        if (!unlockedAchievements.Contains(achievementName))
        {
            unlockedAchievements.Add(achievementName);
            return true; // Newly unlocked
        }
        return false; // Already unlocked
    }
}