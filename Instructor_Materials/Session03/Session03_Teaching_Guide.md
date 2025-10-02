# Session 3: Loops & Methods

## Session Overview

**Duration**: 75-90 minutes (OPTIMIZED FOR BEGINNERS)
**W3Schools Topics**: While Loop, For Loop, Strings, Methods  
**Unity Concepts**: Repetitive systems, code reusability, performance considerations  

## Learning Objectives

By the end of this session, students will:
1. ✅ Understand and implement for loops for counted repetition
2. ✅ Use while loops for condition-based repetition
3. ✅ Apply essential string manipulation methods for text processing
4. ✅ Create custom methods with parameters and return values
5. ✅ Implement method overloading for flexible functionality
6. ✅ Recognise and prevent infinite loops for safe coding
7. ✅ Apply loops and methods to practical game development scenarios

## Scripts Included

### 1. `ForLoops.cs`
**Purpose**: Comprehensive for loop demonstrations with game applications  
**Key Features**:
- Basic counting loops with clear syntax explanation
- Array iteration with safe bounds checking
- Nested loops for 2D structures (grids, formations)
- Practical game examples (spawning, scoring, inventory)
- Performance considerations and best practices
- Inspector integration for real-time parameter adjustment

### 2. `WhileLoops.cs`
**Purpose**: While loop mastery with safety practices  
**Key Features**:
- Basic while loops with clear termination conditions
- Do-while loops for guarantee-at-least-once execution
- Safety counter patterns to prevent infinite loops
- Combat simulation and turn-based game examples
- Error handling and loop exit strategies
- Real-time monitoring of loop progression

### 3. `StringMethods.cs`
**Purpose**: Complete string manipulation toolkit  
**Key Features**:
- Essential string methods (Length, ToUpper, ToLower, Trim)
- String searching and testing (Contains, StartsWith, EndsWith)
- String modification (Replace, Remove, Insert, Substring)
- Input validation and text processing patterns
- Practical game applications (player names, chat systems)
- Performance tips for string operations

### 4. `CustomMethods.cs`
**Purpose**: Method creation, parameters, and overloading mastery  
**Key Features**:
- Void methods for actions and procedures
- Return methods for calculations and data processing
- Parameter passing with different data types
- Method overloading with multiple signatures
- Game development patterns (damage calculation, utility methods)
- Static vs instance method examples
## Teaching Sequence

### Phase 1: Setup and For Loop Foundation (25 minutes)
**Using `ForLoops.cs`:**

1. **Create Unity Scene Setup**:
   - New scene: `03_Loops_Methods`
   - Create GameObject: "Session03Manager"
   - Attach ForLoops.cs script
   - Show Inspector with organised sections and parameter controls

2. **For Loop Structure Deep Dive**:
   ```csharp
   for (int i = 0; i < 5; i++)
   {
       Debug.Log("Iteration: " + i);
   }
   ```
   **Break down each component**:
   - **`int i = 0`** - Initialiser: where we start
   - **`i < 5`** - Condition: when to stop
   - **`i++`** - Increment: what changes each loop

3. **Practical For Loop Applications**:
   ```csharp
   // Spawn enemies in formation
   for (int enemy = 0; enemy < enemyCount; enemy++)
   {
       Vector3 spawnPos = startPosition + new Vector3(enemy * spacing, 0, 0);
       Debug.Log($"Spawning enemy {enemy} at position {spawnPos}");
   }
   
   // Process array data safely
   for (int i = 0; i < scoreArray.Length; i++)
   {
       totalScore += scoreArray[i];
       Debug.Log($"Added score {scoreArray[i]}, total now: {totalScore}");
   }
   ```

4. **Nested Loops for 2D Structures**:
   ```csharp
   // Create a grid pattern
   for (int row = 0; row < 3; row++)
   {
       for (int col = 0; col < 4; col++)
       {
           Debug.Log($"Grid position: ({row}, {col})");
       }
   }
   ```

