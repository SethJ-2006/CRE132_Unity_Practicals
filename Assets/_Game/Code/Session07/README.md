# Session 07: Interfaces & Game Management

## 🎯 **Quick Overview**

This session teaches advanced programming concepts essential for professional game development:
- **Interfaces** - Contracts that classes can implement (multiple inheritance capability)
- **Switch Statements** - Elegant conditional logic for complex scenarios
- **Game State Management** - Professional game architecture patterns
- **Design Patterns** - Combining interfaces with inheritance for flexible systems

## 📁 **Files in This Session**

### **📖 Learning Materials**
- `Session07_Practical.md` - Complete practical guide with detailed explanations
- `README.md` - This overview document

### **💻 Demonstration Scripts**
- `InterfaceBasics.cs` - Interface implementation with game entities (IAttackable, IDamageable, IUpgradeable)
- `SwitchStatementDemo.cs` - Switch statements vs if-else chains with input handling examples
- `GameStateManager.cs` - Professional state management system (Menu, Playing, Paused, Game Over)

### **✏️ Student Exercise**
- `Session07_StudentExercise.cs` - Comprehensive TODO-based exercises

## 🎮 **What You'll Build**

### **Interface System**
```
IAttackable - entities that can attack
IDamageable - entities that can take damage  
IUpgradeable - entities that can be enhanced
IHealable - entities that can heal others
```

### **Game State Management**
```
GameState Machine:
MainMenu → Loading → Playing ⇄ Paused → GameOver
    ↓         ↓                           ↓
  Settings  Credits                  MainMenu
```

### **Student Exercises**
- **Inventory System** - ICollectable, IUseable, IValuable interfaces
- **Combat System** - IFighter, IHealable, IMagicUser interfaces  
- **Switch Logic** - Difficulty, quest, and item type processing
- **Mini-Game Manager** - Complete state management implementation

## 🔑 **Key Learning Points**

### **Interfaces vs Inheritance**
| **Inheritance** | **Interfaces** |
|----------------|----------------|
| "IS-A" relationship | "CAN-DO" relationship |
| Single inheritance | Multiple interfaces |
| Shares code | Defines contract |
| `class Dog : Animal` | `class Dog : IRunnable, IBarkable` |

### **Interface Benefits**
- **Multiple Implementation** - Class can implement many interfaces
- **Flexible Design** - Different classes share same interface
- **Polymorphism** - Use interface type for different implementations
- **Professional Patterns** - Used throughout game industry

### **Switch Statement Advantages**
- **Performance** - Faster than long if-else chains
- **Readability** - Clear structure for multiple conditions
- **Maintainability** - Easy to add new cases
- **Type Safety** - Compiler ensures complete coverage

## 🛠️ **Unity Integration**

### **Unity's Built-in Interfaces**
Unity extensively uses interfaces:
```csharp
// UI Event Interfaces
IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler

// Physics Interfaces  
ICollisionHandler, ITriggerHandler

// Animation Interfaces
IAnimationClipSource

// Your classes can implement these!
public class Button : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Handle click
    }
}
```

### **Professional Game Architecture**
- **Component Systems** - Interfaces define component contracts
- **State Machines** - Switch statements handle state transitions
- **Event Systems** - Interfaces for observers and listeners
- **Plugin Architecture** - Interfaces for modular systems

## 🎯 **Real-World Applications**

### **Game Development**
- **Character Systems** - IFighter, IMagicUser, IHealable
- **Item Systems** - IUseable, IEquippable, IStackable
- **AI Systems** - IBehaviour, IDecisionMaker, IPathfinder
- **UI Systems** - IClickable, IDraggable, ISelectable

### **Professional Benefits**
- **Team Development** - Clear contracts between developers
- **Code Reusability** - Same interface, different implementations
- **Testing** - Easy to create mock objects
- **Maintenance** - Changes don't break dependent code

## ✅ **Session Completion Checklist**

- [ ] **Read** `Session07_Practical.md` thoroughly
- [ ] **Study** all demonstration scripts and run them in Unity
- [ ] **Complete** all TODO sections in `Session07_StudentExercise.cs`
- [ ] **Test** each exercise using Inspector checkboxes
- [ ] **Understand** interfaces, switch statements, and state management
- [ ] **Ready** for Session 08 (Final Project & Data Persistence)

## 🔄 **Connection to Previous Sessions**

**Builds Upon:**
- **Session 06**: Advanced OOP (inheritance, polymorphism, abstract classes)
- **Session 05**: Basic OOP (classes, objects, methods)
- **Session 04**: Collections (Lists for interface polymorphism)

**Prepares For:**
- **Session 08**: Complete game project integrating all concepts
- **Final Project**: Professional game development patterns

## 🆘 **Common Issues & Solutions**

### **Interface Problems**
- **"Class doesn't implement interface member"**
  - **Solution**: Implement ALL methods defined in interface
- **"Cannot convert type"**
  - **Solution**: Make sure class implements the interface you're using

### **Switch Statement Issues**
- **Fall-through behavior** → Always include `break;` statements
- **Missing default case** → Include `default:` for unexpected values
- **Wrong data types** → Switch works with int, enum, char, string

### **State Management Problems**
- **States getting stuck** → Always properly exit old state before entering new
- **Input not working** → Check current state in input handling
- **Time.timeScale issues** → Remember to reset to 1f when unpausing

## 🏆 **Professional Development Notes**

### **Industry Standards**
This session teaches concepts used in **all professional game engines**:
- **Unity**: Interface-based component systems, state machines
- **Unreal**: Blueprint interfaces, state tree systems
- **Godot**: Signal systems, node interfaces
- **Custom Engines**: Plugin architectures, modular systems

### **Career Benefits**
Understanding interfaces and state management is **essential** for:
- **Senior Developer Roles** - Architectural decision making
- **Team Leadership** - Designing system contracts
- **Code Reviews** - Identifying design pattern opportunities
- **System Architecture** - Building scalable, maintainable systems

## 📚 **Advanced Concepts Preview**

### **Generic Interfaces**
```csharp
public interface IContainer<T>
{
    void Add(T item);
    T Get(int index);
    bool Contains(T item);
}
```

### **Interface Inheritance**
```csharp
public interface IAdvancedFighter : IFighter
{
    void SpecialAttack();
    void ComboAttack(IFighter[] targets);
}
```

### **Event-Driven Architecture**
```csharp
public interface IEventListener<T>
{
    void OnEvent(T eventData);
}
```

---

**🎓 Ready to Practice?** Open `Session07_StudentExercise.cs` and complete the TODO sections!

**Next Session Preview**: Session 08 will cover File I/O, Data Persistence, and creating a Complete Final Project that integrates ALL concepts learned throughout the course.

---

*Session 07 - Interfaces & Game Management*  
*CRE132 Game Development Fundamentals*  
*Learn professional game architecture through interfaces and state management*