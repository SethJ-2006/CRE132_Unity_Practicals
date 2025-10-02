# CRE132 Session 1: C# Fundamentals Practical

## 🎯 **Learning Objectives**
By the end of this practical, you will understand:
- Basic C# syntax and Unity script structure
- How to declare and use different data types
- The difference between constants and variables
- How to write proper comments in your code
- Unity's MonoBehaviour lifecycle (Start and Update methods)

---

## 📚 **Key Concepts to Learn**

### **The 4 Core C# Data Types**
- **`int`** - Whole numbers (e.g., `42`, `-10`, `1000`)
- **`float`** - Decimal numbers (e.g., `3.14f`, `0.5f`) *Always add 'f' at the end!*
- **`bool`** - True or false values only (e.g., `true`, `false`)
- **`string`** - Text in double quotes (e.g., `"Hello World"`)

### **Variables**
- **Variables** can be changed: `playerScore = 100;` then later `playerScore = 200;`
- **Public variables** show up in Unity's Inspector for easy editing
- **Always give variables descriptive names** like `playerHealth` not just `hp`

### **Comments**
- **Single-line**: `// This explains one line of code`
- **Multi-line**: `/* This explains multiple lines */`
- **XML Documentation**: `/// <summary>This creates tooltips</summary>`

### **Unity MonoBehaviour**
- **`Start()`** - Runs once when the game object becomes active
- **`Update()`** - Runs every frame while the game is running
- **`Debug.Log()`** - Prints messages to Unity's Console window

---

## 🛠️ **Practical Instructions**

### **Step 1: Examine the Example Scripts**
1. Open Unity and load the CRE132 project
2. Navigate to: `Assets/_Game/Code/Session01/`
3. Look at these two scripts:
   - **`CSharpBasics.cs`** - Shows C# syntax and Unity structure
   - **`VariableExplorer.cs`** - Demonstrates all data types

### **Step 2: Set Up Your Scene**
1. Create a new scene: `File > New Scene` 
2. Save it as: `01_CSharp_Basics` in `Assets/_Game/Scenes/`
3. Create an empty GameObject: `GameObject > Create Empty`
4. Rename it to: `Session01Manager`
5. Attach both scripts to this GameObject:
   - Select the GameObject
   - Click `Add Component`
   - Search for `CSharpBasics` and add it
   - Do the same for `VariableExplorer`

### **Step 3: Run and Observe**
1. **Press Play** to run the scene
2. **Open the Console** window: `Window > General > Console`
3. **Read the output** - this shows what the scripts are doing
4. **Stop the scene** by pressing Play again

### **Step 4: Explore the Inspector**
1. **Select your GameObject** with the scripts
2. **Look at the Inspector** on the right side
3. **Notice the public variables** from `VariableExplorer.cs`
4. **Try changing some values** (like playerScore or playerName)
5. **Press Play again** and see how your changes affect the output

### **Step 5: Complete the Student Exercise**

#### **5.1: Open the Exercise Script**
1. **In Unity**, navigate to `Assets/_Game/Code/Session01/`
2. **Double-click** on `Session01_StudentExercise.cs` 
3. **This will open Visual Studio Code** (or your default code editor)
4. **Wait for the editor to load** - you'll see the C# code with green and grey text

#### **5.2: Find the TODO Sections**
1. **Look for comments that say `// TODO:`** - these are in green text
2. **There are several sections** you need to complete:
   - Student Information variables (around line 25)
   - Game Character Stats variables (around line 30)
   - Simple game settings (around line 40)
   - Method implementations (multiple locations)

#### **5.3: Add Your Variables**
**In the Student Information section**, you'll see:
```csharp
// TODO: Create a public string variable for your first name
// TODO: Create a public string variable for your student ID  
// TODO: Create a public int variable for your age
```

**Replace these lines with actual code**, for example:
```csharp
public string firstName = "John";        // Replace "John" with your name
public string studentID = "12345678";    // Replace with your student ID
public int age = 20;                     // Replace with your age
```

**In the Game Character Stats section**, you'll see:
```csharp
// TODO: Create public variables for a game character:
// - Character name (string)
// - Health points (int) - set to 100
// - Movement speed (float) - set to 5.5f
// - Is character alive (bool) - set to true
```

**Replace with actual variable declarations (using the 4 core types):**
```csharp
public string characterName = "Hero";
public int healthPoints = 100;
public float movementSpeed = 5.5f;
public bool isCharacterAlive = true;
```