5. **Common For Loop Patterns**:
   - Counting up: `i++` or `i += 1`
   - Counting down: `i--` or `i -= 1`
   - Custom increments: `i += 2` (every other)
   - Array bounds safety: always use `array.Length`

### Phase 2: While Loop Mastery and Safety (20 minutes)
**Using `WhileLoops.cs`:**

1. **While Loop Fundamentals**:
   ```csharp
   int health = 100;
   int turn = 0;
   
   while (health > 0 && turn < 10)  // Safety: multiple exit conditions
   {
       health -= Random.Range(5, 15);
       turn++;
       Debug.Log($"Turn {turn}: Health remaining: {health}");
   }
   ```

2. **Do-While Loop Introduction**:
   ```csharp
   int userChoice;
   do
   {
       // Get user input (always runs at least once)
       userChoice = GetPlayerInput();
       Debug.Log("Processing player choice: " + userChoice);
   }
   while (userChoice != 0);  // Continue until player chooses 0 to quit
   ```

3. **Critical Safety Patterns**:
   ```csharp
   // ❌ DANGEROUS - Could loop forever
   while (x > 0)
   {
       // If x never decreases, this never ends!
   }
   
   // ✅ SAFE - Multiple exit conditions
   int safetyCounter = 0;
   while (x > 0 && safetyCounter < 1000)
   {
       x -= someValue;
       safetyCounter++;
       if (safetyCounter >= 1000)
           Debug.LogError("Safety exit: loop ran too long!");
   }
   ```

4. **Game Development Applications**:
   - Combat systems (battle until victory/defeat)
   - Menu navigation (loop until valid selection)
   - Resource gathering (continue until inventory full)
   - Turn-based mechanics (play until game over)

### Phase 3: String Manipulation Mastery (25 minutes)
**Using `StringMethods.cs`:**

1. **Essential String Properties and Methods**:
   ```csharp
   string playerName = "  John_Doe  ";
   
   // Basic properties
   Debug.Log("Length: " + playerName.Length);  // 12 (includes spaces)
   
   // Cleaning and formatting
   string cleanName = playerName.Trim();       // Remove leading/trailing spaces
   cleanName = cleanName.Replace("_", " ");    // Replace underscores with spaces
   cleanName = cleanName.ToLower();            // Convert to lowercase
   
   Debug.Log("Cleaned name: '" + cleanName + "'");  // "john doe"
   ```

2. **String Testing and Searching**:
   ```csharp
   string message = "Player scored 150 points!";
   
   // Testing content
   if (message.Contains("scored"))
       Debug.Log("Message is about scoring");
   
   if (message.StartsWith("Player"))
       Debug.Log("Message is about a player");
   
   if (message.EndsWith("!"))
       Debug.Log("Message is exclamatory");
   ```

3. **Advanced String Operations**:
   ```csharp
   string fullMessage = "Error: Player health is low";
   
   // Extract parts of strings
   string errorType = fullMessage.Substring(0, 5);     // "Error"
   string details = fullMessage.Substring(7);          // "Player health is low"
   
   // Modify strings
   string fixedMessage = fullMessage.Remove(0, 7);     // Remove "Error: "
   string newMessage = fullMessage.Insert(6, "Warning: "); // Insert text
   ```

4. **Practical Game Applications**:
   - Player name validation and cleaning
   - Chat message filtering and processing
   - Save file naming and validation
   - Dynamic text generation for UI
   - Command parsing for console systems


### Phase 4: Custom Method Creation and Mastery (30 minutes)
**Using `CustomMethods.cs`:**

1. **Method Basics - Void Methods (No Return)**:
   ```csharp
   // Simple action method
   public void SayHello()
   {
       Debug.Log("Hello from a custom method!");
   }
   
   // Method with parameters
   public void DisplayPlayerInfo(string name, int level, float health)
   {
       Debug.Log($"Player: {name}, Level: {level}, Health: {health}");
   }
   
   // Calling methods
   SayHello();                                    // No parameters
   DisplayPlayerInfo("Alice", 5, 87.5f);         // With parameters
   ```

