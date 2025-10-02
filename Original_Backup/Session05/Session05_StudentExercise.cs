using UnityEngine;

/// <summary>
/// Session 05 Student Exercise: Object-Oriented Programming Basics
/// 
/// INSTRUCTIONS:
/// 1. Read each TODO section carefully
/// 2. Complete the code where you see "// TODO: ..."
/// 3. Test your work by attaching this script to a GameObject and pressing Play
/// 4. Watch the Console window to see if your implementations work correctly
/// 5. Modify the public variables in the Inspector to test different scenarios
/// 
/// LEARNING GOALS:
/// - Create and use classes and objects
/// - Implement constructors with different parameter sets
/// - Use access modifiers appropriately (public, private, protected)
/// - Understand static vs instance members
/// - Build a complete object-oriented game system
/// 
/// COMPLETION CRITERIA:
/// - All TODO sections completed without compiler errors
/// - Console shows successful creation and interaction of game objects
/// - Different constructor types working correctly
/// - Access modifiers properly protecting data
/// - Static and instance members used appropriately
/// </summary>
public class Session05_StudentExercise : MonoBehaviour
{
    [Header("Exercise Configuration")]
    [Tooltip("Enable this to run automatic tests")]
    public bool runAutomaticTests = true;
    
    [Tooltip("Time between automatic test runs")]
    public float testInterval = 3.0f;
    
    [Header("Exercise Progress Tracking")]
    [Tooltip("These will be updated as you complete exercises")]
    public int exercisesCompleted = 0;
    public int totalExercises = 8;
    
    private float nextTestTime;
    
    #region Exercise 1: Basic Class Creation
    
    /// <summary>
    /// EXERCISE 1: Create a Vehicle class with basic properties and methods
    /// 
    /// TODO: Complete the Vehicle class below by:
    /// 1. Adding the missing fields (make, model, year, fuel)
    /// 2. Creating a default constructor
    /// 3. Creating a parameterised constructor
    /// 4. Implementing the missing methods
    /// </summary>
    public class Vehicle
    {
        // TODO 1.1: Add these public fields:
        // - string make (e.g., "Toyota")
        // - string model (e.g., "Camry") 
        // - int year (e.g., 2023)
        // - float fuel (current fuel level, 0-100)
        // - bool isRunning (whether engine is on)
        
        // TODO 1.2: Create a default constructor that sets:
        // - make = "Unknown"
        // - model = "Generic"
        // - year = 2020
        // - fuel = 50.0f
        // - isRunning = false
        // - Debug.Log a message saying "Vehicle created with default values"
        
        
        // TODO 1.3: Create a parameterised constructor that takes:
        // - string vehicleMake, string vehicleModel, int vehicleYear
        // - Set those values and fuel = 100.0f, isRunning = false
        // - Debug.Log a message with the vehicle details
        
        
        // TODO 1.4: Create a StartEngine() method that:
        // - Checks if fuel > 0
        // - If yes: set isRunning = true, Debug.Log "Engine started"
        // - If no: Debug.Log "Cannot start - no fuel!"
        
        
        // TODO 1.5: Create a Drive(float distance) method that:
        // - Checks if isRunning is true
        // - If yes: reduce fuel by distance * 0.1f, Debug.Log driving message
        // - If no: Debug.Log "Cannot drive - engine not running!"
        // - If fuel reaches 0 or below, set isRunning = false
        
        
        // TODO 1.6: Create a GetVehicleInfo() method that returns a string with:
        // - All vehicle information in a readable format
        // - Example: "Toyota Camry (2023): Fuel=75%, Engine=ON"
        
        
        // Temporary stub implementations to satisfy compiler
        public string make = "TODO";
        public Vehicle() { Debug.Log("TODO: Implement default constructor"); }
        public Vehicle(string make, string model, int year) { Debug.Log("TODO: Implement parameterised constructor"); }
        public void StartEngine() { Debug.Log("TODO: Implement StartEngine"); }
        public void Drive(float distance) { Debug.Log("TODO: Implement Drive"); }
        public string GetVehicleInfo() { return "TODO: Implement GetVehicleInfo"; }
    }
    
    #endregion
    
    #region Exercise 2: Access Modifiers and Encapsulation
    
