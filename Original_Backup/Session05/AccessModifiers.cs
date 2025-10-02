using UnityEngine;

/// <summary>
/// Demonstrates access modifiers (public, private, protected) and data encapsulation.
/// Shows the importance of controlling access to class members and data protection.
/// 
/// Learning Goals:
/// - Understand public, private, and protected access modifiers
/// - Learn why data encapsulation is important
/// - See how to safely expose functionality while protecting internal data
/// - Practice proper object-oriented design principles
/// </summary>
public class AccessModifiers : MonoBehaviour
{
    [Header("Access Modifier Demonstration")]
    [Tooltip("Settings for demonstrating access control")]
    public float demonstrationTimer = 4.0f;
    
    [Header("Demo Objects Status")]
    [Tooltip("Track objects created for demonstration")]
    public int secureObjectsCreated = 0;
    public int insecureObjectsCreated = 0;
    
    private float nextDemoTime;
    
    /// <summary>
    /// INSECURE class - everything is public (BAD DESIGN!)
    /// This shows what NOT to do - all data is exposed and can be corrupted
    /// </summary>
    public class InsecureBankAccount
    {
        // BAD: All fields are public - anyone can modify them directly!
        public string accountHolderName;
        public float balance;
        public string accountNumber;
        public string password;
        public bool isActive;
        
        public InsecureBankAccount(string name, float startingBalance, string accNumber, string pass)
        {
            accountHolderName = name;
            balance = startingBalance;
            accountNumber = accNumber;
            password = pass;
            isActive = true;
        }
        
        public void DisplayAccountInfo()
        {
            Debug.Log($"INSECURE Account: {accountHolderName}, Balance: £{balance:F2}, Active: {isActive}");
        }
    }
    
    /// <summary>
    /// SECURE class - proper access modifiers protect important data
    /// This shows GOOD DESIGN with controlled access to sensitive information
    /// </summary>
    public class SecureBankAccount
    {
        // PUBLIC: Information that others need to access
        public string accountHolderName;
        
        // PRIVATE: Critical data that should be protected
        private float balance;
        private string accountNumber;
        private string password;
        private bool isActive;
        private int failedLoginAttempts;
        
        // PRIVATE: Internal validation and security
        private const int MAX_FAILED_ATTEMPTS = 3;
        private const float MIN_BALANCE = 0.0f;
        private const float MAX_DAILY_WITHDRAWAL = 500.0f;
        private float todaysWithdrawals;
        
        // Constructor
        public SecureBankAccount(string name, float startingBalance, string accNumber, string pass)
        {
            accountHolderName = name;
            balance = Mathf.Max(startingBalance, 0);  // Ensure non-negative balance
            accountNumber = accNumber;
            password = pass;
            isActive = true;
            failedLoginAttempts = 0;
            todaysWithdrawals = 0;
        }
        
        // PUBLIC METHODS: Safe ways to interact with private data
        
        /// <summary>
        /// Safely get account balance (read-only access)
        /// </summary>
        public float GetBalance()
        {
            return balance;
        }
        
        /// <summary>
        /// Secure deposit with validation
        /// </summary>
        public bool Deposit(float amount)
        {
            if (!isActive)
            {
                Debug.Log("❌ Account is not active - deposit rejected");
                return false;
            }
            
            if (amount <= 0)
            {
                Debug.Log("❌ Invalid deposit amount - must be positive");
                return false;
            }
            
            balance += amount;
            Debug.Log($"✅ Deposited £{amount:F2}. New balance: £{balance:F2}");
            return true;
        }
        
        /// <summary>
        /// Secure withdrawal with multiple safety checks
        /// </summary>
        public bool Withdraw(float amount, string passwordAttempt)
        {
            // Security check 1: Account must be active
            if (!isActive)
            {
                Debug.Log("❌ Account locked - withdrawal rejected");
                return false;
            }
            
            // Security check 2: Password validation
            if (!ValidatePassword(passwordAttempt))
            {
                return false;  // ValidatePassword handles error messages
            }
            
            // Business logic check 1: Valid amount
            if (amount <= 0)
            {
                Debug.Log("❌ Invalid withdrawal amount");
                return false;
            }
            
            // Business logic check 2: Sufficient funds
            if (amount > balance)
            {
                Debug.Log($"❌ Insufficient funds. Balance: £{balance:F2}, Requested: £{amount:F2}");
                return false;
            }
            
            // Business logic check 3: Daily limit
            if (todaysWithdrawals + amount > MAX_DAILY_WITHDRAWAL)
            {
                float remaining = MAX_DAILY_WITHDRAWAL - todaysWithdrawals;
                Debug.Log($"❌ Daily withdrawal limit exceeded. Remaining: £{remaining:F2}");
                return false;
            }
            
            // All checks passed - process withdrawal
            balance -= amount;
            todaysWithdrawals += amount;
            Debug.Log($"✅ Withdrew £{amount:F2}. New balance: £{balance:F2}, Daily total: £{todaysWithdrawals:F2}");
            return true;
        }
        
