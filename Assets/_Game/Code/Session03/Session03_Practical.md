# CRE132 Session 3: Loops & Methods Practical

## 🎯 **Learning Objectives**
By the end of this practical, you will understand:
- For loops and while loops for repetitive tasks
- String manipulation and text processing
- Creating custom methods with parameters and return types
- Method overloading and practical applications
- How loops are essential in game development
- Performance considerations with loops

---

## 📚 **Key Concepts to Learn**

### **For Loops**
Perfect for when you know exactly how many times you want to repeat something:
```csharp
for (int i = 0; i < 10; i++)
{
    Debug.Log("Loop iteration: " + i);
}
```
- **`int i = 0`** - Starting value (initialiser)
- **`i < 10`** - Continue while this is true (condition)
- **`i++`** - What happens after each loop (increment)

### **While Loops**
Perfect for repeating until a condition becomes false:
```csharp
int health = 100;
while (health > 0)
{
    health -= 10;
    Debug.Log("Health remaining: " + health);
}
```

### **String Methods**
Powerful tools for working with text:
- **`.Length`** - Get text length: `"Hello".Length` (result: 5)
- **`.ToUpper()`** - Make uppercase: `"hello".ToUpper()` (result: "HELLO")
- **`.ToLower()`** - Make lowercase: `"HELLO".ToLower()` (result: "hello")
- **`.Contains()`** - Check if contains text: `"Hello World".Contains("World")` (result: true)
- **`.Substring()`** - Get part of text: `"Hello".Substring(1, 3)` (result: "ell")

### **Creating Custom Methods**
Methods are reusable blocks of code:
```csharp
// Method with no parameters, no return value
public void SayHello()
{
    Debug.Log("Hello World!");
}

// Method with parameters and return value
public int AddNumbers(int a, int b)
{
    return a + b;
}

// Method with multiple parameters
public void DealDamage(string enemyName, int damage, bool isCritical)
{
    Debug.Log(enemyName + " takes " + damage + " damage!");
}
```

### **Method Return Types**
- **`void`** - Returns nothing
- **`int`** - Returns whole number
- **`float`** - Returns decimal number
- **`string`** - Returns text
- **`bool`** - Returns true/false

---

## 🛠️ **Unity Setup Instructions**

### **Step 1: Create GameObject**
1. Right-click in **Hierarchy** → **Create Empty**
2. Rename to `"Session03_LoopsAndMethods"`

### **Step 2: Add Scripts**
1. Select your GameObject
2. **Add Component** → **New Script**
3. Create these scripts one by one:
   - `ForLoops.cs`
   - `WhileLoops.cs`
   - `StringMethods.cs`
   - `CustomMethods.cs`
   - `Session03_StudentExercise.cs`

### **Step 3: Test Each Script**
1. Attach script to GameObject
2. Press **Play**
3. Check **Console** window (`Window > General > Console`)
4. Observe the output and Inspector changes

---

## 🎮 **Practical Examples**

### **Example 1: Spawning Enemies with For Loops**
```csharp
for (int i = 0; i < 5; i++)
{
    Debug.Log("Spawning enemy #" + (i + 1) + " at position: " + (i * 2));
}
```

### **Example 2: Player Health System with While Loop**
```csharp
int playerHealth = 100;
int turnCounter = 1;

while (playerHealth > 0 && turnCounter <= 10)
{
    int damage = Random.Range(5, 20);
    playerHealth -= damage;
    Debug.Log("Turn " + turnCounter + ": Player takes " + damage + " damage. Health: " + playerHealth);
    turnCounter++;
}
```

### **Example 3: Processing Player Names**
```csharp
string playerName = "  JOHN_DOE  ";
string cleanName = playerName.Trim().ToLower().Replace("_", " ");
Debug.Log("Clean name: " + cleanName); // Result: "john doe"
```

### **Example 4: Damage Calculation Method**
```csharp
public float CalculateDamage(float baseDamage, float weaponMultiplier, bool isCriticalHit)
{
    float totalDamage = baseDamage * weaponMultiplier;
    
    if (isCriticalHit)
    {
        totalDamage *= 2f;
        Debug.Log("CRITICAL HIT!");
    }
    
    return totalDamage;
}
```

---

## 🔧 **Visual Studio Code Instructions**

### **Working with Methods**
1. **Method Signature**: The first line defining name, parameters, and return type
2. **Method Body**: Code between the curly braces `{ }`
3. **IntelliSense**: VS Code will show available methods as you type
4. **Parameter Hints**: Hover over method calls to see what parameters are needed

