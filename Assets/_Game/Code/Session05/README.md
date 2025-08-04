# Session 05: Object-Oriented Programming (OOP) Basics

## 🎯 **Session Overview**

This session introduces the fundamental concepts of Object-Oriented Programming (OOP) in C# within Unity. Students learn to create classes, instantiate objects, use constructors, implement access modifiers, and understand the difference between static and instance members.

## 📚 **Key Concepts Covered**

### **Classes and Objects**
- Classes as blueprints for creating objects
- Objects as instances of classes with their own data
- Creating multiple objects from the same class
- Understanding object lifecycle and memory management

### **Constructors**
- Default constructors with standard initialization
- Parameterised constructors for custom object creation
- Constructor overloading with different parameter sets
- Constructor chaining and validation
- Unity-specific initialization patterns (since MonoBehaviour can't use standard constructors)

### **Access Modifiers**
- **Public**: Accessible from anywhere (use sparingly for external interfaces)
- **Private**: Only accessible within the same class (preferred default for data protection)
- **Protected**: Accessible within class and derived classes (for inheritance)
- Data encapsulation principles and security benefits

### **Static vs Instance Members**
- **Static**: Shared by all objects of the class (global counters, utility methods)
- **Instance**: Unique to each object (individual data and behavior)
- When to use each type appropriately
- Static constructors and utility classes

## 🛠️ **Files in This Session**

### **📖 Study Materials**
- **`Session05_Practical.md`** - Complete learning guide with examples and Unity setup instructions
- **`README.md`** - This overview file

### **💻 Demonstration Scripts**
- **`ClassBasics.cs`** - Shows fundamental class/object concepts with Enemy and Weapon classes
- **`AccessModifiers.cs`** - Demonstrates secure vs insecure design patterns with bank account examples
- **`ConstructorExamples.cs`** - Multiple constructor patterns with Spaceship and GameCharacter classes
- **`StaticVsInstance.cs`** - Clear comparison of static and instance members with game examples

### **📝 Student Exercise**
- **`Session05_StudentExercise.cs`** - TODO-based exercises covering all OOP basics concepts

## 🎮 **How to Use This Session**

### **For Students:**
1. **Read** `Session05_Practical.md` thoroughly
2. **Attach** demonstration scripts to GameObjects to see OOP concepts in action
3. **Watch** the Console window to understand object creation and interaction
4. **Complete** the student exercise with step-by-step TODO guidance
5. **Test** your implementations using the built-in testing system

### **For Instructors:**
- Each script demonstrates different aspects of OOP with clear, game-focused examples
- Console output shows object creation, method calls, and data manipulation
- Student exercise provides comprehensive hands-on practice
- Built-in testing system validates student implementations

## 🧪 **Practical Examples**

### **Game Development Applications**
- **Enemy Systems**: Individual enemies with shared global statistics
- **Weapon Systems**: Different weapon types with unique properties and shared ammo counters
- **Player Management**: Character data with global game settings
- **Bank Account Security**: Demonstrates data protection principles applicable to save games and user data

### **Real-World Connections**
- **Vehicle Management**: Shows practical class design with validation
- **Security Systems**: Illustrates proper access control and data protection
- **Game Statistics**: Global vs individual data management
- **Utility Classes**: Mathematical and helper functions without object instances

## ✅ **Learning Outcomes**

By completing this session, students will be able to:

### **Create and Use Classes**
- Design classes with appropriate fields, properties, and methods
- Instantiate objects and understand object independence
- Implement multiple objects working together in game systems

### **Implement Constructors**
- Create default and parameterised constructors
- Use constructor overloading for different object creation scenarios
- Validate constructor parameters and handle edge cases
- Apply Unity-specific initialization patterns

### **Apply Access Modifiers**
- Choose appropriate access levels for class members
- Implement data encapsulation and security principles
- Create safe public interfaces while protecting internal data
- Understand inheritance accessibility with protected members

### **Use Static and Instance Members**
- Identify when data should be shared vs individual
- Implement static utility classes and methods
- Create global game managers and counters
- Balance static and instance members in game design

## 🔗 **Connection to Previous Sessions**

- **Session 01-02**: Uses variables, operators, and basic control flow
- **Session 03**: Applies methods and loops within class structures
- **Session 04**: Integrates collections (arrays/lists) as class members

## ➡️ **Preparation for Next Session**

**Session 06: Advanced OOP** will build on these concepts with:
- **Inheritance**: Creating specialized classes from base classes
- **Polymorphism**: Same interface, different implementations
- **Virtual and Override**: Customizing behavior in derived classes
- **Abstract Classes**: Defining contracts for implementation

## 💡 **Key Teaching Tips**

### **Analogies That Work**
- Classes = Blueprints, Objects = Houses built from blueprints
- Access Modifiers = Security levels in a building (lobby=public, office=private, manager area=protected)
- Static vs Instance = Global thermostat vs individual room temperature controls

### **Common Student Mistakes**
- Making everything public (discuss security implications)
- Confusing static and instance access
- Forgetting to instantiate objects before use
- Not understanding constructor parameter validation

### **Debugging Support**
- Extensive Debug.Log output shows object creation and interaction
- Clear error messages for common mistakes
- Built-in validation and testing systems
- Step-by-step TODO structure with specific completion criteria

---

**🎯 Goal**: Master the fundamental building blocks of object-oriented programming that will enable advanced game development patterns and professional code organization.

*Session 05 - Object-Oriented Programming Basics*  
*CRE132 Game Development Fundamentals*  
*Northern Irish University - AI and Games Department*