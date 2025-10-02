using UnityEngine;

/// <summary>
/// Demonstrates string methods and manipulation in C# for game development
/// This script shows how to work with text, player names, and game messages
/// </summary>
public class StringMethods : MonoBehaviour
{
    [Header("=== PLAYER DATA ===")]
    public string playerName = "  JOHN_DOE  ";
    public string[] itemNames = {"sword", "SHIELD", "Potion", "KEY"};
    public string gameTitle = "Epic Adventure Game";
    
    [Header("=== MESSAGE SETTINGS ===")]
    public string welcomeMessage = "Welcome to our amazing game!";
    public string[] chatMessages = {"Hello there!", "How are you?", "Ready to play?"};
    
    [Header("=== RESULTS (READ-ONLY) ===")]
    [SerializeField] private string cleanPlayerName;
    [SerializeField] private string uppercaseTitle;
    [SerializeField] private string combinedMessages;
    [SerializeField] private int totalCharacters;
    
    void Start()
    {
        Debug.Log("=== STRING METHODS DEMONSTRATION ===");
        Debug.Log("Learning how to manipulate text and strings in games");
        
        // Demonstrate different string methods
        BasicStringProperties();
        StringCaseConversion();
        StringSearching();
        StringModification();
        StringCombination();
        PracticalGameExamples();
        StringValidation();
    }
    
    /// <summary>
    /// Demonstrates basic string properties and information
    /// </summary>
    private void BasicStringProperties()
    {
        Debug.Log("\n--- BASIC STRING PROPERTIES ---");
        
        Debug.Log("Player name: '" + playerName + "'");
        Debug.Log("Length: " + playerName.Length);
        Debug.Log("Is null or empty: " + string.IsNullOrEmpty(playerName));
        Debug.Log("Is null or whitespace: " + string.IsNullOrWhiteSpace(playerName));
        
        // Character access
        if (playerName.Length > 0)
        {
            Debug.Log("First character: " + playerName[0]);
            Debug.Log("Last character: " + playerName[playerName.Length - 1]);
        }
    }    
    /// <summary>
    /// Demonstrates converting string case (upper/lower)
    /// </summary>
    private void StringCaseConversion()
    {
        Debug.Log("\n--- STRING CASE CONVERSION ---");
        
        Debug.Log("Original title: " + gameTitle);
        
        uppercaseTitle = gameTitle.ToUpper();
        string lowercaseTitle = gameTitle.ToLower();
        
        Debug.Log("Uppercase: " + uppercaseTitle);
        Debug.Log("Lowercase: " + lowercaseTitle);
        
        // Process item names
        Debug.Log("\nStandardising item names:");
        for (int i = 0; i < itemNames.Length; i++)
        {
            string standardName = itemNames[i].ToLower();
            Debug.Log("Item " + (i + 1) + ": " + itemNames[i] + " → " + standardName);
        }
    }
    
    /// <summary>
    /// Demonstrates searching within strings
    /// </summary>
    private void StringSearching()
    {
        Debug.Log("\n--- STRING SEARCHING ---");
        
        Debug.Log("Searching in: '" + welcomeMessage + "'");
        Debug.Log("Contains 'game': " + welcomeMessage.Contains("game"));
        Debug.Log("Contains 'GAME': " + welcomeMessage.Contains("GAME"));
        Debug.Log("Contains 'amazing' (case insensitive): " + welcomeMessage.ToLower().Contains("amazing"));
        
        // Find positions
        int gamePosition = welcomeMessage.IndexOf("game");
        Debug.Log("Position of 'game': " + gamePosition);
        
        // Check beginning and ending
        Debug.Log("Starts with 'Welcome': " + welcomeMessage.StartsWith("Welcome"));
        Debug.Log("Ends with '!': " + welcomeMessage.EndsWith("!"));
    }    
    /// <summary>
    /// Demonstrates string modification methods
    /// </summary>
    private void StringModification()
    {
        Debug.Log("\n--- STRING MODIFICATION ---");
        
        Debug.Log("Original player name: '" + playerName + "'");
        
        // Clean up the player name
        cleanPlayerName = playerName.Trim(); // Remove whitespace
        cleanPlayerName = cleanPlayerName.Replace("_", " "); // Replace underscores with spaces
        cleanPlayerName = cleanPlayerName.ToLower(); // Convert to lowercase
        
        Debug.Log("Cleaned player name: '" + cleanPlayerName + "'");
        
        // Substring examples
        if (gameTitle.Length >= 4)
        {
            string shortTitle = gameTitle.Substring(0, 4);
            Debug.Log("First 4 characters of title: " + shortTitle);
        }
        
        // String padding
        string paddedName = cleanPlayerName.PadLeft(15, '-');
        Debug.Log("Padded name: '" + paddedName + "'");
    }
    
