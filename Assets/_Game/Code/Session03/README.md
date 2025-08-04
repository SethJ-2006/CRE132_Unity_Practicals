# Session 03: Loops & Methods

## 🎯 **Session Overview**
Learn the power of repetition and code reusability! This session covers for loops, while loops, string manipulation, and creating custom methods that make your code modular and efficient.

## 📚 **What You'll Learn**

### **Core Concepts**
- **For Loops**: Perfect for when you know exactly how many times to repeat
- **While Loops**: Continue until a condition becomes false
- **String Methods**: Powerful text manipulation tools
- **Custom Methods**: Create reusable blocks of code
- **Method Parameters**: Make methods flexible with input values
- **Return Types**: Get information back from methods
- **Method Overloading**: Same name, different parameters

### **Practical Applications**
- Spawning multiple enemies or items
- Processing player collections (inventory, high scores)
- Text processing for chat systems and user input
- Damage calculations and game mechanics
- Health systems and turn-based combat
- Input validation and data cleaning

## 🛠️ **Files in This Session**

### **📋 Practical Guide**
- `Session03_Practical.md` - Comprehensive learning guide with examples and troubleshooting

### **💻 Demonstration Scripts**
- `ForLoops.cs` - All types of for loops with game examples
- `WhileLoops.cs` - While loops, do-while loops, and safety practices
- `StringMethods.cs` - Complete string manipulation toolkit
- `CustomMethods.cs` - Method creation, parameters, and overloading

### **✏️ Student Exercise**
- `Session03_StudentExercise.cs` - Hands-on TODO-based practice

## 🎮 **Key Game Development Applications**

### **Loops in Action**
```csharp
// Spawn enemies in formation
for (int i = 0; i < enemyCount; i++)
{
    SpawnEnemy(startPosition + (i * spacing));
}

// Combat simulation
while (playerHealth > 0 && enemyHealth > 0)
{
    ProcessCombatTurn();
}
```

### **String Power**
```csharp
// Clean player input
string playerName = input.Trim().ToLower().Replace("_", " ");

// Create dynamic messages
string message = $"Player {name} dealt {damage} damage!";
```

### **Method Magic**
```csharp
// Reusable damage calculation
public float CalculateDamage(float base, float multiplier, bool critical)
{
    float total = base * multiplier;
    return critical ? total * 2f : total;
}
```

## 🎯 **Learning Progression**

### **Beginner Level**
- ✅ Understand for loop structure (initialiser, condition, increment)
- ✅ Create basic while loops with safety checks
- ✅ Use essential string methods (Length, ToUpper, ToLower)
- ✅ Write simple void methods

### **Intermediate Level**
- ✅ Use nested loops for 2D structures
- ✅ Combine loops with arrays for data processing
- ✅ Master string searching and modification
- ✅ Create methods with parameters and return values

### **Advanced Level**
- ✅ Implement method overloading
- ✅ Create complex string validation systems
- ✅ Build comprehensive game mechanics using methods
- ✅ Combine all concepts for complete game features

## 🚨 **Common Challenges & Solutions**

### **Infinite Loop Prevention**
```csharp
// ❌ DANGER - This will freeze Unity!
while (x > 0)
{
    Debug.Log("This never changes x!");
}

// ✅ SAFE - Always modify the condition
while (x > 0)
{
    Debug.Log("Processing: " + x);
    x--; // Don't forget this!
}
```

### **Off-by-One Errors**
```csharp
// Count 10 items (0 through 9)
for (int i = 0; i < 10; i++) // ✅ Correct

// Common mistake
for (int i = 0; i <= 10; i++) // ❌ Counts 11 times!
```

## 💡 **Best Practices**

### **Loop Guidelines**
- Always include safety counters for while loops
- Use descriptive variable names beyond simple `i`, `j`
- Avoid heavy calculations inside loops when possible
- Break out early when conditions are met

### **Method Design**
- One method, one responsibility
- Use meaningful names that describe the action
- Order parameters logically (most important first)
- Include comprehensive XML documentation

### **String Handling**
- Always check for null/empty before using methods
- Use string interpolation for readable formatting
- Remember strings are immutable (methods create new strings)

## 🔄 **Building on Previous Sessions**

### **From Session 01 & 02**
- Variables and data types → Loop counters and method parameters
- Operators and conditionals → Loop conditions and method logic
- Debug.Log() → Method testing and loop monitoring

### **Preparing for Session 04**
- Arrays and loops → Collections and iteration
- Methods → Unity Transform manipulation
- String processing → UI text management

## 🎖️ **Completion Checklist**

- [ ] Run all demonstration scripts and understand the output
- [ ] Complete Session03_StudentExercise.cs with all TODO sections
- [ ] Create your own custom method for a game mechanic
- [ ] Successfully use a for loop to process an array
- [ ] Implement a while loop with proper safety checks
- [ ] Use string methods to clean and validate user input
- [ ] Test method overloading with different parameter combinations

## 🚀 **Next Steps**
After mastering loops and methods, you'll be ready for **Session 04: Collections & Movement**, where you'll learn to manage multiple objects and move them around in Unity space.

---

*Remember: Loops and methods are the building blocks of efficient programming. Take time to understand each concept - they'll be used in every game you create!* 🎮