    /// <summary>
    /// EXERCISE 2: Create a BankAccount class demonstrating proper encapsulation
    /// 
    /// TODO: Complete the BankAccount class with proper access modifiers
    /// </summary>
    public class BankAccount
    {
        // TODO 2.1: Add these PRIVATE fields (protect the data):
        // - float balance
        // - string accountNumber
        // - string ownerName
        // - bool isActive
        
        
        // TODO 2.2: Add these PUBLIC fields (safe to expose):
        // - string bankName
        // - string accountType (e.g., "Savings", "Checking")
        
        
        // TODO 2.3: Create a constructor that takes:
        // - string owner, string accNumber, string accType, float initialBalance
        // - Set all private fields appropriately
        // - Set bankName = "Unity Bank"
        // - Ensure initialBalance is not negative (use Mathf.Max)
        // - Set isActive = true
        
        
        // TODO 2.4: Create a PUBLIC method GetBalance() that:
        // - Returns the current balance (safe read-only access)
        
        
        // TODO 2.5: Create a PUBLIC method Deposit(float amount) that:
        // - Checks if account isActive and amount > 0
        // - If valid: add amount to balance, Debug.Log success message, return true
        // - If invalid: Debug.Log error message, return false
        
        
        // TODO 2.6: Create a PUBLIC method Withdraw(float amount) that:
        // - Checks if account isActive, amount > 0, and sufficient balance
        // - If valid: subtract amount, Debug.Log success, return true
        // - If invalid: Debug.Log appropriate error, return false
        
        
        // TODO 2.7: Create a PUBLIC method GetAccountInfo() that returns:
        // - A string with owner name, account type, and balance
        // - Do NOT include the private account number for security
        
        
        // TODO 2.8: Create a PRIVATE method ValidateTransaction(float amount) that:
        // - Returns true if account is active and amount > 0
        // - This is internal helper logic that outside code shouldn't access
        
        
        // Temporary stub implementations to satisfy compiler
        public BankAccount(string owner, string accNumber, string accType, float initialBalance) { Debug.Log("TODO: Implement constructor"); }
        public float GetBalance() { return 0f; }
        public bool Deposit(float amount) { Debug.Log("TODO: Implement Deposit"); return false; }
        public bool Withdraw(float amount) { Debug.Log("TODO: Implement Withdraw"); return false; }
        public string GetAccountInfo() { return "TODO: Implement GetAccountInfo"; }
    }
    
    #endregion
    
    #region Exercise 3: Constructor Overloading and Validation
    
    /// <summary>
    /// EXERCISE 3: Create a Weapon class with multiple constructors and validation
    /// 
    /// TODO: Complete the Weapon class with constructor overloading
    /// </summary>
    public class Weapon
    {
        public string weaponName;
        public int damage;
        public float range;
        public int durability;
        public string weaponType;
        public bool isBroken;
        
        // TODO 3.1: Create a DEFAULT constructor that creates a basic weapon:
        // - weaponName = "Basic Sword"
        // - damage = 10, range = 2.0f, durability = 50
        // - weaponType = "Melee", isBroken = false
        // - Debug.Log creation message
        
        
        // TODO 3.2: Create a constructor with just NAME parameter:
        // - Takes string name
        // - Sets weaponName = name
        // - Sets random damage (15-25), range (1.5f-3.0f), durability (40-60)
        // - weaponType = "Custom", isBroken = false
        // - Use Random.Range for the random values
        // - Debug.Log creation message with stats
        
        
        // TODO 3.3: Create a FULL constructor with all parameters:
        // - string name, int dmg, float weaponRange, int dur, string type
        // - Set all fields but validate them first:
        //   * damage must be 1-100 (use Mathf.Clamp)
        //   * range must be 0.5f-10.0f (use Mathf.Clamp)
        //   * durability must be 1-100 (use Mathf.Clamp)
        // - Set isBroken = false
        // - Debug.Log creation with all stats
        
        
        // TODO 3.4: Create a constructor using WEAPON TYPE enum:
        // - Takes string name and WeaponType weaponTypeEnum
        // - Use a switch statement to set appropriate stats:
        //   * Sword: damage=25, range=2.0f, durability=60
        //   * Bow: damage=20, range=8.0f, durability=40
        //   * Staff: damage=30, range=5.0f, durability=35
        //   * Dagger: damage=15, range=1.0f, durability=70
        // - Set weaponType to the enum name as string
        // - Debug.Log creation message
        
        
        // TODO 3.5: Create a UseWeapon() method that:
        // - Checks if weapon is not broken
        // - Reduces durability by 1
        // - If durability reaches 0, set isBroken = true
        // - Debug.Log usage message with remaining durability
        // - Return the damage value (0 if broken)
        
        
        // TODO 3.6: Create a RepairWeapon(int repairAmount) method that:
        // - Adds repairAmount to durability (max 100)
        // - If durability > 0, set isBroken = false
        // - Debug.Log repair message
        
        
        // Temporary stub implementations to satisfy compiler
        public Weapon() { Debug.Log("TODO: Implement default constructor"); }
        public Weapon(string name) { Debug.Log("TODO: Implement name constructor"); }
        public Weapon(string name, int dmg, float weaponRange, int dur, string type) { Debug.Log("TODO: Implement full constructor"); }
        public Weapon(string name, WeaponType weaponTypeEnum) { Debug.Log("TODO: Implement enum constructor"); }
        public int UseWeapon() { Debug.Log("TODO: Implement UseWeapon"); return 0; }
        public void RepairWeapon(int repairAmount) { Debug.Log("TODO: Implement RepairWeapon"); }
    }
    