2. **Return Methods - Getting Information Back**:
   ```csharp
   // Simple calculation method
   public int AddNumbers(int a, int b)
   {
       return a + b;
   }
   
   // Game calculation method
   public float CalculateDamage(float baseDamage, float multiplier, bool isCritical)
   {
       float damage = baseDamage * multiplier;
       if (isCritical)
           damage *= 2f;  // Double damage for critical hits
       return damage;
   }
   
   // Using return values
   int sum = AddNumbers(10, 15);                           // sum = 25
   float damage = CalculateDamage(50f, 1.5f, true);       // damage = 150f
   ```

3. **Method Overloading - Same Name, Different Parameters**:
   ```csharp
   // Multiple versions of the same method
   public void SpawnEnemy()
   {
       SpawnEnemy(Vector3.zero, "Basic Enemy");  // Default position and type
   }
   
   public void SpawnEnemy(Vector3 position)
   {
       SpawnEnemy(position, "Basic Enemy");      // Default type only
   }
   
   public void SpawnEnemy(Vector3 position, string enemyType)
   {
       Debug.Log($"Spawning {enemyType} at {position}");
       // Actual spawning logic here
   }
   ```

4. **Practical Game Development Patterns**:
   ```csharp
   // Utility methods for common calculations
   public bool IsPlayerInRange(Vector3 playerPos, Vector3 enemyPos, float range)
   {
       float distance = Vector3.Distance(playerPos, enemyPos);
       return distance <= range;
   }
   
   // Validation methods
   public bool IsValidPlayerName(string name)
   {
       if (string.IsNullOrEmpty(name))
           return false;
       if (name.Length < 3 || name.Length > 20)
           return false;
       return true;
   }
   
   // Game state methods
   public string GetHealthStatus(float health, float maxHealth)
   {
       float percentage = (health / maxHealth) * 100f;
       
       if (percentage > 75f)
           return "Excellent";
       else if (percentage > 50f)
           return "Good";
       else if (percentage > 25f)
           return "Warning";
       else
           return "Critical";
   }
   ```

5. **Method Organisation and Best Practices**:
   - **Naming**: Use clear, descriptive names (`CalculateDamage` not `CalcDmg`)
   - **Single purpose**: Each method should do one thing well
   - **Parameter order**: Most important parameters first
   - **Return types**: Use appropriate return types (bool for yes/no, float for calculations)
   - **Documentation**: Add comments explaining what the method does

### Phase 5: Integration and Hands-On Practice (15 minutes)

1. **Combining All Concepts**:
   ```csharp
   // Method that uses loops and strings together
   public string CreateScoresList(int[] scores)
   {
       string result = "High Scores:\n";
       
       for (int i = 0; i < scores.Length; i++)
       {
           result += $"{i + 1}. {scores[i]} points\n";
       }
       
       return result;
   }
   
   // Method that uses while loops for game logic
   public bool ProcessCombat(float playerHealth, float enemyHealth)
   {
       int turn = 0;
       
       while (playerHealth > 0 && enemyHealth > 0 && turn < 100)
       {
           // Player attacks
           enemyHealth -= CalculateDamage(25f, 1.0f, false);
           turn++;
           
           if (enemyHealth <= 0)
               return true;  // Player wins
           
           // Enemy attacks
           playerHealth -= CalculateDamage(20f, 1.0f, false);
           turn++;
       }
       
       return false;  // Player loses or draw
   }
   ```

2. **Real-World Game System Example**:
   ```csharp
   // Complete inventory system using all concepts
   public void ProcessInventory(string[] items)
   {
       Debug.Log("=== INVENTORY PROCESSING ===");
       
       // Use for loop to process each item
       for (int i = 0; i < items.Length; i++)
       {
           string cleanItem = CleanItemName(items[i]);  // String method
           
           if (IsValidItem(cleanItem))  // Custom validation method
           {
               AddToInventory(cleanItem);  // Custom action method
           }
       }
       
       DisplayInventorySummary();  // Custom display method
   }
   ```


