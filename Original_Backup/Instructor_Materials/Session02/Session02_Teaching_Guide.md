# Session 2: Operators & Control Flow

## Session Overview

**Duration**: 90-120 minutes  
**W3Schools Topics**: Operators, User Input, Math, If...Else, Booleans  
**Unity Concepts**: Input System, real-time decision making, interactive feedback  

## Learning Objectives

By the end of this session, students will:
1. ✅ Understand and use all mathematical operators (+, -, *, /, %)
2. ✅ Apply assignment operators (+=, -=, *=, /=) for efficient code
3. ✅ Make comparisons using comparison operators (==, !=, >, <, >=, <=)
4. ✅ Combine conditions using logical operators (&&, ||, !)
5. ✅ Detect keyboard and mouse input using Unity's Input system
6. ✅ Write conditional logic with if/else statements
7. ✅ Create interactive systems that respond to user input

## Scripts Included

### 1. `MathOperators.cs`
**Purpose**: Demonstrates all mathematical operations with practical game calculations  
**Key Features**:
- Basic arithmetic operators with real examples
- Assignment operators for efficient updates
- Modulo operator for cycling and wrapping
- Division safety (avoiding division by zero)
- Practical game calculations (damage, scoring, resources)
- Inspector integration for real-time testing

### 2. `InputDetection.cs`
**Purpose**: Complete coverage of Unity's Input system  
**Key Features**:
- Keyboard input detection (GetKey, GetKeyDown, GetKeyUp)
- Mouse input detection (buttons, position, movement)
- Multiple input combinations for complex interactions
- Real-time feedback through Console and Inspector
- Proper input handling patterns for game development

### 3. `ConditionalLogic.cs`
**Purpose**: Comprehensive if/else statement demonstrations  
**Key Features**:
- Simple if statements for basic decisions
- If-else chains for multiple outcomes
- Nested conditions for complex logic
- Logical operators for combining conditions
- Boolean variables and logic
- Game-relevant decision making examples
## Teaching Sequence

### Phase 1: Setup and Mathematical Operators (25 minutes)
**Using `MathOperators.cs`:**

1. **Create Unity Scene Setup**:
   - New scene: `02_Operators_Control_Flow`
   - Create GameObject: "Session02Manager"
   - Attach MathOperators.cs script
   - Show Inspector with organised sections

2. **Mathematical Operators Walkthrough**:
   ```csharp
   // Basic arithmetic
   int health = 100;
   int damage = 25;
   int newHealth = health - damage;  // Subtraction
   
   // Multiplication for scaling
   float speed = 5.0f;
   float boostedSpeed = speed * 2.0f;  // Double speed
   
   // Division for averages
   float totalScore = 450f;
   float averageScore = totalScore / 3f;  // Average of 3 games
   
   // Modulo for cycling
   int currentWeapon = 5;
   int weaponSlot = currentWeapon % 3;  // Cycles 0, 1, 2
   ```

3. **Assignment Operators Practice**:
   - Show `playerScore += 100;` vs `playerScore = playerScore + 100;`
   - Demonstrate efficiency and readability benefits
   - Practice with health systems: `health -= damage;`
   - Resource management: `coins *= 2;` (double coins powerup)

4. **Common Pitfalls Discussion**:
   - Integer division truncation: `10 / 3` gives `3`, not `3.33`
   - Division by zero protection
   - Operator precedence: `2 + 3 * 4` = `14`, not `20`

### Phase 2: Input Detection Mastery (20 minutes)
**Using `InputDetection.cs`:**

1. **Input System Overview**:
   ```csharp
   // Three types of key detection
   if (Input.GetKeyDown(KeyCode.Space))    // Pressed this frame
       Debug.Log("Space pressed!");
   
   if (Input.GetKey(KeyCode.W))            // Held down
       Debug.Log("W is being held");
   
   if (Input.GetKeyUp(KeyCode.Space))      // Released this frame
       Debug.Log("Space released!");
   ```

2. **Mouse Input Integration**:
   - Left click: `Input.GetMouseButtonDown(0)`
   - Right click: `Input.GetMouseButtonDown(1)`
   - Mouse position: `Input.mousePosition`
   - Practical gaming applications

