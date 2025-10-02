# CRE132 Session 4: Collections & Movement Practical

## 🎯 **Learning Objectives**
By the end of this practical, you will understand:
- Arrays for storing fixed collections of data
- Lists for dynamic collections that can grow and shrink
- Unity's Transform component for positioning and moving objects
- Basic 2D movement patterns and player control
- Managing collections of GameObjects in your games
- When to use arrays vs lists in game development

---

## 📚 **Key Concepts to Learn**

### **Arrays - Fixed Size Collections**
Arrays store multiple values of the same type in a fixed-size container:
```csharp
// Creating arrays
int[] highScores = new int[5];                    // Empty array with 5 slots
string[] playerNames = {"Alice", "Bob", "Charlie"}; // Array with initial values
float[] positions = new float[] {1f, 2.5f, 3f};   // Explicit array creation

// Accessing array elements
playerNames[0] = "Alice";    // First element (index 0)
playerNames[2] = "Charlie";  // Third element (index 2)
int length = playerNames.Length; // Get array size
```

### **Lists - Dynamic Collections**
Lists can grow and shrink during runtime:
```csharp
using System.Collections.Generic; // Required for Lists

// Creating lists
List<string> inventory = new List<string>();
List<int> enemyIDs = new List<int> {1, 2, 3}; // List with initial values

// List methods
inventory.Add("Sword");           // Add item
inventory.Remove("Sword");        // Remove specific item
inventory.RemoveAt(0);           // Remove by index
int count = inventory.Count;      // Get current size
bool hasSword = inventory.Contains("Sword"); // Check if contains item
```

### **Unity Transform Component**
Every GameObject has a Transform that controls its position, rotation, and scale:
```csharp
// Position (where the object is)
transform.position = new Vector3(5f, 2f, 0f);
transform.position += Vector3.right * 2f; // Move right by 2 units

// Rotation (how the object is rotated)
transform.rotation = Quaternion.identity; // No rotation
transform.Rotate(0f, 0f, 90f); // Rotate 90 degrees around Z-axis

// Scale (how big the object is)
transform.localScale = new Vector3(2f, 2f, 1f); // Double size in X and Y
```

### **Vector3 - 3D Positions and Directions**
Unity uses Vector3 for positions and directions:
```csharp
Vector3 position = new Vector3(x, y, z);
Vector3 right = Vector3.right;     // (1, 0, 0)
Vector3 up = Vector3.up;           // (0, 1, 0)
Vector3 forward = Vector3.forward; // (0, 0, 1)

// Vector operations
Vector3 distance = pointB - pointA; // Direction from A to B
float magnitude = distance.magnitude; // Distance between points
Vector3 normalized = distance.normalized; // Unit direction vector
```

### **Basic Movement Patterns**
```csharp
// Linear movement
transform.position += Vector3.right * speed * Time.deltaTime;

// Input-based movement
float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrows
Vector3 movement = new Vector3(horizontal, vertical, 0f);
transform.position += movement * speed * Time.deltaTime;

// Circular movement
float angle = Time.time * rotationSpeed;
transform.position = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
```

---

## 🛠️ **Unity Setup Instructions**

### **Step 1: Create GameObject**
1. Right-click in **Hierarchy** → **Create Empty**
2. Rename to `"Session04_CollectionsAndMovement"`

### **Step 2: Add Scripts**
1. Select your GameObject
2. **Add Component** → **New Script**
3. Create these scripts one by one:
   - `ArrayBasics.cs`
   - `ListManagement.cs`
   - `TransformBasics.cs`
   - `MovementController.cs`
   - `Session04_StudentExercise.cs`

### **Step 3: Create Visual Objects for Movement**
1. Right-click in **Hierarchy** → **2D Object** → **Sprite** → **Square**
2. Rename to `"Player"` (this will be used for movement demonstrations)
3. Change the sprite colour in **Sprite Renderer** component for visibility

