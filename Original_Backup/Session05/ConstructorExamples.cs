using UnityEngine;

/// <summary>
/// Demonstrates various constructor patterns and object initialization techniques.
/// Shows default constructors, parameterised constructors, constructor overloading, and Unity-specific patterns.
/// 
/// Learning Goals:
/// - Understand what constructors are and why they're important
/// - Learn different types of constructors (default, parameterised)
/// - See constructor overloading in action
/// - Practice Unity-specific initialization patterns
/// - Understand constructor chaining and validation
/// </summary>
public class ConstructorExamples : MonoBehaviour
{
    [Header("Constructor Demonstration Settings")]
    [Tooltip("Time between automatic constructor demonstrations")]
    public float demoInterval = 5.0f;
    
    [Header("Object Creation Statistics")]
    [Tooltip("Track objects created using different constructor types")]
    public int defaultConstructorUsed = 0;
    public int parameterisedConstructorUsed = 0;
    public int overloadedConstructorUsed = 0;
    
    private float nextDemoTime;
    
    /// <summary>
    /// Spaceship class demonstrating multiple constructor patterns
    /// Shows default, parameterised, and overloaded constructors
    /// </summary>
    public class Spaceship
    {
        // Properties that can be set via constructors
        public string shipName;
        public float speed;
        public int shields;
        public int weapons;
        public string shipClass;
        public bool isOperational;
        
        // Calculated properties
        public float totalPower;
        public int crewSize;
        
        /// <summary>
        /// Default constructor - creates a basic spaceship with standard values
        /// Use when you want a "blank" object with sensible defaults
        /// </summary>
        public Spaceship()
        {
            Debug.Log("🚀 Default constructor called - creating basic spaceship");
            
            shipName = "USS Default";
            speed = 100.0f;
            shields = 50;
            weapons = 25;
            shipClass = "Scout";
            isOperational = true;
            
            CalculateDerivedValues();
            
            Debug.Log($"Created: {GetShipInfo()}");
        }
        
        /// <summary>
        /// Parameterised constructor - creates spaceship with specific name and basic stats
        /// Use when you have essential information but want defaults for other values
        /// </summary>
        public Spaceship(string name)
        {
            Debug.Log($"🚀 Single-parameter constructor called for: {name}");
            
            shipName = name;
            speed = 120.0f;
            shields = 75;
            weapons = 30;
            shipClass = "Fighter";
            isOperational = true;
            
            CalculateDerivedValues();
            
            Debug.Log($"Created: {GetShipInfo()}");
        }
        
        /// <summary>
        /// Full parameterised constructor - creates spaceship with all custom values
        /// Use when you have specific requirements for all properties
        /// </summary>
        public Spaceship(string name, float shipSpeed, int shieldPower, int weaponPower, string classification)
        {
            Debug.Log($"🚀 Full constructor called for: {name}");
            
            shipName = name;
            speed = ValidateSpeed(shipSpeed);
            shields = ValidateShields(shieldPower);
            weapons = ValidateWeapons(weaponPower);
            shipClass = string.IsNullOrEmpty(classification) ? "Unknown" : classification;
            isOperational = true;
            
            CalculateDerivedValues();
            
            Debug.Log($"Created: {GetShipInfo()}");
        }
        
        /// <summary>
        /// Overloaded constructor - creates spaceship optimised for specific roles
        /// Use when you want predefined configurations for common use cases
        /// </summary>
        public Spaceship(string name, ShipRole role)
        {
            Debug.Log($"🚀 Role-based constructor called for: {name} ({role})");
            
            shipName = name;
            isOperational = true;
            
            // Configure ship based on role
            switch (role)
            {
                case ShipRole.Scout:
                    speed = 200.0f;
                    shields = 30;
                    weapons = 15;
                    shipClass = "Scout";
                    break;
                    
                case ShipRole.Fighter:
                    speed = 150.0f;
                    shields = 75;
                    weapons = 100;
                    shipClass = "Fighter";
                    break;
                    
                case ShipRole.Cruiser:
                    speed = 100.0f;
                    shields = 150;
                    weapons = 75;
                    shipClass = "Cruiser";
                    break;
                    
                case ShipRole.Battleship:
                    speed = 50.0f;
                    shields = 300;
                    weapons = 200;
                    shipClass = "Battleship";
                    break;
                    
                default:
                    speed = 100.0f;
                    shields = 50;
                    weapons = 25;
                    shipClass = "Unknown";
                    break;
            }
            
            CalculateDerivedValues();
            
            Debug.Log($"Created: {GetShipInfo()}");
        }
        