### Phase 6: Student Exercise Completion (20 minutes)

**Student Challenges using `Session03_StudentExercise.cs`:**

1. **Loop Mastery Challenges**:
   - Create for loops to generate game data (scores, spawn patterns)
   - Implement while loops for menu systems and combat simulation
   - Use nested loops for grid-based systems

2. **String Processing Tasks**:
   - Clean and validate player input data
   - Create dynamic game messages using string methods
   - Implement text-based search and filter systems

3. **Custom Method Creation**:
   - Write utility methods for common game calculations
   - Create overloaded methods for flexible functionality
   - Implement validation and processing methods

## Common Student Questions & Answers

**Q: What's the difference between for loops and while loops?**  
A: Use **for loops** when you know exactly how many times to repeat (like processing an array). Use **while loops** when you repeat until a condition changes (like "continue until player dies").

**Q: Why does my while loop never stop running?**  
A: This is an "infinite loop"! Make sure something INSIDE the loop changes the condition. Always include a safety counter to prevent freezing Unity.

**Q: Can I call one method from inside another method?**  
A: Absolutely! This is called "method composition" and is very powerful. One method can call many other methods to break complex tasks into smaller pieces.

**Q: What's the difference between parameters and return values?**  
A: **Parameters** are information you GIVE to a method (inputs). **Return values** are information the method GIVES BACK to you (outputs).

**Q: Why use method overloading instead of different method names?**  
A: Overloading makes your code easier to read and remember. Instead of `SpawnBasicEnemy()`, `SpawnEliteEnemy()`, `SpawnBossEnemy()`, you just use `SpawnEnemy()` with different parameters.

**Q: When should I use string methods like ToUpper() and ToLower()?**  
A: For consistency! Player might type "JOHN", "john", or "John" - using `.ToLower()` makes them all "john" for comparison.

**Q: How do I know if my loop will be infinite?**  
A: Ask yourself: "What inside this loop changes the condition?" If nothing changes the condition, or if it changes in the wrong direction, you'll have an infinite loop.

**Q: Can methods have the same name?**  
A: Yes, if they have different parameters (different number or types). This is called overloading: `AddNumbers(int, int)` and `AddNumbers(float, float, float)` are different methods.

## Assessment Checkpoints

### Knowledge Check (Throughout Session):
- [ ] Can identify when to use for loops vs while loops
- [ ] Understands loop structure (initialiser, condition, increment)
- [ ] Recognises infinite loop dangers and prevention strategies
- [ ] Can use essential string methods for text processing
- [ ] Understands method structure (parameters, return types)
- [ ] Knows difference between void methods and return methods

### Practical Check (End of Session):
- [ ] Successfully implements for loops for repetitive tasks
- [ ] Creates safe while loops with proper exit conditions
- [ ] Uses string methods to process and validate text
- [ ] Writes custom methods with parameters and return values
- [ ] Demonstrates method overloading with multiple signatures
- [ ] Combines loops, strings, and methods in game scenarios

### Technical Skills Check:
- [ ] Writes for loops with proper syntax and bounds checking
- [ ] Implements while loops with safety counters
- [ ] Uses string methods to create dynamic text processing
- [ ] Creates methods that accept parameters and return appropriate values
- [ ] Organises code using methods for reusability and clarity
- [ ] Demonstrates understanding of method calling and composition

### Code Quality Check:
- [ ] Uses descriptive method names and parameter names
- [ ] Includes appropriate comments explaining method purposes
- [ ] Implements proper error checking in methods
- [ ] Creates methods that do one thing well (single responsibility)
- [ ] Uses appropriate data types for parameters and return values


## Extension Activities

For students who finish early:

1. **Advanced Loop Patterns**:
   - Create loops that count backwards or skip numbers
   - Implement break and continue statements for loop control
   - Build 2D grid systems using nested loops

2. **String Algorithm Challenges**:
   - Create a simple encryption/decryption system using string methods
   - Build a word-counting system for text analysis
   - Implement a basic text-based search engine

