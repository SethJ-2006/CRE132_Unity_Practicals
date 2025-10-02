# CRE132 Session 2: Operators & Control Flow Practical

## 🎯 **Learning Objectives**
By the end of this practical, you will understand:
- Mathematical operators and how to use them in calculations
- Comparison operators for making decisions
- Logical operators for combining conditions
- How to get keyboard and mouse input in Unity
- If/else statements for conditional logic
- Boolean variables and logic

---

## 📚 **Key Concepts to Learn**

### **Mathematical Operators**
- **`+`** - Addition: `int sum = 5 + 3;` (result: 8)
- **`-`** - Subtraction: `int difference = 10 - 4;` (result: 6)
- **`*`** - Multiplication: `int product = 6 * 7;` (result: 42)
- **`/`** - Division: `float quotient = 10f / 3f;` (result: 3.333...)
- **`%`** - Modulo (remainder): `int remainder = 10 % 3;` (result: 1)

### **Assignment Operators**
- **`=`** - Assign: `playerScore = 100;`
- **`+=`** - Add and assign: `playerScore += 50;` (same as: `playerScore = playerScore + 50;`)
- **`-=`** - Subtract and assign: `playerHealth -= 10;`
- **`*=`** - Multiply and assign: `damage *= 2;`
- **`/=`** - Divide and assign: `speed /= 2;`

### **Comparison Operators**
- **`==`** - Equal to: `if (playerScore == 100)`
- **`!=`** - Not equal to: `if (playerHealth != 0)`
- **`>`** - Greater than: `if (playerLevel > 5)`
- **`<`** - Less than: `if (ammo < 10)`
- **`>=`** - Greater than or equal: `if (playerScore >= 1000)`
- **`<=`** - Less than or equal: `if (playerHealth <= 25)`

### **Logical Operators**
- **`&&`** - AND: `if (hasKey && doorIsLocked)` (both must be true)
- **`||`** - OR: `if (playerDead || gameOver)` (at least one must be true)
- **`!`** - NOT: `if (!isGamePaused)` (opposite/reverse the boolean)

### **Unity Input System**
- **`Input.GetKeyDown(KeyCode.Space)`** - Detects when Space key is pressed once
- **`Input.GetKey(KeyCode.W)`** - Detects when W key is held down
- **`Input.GetKeyUp(KeyCode.Space)`** - Detects when Space key is released
- **`Input.GetMouseButtonDown(0)`** - Detects left mouse click (0=left, 1=right, 2=middle)
- **`Input.mousePosition`** - Gets current mouse position on screen

### **If/Else Statements**
```csharp
// Simple if statement
if (playerHealth > 0)
{
    Debug.Log("Player is alive!");
}

// If-else statement
if (playerScore >= 100)
{
    Debug.Log("High score achieved!");
}
else
{
    Debug.Log("Keep trying!");
}

// If-else if-else chain
if (playerHealth > 75)
{
    Debug.Log("Health: Excellent");
}
else if (playerHealth > 50)
{
    Debug.Log("Health: Good");
}
else if (playerHealth > 25)
{
    Debug.Log("Health: Warning");
}
else
{
    Debug.Log("Health: Critical!");
}
```

---

## 🛠️ **Practical Instructions**

### **Step 1: Examine the Example Scripts**
1. Open Unity and load the CRE132 project
2. Navigate to: `Assets/_Game/Code/Session02/`
3. Look at these demonstration scripts:
   - **`MathOperators.cs`** - Shows all mathematical operations
   - **`InputDetection.cs`** - Demonstrates keyboard and mouse input
   - **`ConditionalLogic.cs`** - Shows if/else statements in action

### **Step 2: Set Up Your Scene**
1. Create a new scene: `File > New Scene`
2. Save it as: `02_Operators_Control_Flow` in `Assets/_Game/Scenes/`
3. Create an empty GameObject: `GameObject > Create Empty`
4. Rename it to: `Session02Manager`
5. Attach the demonstration scripts to this GameObject

### **Step 3: Test the Example Scripts**
1. **Press Play** to run the scene
2. **Open the Console** window: `Window > General > Console`
3. **Try different inputs**:
   - Press **Space bar** for jump actions
   - Press **W, A, S, D** keys for movement
   - **Click** the mouse buttons
   - Watch the Console for responses
4. **Observe the mathematical calculations** running in real-time

### **Step 4: Explore the Inspector Variables**
1. **Select your GameObject** with the scripts
2. **Look at the Inspector** - you'll see public variables you can modify
3. **Try changing values** while the game is running (Play mode)
4. **See how your changes affect** the calculations and logic

### **Step 5: Complete the Student Exercise**

#### **5.1: Open the Exercise Script** 
1. **In Unity**, navigate to `Assets/_Game/Code/Session02/`
2. **Double-click** on `Session02_StudentExercise.cs`
3. **This opens Visual Studio Code** with the exercise template

#### **5.2: Complete the Variable Declarations**
**Find the TODO sections for variables**, such as:
```csharp
// TODO: Create public variables for a simple calculator
// - firstNumber (float)
// - secondNumber (float)  
// - operation (string) - for storing "+", "-", "*", "/"
```