    /// <summary>
    /// Enum for weapon types - use this in Exercise 3.4
    /// </summary>
    public enum WeaponType
    {
        Sword,
        Bow,
        Staff,
        Dagger
    }
    
    #endregion
    
    #region Exercise 4: Static vs Instance Members
    
    /// <summary>
    /// EXERCISE 4: Create a Player class demonstrating static vs instance members
    /// 
    /// TODO: Complete the Player class with both static and instance members
    /// </summary>
    public class Player
    {
        // TODO 4.1: Add these STATIC fields (shared by all players):
        // - int totalPlayersCreated
        // - int maxPlayersAllowed = 4
        // - string gameVersion = "1.0"
        // - float globalExperienceMultiplier = 1.0f
        
        
        // TODO 4.2: Add these INSTANCE fields (unique to each player):
        // - string playerName
        // - int playerID
        // - int level
        // - float experience
        // - int health
        // - bool isAlive
        
        
        // TODO 4.3: Create a constructor that:
        // - Takes string name
        // - Sets playerName = name
        // - Increments totalPlayersCreated
        // - Sets playerID = totalPlayersCreated (unique ID)
        // - Sets level = 1, experience = 0, health = 100, isAlive = true
        // - Debug.Log player creation with ID
        
        
        // TODO 4.4: Create an INSTANCE method GainExperience(int exp):
        // - Multiply exp by globalExperienceMultiplier
        // - Add to experience
        // - Check if experience >= (level * 100) for level up
        // - If level up: increment level, add 20 to health
        // - Debug.Log experience gain and potential level up
        
        
        // TODO 4.5: Create an INSTANCE method TakeDamage(int damage):
        // - Reduce health by damage
        // - If health <= 0: set isAlive = false, health = 0
        // - Debug.Log damage taken and current health
        
        
        // TODO 4.6: Create a STATIC method CanCreatePlayer():
        // - Return true if totalPlayersCreated < maxPlayersAllowed
        // - This checks global limit without needing a player instance
        
        
        // TODO 4.7: Create a STATIC method GetGlobalPlayerStats():
        // - Return a string with totalPlayersCreated, maxPlayersAllowed, 
        //   gameVersion, and globalExperienceMultiplier
        // - This provides global information without needing an instance
        
        
        // TODO 4.8: Create a STATIC method SetGlobalExperienceMultiplier(float multiplier):
        // - Set globalExperienceMultiplier = multiplier (clamp between 0.1f and 5.0f)
        // - Debug.Log the change
        // - This affects ALL players' experience gain
        
        
        // TODO 4.9: Create an INSTANCE method GetPlayerInfo():
        // - Return string with playerName, playerID, level, experience, health, isAlive
        // - This shows individual player data
        
        
        // Temporary stub implementations to satisfy compiler
        public Player(string name) { Debug.Log("TODO: Implement constructor"); }
        public void GainExperience(int exp) { Debug.Log("TODO: Implement GainExperience"); }
        public void TakeDamage(int damage) { Debug.Log("TODO: Implement TakeDamage"); }
        public static bool CanCreatePlayer() { return true; }
        public static string GetGlobalPlayerStats() { return "TODO: Implement GetGlobalPlayerStats"; }
        public static void SetGlobalExperienceMultiplier(float multiplier) { Debug.Log("TODO: Implement SetGlobalExperienceMultiplier"); }
        public string GetPlayerInfo() { return "TODO: Implement GetPlayerInfo"; }
    }
    
