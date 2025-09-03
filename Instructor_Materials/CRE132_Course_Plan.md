# CRE132 Unity Beginner Coding Course Plan

## Course Overview
This Unity 2D project provides a structured progression through fundamental programming concepts using C# and MonoBehaviour scripts. Each scene focuses on specific coding concepts whilst building simple, interactive experiences.

## Learning Objectives
By the end of this course, students will:
- Understand basic C# syntax and programming concepts
- Know how to work with Unity's MonoBehaviour lifecycle
- Be able to handle user input and create interactive experiences
- Understand object-oriented programming principles
- Create simple game mechanics and systems

## 🔑 Critical Teaching Requirements

### **Tool Integration Mastery**
**Essential for Student Success - Every Session Must Include:**

#### **Unity Workflow Clarity**
- How to navigate Unity interface and project structure
- Script attachment process to GameObjects
- Console window usage for Debug.Log output and error messages
- Inspector integration for public variables and component management
- Scene management and Play mode testing

#### **Visual Studio Code Integration**  
- Opening scripts from Unity (double-click process)
- Understanding syntax highlighting and colour coding
- Save/test cycle between VS Code and Unity
- Error recognition (red squiggly lines, compilation messages)
- TODO completion with exact code examples

#### **Student Instruction Standards**
- **Step-by-step TODO completion**: Exact before/after code examples
- **Common error prevention**: Syntax mistakes with solutions
- **Tool-specific troubleshooting**: Both Unity and VS Code issues
- **Measurable success criteria**: Specific checkboxes for each tool interaction
- **Professional coding practices**: Proper commenting, naming conventions, code organisation

**⚠️ Implementation Note**: Session 1 demonstrates the gold standard for these requirements - all subsequent sessions must maintain this level of instructional clarity.

## 8-Session Course Structure
*Condensed to cover all W3Schools C# concepts within Unity context*

### Session 1: C# Fundamentals in Unity
**W3Schools Topics**: Syntax, Variables, Data Types, Output, Comments
**Unity Scene**: `01_CSharp_Basics`
**Scripts**: `CSharpBasics.cs`, `VariableExplorer.cs`

**Core Concepts:**
- MonoBehaviour lifecycle (Start, Update)
- C# syntax and structure
- Variables: int, float, string, bool, char
- Constants and readonly variables
- Debug.Log vs Console.WriteLine
- Comments (single-line, multi-line)
- Variable naming conventions
- Type conversion (implicit/explicit casting)

### Session 2: Operators, Input & Control Flow
**W3Schools Topics**: Operators, User Input, Math, If...Else, Booleans
**Unity Scene**: `02_Control_Flow`
**Scripts**: `OperatorDemo.cs`, `InputController.cs`, `DecisionMaker.cs`

**Core Concepts:**
- Arithmetic operators (+, -, *, /, %, ++, --)
- Assignment operators (=, +=, -=, etc.)
- Comparison operators (==, !=, <, >, <=, >=)
- Logical operators (&&, ||, !)
- Unity Input System basics
- If, else if, else statements
- Ternary operator (? :)
- Boolean logic and conditions

### Session 3: Loops, Strings & Methods
**W3Schools Topics**: While Loop, For Loop, Strings, Methods
**Unity Scene**: `03_Loops_Methods`
**Scripts**: `LoopExamples.cs`, `StringOperations.cs`, `MethodLibrary.cs`

**Core Concepts:**
- For loops (for, foreach)
- While and do-while loops
- String manipulation (concatenation, interpolation, length, substring)
- Method creation and calling
- Parameters and return values
- Method overloading
- Static vs instance methods
- Scope and lifetime

### Session 4: Arrays, Lists & Movement
**W3Schools Topics**: Arrays, Lists (Collections)
**Unity Scene**: `04_Collections_Movement`
**Scripts**: `ArrayDemo.cs`, `ListManager.cs`, `PlayerMovement.cs`

**Core Concepts:**
- Array declaration, initialisation, and access
- Multi-dimensional arrays
- List<T> operations (Add, Remove, Contains, Count)
- Transform manipulation in Unity
- Time.deltaTime for frame-rate independence
- Boundary checking and constraints
- Iterating through collections

### Session 5: Classes, Objects & Interaction
**W3Schools Topics**: Classes, Objects, Constructors, Access Modifiers
**Unity Scene**: `05_OOP_Basics`
**Scripts**: `Character.cs`, `Player.cs`, `Collectible.cs`, `GameItem.cs`