        /// <summary>
        /// Constructor chaining example - this constructor calls another constructor
        /// Use to avoid code duplication between constructors
        /// </summary>
        public Spaceship(string name, float shipSpeed) : this(name, shipSpeed, 50, 25, "Custom")
        {
            Debug.Log($"🔗 Constructor chaining used for {name} with speed {shipSpeed}");
        }
        
        // Private helper methods for validation
        private float ValidateSpeed(float speed)
        {
            if (speed < 0) 
            {
                Debug.LogWarning("Speed cannot be negative, setting to 0");
                return 0;
            }
            if (speed > 1000)
            {
                Debug.LogWarning("Speed too high, capping at 1000");
                return 1000;
            }
            return speed;
        }
        
        private int ValidateShields(int shields)
        {
            return Mathf.Clamp(shields, 0, 500);
        }
        
        private int ValidateWeapons(int weapons)
        {
            return Mathf.Clamp(weapons, 0, 300);
        }
        
        // Calculate derived values based on base stats
        private void CalculateDerivedValues()
        {
            totalPower = speed * 0.5f + shields * 0.8f + weapons * 1.2f;
            crewSize = Mathf.RoundToInt(totalPower / 50.0f);
            
            if (crewSize < 1) crewSize = 1;
        }
        
        // Public method to get ship information
        public string GetShipInfo()
        {
            return $"{shipName} [{shipClass}]: Speed={speed}, Shields={shields}, Weapons={weapons}, Power={totalPower:F1}, Crew={crewSize}";
        }
        
        // Method to test ship functionality
        public void TestSystems()
        {
            if (!isOperational)
            {
                Debug.Log($"❌ {shipName} systems offline - cannot test");
                return;
            }
            
            Debug.Log($"🔍 Testing {shipName} systems:");
            Debug.Log($"  Engine Test: {(speed > 0 ? "PASS" : "FAIL")}");
            Debug.Log($"  Shield Test: {(shields > 0 ? "PASS" : "FAIL")}");
            Debug.Log($"  Weapon Test: {(weapons > 0 ? "PASS" : "FAIL")}");
            Debug.Log($"  Overall Rating: {GetShipRating()}");
        }
        
        private string GetShipRating()
        {
            if (totalPower < 100) return "Basic";
            if (totalPower < 200) return "Standard";
            if (totalPower < 300) return "Advanced";
            return "Elite";
        }
    }
    
    /// <summary>
    /// Enum for ship roles (used in constructor overloading)
    /// </summary>
    public enum ShipRole
    {
        Scout,
        Fighter,
        Cruiser,
        Battleship
    }
    
    /// <summary>
    /// GameCharacter class showing Unity-specific initialization patterns
    /// Since MonoBehaviour classes can't use constructors normally, we use initialization methods
    /// </summary>
    public class GameCharacter
    {
        public string characterName;
        public int level;
        public float health;
        public float mana;
        public string characterClass;
        public bool isAlive;
        
        // Stats
        public int strength;
        public int intelligence;
        public int agility;
        
        // Calculated values
        public float maxHealth;
        public float maxMana;
        public int combatPower;
        
        /// <summary>
        /// Default initialization - like a default constructor
        /// </summary>
        public void Initialize()
        {
            Debug.Log("⚔️ Default character initialization");
            
            characterName = "Adventurer";
            level = 1;
            characterClass = "Warrior";
            strength = 10;
            intelligence = 8;
            agility = 7;
            
            CalculateStats();
            
            Debug.Log($"Initialized: {GetCharacterInfo()}");
        }
        