3. **Unity Input System Best Practices**:
   - When to use GetKey vs GetKeyDown
   - Frame-rate independent input
   - Input in Update() method
   - Multiple input combinations

4. **Interactive Demonstrations**:
   - Students test different key combinations
   - Real-time Console feedback
   - Inspector variables update in real-time

### Phase 3: Conditional Logic Deep Dive (30 minutes)
**Using `ConditionalLogic.cs`:**

1. **Comparison Operators Foundation**:
   ```csharp
   int playerLevel = 15;
   
   if (playerLevel == 10)
       Debug.Log("Exactly level 10!");
   
   if (playerLevel >= 15)
       Debug.Log("High level player!");
   
   if (playerLevel != 1)
       Debug.Log("Not a beginner!");
   ```

2. **Logical Operators Mastery**:
   ```csharp
   // AND operator - both must be true
   if (hasKey && doorIsLocked)
       Debug.Log("Can unlock door!");
   
   // OR operator - at least one must be true
   if (playerDead || gameOver)
       Debug.Log("Game ended!");
   
   // NOT operator - reverses the boolean
   if (!gameOver)
       Debug.Log("Game is still running!");
   ```

3. **Complex Conditional Chains**:
   - Simple if statements
   - If-else combinations
   - If-else if-else chains
   - Nested conditions for complex logic

4. **Boolean Variables and Logic**:
   - Creating meaningful boolean variables
   - Combining booleans with logical operators
   - Game state management with booleans

### Phase 4: Integration and Practical Application (25 minutes)

1. **Combining All Concepts**:
   - Input detection triggering mathematical operations
   - Conditional logic based on calculated results
   - Real-time system that responds to player actions

2. **Game Development Patterns**:
   - Health systems with damage calculation
   - Scoring systems with bonus conditions
   - Player state management
   - Interactive feedback systems

### Phase 5: Hands-On Student Exercise (20 minutes)

**Student Challenges using `Session02_StudentExercise.cs`:**

1. **Personal Calculator System**:
   - Use if-else statements to perform different operations
   - Implement input detection for operation selection
   - Apply mathematical operators based on user choice

2. **Character Analysis System**:
   - Compare player stats with conditional logic
   - Provide feedback based on character attributes
   - Use logical operators for complex conditions

3. **Interactive Input System**:
   - Detect various keyboard and mouse inputs
   - Respond differently to different input combinations
   - Display real-time feedback for user actions

## Common Student Questions & Answers

**Q: Why use GetKeyDown instead of GetKey for jump actions?**  
A: GetKeyDown triggers once when pressed, preventing rapid jumping. GetKey would make the player jump every frame while held!

**Q: What's the difference between = and == ?**  
A: Single = assigns a value (`health = 100`). Double == compares values (`if (health == 100)`). Mixing these up is a common bug!

**Q: Why does 10 / 3 give 3 instead of 3.33?**  
A: When both numbers are integers, C# does integer division. Use `10f / 3f` or `10.0f / 3.0f` for decimal results.

**Q: How do I check if a key is NOT pressed?**  
A: Use the ! operator: `if (!Input.GetKey(KeyCode.Space))` means "if space is NOT being pressed".

**Q: Can I combine multiple conditions in one if statement?**  
A: Yes! Use && for AND: `if (hasKey && doorLocked)` or || for OR: `if (dead || gameOver)`.


## Assessment Checkpoints

### Knowledge Check (Throughout Session):
- [ ] Can identify and use all mathematical operators correctly
- [ ] Understands difference between GetKey, GetKeyDown, and GetKeyUp
- [ ] Can write proper if-else statement syntax
- [ ] Knows how to combine conditions with logical operators
- [ ] Understands operator precedence in mathematical expressions

### Practical Check (End of Session):
- [ ] Successfully implements mathematical calculations in code
- [ ] Can detect different types of user input
- [ ] Writes working conditional logic for game scenarios
- [ ] Demonstrates understanding of boolean logic
- [ ] Creates interactive systems that respond to player actions

### Technical Skills Check:
- [ ] Uses assignment operators (+=, -=, etc.) appropriately
- [ ] Implements proper division by zero protection
- [ ] Combines multiple input types in conditional statements
- [ ] Creates nested conditional logic when appropriate
- [ ] Demonstrates real-time debugging with Debug.Log statements