    #endregion
    
    #region Exercise Testing Methods
    
    void Start()
    {
        Debug.Log("=== SESSION 05 STUDENT EXERCISE STARTED ===");
        Debug.Log("Complete the TODO sections and watch your implementations work!");
        Debug.Log("Press 1, 2, 3, or 4 to manually test each exercise");
        Debug.Log("");
        
        nextTestTime = Time.time + testInterval;
        
        if (runAutomaticTests)
        {
            TestAllExercises();
        }
    }
    
    void Update()
    {
        if (runAutomaticTests && Time.time >= nextTestTime)
        {
            TestRandomExercise();
            nextTestTime = Time.time + testInterval;
        }
        
        // Manual testing with number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TestExercise1();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TestExercise2();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TestExercise3();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TestExercise4();
        }
    }
    
    /// <summary>
    /// Test Exercise 1: Vehicle class
    /// </summary>
    void TestExercise1()
    {
        Debug.Log("--- TESTING EXERCISE 1: VEHICLE CLASS ---");
        
        try
        {
            // Test default constructor
            Vehicle defaultCar = new Vehicle();
            Debug.Log($"Default vehicle: {defaultCar.GetVehicleInfo()}");
            
            // Test parameterised constructor
            Vehicle customCar = new Vehicle("Honda", "Civic", 2022);
            Debug.Log($"Custom vehicle: {customCar.GetVehicleInfo()}");
            
            // Test methods
            customCar.StartEngine();
            customCar.Drive(50.0f);
            Debug.Log($"After driving: {customCar.GetVehicleInfo()}");
            
            Debug.Log("✅ Exercise 1 tests completed successfully!");
            exercisesCompleted = Mathf.Max(exercisesCompleted, 1);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ Exercise 1 error: {e.Message}");
            Debug.Log("Check your Vehicle class implementation!");
        }
        
        Debug.Log("");
    }
    
    /// <summary>
    /// Test Exercise 2: BankAccount class
    /// </summary>
    void TestExercise2()
    {
        Debug.Log("--- TESTING EXERCISE 2: BANK ACCOUNT CLASS ---");
        
        try
        {
            // Test constructor and basic operations
            BankAccount account = new BankAccount("John Doe", "ACC123", "Savings", 1000.0f);
            Debug.Log($"Account created: {account.GetAccountInfo()}");
            Debug.Log($"Initial balance: £{account.GetBalance()}");
            
            // Test deposit
            account.Deposit(250.0f);
            Debug.Log($"After deposit: £{account.GetBalance()}");
            
            // Test withdrawal
            account.Withdraw(150.0f);
            Debug.Log($"After withdrawal: £{account.GetBalance()}");
            
            // Test invalid operations
            account.Withdraw(5000.0f);  // Should fail
            account.Deposit(-50.0f);    // Should fail
            
            Debug.Log("✅ Exercise 2 tests completed successfully!");
            exercisesCompleted = Mathf.Max(exercisesCompleted, 2);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ Exercise 2 error: {e.Message}");
            Debug.Log("Check your BankAccount class implementation!");
        }
        
        Debug.Log("");
    }
    
    /// <summary>
    /// Test Exercise 3: Weapon class
    /// </summary>
    void TestExercise3()
    {
        Debug.Log("--- TESTING EXERCISE 3: WEAPON CLASS ---");
        
        try
        {
            // Test different constructors
            Weapon defaultWeapon = new Weapon();
            Weapon namedWeapon = new Weapon("Excalibur");
            Weapon customWeapon = new Weapon("Lightning Bolt", 45, 6.0f, 80, "Magic");
            Weapon typeWeapon = new Weapon("Elven Bow", WeaponType.Bow);
            
            // Test weapon usage
            Debug.Log("\\nTesting weapon usage:");
            for (int i = 0; i < 3; i++)
            {
                int damage = defaultWeapon.UseWeapon();
                Debug.Log($"Default weapon dealt {damage} damage");
            }
            
            // Test repair
            defaultWeapon.RepairWeapon(20);
            
            Debug.Log("✅ Exercise 3 tests completed successfully!");
            exercisesCompleted = Mathf.Max(exercisesCompleted, 3);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ Exercise 3 error: {e.Message}");
            Debug.Log("Check your Weapon class implementation!");
        }
        
        Debug.Log("");
    }
    
    /// <summary>
    /// Test Exercise 4: Player class with static members
    /// </summary>
    void TestExercise4()
    {
        Debug.Log("--- TESTING EXERCISE 4: PLAYER CLASS ---");
        
        try
        {
            // Test static methods before creating players
            Debug.Log(Player.GetGlobalPlayerStats());
            Debug.Log($"Can create player? {Player.CanCreatePlayer()}");
            
            // Test player creation
            Player player1 = new Player("Alice");
            Player player2 = new Player("Bob");
            Debug.Log($"Player 1: {player1.GetPlayerInfo()}");
            Debug.Log($"Player 2: {player2.GetPlayerInfo()}");
            
            // Test static vs instance behavior
            Player.SetGlobalExperienceMultiplier(2.0f);
            player1.GainExperience(50);  // Should be doubled
            player2.GainExperience(75);  // Should be doubled
            
            // Test damage
            player1.TakeDamage(30);
            
            // Show updated stats
            Debug.Log($"Updated Player 1: {player1.GetPlayerInfo()}");
            Debug.Log($"Updated Player 2: {player2.GetPlayerInfo()}");
            Debug.Log(Player.GetGlobalPlayerStats());
            
            Debug.Log("✅ Exercise 4 tests completed successfully!");
            exercisesCompleted = Mathf.Max(exercisesCompleted, 4);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ Exercise 4 error: {e.Message}");
            Debug.Log("Check your Player class implementation!");
        }
        
        Debug.Log("");
    }
    
    /// <summary>
    /// Test all exercises in sequence
    /// </summary>
    void TestAllExercises()
    {
        Debug.Log("🧪 Running all exercise tests...");
        TestExercise1();
        TestExercise2();
        TestExercise3();
        TestExercise4();
        
        Debug.Log($"📊 Progress: {exercisesCompleted}/{totalExercises} exercises completed");
        
        if (exercisesCompleted >= totalExercises)
        {
            Debug.Log("🎉 CONGRATULATIONS! All exercises completed successfully!");
            Debug.Log("You've mastered the basics of Object-Oriented Programming!");
        }
    }
    
    /// <summary>
    /// Test a random exercise for variety
    /// </summary>
    void TestRandomExercise()
    {
        int randomTest = Random.Range(1, 5);
        
        Debug.Log("🔄 Auto-Test: Running random exercise test...");
        
        switch (randomTest)
        {
            case 1: TestExercise1(); break;
            case 2: TestExercise2(); break;
            case 3: TestExercise3(); break;
            case 4: TestExercise4(); break;
        }
        
        Debug.Log($"Progress: {exercisesCompleted}/{totalExercises} exercises completed");
        Debug.Log("Press 1, 2, 3, or 4 to manually test specific exercises!");
        Debug.Log("");
    }
    
    #endregion
    
    #region Helper Methods and Completion Checklist
    
    /// <summary>
    /// Call this method when you think you've completed everything
    /// </summary>
    [ContextMenu("Check Exercise Completion")]
    void CheckCompletion()
    {
        Debug.Log("=== EXERCISE COMPLETION CHECKLIST ===");
        
        // Check Exercise 1
        try
        {
            Vehicle testVehicle = new Vehicle();
            bool ex1Complete = !string.IsNullOrEmpty(testVehicle.make);
            Debug.Log($"Exercise 1 (Vehicle): {(ex1Complete ? "✅ COMPLETE" : "❌ INCOMPLETE")}");
        }
        catch
        {
            Debug.Log("Exercise 1 (Vehicle): ❌ INCOMPLETE - Compilation errors");
        }
        
        // Check Exercise 2
        try
        {
            BankAccount testAccount = new BankAccount("Test", "123", "Savings", 100);
            bool ex2Complete = testAccount.GetBalance() >= 0;
            Debug.Log($"Exercise 2 (BankAccount): {(ex2Complete ? "✅ COMPLETE" : "❌ INCOMPLETE")}");
        }
        catch
        {
            Debug.Log("Exercise 2 (BankAccount): ❌ INCOMPLETE - Compilation errors");
        }
        
        // Check Exercise 3
        try
        {
            Weapon testWeapon = new Weapon();
            bool ex3Complete = !string.IsNullOrEmpty(testWeapon.weaponName);
            Debug.Log($"Exercise 3 (Weapon): {(ex3Complete ? "✅ COMPLETE" : "❌ INCOMPLETE")}");
        }
        catch
        {
            Debug.Log("Exercise 3 (Weapon): ❌ INCOMPLETE - Compilation errors");
        }
        
        // Check Exercise 4
        try
        {
            bool ex4Complete = Player.CanCreatePlayer();
            Debug.Log($"Exercise 4 (Player): {(ex4Complete ? "✅ COMPLETE" : "❌ INCOMPLETE")}");
        }
        catch
        {
            Debug.Log("Exercise 4 (Player): ❌ INCOMPLETE - Compilation errors");
        }
        
        if (exercisesCompleted >= totalExercises)
        {
            Debug.Log("\\n🎉 ALL EXERCISES COMPLETE! You've mastered OOP basics!");
            Debug.Log("Ready to move on to Session 06: Advanced OOP concepts!");
        }
        else
        {
            Debug.Log($"\\n📚 Keep working! Complete the remaining TODO sections.");
            Debug.Log("💡 Tip: Look for compilation errors in the Console and fix them first.");
        }
    }
    
    void Reset()
    {
        runAutomaticTests = true;
        testInterval = 3.0f;
        exercisesCompleted = 0;
        totalExercises = 8;
    }
    
    #endregion
}