        /// <summary>
        /// Get account status without exposing sensitive data
        /// </summary>
        public string GetAccountStatus()
        {
            string status = isActive ? "ACTIVE" : "LOCKED";
            return $"Account: {accountHolderName} [{status}], Balance: £{balance:F2}";
        }
        
        /// <summary>
        /// Allow password change with proper validation
        /// </summary>
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!ValidatePassword(oldPassword))
            {
                return false;
            }
            
            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 4)
            {
                Debug.Log("❌ New password must be at least 4 characters");
                return false;
            }
            
            password = newPassword;
            Debug.Log("✅ Password changed successfully");
            return true;
        }
        
        // PRIVATE METHODS: Internal functionality not exposed to outside code
        
        /// <summary>
        /// Private method to validate passwords securely
        /// </summary>
        private bool ValidatePassword(string passwordAttempt)
        {
            if (passwordAttempt != password)
            {
                failedLoginAttempts++;
                Debug.Log($"❌ Incorrect password. Attempts: {failedLoginAttempts}/{MAX_FAILED_ATTEMPTS}");
                
                if (failedLoginAttempts >= MAX_FAILED_ATTEMPTS)
                {
                    LockAccount();
                }
                
                return false;
            }
            
            // Reset failed attempts on successful login
            failedLoginAttempts = 0;
            return true;
        }
        
        /// <summary>
        /// Private method to handle account locking
        /// </summary>
        private void LockAccount()
        {
            isActive = false;
            Debug.Log("🔒 Account locked due to too many failed password attempts!");
        }
        
        /// <summary>
        /// Private method to reset daily limits (would be called by system at midnight)
        /// </summary>
        private void ResetDailyLimits()
        {
            todaysWithdrawals = 0;
            Debug.Log("🔄 Daily withdrawal limits reset");
        }
        
        // PUBLIC method to manually reset daily limits (for demonstration)
        public void AdminResetDaily()
        {
            ResetDailyLimits();
        }
    }
    
    /// <summary>
    /// Player class demonstrating protected access modifier
    /// Protected members are accessible to derived classes but not external code
    /// </summary>
    public class Player
    {
        // PUBLIC: Information other scripts need
        public string playerName;
        
        // PRIVATE: Internal implementation details
        private int experience;
        private float playTime;
        
        // PROTECTED: Available to this class and derived classes
        protected int level;
        protected float baseHealth;
        protected float currentHealth;
        protected bool isAlive;
        
        public Player(string name)
        {
            playerName = name;
            level = 1;
            baseHealth = 100.0f;
            currentHealth = baseHealth;
            isAlive = true;
            experience = 0;
            playTime = 0;
        }
        
        // PUBLIC methods for external interaction
        public int GetLevel() { return level; }
        public float GetHealth() { return currentHealth; }
        public bool IsAlive() { return isAlive; }
        
        public virtual void TakeDamage(float damage)
        {
            if (!isAlive) return;
            
            currentHealth -= damage;
            Debug.Log($"{playerName} took {damage} damage. Health: {currentHealth:F1}");
            
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        
        // PROTECTED method - available to derived classes
        protected virtual void Die()
        {
            isAlive = false;
            currentHealth = 0;
            Debug.Log($"💀 {playerName} has died at level {level}");
        }
        
        // PROTECTED method - derived classes can override this
        protected virtual void LevelUp()
        {
            level++;
            baseHealth += 20;
            currentHealth = baseHealth;  // Full heal on level up
            Debug.Log($"🎉 {playerName} leveled up to level {level}! Health: {currentHealth}");
        }
        
        // PRIVATE method - only this class can use it
        private void AddExperience(int exp)
        {
            experience += exp;
            int expNeeded = level * 100;
            
            if (experience >= expNeeded)
            {
                experience -= expNeeded;
                LevelUp();
            }
        }
        
        // PUBLIC method that safely uses private method
        public void GainExperience(int exp)
        {
            if (exp > 0 && isAlive)
            {
                AddExperience(exp);
            }
        }
    }
    
    /// <summary>
    /// Warrior class that extends Player - can access protected members
    /// </summary>
    public class Warrior : Player
    {
        // New fields specific to Warrior
        public float armor;
        public int rage;
        
        public Warrior(string name) : base(name)
        {
            armor = 10.0f;
            rage = 0;
            
            // Can access protected members from base class
            baseHealth = 150.0f;  // Warriors have more health
            currentHealth = baseHealth;
        }
        
        // Override the TakeDamage method to include armor
        public override void TakeDamage(float damage)
        {
            if (!isAlive) return;
            
            // Calculate damage reduction from armor
            float actualDamage = damage - (armor * 0.1f);
            actualDamage = Mathf.Max(actualDamage, 1.0f);  // Minimum 1 damage
            
            // Increase rage when taking damage
            rage = Mathf.Min(rage + 5, 100);
            
            // Can access protected fields directly
            currentHealth -= actualDamage;
            Debug.Log($"🛡️ {playerName} (Warrior) took {actualDamage:F1} damage (reduced from {damage}). Health: {currentHealth:F1}, Rage: {rage}");
            
            if (currentHealth <= 0)
            {
                Die();  // Can call protected method
            }
        }
        
        // Override the LevelUp method for warriors
        protected override void LevelUp()
        {
            // Can access and modify protected fields
            level++;
            baseHealth += 30;  // Warriors get more health per level
            currentHealth = baseHealth;
            armor += 2.0f;     // Armor increases with level
            
            Debug.Log($"⚔️ {playerName} (Warrior) reached level {level}! Health: {currentHealth}, Armor: {armor}");
        }
    }
    
    void Start()
    {
        Debug.Log("=== ACCESS MODIFIERS DEMONSTRATION STARTED ===");
        Debug.Log("This demonstrates the importance of proper access control in OOP");
        Debug.Log("Watch how secure vs insecure classes behave differently!");
        Debug.Log("");
        
        DemonstrateInsecureDesign();
        DemonstrateSecureDesign();
        DemonstrateInheritanceAccess();
        
        nextDemoTime = Time.time + demonstrationTimer;
    }
    
    void Update()
    {
        if (Time.time >= nextDemoTime)
        {
            RunRandomSecurityTest();
            nextDemoTime = Time.time + demonstrationTimer;
        }
        
        // Manual demonstrations
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DemonstrateInsecureDesign();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DemonstrateSecureDesign();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DemonstrateInheritanceAccess();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DemonstrateHackingAttempts();
        }
    }
    
    /// <summary>
    /// Shows the problems with making everything public
    /// </summary>
    void DemonstrateInsecureDesign()
    {
        Debug.Log("--- INSECURE DESIGN EXAMPLE (BAD!) ---");
        
        InsecureBankAccount badAccount = new InsecureBankAccount("Alice", 1000.0f, "12345", "secret");
        insecureObjectsCreated++;
        
        Debug.Log("Created insecure bank account:");
        badAccount.DisplayAccountInfo();
        
        Debug.Log("\\nPROBLEM: Anyone can directly modify the data!");
        
        // Direct data manipulation - this should NOT be possible!
        badAccount.balance = -999999.0f;  // Setting negative balance!
        badAccount.password = "hacked";   // Changing password!
        badAccount.isActive = false;      // Deactivating account!
        
        Debug.Log("After malicious direct manipulation:");
        badAccount.DisplayAccountInfo();
        
        Debug.Log("😱 This is why we need access modifiers! Public fields are dangerous!");
        Debug.Log("");
    }
    
    /// <summary>
    /// Shows the benefits of proper encapsulation
    /// </summary>
    void DemonstrateSecureDesign()
    {
        Debug.Log("--- SECURE DESIGN EXAMPLE (GOOD!) ---");
        
        SecureBankAccount goodAccount = new SecureBankAccount("Bob", 1000.0f, "67890", "password123");
        secureObjectsCreated++;
        
        Debug.Log("Created secure bank account:");
        Debug.Log(goodAccount.GetAccountStatus());
        
        Debug.Log("\\nTesting legitimate operations:");
        goodAccount.Deposit(500.0f);
        goodAccount.Withdraw(200.0f, "password123");
        Debug.Log($"Current balance: £{goodAccount.GetBalance():F2}");
        
        Debug.Log("\\nTesting security features:");
        goodAccount.Withdraw(100.0f, "wrongpassword");  // Wrong password
        goodAccount.Withdraw(100.0f, "wrongpassword");  // Wrong password again
        goodAccount.Withdraw(100.0f, "wrongpassword");  // Third wrong password - account locks!
        
        Debug.Log("\\nTrying to access private data directly:");
        Debug.Log("// goodAccount.balance = -999;  // COMPILER ERROR - cannot access private field!");
        Debug.Log("// goodAccount.password = 'hack'; // COMPILER ERROR - cannot access private field!");
        
        Debug.Log("✅ Secure design protects data and enforces business rules!");
        Debug.Log("");
    }
    
    /// <summary>
    /// Demonstrates protected access in inheritance
    /// </summary>
    void DemonstrateInheritanceAccess()
    {
        Debug.Log("--- INHERITANCE AND PROTECTED ACCESS ---");
        
        Player basicPlayer = new Player("Hero");
        Warrior warriorPlayer = new Warrior("Conan");
        
        Debug.Log("Created player characters:");
        Debug.Log($"Basic Player: {basicPlayer.playerName}, Level {basicPlayer.GetLevel()}, Health {basicPlayer.GetHealth()}");
        Debug.Log($"Warrior: {warriorPlayer.playerName}, Level {warriorPlayer.GetLevel()}, Health {warriorPlayer.GetHealth()}");
        
        Debug.Log("\\nTesting damage and inheritance:");
        
        // Both take the same damage, but Warrior has armor
        basicPlayer.TakeDamage(50);
        warriorPlayer.TakeDamage(50);  // Reduced by armor
        
        Debug.Log("\\nGaining experience:");
        basicPlayer.GainExperience(150);  // Should level up
        warriorPlayer.GainExperience(150);  // Should level up with warrior bonuses
        
        Debug.Log("\\nAccess level summary:");
        Debug.Log("- Public members: Accessible everywhere");
        Debug.Log("- Protected members: Accessible in derived classes only");
        Debug.Log("- Private members: Accessible only within the same class");
        Debug.Log("");
    }
    
    /// <summary>
    /// Simulates various hacking attempts to show security benefits
    /// </summary>
    void DemonstrateHackingAttempts()
    {
        Debug.Log("--- SIMULATED HACKING ATTEMPTS ---");
        
        SecureBankAccount targetAccount = new SecureBankAccount("Victim", 5000.0f, "11111", "supersecret");
        
        Debug.Log("Target account created with £5000");
        
        Debug.Log("\\n🔓 Hacking attempt 1: Brute force password");
        string[] commonPasswords = { "password", "123456", "admin", "letmein", "supersecret" };
        
        for (int i = 0; i < commonPasswords.Length; i++)
        {
            Debug.Log($"Trying password: '{commonPasswords[i]}'");
            bool success = targetAccount.Withdraw(1000.0f, commonPasswords[i]);
            
            if (success)
            {
                Debug.Log("💥 Password cracked!");
                break;
            }
        }
        
        Debug.Log("\\n🔓 Hacking attempt 2: Multiple withdrawals");
        SecureBankAccount anotherAccount = new SecureBankAccount("AnotherVictim", 1000.0f, "22222", "correct");
        
        // Try to withdraw more than daily limit
        anotherAccount.Withdraw(300.0f, "correct");
        anotherAccount.Withdraw(300.0f, "correct");  // Should fail - exceeds daily limit
        
        Debug.Log("\\n✅ Security features working correctly!");
        Debug.Log("Private fields and validation methods protect against common attacks");
        Debug.Log("");
    }
    
    /// <summary>
    /// Runs random security tests periodically
    /// </summary>
    void RunRandomSecurityTest()
    {
        Debug.Log("🔄 Auto-Demo: Running security test...");
        
        SecureBankAccount testAccount = new SecureBankAccount("TestUser", Random.Range(100, 1000), "AUTO", "test123");
        secureObjectsCreated++;
        
        // Random operations
        float randomAmount = Random.Range(10, 200);
        bool isDeposit = Random.value > 0.5f;
        
        if (isDeposit)
        {
            testAccount.Deposit(randomAmount);
        }
        else
        {
            // Sometimes use wrong password
            string password = Random.value > 0.3f ? "test123" : "wrongpass";
            testAccount.Withdraw(randomAmount, password);
        }
        
        Debug.Log($"Security objects created: {secureObjectsCreated}, Insecure: {insecureObjectsCreated}");
        Debug.Log("Press 1, 2, 3, or 4 for manual security demonstrations!");
        Debug.Log("");
    }
    
    void Reset()
    {
        demonstrationTimer = 4.0f;
        secureObjectsCreated = 0;
        insecureObjectsCreated = 0;
    }
}