## Extension Activities

For students who finish early:

1. **Advanced Input Combinations**: Create systems that respond to multiple keys pressed simultaneously
2. **Mathematical Challenges**: Implement complex game formulas (experience points, damage calculations)
3. **State Machine Basics**: Use booleans to manage simple game states (playing, paused, game over)
4. **Input Buffering**: Store recent inputs and create combo systems
5. **Performance Optimisation**: Learn about caching Input calls vs checking every frame

## Troubleshooting Common Issues

**Error: "Assets\...\Script.cs(X,Y): error CS0029: Cannot implicitly convert type 'float' to 'int'"**  
→ Use explicit casting: `int result = (int)floatValue;` or declare variables with correct types

**Error: "DivideByZeroException: Attempted to divide by zero"**  
→ Always check before division: `if (divisor != 0) { result = dividend / divisor; }`

**Input not working properly**  
→ Check that Input detection is in Update() method, not Start()
→ Verify correct KeyCode spelling (e.g., KeyCode.Space, not KeyCode.Spacebar)

**Nothing happens when keys are pressed**  
→ Ensure script is attached to an active GameObject
→ Check that the GameObject with the script is not disabled
→ Verify Console window is open to see Debug.Log output

**Unexpected mathematical results**  
→ Check for integer division: use 'f' suffix for floats
→ Verify operator precedence: use parentheses for clarity
→ Watch for modulo with negative numbers

**Conditions not working as expected**  
→ Check for assignment (=) vs comparison (==) operators
→ Verify logical operator usage: && vs || vs !
→ Test individual conditions separately before combining


## Unity/Visual Studio Code Integration Notes

### **Opening and Editing Scripts**:
1. **Double-click script in Unity** → Opens in Visual Studio Code
2. **Look for syntax highlighting**:
   - **Green**: Comments and explanations
   - **Blue**: C# keywords (if, else, int, float)
   - **Red**: Strings and text
   - **Red squiggly lines**: Errors that need fixing

### **Save/Test Workflow**:
1. **Edit code in Visual Studio Code**
2. **Save file** (Ctrl+S or Cmd+S)
3. **Return to Unity** → Watch for compilation
4. **Press Play** to test changes
5. **Check Console** for Debug.Log output

### **Session 2 Specific Guidance**:
- **Input testing requires Play mode** - input only works when scene is running
- **Mathematical operations show immediately** in Console with Debug.Log
- **Conditional logic results** appear as different messages based on conditions
- **Real-time variables** update in Inspector while scene plays

## Next Session Preview

Session 3 will cover:
- For loops and while loops for repetitive tasks
- String manipulation and text processing
- Creating custom methods with parameters and return values
- More complex Unity systems using loops and strings

Students should feel confident with operators and conditionals before Session 3!

---

## Files in This Session
- `MathOperators.cs` - Mathematical operations and calculations
- `InputDetection.cs` - Unity Input system demonstrations
- `ConditionalLogic.cs` - If/else statements and boolean logic
- `Session02_StudentExercise.cs` - Student practice template
- `Session02_Teaching_Guide.md` - This instructor guide

**Unity Scene**: `02_Operators_Control_Flow.unity`  
**Estimated Total Teaching Time**: 90-120 minutes  
**Prerequisites**: Session 1 (Variables and basic C# syntax)

---

## Teaching Tips for Success

### **Pacing Recommendations**:
- Spend extra time on logical operators - students often struggle with && vs ||
- Demonstrate input detection interactively - let students try different keys
- Use real game examples for mathematical operations to maintain engagement
- Check understanding frequently with quick practical tests

### **Common Teaching Moments**:
- **Integer division surprise**: Show 10/3 = 3, then 10f/3f = 3.33
- **Assignment vs comparison**: Write = and == on board, show the difference
- **Input timing**: Explain why GetKeyDown is different from GetKey with practical examples
- **Boolean logic**: Use real-world analogies (AND = both keys needed, OR = either door works)

### **Student Engagement Strategies**:
- Have students predict mathematical results before running code
- Create mini-challenges: "Make the character move only when both keys are pressed"
- Use error messages as learning opportunities, not failures
- Encourage experimentation with different operator combinations