**Replace with actual code:**
```csharp
[Header("=== CALCULATOR VARIABLES ===")]
public float firstNumber = 10f;
public float secondNumber = 5f;
public string operation = "+";  // Can be "+", "-", "*", "/"
```

#### **5.3: Complete the Mathematical Methods**
**Find method TODOs like:**
```csharp
void PerformCalculation()
{
    // TODO: Create if/else statements to perform different operations
    // Use the 'operation' variable to determine what calculation to do
    // Display the result using Debug.Log()
}
```

**Complete with conditional logic:**
```csharp
void PerformCalculation()
{
    float result = 0f;
    
    if (operation == "+")
    {
        result = firstNumber + secondNumber;
        Debug.Log($"{firstNumber} + {secondNumber} = {result}");
    }
    else if (operation == "-")
    {
        result = firstNumber - secondNumber;
        Debug.Log($"{firstNumber} - {secondNumber} = {result}");
    }
    else if (operation == "*")
    {
        result = firstNumber * secondNumber;
        Debug.Log($"{firstNumber} * {secondNumber} = {result}");
    }
    else if (operation == "/")
    {
        if (secondNumber != 0) // Check for division by zero!
        {
            result = firstNumber / secondNumber;
            Debug.Log($"{firstNumber} / {secondNumber} = {result}");
        }
        else
        {
            Debug.Log("Error: Cannot divide by zero!");
        }
    }
    else
    {
        Debug.Log("Error: Unknown operation " + operation);
    }
}
```

#### **5.4: Complete the Input Detection Methods**
**Find input-related TODOs:**
```csharp
void CheckPlayerInput()
{
    // TODO: Check for Space key press and display a message
    // TODO: Check for WASD keys and display movement messages
    // TODO: Check for mouse clicks
}
```

**Complete with input detection:**
```csharp
void CheckPlayerInput()
{
    // Check for Space key press (jumping)
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Player jumped!");
    }
    
    // Check for movement keys (held down)
    if (Input.GetKey(KeyCode.W))
    {
        Debug.Log("Moving forward...");
    }
    if (Input.GetKey(KeyCode.A))
    {
        Debug.Log("Moving left...");
    }
    if (Input.GetKey(KeyCode.S))
    {
        Debug.Log("Moving backward...");
    }
    if (Input.GetKey(KeyCode.D))
    {
        Debug.Log("Moving right...");
    }
    
    // Check for mouse clicks
    if (Input.GetMouseButtonDown(0)) // Left click
    {
        Debug.Log("Left mouse clicked at: " + Input.mousePosition);
    }
    if (Input.GetMouseButtonDown(1)) // Right click
    {
        Debug.Log("Right mouse clicked!");
    }
}
```

#### **5.5: Save and Test Your Code**
1. **Save the file**: `Ctrl+S` (Windows) or `Cmd+S` (Mac)
2. **Return to Unity** 
3. **Create a new GameObject** called `StudentExercise`
4. **Attach your completed script** to this GameObject
5. **Press Play** and test your calculator and input detection
6. **Modify the variables** in the Inspector to test different calculations

---

## 💻 **Working with Conditional Logic**

### **Understanding If Statements**
```csharp
// Basic structure
if (condition)
{
    // Code runs if condition is true
}

// Real example
if (playerHealth > 0)
{
    Debug.Log("Player is alive");
}
```

### **Common Condition Examples**
```csharp
// Checking numbers
if (playerScore >= 1000)       // Score is 1000 or higher
if (playerLevel < 10)          // Level is less than 10
if (ammunition == 0)           // Ammunition is exactly 0

// Checking strings
if (playerName == "Hero")      // Name is exactly "Hero"
if (difficulty != "Easy")      // Difficulty is not "Easy"

// Checking booleans
if (isGameOver)                // Same as: if (isGameOver == true)
if (!isGamePaused)             // Same as: if (isGamePaused == false)
```

### **Combining Conditions**
```csharp
// AND - both conditions must be true
if (hasKey && doorIsLocked)
{
    Debug.Log("Opening the door!");
}

// OR - at least one condition must be true  
if (playerHealth <= 0 || gameTimeUp)
{
    Debug.Log("Game Over!");
}

// Complex combinations
if ((playerLevel > 5 && hasWeapon) || isGodMode)
{
    Debug.Log("Player can enter boss area!");
}
```

---

## 🎮 **Unity Input System Guide**

### **Keyboard Input**
```csharp
// In Update() method for continuous checking
void Update()
{
    // Single key press (once when pressed)
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Space pressed!");
    }
    
    // Key held down (continuous while held)
    if (Input.GetKey(KeyCode.W))
    {
        Debug.Log("W is being held down");
    }
    
    // Key released (once when released)
    if (Input.GetKeyUp(KeyCode.Space))
    {
        Debug.Log("Space released!");
    }
}
```

