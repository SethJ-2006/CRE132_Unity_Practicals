# CRE132 Beginner Error Prevention Guide

## Most Common Student Mistakes & Prevention

### **1. Float Literal Syntax Errors**
**❌ Common Mistake:**
```csharp
float speed = 5.5; // Missing 'f' suffix - compiler error!
```

**✅ Correct Version:**
```csharp
float speed = 5.5f; // The 'f' tells C# this is a float
```

**Prevention Added:** Warning comments in Session01 variable examples and validation checks.

---

### **2. Assignment vs Comparison Confusion**
**❌ Common Mistake:**
```csharp
if (playerHealth = 100) // Using = instead of == 
{
    Debug.Log("Full health");
}
```

**✅ Correct Version:**
```csharp
if (playerHealth == 100) // Use == for comparison
{
    Debug.Log("Full health");
}
```

**Prevention Added:** Clear examples in Session02 conditional logic with reminder comments.

---

### **3. Missing Semicolons**
**❌ Common Mistake:**
```csharp
int score = 100  // Missing semicolon
Debug.Log("Score: " + score)  // Missing semicolon
```

**✅ Correct Version:**
```csharp
int score = 100; // Every statement ends with semicolon
Debug.Log("Score: " + score); // Don't forget the semicolon!
```

**Prevention Added:** Validation methods check for compilation errors and provide specific guidance.

---

### **4. String vs Character Quotes**
**❌ Common Mistake:**
```csharp
char letter = "A"; // Double quotes for char - wrong!
string word = 'Hello'; // Single quotes for string - wrong!
```

**✅ Correct Version:**
```csharp
char letter = 'A'; // Single quotes for single character
string word = "Hello"; // Double quotes for text
```

**Prevention Added:** Clear examples in Session01 with visual distinction.

---

### **5. Public vs Private Variable Confusion**
**❌ Common Issue:**
```csharp
private int playerHealth = 100; // Won't show in Inspector
```
*Student asks: "Why can't I see my variable in Unity?"*

**✅ Learning Point:**
```csharp
public int playerHealth = 100; // Shows in Inspector
[SerializeField] private int secretValue; // Private but still visible for debugging
```

**Prevention Added:** Clear Inspector integration examples in all early sessions.

---

### **6. Division by Zero Crashes**
**❌ Dangerous Code:**
```csharp
int result = 100 / secondNumber; // If secondNumber is 0, crash!
```

**✅ Safe Version:**
```csharp
if (secondNumber != 0)
{
    int result = 100 / secondNumber;
    Debug.Log("Result: " + result);
}
else
{
    Debug.Log("Error: Cannot divide by zero!");
}
```

**Prevention Added:** Division safety examples in Session02 calculator exercise.

---

### **7. Case Sensitivity Issues**
**❌ Common Mistake:**
```csharp
Debug.log("Hello"); // Wrong capitalization - compiler error!
debug.Log("Hello"); // Wrong capitalization - compiler error!
```

**✅ Correct Version:**
```csharp
Debug.Log("Hello"); // Correct: capital D, capital L
```

**Prevention Added:** Case sensitivity demonstration in Session01 basics.

---

### **8. Forgetting to Attach Scripts**
**❌ Common Issue:**
Student writes perfect code but nothing happens when they press Play.

**✅ Solution Process:**
1. Create GameObject in scene
2. Attach script to GameObject (drag or Add Component)
3. Check Inspector shows script with public variables
4. Press Play to test

**Prevention Added:** Step-by-step Unity integration guidance in all session teaching materials.

---

### **9. Input System Confusion**
**❌ Wrong Input Usage:**
```csharp
void Start() // Wrong place for input detection!
{
    if (Input.GetKeyDown(KeyCode.Space))
        Debug.Log("Jump!");
}
```

**✅ Correct Usage:**
```csharp
void Update() // Input should be checked every frame
{
    if (Input.GetKeyDown(KeyCode.Space))
        Debug.Log("Jump!");
}
```

**Prevention Added:** Clear explanation of Update() vs Start() in Session02 input exercises.

---

### **10. Method Call Syntax Errors**
**❌ Common Mistakes:**
```csharp
DisplayPlayerInfo; // Missing parentheses
DisplayPlayerInfo(; // Missing closing parenthesis
displayplayerinfo(); // Wrong capitalization
```

**✅ Correct Version:**
```csharp
DisplayPlayerInfo(); // Correct method call syntax
```

**Prevention Added:** Method calling examples throughout Session03 with syntax emphasis.

## Validation System Error Catching

Our new validation system helps catch these errors by:

1. **Compilation Checks**: Validates that code compiles without errors
2. **Syntax Guidance**: Provides specific error messages for common mistakes
3. **Progressive Feedback**: Encourages testing after each TODO section
4. **Visual Confirmation**: Inspector shows when variables are correctly declared

## Teaching Strategy Integration

### **For Instructors:**
- **Anticipate Errors**: Use this guide to identify potential student issues early
- **Preventive Teaching**: Address these mistakes before they occur
- **Quick Reference**: Use during lab sessions to diagnose student problems

### **For Students:**
- **Error Messages**: When you see red errors, check this common list first
- **Validation Tool**: Use the "Validate My Work" feature to catch mistakes
- **Don't Panic**: These errors are normal and part of learning!

This error prevention system is integrated into the improved course materials and validation systems.