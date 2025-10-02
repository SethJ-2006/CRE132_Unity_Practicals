# Session 06: Advanced Object-Oriented Programming

## 🎯 **Quick Overview**

This session teaches advanced OOP concepts essential for professional game development:
- **Inheritance** - Creating specialised classes from base classes
- **Polymorphism** - Same interface, different implementations  
- **Abstract Classes** - Defining contracts for child classes
- **Method Overriding** - Customising parent class behaviour

## 📁 **Files in This Session**

### **📖 Learning Materials**
- `Session06_Practical.md` - Complete practical guide with Unity setup
- `README.md` - This overview document

### **💻 Demonstration Scripts**
- `InheritanceBasics.cs` - Enemy hierarchy with Zombie, Robot, and Wizard classes
- `PolymorphismExample.cs` - Battle simulation showing polymorphism in action
- `AbstractClassDemo.cs` - Weapon system using abstract classes and methods

### **✏️ Student Exercise**
- `Session06_StudentExercise.cs` - Comprehensive TODO-based exercises

## 🎮 **What You'll Build**

### **Enemy System Hierarchy**
```
Enemy (base class)
├── Zombie (shamble, bite attacks)
├── Robot (laser attacks, scanning)
└── Wizard (magic spells, mana system)
```

### **Weapon System (Abstract Classes)**
```
Weapon (abstract base)
├── Sword (slashing, sharpening)
├── Bow (arrows, aiming)
└── MagicStaff (spells, channelling)
```

### **Student Exercises**
- Vehicle hierarchy (Car, Motorcycle, Truck)
- Character classes (Warrior, Mage, Archer)  
- Shape system with mathematical calculations
- Final challenge: Complete battle system

## 🔑 **Key Learning Points**

### **Inheritance Benefits**
- **Code Reuse** - Child classes inherit parent properties/methods
- **Consistent Interface** - All enemies have health, damage, Attack()
- **Specialisation** - Each child class adds unique behaviour

### **Polymorphism Power**
- **Same Method Call** - `enemy.Attack()` works for all enemy types
- **Different Behaviour** - Each enemy attacks uniquely
- **Flexible Collections** - Store different types in same list

### **Abstract Classes**
- **Enforce Implementation** - Child classes MUST implement abstract methods
- **Provide Structure** - Define common properties and methods
- **Professional Patterns** - Used throughout game engines

## 🛠️ **Unity Integration**

### **MonoBehaviour Inheritance**
Every Unity script inherits from MonoBehaviour:
```csharp
public class MyScript : MonoBehaviour // Inheritance!
{
    // Inherits Start(), Update(), OnCollisionEnter(), etc.
}
```

### **Component System**
Unity's components use polymorphism:
```csharp
// Same interface, different implementations
Collider boxCollider = GetComponent<BoxCollider>();
Collider sphereCollider = GetComponent<SphereCollider>();
```

## 🎯 **Real-World Applications**

### **Game Development**
- **Character Systems** - Player, NPC, Enemy hierarchies
- **Weapon/Item Systems** - Base item with specialised types
- **AI Behaviours** - Different AI types sharing common interface
- **UI Systems** - Button, Slider, Toggle all inherit from UI base

### **Professional Benefits**
- **Maintainable Code** - Easy to add new types without changing existing code
- **Team Collaboration** - Clear structure for multiple developers
- **Engine Integration** - Understanding how game engines work internally

## ✅ **Session Completion Checklist**

- [ ] **Read** `Session06_Practical.md` for detailed explanations
- [ ] **Study** all demonstration scripts and run them in Unity
- [ ] **Complete** all TODO sections in `Session06_StudentExercise.cs`
- [ ] **Test** each exercise using Inspector checkboxes
- [ ] **Understand** inheritance, polymorphism, and abstract classes
- [ ] **Ready** for Session 07 (Interfaces & Game Management)

## 🔄 **Connection to Previous Sessions**

**Builds Upon:**
- **Session 05**: Basic OOP (classes, objects, constructors)
- **Session 04**: Collections (List<Enemy> for polymorphism)
- **Session 03**: Methods (virtual/override method concepts)

**Prepares For:**
- **Session 07**: Interfaces, Switch Statements, Game State Management
- **Session 08**: Complete systems integration and final project

## 🆘 **Common Issues & Solutions**

### **Inheritance Problems**
- **"No constructor" error** → Use `: base(parameters)` in child constructor
- **Method not overriding** → Add `virtual` to parent, `override` to child

### **Polymorphism Issues**  
- **Same behaviour for all** → Check you're using `override` in child classes
- **Cannot add to list** → Use parent type: `List<Enemy>` not `List<Zombie>`

### **Abstract Class Confusion**
- **Cannot instantiate** → Abstract classes can't be created directly
- **Must implement** → Child classes MUST implement all abstract methods

---

**🎓 Ready to Start?** Open `Session06_Practical.md` for detailed instructions!

**Next Session Preview**: Session 07 covers Interfaces, Switch Statements, and Game State Management - the tools for creating complete, professional game systems.

---

*Session 06 - Advanced Object-Oriented Programming*  
*CRE132 Game Development Fundamentals*  
*Learn inheritance, polymorphism, and abstract classes through game development*