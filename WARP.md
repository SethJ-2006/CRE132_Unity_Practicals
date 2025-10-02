# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

This is **CRE132 Unity Beginner Coding Course** - an educational Unity project teaching C# programming through game development. The project contains 8 progressive sessions, each focusing on specific programming concepts while building playable examples.

**Unity Version:** 6000.1.1f1 (Unity 6)  
**Platform:** Windows (PowerShell environment)  
**Target Audience:** Programming beginners learning C# through Unity

## Development Commands

### Unity Project Operations
```powershell
# Open Unity Editor (from project root)
# Note: Unity Hub should be used to open projects, or Unity Editor directly
# No specific command-line build process - primarily educational/editor-based

# View Console logs in Unity Editor
# Window > General > Console

# Test individual session scripts
# Attach scripts to GameObjects and press Play in Unity Editor
```

### File Navigation
```powershell
# Navigate to specific session materials
Get-ChildItem "Assets\_Game\Code\Session0X\"

# Find all C# scripts in the project
Get-ChildItem -Path "Assets\_Game" -Recurse -Filter "*.cs"

# View instructor materials
Get-ChildItem -Path "Instructor_Materials" -Recurse -Filter "*.md"

# Check project structure
Get-ChildItem -Path "Assets" -Recurse -Directory
```

### Testing Scripts
```powershell
# Unity Console is the primary testing interface
# Scripts use Debug.Log() extensively for output
# No traditional unit testing framework - educational demonstrations via Console output
```

## Code Architecture

### Project Structure
```
Assets/
├── _Game/                          # Main game content
│   └── Code/
│       ├── Scenes/                 # Unity scenes (Game.unity)
│       ├── Session01/              # C# Fundamentals
│       ├── Session02/              # Operators & Control Flow
│       ├── Session03/              # Loops & Methods
│       ├── Session04/              # Collections & Movement
│       ├── Session05/              # OOP Basics
│       ├── Session06/              # Advanced OOP
│       ├── Session07/              # Interfaces & Management
│       └── Session08/              # Data & Final Project
├── Markdown/                       # Markdown display package
└── Settings/                       # Unity project settings

Instructor_Materials/               # Teaching guides and course materials
├── Session01-08/                   # Individual session teaching guides
├── CRE132_Course_Plan.md          # Complete course overview
└── W3Schools_Mapping.md           # W3Schools curriculum alignment
```

### Code Organization Patterns

#### Script Naming Conventions
- **Concept Scripts**: `CSharpBasics.cs`, `ConditionalLogic.cs`, `MathOperators.cs`
- **Exercise Scripts**: `SessionXX_StudentExercise.cs`
- **Demonstration Scripts**: `VariableExplorer.cs`, `InputDetection.cs`

#### Code Structure Patterns
All scripts follow consistent patterns:

```csharp
/// <summary>
/// Comprehensive XML documentation
/// Lists W3Schools topics covered
/// Defines learning objectives
/// </summary>
public class ScriptName : MonoBehaviour
{
    #region Unity Inspector Variables
    [Header("=== DESCRIPTIVE HEADERS ===")]
    public Type publicVariable;
    [SerializeField] private Type serializedPrivate;
    #endregion
    
    #region Unity Lifecycle
    void Start() { /* Initialization and demonstrations */ }
    void Update() { /* Real-time updates and input */ }
    #endregion
    
    #region Demonstration Methods
    void DemonstrateConceptX() { /* Educational examples */ }
    #endregion
}
```

#### Educational Code Features
- **Extensive Debug.Log Usage**: All output goes to Unity Console
- **Inspector Integration**: Public variables for real-time testing
- **Progressive Complexity**: Each session builds on previous concepts
- **TODO-Driven Learning**: Student exercises use TODO comments for guidance
- **Region Organization**: Code organized with #region blocks for clarity

### Key Architectural Elements

#### MonoBehaviour-Centric Design
- All scripts inherit from `MonoBehaviour`
- Heavy use of Unity lifecycle methods (`Start()`, `Update()`)
- Inspector-driven variable modification for live testing

#### Educational Scaffolding
- **Student Exercise Scripts**: Template-based learning with TODO sections
- **Demonstration Scripts**: Complete examples showing concepts in action
- **Progressive Sessions**: Building complexity from variables to complete systems

#### Debugging and Testing Philosophy
- `Debug.Log()` for all output (not `Console.WriteLine`)
- Unity Console window as primary feedback mechanism
- Real-time Inspector variable modification for testing
- Key press demonstrations (`Input.GetKeyDown()`) for interactive learning

## Development Workflow

### For Code Modification
1. **Always test in Unity Editor** - Scripts are designed for Unity environment
2. **Use Unity Console** - Check `Window > General > Console` for all output
3. **Leverage Inspector** - Modify public variables in real-time for testing
4. **Follow session progression** - Each session builds on previous knowledge

### For Adding New Content
1. **Follow naming conventions** - SessionXX_ScriptName.cs
2. **Use extensive XML documentation** - Include learning objectives and W3Schools mapping
3. **Implement Inspector headers** - `[Header("=== DESCRIPTIVE HEADERS ===")]`
4. **Include TODO sections** - For student exercises
5. **Use region organization** - Keep code structured with #region blocks

### For Student Exercise Creation
- **Provide complete examples** alongside TODO exercises
- **Use `[ContextMenu()]`** for bonus methods accessible via Inspector
- **Include grading checklists** in comments
- **Progressive difficulty** - build on previous session concepts

## Important Notes

- **No traditional build process** - This is an educational Unity project focused on editor-based learning
- **PowerShell environment** - Use PowerShell commands for file operations
- **Unity 6 compatibility** - Ensure any modifications work with Unity 6000.1.1f1
- **Educational focus** - Prioritize clarity and progressive learning over performance optimization
- **Markdown integration** - Project includes Markdown display package for in-editor documentation

## Session Content Overview

1. **Session01**: C# syntax, variables, data types, Unity basics
2. **Session02**: Operators, input handling, if/else logic  
3. **Session03**: Loops, strings, custom methods
4. **Session04**: Collections (arrays/lists), Unity Transform
5. **Session05**: OOP fundamentals, classes, constructors
6. **Session06**: Inheritance, polymorphism, game systems
7. **Session07**: Interfaces, switch statements, state management
8. **Session08**: File I/O, data persistence, final project integration

Each session contains practical markdown guides with Unity Editor instructions alongside the C# scripts.