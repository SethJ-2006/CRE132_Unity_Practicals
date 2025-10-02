# Session 1: C# Fundamentals in Unity

## Session Overview

**Duration**: 45-60 minutes (SIMPLIFIED FOR BEGINNERS)
**W3Schools Topics**: Syntax, Variables, Data Types, Output, Comments  
**Unity Concepts**: MonoBehaviour lifecycle, Inspector integration, Debug.Log  

## Learning Objectives

By the end of this session, students will:
1. ✅ Understand basic C# syntax and Unity script structure
2. ✅ Know all major C# data types and when to use them
3. ✅ Be able to declare, assign, and modify variables
4. ✅ Understand the difference between constants and variables
5. ✅ Use proper commenting and naming conventions
6. ✅ Perform basic type conversion and casting
7. ✅ Navigate Unity's MonoBehaviour lifecycle

## Scripts Included

### 1. `CSharpBasics.cs`
**Purpose**: Introduces C# syntax, Unity structure, and commenting  
**Key Features**:
- Comprehensive commenting examples (single-line, multi-line, XML)
- MonoBehaviour lifecycle demonstration (Start/Update)
- Method access levels (public/private)
- Unity vs standard C# differences
- Proper code organisation with regions

### 2. `VariableExplorer.cs`
**Purpose**: Complete coverage of all C# data types and variable concepts  
**Key Features**:
- All W3Schools data types with examples
- Inspector integration with headers and tooltips
- Constants vs readonly variables
- Type casting demonstrations
- Variable naming conventions
- Interactive methods for testing

## Teaching Sequence

### Phase 1: Setup (10 minutes)
1. Create new Unity scene: `01_CSharp_Basics`
2. Create empty GameObject: "Session01Manager"
3. Attach both scripts to the GameObject
4. Show students the Inspector - explain the public variables

### Phase 2: C# Syntax Introduction (20 minutes)
**Using `CSharpBasics.cs`:**

1. **Explain the script structure**:
   ```csharp
   using System;           // Import functionality
   public class ClassName  // Class definition
   {
       void Start() { }    // Unity method
   }
   ```

2. **Run the scene** - observe Console output
3. **Explain MonoBehaviour lifecycle**:
   - Start() runs once when object becomes active
   - Update() runs every frame (show frame rate impact)
   - Awake() runs before Start() (mentioned in VariableExplorer)

4. **Comment types walkthrough**:
   - `//` single-line comments
   - `/* */` multi-line comments  
   - `///` XML documentation comments
   - When to use each type

5. **Method calling demonstration**:
   - Show how `DemonstrateSyntax()` calls `ShowMethodCall()`
   - Explain public vs private methods

### Phase 3: Data Types Deep Dive (25 minutes)
**Using `VariableExplorer.cs`:**

1. **Show Inspector organisation**:
   - Headers group related variables
   - Tooltips provide explanations
   - Public variables appear, private ones don't

2. **Data type exploration**:
   - **Integers**: int, long, short, byte - when to use each
   - **Floats**: float (needs 'f'), double, decimal - precision differences
   - **Boolean**: true/false only - perfect for game states
   - **Character**: single quotes, escape sequences
   - **String**: double quotes, concatenation, properties

3. **Practical demonstrations**:
   - Modify values in Inspector, press Play, observe changes
   - Right-click on script → "Show All Variables" (context menu)
   - Run "Modify Variables" to see programmatic changes

4. **Constants explanation**:
   - `const` never changes, must be set at declaration
   - `readonly` can only be set in constructor
   - When to use each approach

### Phase 4: Type Conversion (15 minutes)
**Still using `VariableExplorer.cs`:**

1. **Implicit casting** (automatic):
   - Small to large: int → long → float → double
   - Safe conversions that don't lose data

2. **Explicit casting** (manual):
   - Large to small: `(int)someFloat`
   - Might lose data - explain precision loss

3. **Convert class methods**:
   - `Convert.ToInt32()` for strings to numbers
   - `.ToString()` for numbers to strings
   - Safer for user input handling

### Phase 5: Hands-On Practice (15-20 minutes)

**Student Exercises:**

1. **Basic Variable Creation**:
   - Create a new script called `MyFirstVariables.cs`
   - Declare variables for: player name, health, score, is alive
   - Use different data types appropriately
   - Add meaningful comments

2. **Inspector Interaction**:
   - Make variables public to see in Inspector
   - Add `[Header]` and `[Tooltip]` attributes
   - Test changing values in Inspector vs code

3. **Type Conversion Practice**:
   - Convert a string "100" to an integer
   - Convert a float 3.14f to an integer (observe data loss)
   - Create a method that combines string and number variables

## Common Student Questions & Answers

**Q: Why do floats need the 'f' suffix?**  
A: Without 'f', Unity treats decimal numbers as doubles. The 'f' tells C# "this is specifically a float". Try removing it and see the error!

**Q: What's the difference between string and char?**  
A: char is ONE character in single quotes 'A'. string is text of any length in double quotes "Hello World".

**Q: When should I use const vs readonly?**  
A: Use `const` for values that truly never change (like PI). Use `readonly` for values set once but might be different per object (like birth date).

**Q: Why does integer division give weird results?**  
A: `10 / 3` gives `3`, not `3.33` because both numbers are integers. Use `10f / 3f` for decimal results.

## Assessment Checkpoints

### Knowledge Check (Throughout Session):
- [ ] Can identify different data types in code
- [ ] Understands difference between public/private variables
- [ ] Can explain when Start() vs Update() runs
- [ ] Knows how to write different types of comments

### Practical Check (End of Session):
- [ ] Successfully creates variables of different types
- [ ] Can modify variables both in code and Inspector
- [ ] Demonstrates understanding of type conversion
- [ ] Uses appropriate variable names and comments

## Extension Activities

For students who finish early:

1. **Character Experiments**: Try different escape characters (`\n`, `\t`, `\"`)
2. **Large Number Testing**: See what happens with very large integers
3. **Dangerous Casting**: Deliberately cause data loss and explain why
4. **String Methods**: Explore `.Length`, `.ToUpper()`, `.Substring()`

## Troubleshooting Common Issues

**Error: "Assets\...\VariableExplorer.cs(X,Y): error CS0123: A method or delegate 'Start' is expected"**  
→ Check for missing semicolons or mismatched braces

**Error: "The name 'Debug' does not exist in the current context"**  
→ Add `using UnityEngine;` at the top of the script

**Variables don't appear in Inspector**  
→ Make sure they're declared as `public` and script is attached to GameObject

**Console shows nothing when playing**  
→ Check that Console window is open (Window → General → Console)

## Next Session Preview

Session 2 will cover:
- All types of operators (arithmetic, comparison, logical)
- Unity Input System basics
- If/else statements and boolean logic
- Interactive user input examples

Students should feel confident with variables before moving forward!

---

## Files in This Session
- `CSharpBasics.cs` - Syntax and Unity fundamentals
- `VariableExplorer.cs` - Complete data types coverage
- `Session01_Guide.md` - This teaching guide

**Unity Scene**: `01_CSharp_Basics.unity`  
**Estimated Total Teaching Time**: 60 minutes (reduced via complexity optimization)  
**Prerequisites**: Basic Unity interface familiarity  
**Optimization Notes**: This session has been streamlined to focus on 4 core data types only