### **Step 4: Test Each Script**
1. Attach script to GameObject
2. Press **Play**
3. Check **Console** window and **Inspector** changes
4. For movement scripts, watch the objects move in **Scene** view

---

## 🎮 **Practical Examples**

### **Example 1: Player Inventory System**
```csharp
List<string> playerInventory = new List<string>();
playerInventory.Add("Health Potion");
playerInventory.Add("Magic Sword");
playerInventory.Add("Shield");

foreach (string item in playerInventory)
{
    Debug.Log("Player has: " + item);
}
```

### **Example 2: Enemy Spawn Positions**
```csharp
Vector3[] spawnPoints = {
    new Vector3(-5f, 2f, 0f),
    new Vector3(0f, 3f, 0f),
    new Vector3(5f, 1f, 0f)
};

for (int i = 0; i < spawnPoints.Length; i++)
{
    Debug.Log($"Enemy {i + 1} spawns at: {spawnPoints[i]}");
}
```

### **Example 3: Simple Player Movement**
```csharp
void Update()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    
    Vector3 movement = new Vector3(horizontal, vertical, 0f);
    transform.position += movement * 5f * Time.deltaTime;
}
```

### **Example 4: Managing Multiple Enemies**
```csharp
List<GameObject> enemies = new List<GameObject>();

// Add enemies to list
enemies.Add(enemy1);
enemies.Add(enemy2);
enemies.Add(enemy3);

// Move all enemies
foreach (GameObject enemy in enemies)
{
    enemy.transform.position += Vector3.left * enemySpeed * Time.deltaTime;
}
```

---

## 🔧 **Visual Studio Code Instructions**

### **Working with Collections**
1. **Array Declaration**: Always specify the size or initial values
2. **List Import**: Add `using System.Collections.Generic;` at the top
3. **Index Safety**: Always check bounds before accessing elements
4. **Foreach Loops**: Use `foreach` for reading collections, `for` when you need the index

### **Transform Operations**
1. **Vector3 Constructor**: `new Vector3(x, y, z)` - remember the Z coordinate for 2D (usually 0)
2. **Time.deltaTime**: Always multiply movement by `Time.deltaTime` for frame-rate independence
3. **Transform vs LocalTransform**: `transform.position` is world position, `transform.localPosition` is relative to parent

---

## 🚨 **Common Errors & Solutions**

### **Array Index Out of Bounds**
**Problem**: Trying to access an index that doesn't exist
```csharp
int[] scores = new int[3]; // Indices 0, 1, 2 only
int value = scores[5]; // ERROR: Index 5 doesn't exist!
```
**Solution**: Always check array length
```csharp
if (index >= 0 && index < scores.Length)
{
    int value = scores[index]; // Safe access
}
```

### **Null Reference Exception with Lists**
**Problem**: Trying to use a list that hasn't been initialized
```csharp
List<string> items; // Not initialized!
items.Add("Sword"); // ERROR: NullReferenceException
```
**Solution**: Always initialize lists
```csharp
List<string> items = new List<string>(); // Proper initialization
items.Add("Sword"); // Now it works
```

### **Movement Too Fast or Stuttery**
**Problem**: Not using Time.deltaTime for movement
```csharp
// BAD - Framerate dependent
transform.position += Vector3.right * speed;
```
**Solution**: Always use Time.deltaTime
```csharp
// GOOD - Smooth, framerate independent
transform.position += Vector3.right * speed * Time.deltaTime;
```

### **Objects Not Moving**
**Problem**: Movement code not in Update() method
```csharp
void Start()
{
    // This only runs once - object won't keep moving!
    transform.position += Vector3.right;
}
```
**Solution**: Put continuous movement in Update()
```csharp
void Update()
{
    // This runs every frame - smooth movement!
    transform.position += Vector3.right * speed * Time.deltaTime;
}
```

---

## 🎯 **Testing Your Code**

