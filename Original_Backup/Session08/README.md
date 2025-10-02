# Session 08: Data Persistence & Final Project
*CRE132 Game Development Fundamentals - Northern Irish University*

## 🎯 Session Overview
Session 08 completes the CRE132 course by focusing on **data persistence systems** and creating a **complete mini-game project** that integrates all concepts learned throughout the course. Students will master file I/O operations, JSON serialisation, PlayerPrefs, Dictionary management, and professional game development practices.

---

## 📚 Core Learning Objectives

### **Technical Skills**
- **File I/O Operations**: Read and write files using Unity's persistent data path
- **JSON Serialisation**: Convert complex C# objects to/from JSON for save systems
- **PlayerPrefs Management**: Handle simple settings and preferences persistence
- **Dictionary Systems**: Implement fast data lookup and management systems
- **Error Handling**: Robust file operations with proper exception handling
- **Game Architecture**: Professional patterns for data-driven game systems

### **Unity Integration**
- **Persistent Data Path**: Understanding Unity's file system locations
- **JsonUtility**: Unity's built-in JSON serialisation system
- **PlayerPrefs**: Unity's cross-platform preference storage
- **Inspector Integration**: Viewing and debugging data structures
- **Scene Persistence**: Maintaining data across game sessions

### **Programming Concepts**
- **Serialisation/Deserialisation**: Converting objects to storable formats
- **Data Structures**: Choosing appropriate collections for different use cases
- **Exception Handling**: Try-catch blocks for robust error management
- **Performance Considerations**: Efficient data access and storage patterns
- **Code Architecture**: Organising systems for maintainability and scalability

---

## 🗂️ Session Files Structure

### **Demonstration Scripts**
```
Session08/
├── FileManager.cs              # Basic file I/O operations
├── PlayerData.cs               # Serialisable data class for JSON
├── JSONManager.cs              # Complete JSON save/load system
├── PlayerPrefsManager.cs       # Settings and preferences management
├── DictionaryManager.cs        # Dictionary operations and management
├── DataQuestGame.cs           # Complete mini-game integration
└── Session08_StudentExercise.cs # TODO-based learning exercises
```

### **Key Components**

#### **FileManager.cs**
- Basic file reading and writing operations
- Error handling for file operations
- Unity persistent data path usage
- File existence checking and management

#### **JSONManager.cs + PlayerData.cs**
- Complex data structure serialisation
- Auto-save functionality with timers
- JSON conversion and file management
- Player progress and game state persistence

#### **PlayerPrefsManager.cs**
- Settings and preferences storage
- Cross-platform data persistence
- Key-value pair management
- Data type conversion for PlayerPrefs limitations

#### **DictionaryManager.cs**
- Fast data lookup systems
- Item databases and configuration management
- Dynamic data modification
- Performance-optimised data access

#### **DataQuestGame.cs**
- Complete mini-game implementation
- Integration of all course concepts
- Professional game architecture patterns
- Real-world development practices

---

## 🎮 Complete Mini-Game: "Data Quest"

### **Game Features**
- **Player Movement**: WASD controls with smooth movement
- **Collectible System**: Items with different rarities and values
- **Inventory Management**: Persistent item collection
- **Achievement System**: Unlockable achievements with progress tracking
- **Save/Load Functionality**: Complete game state persistence
- **Settings Management**: Volume, graphics, and control preferences
- **Statistics Tracking**: Comprehensive player data recording

### **Technical Implementation**
- **Object-Oriented Design**: Clean class hierarchies and inheritance
- **Data Persistence**: Multiple save/load systems working together
- **Error Recovery**: Graceful handling of corrupted or missing save data
- **Performance Optimisation**: Efficient data structures and access patterns
- **Professional Practices**: Comprehensive documentation and code organisation

---

## 🔧 Technical Demonstrations

### **File I/O Operations**
```csharp
// Writing to file with error handling
try 
{
    string content = "Game data here";
    File.WriteAllText(Application.persistentDataPath + "/save.txt", content);
}
catch (Exception ex) 
{
    Debug.LogError($"Save failed: {ex.Message}");
}
```

### **JSON Serialisation**
```csharp
// Complex object to JSON
PlayerData data = new PlayerData();
string json = JsonUtility.ToJson(data, true);
File.WriteAllText(savePath, json);

// JSON back to object
string loadedJson = File.ReadAllText(savePath);
PlayerData loadedData = JsonUtility.FromJson<PlayerData>(loadedJson);
```