        /// <summary>
        /// Name-based initialization - like a single-parameter constructor
        /// </summary>
        public void Initialize(string name)
        {
            Debug.Log($"⚔️ Character initialization for: {name}");
            
            characterName = name;
            level = 1;
            characterClass = "Adventurer";
            strength = Random.Range(8, 12);
            intelligence = Random.Range(8, 12);
            agility = Random.Range(8, 12);
            
            CalculateStats();
            
            Debug.Log($"Initialized: {GetCharacterInfo()}");
        }
        
        /// <summary>
        /// Full initialization - like a full parameterised constructor
        /// </summary>
        public void Initialize(string name, string charClass, int str, int intel, int agi)
        {
            Debug.Log($"⚔️ Full character initialization for: {name}");
            
            characterName = name;
            level = 1;
            characterClass = charClass;
            strength = Mathf.Clamp(str, 1, 20);
            intelligence = Mathf.Clamp(intel, 1, 20);
            agility = Mathf.Clamp(agi, 1, 20);
            
            CalculateStats();
            
            Debug.Log($"Initialized: {GetCharacterInfo()}");
        }
        
        /// <summary>
        /// Class-based initialization - like role-based constructor
        /// </summary>
        public void Initialize(string name, CharacterClass charClass)
        {
            Debug.Log($"⚔️ Class-based initialization for: {name} ({charClass})");
            
            characterName = name;
            level = 1;
            
            switch (charClass)
            {
                case CharacterClass.Warrior:
                    this.characterClass = "Warrior";
                    strength = 15;
                    intelligence = 6;
                    agility = 9;
                    break;
                    
                case CharacterClass.Mage:
                    this.characterClass = "Mage";
                    strength = 6;
                    intelligence = 15;
                    agility = 9;
                    break;
                    
                case CharacterClass.Rogue:
                    this.characterClass = "Rogue";
                    strength = 9;
                    intelligence = 9;
                    agility = 15;
                    break;
                    
                case CharacterClass.Paladin:
                    this.characterClass = "Paladin";
                    strength = 12;
                    intelligence = 12;
                    agility = 6;
                    break;
            }
            
            CalculateStats();
            
            Debug.Log($"Initialized: {GetCharacterInfo()}");
        }
        
        private void CalculateStats()
        {
            maxHealth = 50 + (strength * 5) + (level * 10);
            maxMana = 30 + (intelligence * 3) + (level * 5);
            health = maxHealth;
            mana = maxMana;
            isAlive = true;
            
            combatPower = strength * 2 + intelligence + agility + level * 3;
        }
        
        public string GetCharacterInfo()
        {
            return $"{characterName} [{characterClass}] Lv.{level}: STR={strength}, INT={intelligence}, AGI={agility}, HP={health:F0}/{maxHealth:F0}, MP={mana:F0}/{maxMana:F0}, Power={combatPower}";
        }
    }
    
    public enum CharacterClass
    {
        Warrior,
        Mage,
        Rogue,
        Paladin
    }
    
    void Start()
    {
        Debug.Log("=== CONSTRUCTOR EXAMPLES DEMONSTRATION STARTED ===");
        Debug.Log("This demonstrates various constructor patterns and initialization techniques");
        Debug.Log("Watch how different constructors create objects with different initial states!");
        Debug.Log("");
        
        DemonstrateBasicConstructors();
        DemonstrateConstructorOverloading();
        DemonstrateUnityInitialization();
        
        nextDemoTime = Time.time + demoInterval;
    }
    