#### **5.4: Complete the Method TODOs**
**Scroll down to find methods with TODO comments**, for example:
```csharp
void DisplayStudentInfo()
{
    Debug.Log("--- Student Information ---");
    
    // TODO: Use Debug.Log to display your first name
    // Example: Debug.Log("Student Name: " + yourNameVariable);
}
```

**Add your Debug.Log statements:**
```csharp
void DisplayStudentInfo()
{
    Debug.Log("--- Student Information ---");
    
    Debug.Log("Student Name: " + firstName);
    Debug.Log("Student ID: " + studentID);
    Debug.Log("Student Age: " + age);
}
```

#### **5.5: Save and Test Your Code**
1. **Save the file**: Press `Ctrl+S` (Windows) or `Cmd+S` (Mac)
2. **Return to Unity** - click on the Unity window
3. **Wait for compilation** - check the Console for any red error messages
4. **If there are errors**, go back to Visual Studio Code and fix them
5. **Create a new GameObject** called `StudentExercise` 
6. **Attach your completed script** to this GameObject
7. **Press Play** and check the Console for your output

#### **5.6: What Your Completed Code Should Look Like**
Here's an example of what the variable section should look like when finished:
```csharp
[Header("=== STUDENT INFORMATION ===")]
public string firstName = "Sarah";      // Your actual name
public string studentID = "20241234";   // Your actual student ID
public int age = 19;                    // Your actual age

[Header("=== GAME CHARACTER STATS ===")]
public string characterName = "Warrior";
public int healthPoints = 100;
public float movementSpeed = 5.5f;
public bool isCharacterAlive = true;

[Header("=== SIMPLE GAME SETTINGS ===")]
public int maxLevel = 10;
```

---

## 💻 **Working with Visual Studio Code**

### **Opening Scripts**
- **Double-click** any `.cs` file in Unity to open it in your code editor
- **Wait for loading** - Visual Studio Code may take a few seconds to start
- **Look for syntax highlighting** - code should appear in different colours