### **Common KeyCodes**
- **Letters**: `KeyCode.A`, `KeyCode.B`, `KeyCode.W`, etc.
- **Numbers**: `KeyCode.Alpha1`, `KeyCode.Alpha2`, etc.
- **Arrows**: `KeyCode.UpArrow`, `KeyCode.DownArrow`, etc.
- **Special**: `KeyCode.Space`, `KeyCode.Return`, `KeyCode.Escape`

### **Mouse Input**
```csharp
void Update()
{
    // Mouse button clicks
    if (Input.GetMouseButtonDown(0))    // Left click
    {
        Vector3 mousePos = Input.mousePosition;
        Debug.Log("Left clicked at: " + mousePos);
    }
    
    if (Input.GetMouseButtonDown(1))    // Right click
    {
        Debug.Log("Right clicked!");
    }
    
    if (Input.GetMouseButtonDown(2))    // Middle click
    {
        Debug.Log("Middle mouse clicked!");
    }
}
```

---

## ✅ **Exercise Checklist**

Make sure you can do all of these:

### **Mathematical Operations**
- [ ] I can use +, -, *, / operators for calculations
- [ ] I understand the modulo (%) operator
- [ ] I can use +=, -=, *=, /= assignment operators
- [ ] I can check for division by zero before dividing

### **Comparison and Logic**
- [ ] I can use ==, !=, >, <, >=, <= for comparisons
- [ ] I understand the difference between = (assign) and == (compare)
- [ ] I can use && (AND), || (OR), ! (NOT) logical operators
- [ ] I can combine multiple conditions in one if statement

### **Control Flow**
- [ ] I can write simple if statements
- [ ] I can write if-else statements  
- [ ] I can write if-else if-else chains
- [ ] I can nest if statements inside other if statements

### **Input Detection**
- [ ] I can detect single key presses with GetKeyDown()
- [ ] I can detect held keys with GetKey()
- [ ] I can detect key releases with GetKeyUp()
- [ ] I can detect mouse clicks with GetMouseButtonDown()
- [ ] I can get the mouse position with Input.mousePosition

### **Coding Tasks (Student Exercise)**
- [ ] I completed the calculator variables section
- [ ] I implemented the PerformCalculation() method with if/else logic
- [ ] I added division by zero checking
- [ ] I completed the CheckPlayerInput() method
- [ ] I tested different operations by changing the Inspector variables
- [ ] I tested the input detection by pressing keys and clicking
- [ ] My code compiles without errors

---

## 🔧 **Common Issues and Solutions**

### **Logical Operator Confusion**
**Problem**: Mixing up = and ==
```csharp
// ❌ Wrong - assigns value instead of comparing
if (playerHealth = 100)

// ✅ Correct - compares values
if (playerHealth == 100)
```

**Problem**: Incorrect logical operators
```csharp
// ❌ Wrong - using single & or |
if (hasKey & doorLocked)

// ✅ Correct - using double && or ||
if (hasKey && doorLocked)
```

### **Input Detection Issues**
**Problem**: Input not working
**Solutions**:
- Make sure input code is in `Update()` method
- Check you're using correct KeyCode names
- Ensure GameObject with script is active and in the scene

**Problem**: Input firing too often
```csharp
// ❌ Wrong - fires every frame while held
if (Input.GetKey(KeyCode.Space))
{
    Debug.Log("Jump!"); // This prints many times per second!
}

// ✅ Correct - fires once per press
if (Input.GetKeyDown(KeyCode.Space))
{
    Debug.Log("Jump!"); // This prints once per press
}
```

### **Division Problems**
**Problem**: Integer division giving wrong results
```csharp
// ❌ Wrong - integer division truncates decimals
int result = 10 / 3;  // Result is 3, not 3.333...

// ✅ Correct - use floats for decimal results
float result = 10f / 3f;  // Result is 3.333...
```

**Problem**: Division by zero crashes
```csharp
// ❌ Dangerous - could crash if secondNumber is 0
float result = firstNumber / secondNumber;

// ✅ Safe - check before dividing
if (secondNumber != 0)
{
    float result = firstNumber / secondNumber;
}
else
{
    Debug.Log("Cannot divide by zero!");
}
```

### **String Comparison Issues**
**Problem**: String comparison not working
```csharp
// ❌ Wrong - case sensitive
if (playerName == "hero")  // Won't match "Hero"

// ✅ Better - case insensitive comparison
if (playerName.ToLower() == "hero")  // Matches "Hero", "HERO", etc.
```

---

## 🎉 **Success Criteria**

You've successfully completed this practical when:

1. **You can perform mathematical calculations** using operators
2. **You can make decisions** using if/else statements
3. **You can detect player input** and respond appropriately
4. **You can combine conditions** using logical operators
5. **You can modify variables** in the Inspector and see the effects
6. **Your calculator works** with different operations and handles division by zero

---

## 🔜 **Next Session Preview**

In Session 3, you'll learn about:
- For loops and while loops for repetition
- Working with strings and string methods
- Creating your own methods/functions
- Method parameters and return types

**Make sure you're comfortable with if/else statements and input detection before moving on!**

---

*CRE132 - Game Development Fundamentals*  
*Session 2: Operators & Control Flow*