/*
COMPLETION CHECKLIST - Mark each TODO as complete:

EXERCISE 1 - VEHICLE CLASS:
☐ TODO 1.1: Added all required fields (make, model, year, fuel, isRunning)
☐ TODO 1.2: Created default constructor with proper initialization
☐ TODO 1.3: Created parameterised constructor with Debug.Log
☐ TODO 1.4: Implemented StartEngine() method with fuel check
☐ TODO 1.5: Implemented Drive() method with fuel consumption
☐ TODO 1.6: Created GetVehicleInfo() method returning formatted string

EXERCISE 2 - BANKACCOUNT CLASS:
☐ TODO 2.1: Added private fields for sensitive data
☐ TODO 2.2: Added public fields for safe data
☐ TODO 2.3: Created constructor with validation
☐ TODO 2.4: Created GetBalance() method for safe access
☐ TODO 2.5: Implemented Deposit() method with validation
☐ TODO 2.6: Implemented Withdraw() method with validation
☐ TODO 2.7: Created GetAccountInfo() method (without private data)
☐ TODO 2.8: Created private ValidateTransaction() helper method

EXERCISE 3 - WEAPON CLASS:
☐ TODO 3.1: Created default constructor with basic weapon stats
☐ TODO 3.2: Created single-parameter constructor with random stats
☐ TODO 3.3: Created full constructor with validation using Mathf.Clamp
☐ TODO 3.4: Created enum-based constructor with switch statement
☐ TODO 3.5: Implemented UseWeapon() method with durability system
☐ TODO 3.6: Implemented RepairWeapon() method

EXERCISE 4 - PLAYER CLASS:
☐ TODO 4.1: Added static fields for global player data
☐ TODO 4.2: Added instance fields for individual player data
☐ TODO 4.3: Created constructor with unique ID assignment
☐ TODO 4.4: Implemented GainExperience() instance method with leveling
☐ TODO 4.5: Implemented TakeDamage() instance method
☐ TODO 4.6: Created CanCreatePlayer() static method
☐ TODO 4.7: Created GetGlobalPlayerStats() static method
☐ TODO 4.8: Created SetGlobalExperienceMultiplier() static method
☐ TODO 4.9: Created GetPlayerInfo() instance method

TESTING:
☐ All classes compile without errors
☐ Exercise 1 test passes (Vehicle functionality works)
☐ Exercise 2 test passes (BankAccount encapsulation works)
☐ Exercise 3 test passes (Weapon constructors and methods work)
☐ Exercise 4 test passes (Player static/instance behavior works)
☐ Manual testing with number keys works
☐ Automatic testing runs without errors

When complete, you should understand:
✓ How to create classes and objects
✓ The purpose and implementation of constructors
✓ When and how to use access modifiers (public, private, protected)
✓ The difference between static and instance members
✓ How to design object-oriented game systems
✓ Data encapsulation and validation principles
*/