### **Understanding the Code Editor**
- **Green text** = Comments (explanations for humans)
- **Blue text** = C# keywords (like `public`, `int`, `string`)
- **Red text** = Strings (text in quotes)
- **Yellow/Orange text** = Variable names
- **Red squiggly lines** = Errors (hover to see what's wrong)

### **Writing Code**
1. **Find the TODO comments** (in green text)
2. **Delete the TODO line** and replace with actual code
3. **Follow the example format** shown in the comments
4. **Remember the semicolon** `;` at the end of each statement
5. **Match the spacing/indentation** of surrounding code

### **Saving and Testing**
1. **Save**: `Ctrl+S` (Windows) or `Cmd+S` (Mac)
2. **Return to Unity** - click on the Unity window
3. **Check Console** for compilation errors (red messages)
4. **Fix errors** before testing by pressing Play

### **Step-by-Step Coding Example**
Here's exactly what the process looks like:

**1. You'll see this in the code:**
```csharp
// TODO: Create a public string variable for your first name
```

**2. Delete the TODO line and replace with:**
```csharp
public string firstName = "Alex";    // Replace "Alex" with your actual name
```

**3. Continue with the next TODO:**
```csharp
// TODO: Create a public int variable for your age
```

**4. Replace with:**
```csharp
public int age = 21;                 // Replace 21 with your actual age
```

**5. For method TODOs, you'll see:**
```csharp
// TODO: Use Debug.Log to display your first name
```

**6. Replace with:**
```csharp
Debug.Log("Student Name: " + firstName);
```

**Remember**: Each line of code ends with a semicolon `;`

---

## ✅ **Exercise Checklist**

Make sure you can do all of these:

### **Basic Understanding**
- [ ] I can identify different data types in C# code
- [ ] I understand the difference between `int` and `float`
- [ ] I know why strings use `"` and chars use `'`
- [ ] I can explain when `Start()` vs `Update()` runs

### **Practical Skills** 
- [ ] I can declare variables with different data types
- [ ] I can assign values to variables
- [ ] I can write single-line and multi-line comments
- [ ] I can make variables appear in Unity's Inspector

### **Coding Tasks (Student Exercise)**
- [ ] I opened `Session01_StudentExercise.cs` in Visual Studio Code
- [ ] I added my personal information variables (name, student ID, age)
- [ ] I created all the game character variables with correct data types
- [ ] I added the required constants (MAX_LEVEL and GAME_VERSION)
- [ ] I completed the `DisplayStudentInfo()` method with Debug.Log statements
- [ ] I completed the `DisplayCharacterStats()` method 
- [ ] I completed the `PerformCalculations()` method
- [ ] I completed the `TestTypeConversion()` method
- [ ] I saved the file and returned to Unity
- [ ] My script compiles without red errors in the Console

---

## 🔧 **Common Issues and Solutions**

### **Code Editor Problems**
**Problem**: Visual Studio Code won't open when I double-click a script  
**Solution**: 
- Make sure Visual Studio Code is installed
- In Unity: `Edit > Preferences > External Tools > External Script Editor` - set to Visual Studio Code
- Try right-clicking the script and choosing "Open C# Project"

**Problem**: Code appears all in one colour (no syntax highlighting)  
**Solution**: 
- Install the C# extension in Visual Studio Code
- Make sure the file has `.cs` extension
- Wait for the editor to fully load (may take 30 seconds first time)

### **Compilation Errors**
**Problem**: Red error messages in Unity Console  
**Common Causes and Solutions**:

**Error: "Missing semicolon"**
```csharp
// ❌ Wrong - missing semicolon
public string playerName = "Hero"

// ✅ Correct - has semicolon
public string playerName = "Hero";
```

**Error: "Cannot convert 'double' to 'float'"**
```csharp
// ❌ Wrong - missing 'f' suffix
public float speed = 5.5;

// ✅ Correct - has 'f' suffix
public float speed = 5.5f;
```

**Error: "Expected ';' or '='"**
```csharp
// ❌ Wrong - missing assignment
public int health;

// ✅ Correct - assigned value
public int health = 100;
```

**Error: "Variable not found"**
```csharp
// ❌ Wrong - using variable that doesn't exist
Debug.Log("Name: " + myName);

// ✅ Correct - using actual variable name
Debug.Log("Name: " + firstName);
```

### **Unity Integration Issues**
**Problem**: Variables don't show in Inspector  
**Solution**: 
- Make sure variables are declared as `public`
- Check that script is attached to a GameObject
- Try selecting another GameObject and back again

**Problem**: Nothing happens when I press Play  
**Solutions**:
- Check Console for red error messages - fix them first
- Make sure script is attached to an active GameObject
- Verify GameObject has a checkmark (is active) in the hierarchy

**Problem**: Can't see Debug.Log output  
**Solution**: 
- Open Console window: `Window > General > Console`
- Make sure "Collapse" is unchecked to see all messages
- Check that you're using `Debug.Log()` not `Console.WriteLine()`

### **Common Coding Mistakes**
**Problem**: String vs Char confusion
```csharp
// ❌ Wrong - char uses double quotes
public char grade = "A";

// ✅ Correct - char uses single quotes
public char grade = 'A';

// ❌ Wrong - string uses single quotes  
public string name = 'John';

// ✅ Correct - string uses double quotes
public string name = "John";
```

**Problem**: Wrong variable type for numbers
```csharp
// ❌ Wrong - using int for decimal numbers
public int speed = 5.5;    // Will cause error

// ✅ Correct - using float for decimal numbers
public float speed = 5.5f;

// ❌ Wrong - using float for whole numbers (not wrong, but unnecessary)
public float score = 100f;

// ✅ Correct - using int for whole numbers
public int score = 100;
```

---

## 🎉 **Success Criteria**

You've successfully completed this practical when:

1. **You can run the example scripts** and understand what they're demonstrating
2. **You can modify variables** in the Inspector and see the changes
3. **You've completed the student exercise** without compilation errors
4. **You understand** the basic concepts listed at the top
5. **You can explain** to someone else what `Start()`, `Update()`, and `Debug.Log()` do

---

## 📖 **Additional Resources**

- **Unity Console**: `Window > General > Console` - see your `Debug.Log()` output here
- **Inspector**: Select a GameObject to see its components and public variables
- **Unity Documentation**: Search for "MonoBehaviour" to learn more about Unity scripts

## 🔜 **Next Session Preview**

In Session 2, you'll learn about:
- Mathematical operators (+, -, *, /, %)
- User input (keyboard and mouse)  
- If/else statements for decision making
- Boolean logic (true/false conditions)

**Make sure you're comfortable with variables and data types before moving on!**

---

*CRE132 - Game Development Fundamentals*  
*Session 1: C# Fundamentals*