3. **Method Design Challenges**:
   - Create a complete damage calculation system with multiple factors
   - Build a text-based adventure game using only methods
   - Design a modular scoring system with different calculation methods

4. **Performance Optimisation**:
   - Compare for loops vs foreach loops for different scenarios
   - Learn about StringBuilder for efficient string building
   - Explore method caching for expensive calculations

5. **Integration Projects**:
   - Build a complete inventory system using all session concepts
   - Create a turn-based combat system with methods and loops
   - Design a text-based menu system with input validation

## Troubleshooting Common Issues

### **Loop-Related Errors**

**Error: Unity freezes when pressing Play**  
→ **Cause**: Infinite loop detected  
→ **Solution**: Check all while loops have proper exit conditions and safety counters
```csharp
// Add safety counter to prevent infinite loops
int safety = 0;
while (condition && safety < 1000)
{
    // Your loop code here
    safety++;
}
```

**Error: "Index was outside the bounds of the array"**  
→ **Cause**: For loop goes beyond array length  
→ **Solution**: Always use `array.Length` in condition, never hard-coded numbers
```csharp
// ✅ CORRECT
for (int i = 0; i < myArray.Length; i++)

// ❌ WRONG  
for (int i = 0; i <= myArray.Length; i++)  // <= causes index error
```

**Warning: Loop runs too many times**  
→ **Check increment/decrement**: Make sure loop variable actually changes
→ **Verify condition**: Ensure condition can actually become false

### **String Method Errors**

**Error: "Object reference not set to an instance of an object"**  
→ **Cause**: Trying to use string methods on null string  
→ **Solution**: Check for null before using string methods
```csharp
if (!string.IsNullOrEmpty(playerName))
{
    string cleanName = playerName.ToLower();
}
```

**Error: "ArgumentOutOfRangeException"**  
→ **Cause**: Substring index beyond string length  
→ **Solution**: Check string length before using Substring
```csharp
if (text.Length > 5)
{
    string part = text.Substring(0, 5);
}
```

### **Method-Related Errors**

**Error: "A method with this name already exists"**  
→ **Cause**: Duplicate method names without proper overloading  
→ **Solution**: Either change method name or add different parameters for overloading

**Error: "Not all code paths return a value"**  
→ **Cause**: Return method missing return statement in some conditions  
→ **Solution**: Ensure all possible code paths have return statements
```csharp
public int GetPlayerLevel(int experience)
{
    if (experience > 1000)
        return 10;
    else if (experience > 500)
        return 5;
    // ❌ Missing return for other cases
    
    return 1;  // ✅ Default return value
}
```

**Error: "Cannot convert 'void' to 'int'"**  
→ **Cause**: Trying to assign result of void method to variable  
→ **Solution**: Change method to return appropriate type or don't assign result

### **General Compilation Issues**

**Variables not accessible between methods**  
→ **Use class-level variables** (fields) for data shared between methods
→ **Pass data as parameters** between methods

**Methods not appearing in IntelliSense**  
→ **Check method access level**: Use `public` for methods you want to call
→ **Verify method is in same class** or use proper object reference


## Unity/Visual Studio Code Integration Notes

### **Session 3 Specific Workflow**

1. **Testing Loops Safely**:
   - **Always save before testing loops** - infinite loops require Unity restart
   - **Use Debug.Log extensively** - see loop progression in Console
   - **Test with small numbers first** - verify loop logic before scaling up
   - **Watch performance** - loops with many iterations can slow Unity

2. **Method Development Process**:
   - **Write method signature first**: `public int MethodName(parameters)`
   - **Add method body with return statement**: Basic structure before logic
   - **Test with simple values**: Verify method calling works
   - **Add complexity gradually**: Build up method functionality step by step

3. **String Method Testing**:
   - **Use immediate mode**: Test string operations in Start() method first
   - **Debug.Log results**: Always output string operations to see results
   - **Test edge cases**: Empty strings, null values, very long strings
   - **Watch for performance**: String operations can be expensive in loops