    /// <summary>
    /// Demonstrates combining strings in different ways
    /// </summary>
    private void StringCombination()
    {
        Debug.Log("\n--- STRING COMBINATION ---");
        
        // Simple concatenation
        string greeting = "Hello, " + cleanPlayerName + "!";
        Debug.Log("Simple greeting: " + greeting);
        
        // String interpolation (preferred method)
        string betterGreeting = $"Welcome {cleanPlayerName}, your level is {Random.Range(1, 50)}";
        Debug.Log("String interpolation: " + betterGreeting);
        
        // Combine multiple messages
        combinedMessages = "";
        totalCharacters = 0;
        
        for (int i = 0; i < chatMessages.Length; i++)
        {
            combinedMessages += chatMessages[i];
            totalCharacters += chatMessages[i].Length;
            
            if (i < chatMessages.Length - 1)
            {
                combinedMessages += " | ";
            }
        }
        
        Debug.Log("Combined messages: " + combinedMessages);
        Debug.Log("Total characters: " + totalCharacters);
    }    
    /// <summary>
    /// Demonstrates practical string applications in games
    /// </summary>
    private void PracticalGameExamples()
    {
        Debug.Log("\n--- PRACTICAL GAME EXAMPLES ---");
        
        // Example 1: Score formatting
        int playerScore = 12345;
        string formattedScore = playerScore.ToString("N0"); // Adds commas
        Debug.Log("Formatted score: " + formattedScore);
        
        // Example 2: Health bar text
        int currentHealth = 75;
        int maxHealth = 100;
        float healthPercent = (float)currentHealth / maxHealth * 100f;
        string healthDisplay = $"Health: {currentHealth}/{maxHealth} ({healthPercent:F1}%)";
        Debug.Log("Health display: " + healthDisplay);
        
        // Example 3: Item description
        string itemName = "Magic Sword";
        int itemLevel = 15;
        float itemDamage = 23.7f;
        string itemDescription = $"{itemName} (Level {itemLevel}) - Damage: {itemDamage:F1}";
        Debug.Log("Item description: " + itemDescription);
        
        // Example 4: Chat command parsing
        string chatCommand = "/give sword 5";
        string[] commandParts = chatCommand.Split(' ');
        if (commandParts.Length >= 3)
        {
            string command = commandParts[0];
            string item = commandParts[1];
            string quantity = commandParts[2];
            Debug.Log($"Command: {command}, Item: {item}, Quantity: {quantity}");
        }
    }    
    /// <summary>
    /// Demonstrates string validation for user input
    /// </summary>
    private void StringValidation()
    {
        Debug.Log("\n--- STRING VALIDATION ---");
        
        // Test different validation scenarios
        string[] testNames = {"", "   ", "John", "Player123", "A", "VeryLongPlayerNameThatExceedsLimit"};
        
        foreach (string testName in testNames)
        {
            bool isValid = ValidatePlayerName(testName);
            Debug.Log($"Name: '{testName}' - Valid: {isValid}");
        }
        
        Debug.Log("\n🎯 STRING METHOD TIPS:");
        Debug.Log("• Always check for null/empty strings before using methods");
        Debug.Log("• Use string interpolation ($\"\") for readable formatting");
        Debug.Log("• Remember that strings are immutable (methods create new strings)");
        Debug.Log("• ToLower() is useful for case-insensitive comparisons");
        Debug.Log("• Trim() removes whitespace from beginning and end");
    }
    
    /// <summary>
    /// Validates a player name according to game rules
    /// </summary>
    /// <param name="name">The name to validate</param>
    /// <returns>True if the name is valid, false otherwise</returns>
    private bool ValidatePlayerName(string name)
    {
        // Check if null or empty
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }
        
        // Check length (between 2 and 20 characters)
        string trimmedName = name.Trim();
        if (trimmedName.Length < 2 || trimmedName.Length > 20)
        {
            return false;
        }
        
        // Check for valid characters (letters and numbers only)
        foreach (char c in trimmedName)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        
        return true;
    }
}