**Core Concepts:**
- Class definition and instantiation
- Fields, properties, and methods
- Constructors (default and parameterised)
- Access modifiers (public, private, protected)
- Object interaction and communication
- Collision detection (OnTriggerEnter2D)
- Component-based architecture

### Session 6: Inheritance, Polymorphism & Game Systems
**W3Schools Topics**: Inheritance, Polymorphism, Abstract Classes
**Unity Scene**: `06_Advanced_OOP`
**Scripts**: `Enemy.cs`, `Shooter.cs`, `Projectile.cs`, `HealthSystem.cs`

**Core Concepts:**
- Class inheritance (base classes, derived classes)
- Virtual and override methods
- Polymorphism in practice
- Abstract classes and methods
- Prefab instantiation and destruction
- Basic shooting mechanics
- Health and damage systems

### Session 7: Interfaces, Switch & Game Management
**W3Schools Topics**: Interface, Switch Statements, Exception Handling
**Unity Scene**: `07_Game_Management`
**Scripts**: `ICollectable.cs`, `GameManager.cs`, `StateManager.cs`, `UIController.cs`

**Core Concepts:**
- Interface definition and implementation
- Switch statements and pattern matching
- Game state management with enums
- UI integration (Canvas, Text, Buttons)
- Try-catch exception handling
- Scene management basics
- Singleton pattern introduction

### Session 8: File I/O, Data Persistence & Final Project
**W3Schools Topics**: Files, Data Structures, Review & Integration
**Unity Scene**: `08_Data_Persistence`
**Scripts**: `SaveSystem.cs`, `PlayerData.cs`, `GameStats.cs`, `MiniGame.cs`

**Core Concepts:**
- File reading and writing in Unity
- JSON serialisation for save data
- PlayerPrefs for simple persistence
- Dictionary usage for data storage
- Creating a complete mini-game
- Code organisation and best practices
- Performance considerations

## W3Schools C# Concepts Coverage ✅

Our Unity course comprehensively covers all W3Schools C# topics:

**✅ Basics**: Syntax, Variables, Data Types, Type Casting, User Input, Operators, Math, Strings, Booleans, Comments
**✅ Control Flow**: If...Else, Switch, While Loop, For Loop  
**✅ Methods**: Method creation, parameters, return values, overloading
**✅ OOP**: Classes, Objects, Constructors, Access Modifiers, Properties, Inheritance, Polymorphism, Abstraction, Interfaces
**✅ Collections**: Arrays, Lists
**✅ Advanced**: File I/O, Exception Handling, Data Structures

## Assessment Opportunities

### Practical Exercises (Sessions 2, 4, 6, 8)
- **Session 2**: Create a simple decision-making game using conditions
- **Session 4**: Build a collection-based inventory system  
- **Session 6**: Design an inheritance-based character system
- **Session 8**: Complete mini-game project integrating all concepts

### Code Reviews
- Peer review sessions after each major session
- Best practice discussions and debugging workshops

## Course Timeline: 8 Sessions

**Sessions 1-2**: Foundations (C# basics, operators, control flow)
**Sessions 3-4**: Core Programming (loops, methods, collections, movement)  
**Sessions 5-6**: Object-Oriented Programming (classes, inheritance, polymorphism)
**Sessions 7-8**: Advanced Systems (interfaces, file I/O, complete project)

## Technical Requirements

### Unity Setup
- Unity 6.1 with 2D URP template
- Input System package
- TextMeshPro (for UI text)

### Graphics Assets
- Unity 2D sprite primitives
- ProBuilder for geometric shapes
- Free Unity asset store packages where appropriate
- Minimalist/greybox aesthetic focus

### Coding Standards
- Clear, readable variable names
- Proper commenting
- Consistent indentation
- Region organisation for larger scripts

## Project Structure
```
Assets/
└── _Game/
    ├── Code/
    │   ├── Core/           # Reusable systems
    │   ├── Player/         # Player-specific scripts
    │   ├── UI/            # User interface scripts
    │   ├── Utilities/     # Helper and utility classes
    │   └── Scenes/        # Scene-specific scripts
    ├── Graphics/
    │   ├── Materials/
    │   ├── Sprites/
    │   └── Animations/
    └── Scenes/
        ├── 01_CSharp_Basics.unity
        ├── 02_Control_Flow.unity
        ├── 03_Loops_Methods.unity
        ├── 04_Collections_Movement.unity
        ├── 05_OOP_Basics.unity
        ├── 06_Advanced_OOP.unity
        ├── 07_Game_Management.unity
        └── 08_Data_Persistence.unity
```

---
*Last updated: July 30, 2025*
*Course: CRE132 - Game Development Fundamentals*