### **Visual Studio Code Session 3 Tips**:

1. **Loop Code Folding**:
   - **Collapse loops**: Use code folding to manage complex nested loops
   - **Method navigation**: Use Ctrl+Shift+O to jump between methods quickly
   - **Bracket matching**: Click on loop braces to see matching pairs

2. **Method IntelliSense**:
   - **Parameter hints**: VS Code shows method parameters as you type
   - **Return type checking**: Red squiggles appear if return types don't match
   - **Method suggestions**: Auto-complete suggests available methods

3. **Debugging Session 3 Concepts**:
   - **Breakpoints in loops**: Set breakpoints to watch loop variables change
   - **Step through methods**: Use F10 to step through method calls
   - **Watch variables**: Monitor loop counters and string values in real-time

## Next Session Preview

Session 4 will cover:
- **Arrays and Lists**: Store and manage collections of data
- **Unity Transform system**: Move and manipulate game objects
- **2D Movement patterns**: Create player and NPC movement systems
- **Advanced collection operations**: Search, sort, and process data efficiently

The methods students learn in Session 3 will be essential for Session 4's collection processing and movement systems!

---

## Files in This Session
- `ForLoops.cs` - For loop demonstrations with game applications
- `WhileLoops.cs` - While loop examples with safety practices
- `StringMethods.cs` - Complete string manipulation toolkit
- `CustomMethods.cs` - Method creation, parameters, and overloading
- `Session03_StudentExercise.cs` - Comprehensive student practice
- `Session03_Teaching_Guide.md` - This instructor guide

**Unity Scene**: `03_Loops_Methods.unity`  
**Estimated Total Teaching Time**: 90-120 minutes  
**Prerequisites**: Sessions 1-2 (Variables, operators, conditional logic)

---

## Teaching Tips for Success

### **Critical Session 3 Concepts to Emphasise**

1. **Loop Safety First**:
   - **Always demonstrate infinite loop danger** - show Unity freezing, explain recovery
   - **Teach safety counter pattern early** - make it a habit from first while loop
   - **Explain when Unity might freeze** - help students recognise warning signs

2. **Method Thinking**:
   - **Start with simple examples** - void methods with no parameters first
   - **Build complexity gradually** - parameters, then return values, then overloading
   - **Emphasise reusability** - show how methods reduce code duplication

3. **String Method Mastery**:
   - **Demonstrate common patterns** - cleaning user input, text validation
   - **Show practical applications** - how strings are used in real games
   - **Teach defensive programming** - always check for null/empty strings

### **Pacing Recommendations**

- **Spend extra time on method creation** - this is often the most challenging concept
- **Practice loop safety extensively** - infinite loops can be discouraging for beginners
- **Use Interactive examples** - let students modify loops and methods in real-time
- **Check understanding frequently** - concepts build on each other rapidly in this session

### **Student Engagement Strategies**

1. **Interactive Loop Challenges**:
   - "Can you make this loop count backwards?"
   - "What happens if we change the condition?"
   - "How would you make this loop safer?"

2. **Method Building Games**:
   - Start with simple method, have students add features
   - "What parameters would make this method more flexible?"
   - "How could we make this method return useful information?"

3. **String Processing Contests**:
   - "Who can clean this messy user input fastest?"
   - "Create the most creative text processing method"
   - "Build a simple text-based game using only string methods"

### **Common Teaching Moments**

- **When students write infinite loops**: Use as learning opportunity, not failure
- **When methods don't work**: Walk through parameter passing step-by-step
- **When string operations fail**: Demonstrate null checking and validation
- **When loops are confusing**: Draw the loop execution on whiteboard/screen

### **Assessment Focus Points**

- **Loop comprehension**: Can student predict what a loop will do?
- **Method design**: Does student choose appropriate parameters and return types?
- **Code organization**: Are methods used to reduce repetition and improve clarity?
- **Safety awareness**: Does student consider edge cases and potential problems?

This session establishes the foundation for all advanced programming concepts. Ensure students are comfortable with these concepts before moving to Session 4!