### **String Operations**
1. Use **string interpolation**: `$"Player {playerName} has {health} health"`
2. **Escape characters**: `\n` for new line, `\"` for quotes in strings
3. **Null checking**: Always check if strings exist before using methods

---

## 🚨 **Common Errors & Solutions**

### **Infinite Loops**
**Problem**: While loop never ends
```csharp
// BAD - i never changes!
int i = 0;
while (i < 10)
{
    Debug.Log("This will run forever!");
}
```
**Solution**: Always modify the condition variable
```csharp
// GOOD - i increases each loop
int i = 0;
while (i < 10)
{
    Debug.Log("Loop: " + i);
    i++; // Don't forget this!
}
```

### **Off-by-One Errors**
**Problem**: Loop runs one time too many or too few
```csharp
// Runs 11 times (0,1,2,3,4,5,6,7,8,9,10)
for (int i = 0; i <= 10; i++)

// Runs 10 times (0,1,2,3,4,5,6,7,8,9) - Usually what you want
for (int i = 0; i < 10; i++)
```

### **Method Not Returning Value**
**Problem**: Method says it returns something but doesn't
```csharp
public int AddNumbers(int a, int b)
{
    int result = a + b;
    // ERROR: Missing return statement!
}
```
**Solution**: Always return the correct type
```csharp
public int AddNumbers(int a, int b)
{
    int result = a + b;
    return result; // Don't forget this!
}
```

### **String Method Errors**
**Problem**: Calling methods on null or empty strings
```csharp
string playerName = null;
int length = playerName.Length; // ERROR: NullReferenceException
```
**Solution**: Check for null/empty first
```csharp
if (!string.IsNullOrEmpty(playerName))
{
    int length = playerName.Length;
}
```

---

## 🎯 **Testing Your Code**

### **Console Output Checklist**
- [ ] For loops show iteration numbers
- [ ] While loops show condition changes
- [ ] String methods show before/after text
- [ ] Custom methods show parameters and return values
- [ ] No infinite loops (Unity doesn't freeze)

### **Inspector Verification**
- [ ] Public variables update in real-time
- [ ] String results display correctly
- [ ] Number calculations show expected results
- [ ] Arrays/lists populated correctly

---

---


## 🏆 **Best Practices**

### **Loop Guidelines**
1. **Avoid infinite loops** - Always modify your condition variable
2. **Use descriptive variable names** - `i` is fine for simple loops, `enemyIndex` is better for complex ones
3. **Consider performance** - Avoid heavy calculations inside loops
4. **Break out early** - Use `break` to exit loops when condition is met

### **Method Guidelines**
1. **Single responsibility** - Each method should do one thing well
2. **Meaningful names** - `CalculateDamage()` not `DoStuff()`
3. **Parameter order** - Most important parameters first
4. **Return consistently** - Always return the same type

### **String Guidelines**
1. **Use string interpolation** - `$"Health: {health}"` instead of `"Health: " + health`
2. **Check for null/empty** - Prevent crashes with validation
3. **Consider performance** - String operations can be expensive in loops

---

## 🎮 **Game Development Applications**

### **Loops in Games**
- **Spawning items**: Create multiple pickups, enemies, or obstacles
- **Animation frames**: Cycle through sprite animations
- **Turn-based systems**: Process each player's turn
- **Level generation**: Create procedural content
- **UI updates**: Refresh multiple interface elements

### **Methods in Games**
- **Damage systems**: `DealDamage(target, amount, type)`
- **Movement**: `MovePlayer(direction, speed)`
- **Scoring**: `CalculateScore(basePoints, multiplier, bonus)`
- **Audio**: `PlaySound(soundName, volume, pitch)`
- **Save/Load**: `SavePlayerData(playerProfile)`

---

## 🔜 **Next Steps**

After completing this session, you'll be ready for **Session 04: Collections & Movement**, where you'll learn:
- Arrays and Lists for storing multiple values
- Unity's Transform system for object positioning
- Moving GameObjects through code
- Creating collections of game objects

---

## 💡 **Practice Challenges**

### **Beginner Challenges**
1. Create a for loop that counts from 10 down to 1
2. Make a method that takes two numbers and returns the larger one
3. Create a string that combines first name and last name with a space

### **Intermediate Challenges**
1. Write a while loop that simulates rolling dice until you get a 6
2. Create a method that checks if a string contains only letters
3. Make a for loop that creates a multiplication table

### **Advanced Challenges**
1. Create a method that generates a random password with specific criteria
2. Write nested loops to create a simple grid pattern in the console
3. Combine string methods to create a text-based word game helper

---

*Remember: Programming is about practice! Don't just read the code - type it out, modify it, and experiment with it.*

**🎉 Ready to start coding? Open Unity and create your first script!**