    void Update()
    {
        if (Time.time >= nextDemoTime)
        {
            RunRandomConstructorDemo();
            nextDemoTime = Time.time + demoInterval;
        }
        
        // Manual demonstrations
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DemonstrateBasicConstructors();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DemonstrateConstructorOverloading();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DemonstrateUnityInitialization();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DemonstrateConstructorValidation();
        }
    }
    
    /// <summary>
    /// Shows basic default and parameterised constructors
    /// </summary>
    void DemonstrateBasicConstructors()
    {
        Debug.Log("--- BASIC CONSTRUCTORS DEMONSTRATION ---");
        
        // Default constructor
        Debug.Log("Creating spaceship with DEFAULT constructor:");
        Spaceship basicShip = new Spaceship();
        defaultConstructorUsed++;
        basicShip.TestSystems();
        
        Debug.Log("");
        
        // Single parameter constructor
        Debug.Log("Creating spaceship with SINGLE-PARAMETER constructor:");
        Spaceship namedShip = new Spaceship("USS Enterprise");
        parameterisedConstructorUsed++;
        namedShip.TestSystems();
        
        Debug.Log("");
        
        // Full parameter constructor
        Debug.Log("Creating spaceship with FULL constructor:");
        Spaceship customShip = new Spaceship("Millennium Falcon", 180.0f, 60, 85, "Light Freighter");
        parameterisedConstructorUsed++;
        customShip.TestSystems();
        
        Debug.Log($"Constructor usage: Default={defaultConstructorUsed}, Parameterised={parameterisedConstructorUsed}");
        Debug.Log("");
    }
    
    /// <summary>
    /// Demonstrates constructor overloading with different parameter types
    /// </summary>
    void DemonstrateConstructorOverloading()
    {
        Debug.Log("--- CONSTRUCTOR OVERLOADING DEMONSTRATION ---");
        
        Debug.Log("Creating ships using ROLE-BASED constructors:");
        
        // Create ships for different roles
        Spaceship scout = new Spaceship("Swift Arrow", ShipRole.Scout);
        overloadedConstructorUsed++;
        
        Spaceship fighter = new Spaceship("Viper", ShipRole.Fighter);
        overloadedConstructorUsed++;
        
        Spaceship cruiser = new Spaceship("Thunder", ShipRole.Cruiser);
        overloadedConstructorUsed++;
        
        Spaceship battleship = new Spaceship("Dreadnought", ShipRole.Battleship);
        overloadedConstructorUsed++;
        
        Debug.Log("\\nComparing ships created with role-based constructors:");
        scout.TestSystems();
        fighter.TestSystems();
        cruiser.TestSystems();
        battleship.TestSystems();
        
        Debug.Log("\\nDemonstrating CONSTRUCTOR CHAINING:");
        Spaceship speedShip = new Spaceship("Lightning", 250.0f);  // Uses constructor chaining
        parameterisedConstructorUsed++;
        speedShip.TestSystems();
        
        Debug.Log($"Constructor usage: Default={defaultConstructorUsed}, Parameterised={parameterisedConstructorUsed}, Overloaded={overloadedConstructorUsed}");
        Debug.Log("");
    }
    
    /// <summary>
    /// Shows Unity-specific initialization patterns (since MonoBehaviour can't use constructors normally)
    /// </summary>
    void DemonstrateUnityInitialization()
    {
        Debug.Log("--- UNITY INITIALIZATION PATTERNS ---");
        Debug.Log("MonoBehaviour classes can't use constructors, so we use Initialize() methods:");
        
        // Default initialization
        GameCharacter defaultChar = new GameCharacter();
        defaultChar.Initialize();
        
        // Name-based initialization
        GameCharacter namedChar = new GameCharacter();
        namedChar.Initialize("Aragorn");
        
        // Full initialization
        GameCharacter customChar = new GameCharacter();
        customChar.Initialize("Gandalf", "Wizard", 8, 18, 10);
        
        // Class-based initialization
        GameCharacter warrior = new GameCharacter();
        warrior.Initialize("Conan", CharacterClass.Warrior);
        
        GameCharacter mage = new GameCharacter();
        mage.Initialize("Merlin", CharacterClass.Mage);
        
        GameCharacter rogue = new GameCharacter();
        rogue.Initialize("Robin", CharacterClass.Rogue);
        
        Debug.Log("\\nCharacter comparison:");
        Debug.Log($"Default: {defaultChar.GetCharacterInfo()}");
        Debug.Log($"Named: {namedChar.GetCharacterInfo()}");
        Debug.Log($"Custom: {customChar.GetCharacterInfo()}");
        Debug.Log($"Warrior: {warrior.GetCharacterInfo()}");
        Debug.Log($"Mage: {mage.GetCharacterInfo()}");
        Debug.Log($"Rogue: {rogue.GetCharacterInfo()}");
        Debug.Log("");
    }
    
    /// <summary>
    /// Shows constructor validation and error handling
    /// </summary>
    void DemonstrateConstructorValidation()
    {
        Debug.Log("--- CONSTRUCTOR VALIDATION DEMONSTRATION ---");
        Debug.Log("Testing constructors with invalid data to show validation:");
        
        // Test with invalid values
        Debug.Log("\\nCreating ship with NEGATIVE speed:");
        Spaceship invalidShip1 = new Spaceship("Bad Ship", -50.0f, 100, 50, "Broken");
        
        Debug.Log("\\nCreating ship with EXCESSIVE values:");
        Spaceship invalidShip2 = new Spaceship("Overpowered", 2000.0f, 999, 500, "Cheater");
        
        Debug.Log("\\nCreating character with INVALID stats:");
        GameCharacter invalidChar = new GameCharacter();
        invalidChar.Initialize("Broken Hero", "Hacker", -5, 50, 0);
        
        Debug.Log("\\n✅ Notice how constructors validate and fix invalid data!");
        Debug.Log("This prevents objects from being created in invalid states.");
        Debug.Log("");
    }
    
    /// <summary>
    /// Runs random constructor demonstrations
    /// </summary>
    void RunRandomConstructorDemo()
    {
        Debug.Log("🔄 Auto-Demo: Creating random objects with different constructors...");
        
        int choice = Random.Range(0, 4);
        
        switch (choice)
        {
            case 0:
                // Random spaceship with default constructor
                Spaceship randomShip1 = new Spaceship();
                defaultConstructorUsed++;
                Debug.Log($"Random creation: {randomShip1.GetShipInfo()}");
                break;
                
            case 1:
                // Random spaceship with name
                string[] shipNames = { "Phoenix", "Nova", "Starlight", "Cosmos", "Nebula" };
                string randomName = shipNames[Random.Range(0, shipNames.Length)];
                Spaceship randomShip2 = new Spaceship(randomName);
                parameterisedConstructorUsed++;
                Debug.Log($"Random creation: {randomShip2.GetShipInfo()}");
                break;
                
            case 2:
                // Random spaceship with role
                ShipRole randomRole = (ShipRole)Random.Range(0, 4);
                Spaceship randomShip3 = new Spaceship($"Auto-{randomRole}", randomRole);
                overloadedConstructorUsed++;
                Debug.Log($"Random creation: {randomShip3.GetShipInfo()}");
                break;
                
            case 3:
                // Random character
                string[] charNames = { "Hero", "Champion", "Adventurer", "Warrior", "Mage" };
                CharacterClass randomClass = (CharacterClass)Random.Range(0, 4);
                GameCharacter randomChar = new GameCharacter();
                randomChar.Initialize(charNames[Random.Range(0, charNames.Length)], randomClass);
                Debug.Log($"Random creation: {randomChar.GetCharacterInfo()}");
                break;
        }
        
        Debug.Log($"Usage stats - Default: {defaultConstructorUsed}, Parameterised: {parameterisedConstructorUsed}, Overloaded: {overloadedConstructorUsed}");
        Debug.Log("Press 1, 2, 3, or 4 for manual constructor demonstrations!");
        Debug.Log("");
    }
    
    void Reset()
    {
        demoInterval = 5.0f;
        defaultConstructorUsed = 0;
        parameterisedConstructorUsed = 0;
        overloadedConstructorUsed = 0;
    }
}