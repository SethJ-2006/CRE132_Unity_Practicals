# CRE132 Code Complexity Evaluation Framework

## 📊 **Educational Complexity Scoring Matrix**

### **Complexity Factors for Beginner Programming**

#### **1. Syntactic Complexity (Weight: 25%)**
- **Lines of code per concept** (more lines = higher complexity)
- **Nesting levels** (if/for/while inside each other)
- **Number of new keywords** introduced simultaneously
- **Punctuation density** (brackets, semicolons, operators)

#### **2. Conceptual Complexity (Weight: 35%)**
- **New concepts per exercise** (ideal: 1-2 max for beginners)
- **Abstract thinking required** (concrete vs abstract concepts)
- **Prerequisites assumed** (builds on how many prior concepts)
- **Mental model complexity** (how many things to track mentally)

#### **3. Cognitive Load (Weight: 25%)**
- **Working memory demands** (how much to remember simultaneously)
- **Context switching** (jumping between different ideas)
- **Problem decomposition required** (breaking down complex tasks)
- **Error recovery difficulty** (how hard to fix when wrong)

#### **4. Unity-Specific Complexity (Weight: 15%)**
- **Unity API knowledge required** (MonoBehaviour, GameObject, etc.)
- **Inspector interaction complexity** (public variables, components)
- **Scene setup requirements** (GameObjects, attachments)
- **Unity workflow understanding** (Play mode, Console, etc.)

### **Scoring Scale (1-10)**

#### **Level 1-2: Absolute Beginner** ✅
- Single concept introduction
- Concrete, visible examples
- Step-by-step guidance
- Immediate feedback possible

#### **Level 3-4: Novice** ✅
- 2 concepts combined carefully
- Some abstraction with concrete examples
- Clear TODO structure
- Error prevention built-in

#### **Level 5-6: Developing** ⚠️
- Multiple concept integration
- Requires planning ahead
- Some independent problem-solving
- Abstract thinking emerging

#### **Level 7-8: Intermediate** ❌ (Too high for CRE132)
- Complex concept combinations
- Significant abstraction
- Multi-step problem solving
- Design decisions required

#### **Level 9-10: Advanced** ❌ (Completely inappropriate)
- Multiple advanced concepts
- High abstraction level
- Independent system design
- Professional-level thinking

### **Target Complexity Distribution for CRE132**

| Session | Target Level | Justification |
|---------|-------------|---------------|
| **Session 01** | Level 1-2 | First exposure to programming |
| **Session 02** | Level 2-3 | Basic logic, still very concrete |
| **Session 03** | Level 3-4 | First abstractions (methods) |
| **Session 04** | Level 4-5 | Collections, more planning needed |
| **Session 05** | Level 4-5 | Basic OOP, concrete objects |
| **Session 06** | Level 5-6 | Advanced OOP, significant abstraction |
| **Session 07** | Level 6-7 | Complex systems, design thinking |
| **Session 08** | Level 6-7 | Integration project, synthesis |

## 🔍 **Evaluation Methodology**

### **Code Example Analysis Checklist**
For each code example, evaluate:

1. **Can a complete beginner understand this without prior programming experience?**
2. **How many new concepts are introduced simultaneously?**
3. **Is the example concrete and relatable?**
4. **Can students predict what will happen before running the code?**
5. **If they make a mistake, can they easily identify and fix it?**

### **Exercise Complexity Assessment**
For each TODO exercise, evaluate:

1. **Is the task clearly defined with specific, measurable outcomes?**
2. **Can students complete it by following the pattern shown in examples?**
3. **Are the steps small enough that failure points are obvious?**
4. **Is there exactly one main concept being practiced (not multiple)?**
5. **Can success be immediately validated (visible output, Inspector change)?**

## 🎯 **Red Flags to Watch For**

### **Immediate Complexity Issues:**
- ❌ **Magic Numbers**: Unexplained values in code
- ❌ **Implicit Knowledge**: Assuming students know Unity workflows
- ❌ **Concept Leaking**: Advanced concepts mentioned prematurely
- ❌ **Multiple New Syntaxes**: Too many new symbols/keywords at once

### **Cognitive Overload Symptoms:**
- ❌ **Too Many Variables**: More than 3-4 variables to track mentally
- ❌ **Deep Nesting**: More than 2 levels of if/for/while nesting
- ❌ **Long Methods**: More than 10-12 lines in student exercises
- ❌ **Abstract Examples**: Concepts not tied to concrete, relatable scenarios

### **Unity-Specific Complexity Issues:**
- ❌ **Workflow Assumptions**: Expecting students to know Inspector, Console, etc.
- ❌ **Component Complexity**: Multiple components or complex GameObject hierarchies
- ❌ **API Overload**: Too many Unity methods/properties introduced at once
- ❌ **Setup Complexity**: Requiring complex scene or project setup

## 📈 **Complexity Progression Principles**

### **Appropriate Progression:**
1. **Concrete → Abstract**: Start with visible, tangible examples
2. **Simple → Complex**: Add one layer of complexity at a time  
3. **Guided → Independent**: Reduce scaffolding gradually
4. **Practice → Application**: Master basics before creative application

### **Signs of Good Complexity Management:**
- ✅ Students can predict code behavior before running it
- ✅ Error messages make sense and guide toward solutions
- ✅ Each exercise builds directly on the previous one
- ✅ Students finish exercises feeling confident, not frustrated
- ✅ Concepts feel like natural progressions, not sudden jumps

This framework will guide our detailed evaluation of each session's complexity level.