### **Collection Testing Checklist**
- [ ] Arrays show correct length and values in Console
- [ ] Lists can add and remove items successfully
- [ ] No index out of bounds errors
- [ ] Collections display properly in Inspector
- [ ] Foreach loops process all elements

### **Movement Testing Checklist**
- [ ] Objects move smoothly without stuttering
- [ ] Input controls work correctly (WASD or arrow keys)
- [ ] Movement speed is reasonable (not too fast/slow)
- [ ] Objects stay on screen (or implement boundaries)
- [ ] Transform values update in Inspector while playing

### **Visual Verification**
- [ ] Watch objects move in **Scene** view during Play mode
- [ ] Check **Inspector** shows changing Transform values
- [ ] Verify **Console** outputs expected collection information
- [ ] Test different input combinations work correctly

---

## 🏆 **Best Practices**

### **Collection Guidelines**
1. **Use Arrays for**: Fixed-size data that doesn't change (e.g., spawn points, difficulty levels)
2. **Use Lists for**: Dynamic data that grows/shrinks (e.g., inventory, active enemies)
3. **Initialize properly**: Always create new instances before using
4. **Check bounds**: Prevent index errors with proper validation
5. **Use foreach**: When you don't need the index number

### **Movement Guidelines**
1. **Time.deltaTime**: Always use for smooth, frame-rate independent movement
2. **Input.GetAxis()**: Preferred over GetKey() for smooth analog input
3. **Reasonable speeds**: Test different values to find what feels good
4. **Boundaries**: Consider screen edges and play area limits
5. **Null checks**: Verify GameObjects exist before moving them

### **Transform Guidelines**
1. **Cache references**: Store frequently used transforms in variables
2. **World vs Local**: Understand the difference between world and local coordinates
3. **Vector3 shortcuts**: Use Vector3.right, Vector3.up instead of new Vector3(1,0,0)
4. **Magnitude vs SqrMagnitude**: Use SqrMagnitude for distance comparisons (faster)

---

## 🎮 **Game Development Applications**

### **Collections in Games**
- **Inventory Systems**: Lists for player items that can be added/removed
- **Enemy Management**: Arrays for spawn points, Lists for active enemies
- **High Scores**: Arrays for fixed leaderboard positions
- **Quest Systems**: Lists for active quests and completed objectives
- **Weapon Systems**: Arrays for weapon stats, Lists for available weapons

### **Movement in Games**
- **Player Control**: WASD movement for platformers and top-down games
- **Enemy AI**: Patrol patterns, following player, circular orbits
- **Projectiles**: Bullets, arrows, fireballs moving across screen
- **Platforms**: Moving platforms in platformer games
- **Cameras**: Following player, smooth panning effects

### **Transform Applications**
- **Positioning**: Placing objects at specific world coordinates
- **Scaling**: Growing/shrinking effects, size-based power-ups
- **Rotation**: Spinning objects, aiming weapons, rotating obstacles
- **Parenting**: Attaching objects to follow others (weapons to player)

---

## 🔜 **Next Steps**

After completing this session, you'll be ready for **Session 05: OOP Basics**, where you'll learn:
- Classes and objects for better code organization
- Constructors for initializing objects
- Access modifiers (public, private) for data protection
- Creating custom game component systems

---

## 💡 **Practice Challenges**

### **Beginner Challenges**
1. Create an array of 5 enemy names and print them all
2. Make a list of collectible items and add/remove items
3. Move a GameObject using WASD keys

### **Intermediate Challenges**
1. Create a patrol system where an enemy moves between waypoints
2. Build an inventory system that prevents duplicate items
3. Make objects spawn at random positions from an array of locations

### **Advanced Challenges**
1. Create a formation system where multiple objects follow a leader
2. Build a projectile system that manages bullets in a list
3. Implement smooth camera following with position interpolation

---

*Remember: Collections and movement are core game development skills. Master these concepts and you'll be able to create complex, interactive games!*

**🎉 Ready to start coding? Open Unity and create your first script!**