### **PlayerPrefs Management**
```csharp
// Save preferences
PlayerPrefs.SetFloat("MasterVolume", 0.8f);
PlayerPrefs.SetInt("GraphicsQuality", 2);
PlayerPrefs.Save(); // Force write to disk

// Load with defaults
float volume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
int quality = PlayerPrefs.GetInt("GraphicsQuality", 1);
```

### **Dictionary Operations**
```csharp
// Fast item lookup
Dictionary<string, ItemData> itemDatabase = new Dictionary<string, ItemData>();
itemDatabase["sword_basic"] = new ItemData("Iron Sword", 100);

// Efficient data access
if (itemDatabase.ContainsKey("sword_basic"))
{
    ItemData sword = itemDatabase["sword_basic"];
    Debug.Log($"Found: {sword.name}");
}
```

---

## 📋 Student Exercise Structure

### **Progressive TODO System**
The student exercise file contains **18 comprehensive TODO sections** that guide students through:

1. **Data Structure Design** (TODOs 1-2): Creating serialisable classes
2. **System Initialisation** (TODOs 3-4): Setting up game systems
3. **File Operations** (TODO 5): Basic file I/O implementation
4. **JSON Systems** (TODO 6): Save/load with JSON serialisation
5. **PlayerPrefs Usage** (TODO 7): Settings management
6. **Dictionary Management** (TODO 8): Data lookup systems
7. **Game Integration** (TODOs 9-16): Complete game system implementation
8. **Advanced Features** (TODOs 17-18): Custom systems and progress tracking

### **Learning Scaffolding**
- **Guided Implementation**: Step-by-step TODO completion
- **Error Prevention**: Common mistakes highlighted and prevented
- **Testing Integration**: Built-in testing methods for each system
- **Progress Tracking**: Completion checklists and validation
- **Professional Practices**: Industry-standard coding patterns

---

## 🎯 Course Integration

### **Previous Session Concepts Applied**
- **Session 01**: C# basics, variables, MonoBehaviour lifecycle
- **Session 02**: Operators, input handling, conditional logic
- **Session 03**: Loops, methods, string manipulation
- **Session 04**: Collections, arrays, lists, movement systems
- **Session 05**: Classes, objects, constructors, access modifiers
- **Session 06**: Inheritance, polymorphism, abstract classes
- **Session 07**: Interfaces, switch statements, state management

### **Professional Development Skills**
- **Code Organisation**: Clear structure and documentation
- **Error Handling**: Robust exception management
- **Performance Awareness**: Efficient data operations
- **User Experience**: Graceful data recovery and validation
- **Testing Methodology**: Comprehensive system validation
- **Industry Practices**: Professional game development patterns

---

## ✅ Success Criteria

### **Technical Mastery**
- [ ] **File I/O**: Can read/write files with proper error handling
- [ ] **JSON Serialisation**: Can persist complex object hierarchies
- [ ] **PlayerPrefs**: Can manage settings and simple preferences
- [ ] **Dictionaries**: Can implement efficient data lookup systems
- [ ] **Integration**: Can combine all systems into a working game

### **Unity Proficiency**
- [ ] **Data Paths**: Understands Unity's file system locations
- [ ] **Serialisation**: Can use Unity's JsonUtility effectively
- [ ] **Inspector**: Can debug data structures in real-time
- [ ] **Performance**: Understands data operation implications
- [ ] **Architecture**: Can design maintainable system hierarchies

### **Professional Practices**
- [ ] **Documentation**: Comprehensive XML comments and README files
- [ ] **Error Prevention**: Robust validation and exception handling
- [ ] **Code Quality**: Clean, readable, and maintainable implementations
- [ ] **Testing**: Systematic validation of all data operations
- [ ] **Portfolio Ready**: Complete project suitable for demonstration

---

## 🎓 Course Completion

**Congratulations!** By completing Session 08, you have mastered:

- **Complete C# Programming**: From basic syntax to advanced object-oriented design
- **Unity Game Development**: Professional development workflows and best practices
- **Data Systems Engineering**: Comprehensive persistence and management systems
- **Professional Practices**: Industry-standard coding, documentation, and architecture
- **Portfolio Development**: Complete project demonstrating all learned concepts

### **Next Steps**
- **Expand Your Project**: Add advanced features like networking, AI, or procedural generation
- **Explore Advanced Unity**: Animation systems, physics, rendering pipelines
- **Join Communities**: Unity forums, game development Discord servers, local meetups
- **Build Portfolio**: Showcase your completed projects to potential employers
- **Continue Learning**: Advanced courses in specialised areas like VR, mobile, or console development

---

*Session 08 - CRE132 Game Development Fundamentals*  
*Northern Irish University - AI and Games Department*  
*Course Completion: Data Persistence & Professional Development*