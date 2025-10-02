using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CRE132 Session 1: C# Fundamentals in Unity
/// 
/// This script demonstrates core C# concepts within Unity's MonoBehaviour framework.
/// 
/// W3Schools Topics Covered:
/// - C# Syntax and Structure
/// - Comments (single-line and multi-line)
/// - Basic Unity MonoBehaviour lifecycle
/// - Debug output vs Console output
/// 
/// Learning Objectives:
/// 1. Understand basic C# syntax and Unity script structure
/// 2. Learn the difference between Start() and Update() methods
/// 3. Use Debug.Log() for Unity console output
/// 4. Apply proper commenting practices
/// 5. Understand using statements and namespaces
/// </summary>
public class CSharpBasics : MonoBehaviour
{
    #region Unity MonoBehaviour Lifecycle
    
    /// <summary>
    /// Start() is called once when the GameObject becomes active
    /// This is similar to a constructor but happens in Unity's lifecycle
    /// Perfect for initialisation that needs Unity systems to be ready
    /// </summary>
    void Start()
    {
        // Single-line comment: This runs once at the beginning
        Debug.Log("=== CRE132 Session 1: C# Fundamentals ===");
        
        /*
         * Multi-line comment:
         * This is useful for longer explanations
         * or when you need to comment out multiple lines of code
         * Notice how it's formatted for readability
         */
        
        Debug.Log("Start() method executed - this runs once when the object becomes active");
        
        // Call our demonstration methods
        DemonstrateSyntax();
        ExplainComments();
        ShowUnitySpecificConcepts();
    }
    
    /// <summary>
    /// Update() is called once per frame
    /// This runs continuously while the GameObject is active
    /// Perfect for ongoing logic like input checking or animations
    /// </summary>
    void Update()
    {
        // This would run every frame - but we'll keep it simple for now
        // Uncomment the line below to see how often Update() runs (warning: lots of output!)
        // Debug.Log("Update() running at " + Time.time + " seconds");
    }
    
    #endregion
    
    #region C# Syntax Demonstration
    
    /// <summary>
    /// Demonstrates basic C# syntax rules and conventions
    /// Shows how methods are structured and called
    /// </summary>
    void DemonstrateSyntax()
    {
        Debug.Log("--- C# Syntax Demonstration ---");
        
        // C# is case-sensitive - these are different:
        string myVariable = "Hello";
        string MyVariable = "World";
        
        Debug.Log("Case sensitivity: " + myVariable + " vs " + MyVariable);
        Debug.Log("Every C# statement ends with a semicolon");
        
        // Method calls require parentheses, even with no parameters
        ShowMethodCall();
    }
    
    /// <summary>
    /// A simple method to demonstrate method calling syntax
    /// Methods can be public (accessible from other scripts) or private (only within this script)
    /// </summary>
    void ShowMethodCall()
    {
        Debug.Log("This message comes from ShowMethodCall() method");
    }
    
    #endregion
    
    #region Comments and Documentation
    
    /// <summary>
    /// Demonstrates different types of comments and their uses
    /// XML documentation comments (///) provide IntelliSense tooltips
    /// </summary>
    void ExplainComments()
    {
        Debug.Log("--- Comments and Documentation ---");
        
        // Single-line comment: Use for brief explanations
        int number = 42;
        
        /*
         * Multi-line comments: Use for longer explanations
         * Great for explaining complex logic or temporarily disabling code
         */
        
        Debug.Log("Number value: " + number);
        
        // TODO: Common pattern for marking future work
        // FIXME: Pattern for marking bugs to fix
        // NOTE: For important information
        
        /* 
         * Commented out code example:
         * Debug.Log("This line won't execute");
         */
    }
    
    #endregion
    
    #region Unity-Specific Concepts
    
    /// <summary>
    /// Shows Unity-specific concepts that differ from standard C#
    /// Introduces Unity's component-based architecture
    /// </summary>
    void ShowUnitySpecificConcepts()
    {
        Debug.Log("--- Unity-Specific Concepts ---");
        
        // Unity uses Debug.Log instead of Console.WriteLine
        Debug.Log("This appears in Unity's Console window");
        
        // In regular C#, you'd use:
        // Console.WriteLine("This would appear in a command prompt");
        // But Unity doesn't show command prompts, so we use Debug.Log
        
        // Unity scripts inherit from MonoBehaviour
        Debug.Log("This script inherits from MonoBehaviour class");
        
        // MonoBehaviour gives us access to Unity-specific features:
        Debug.Log("GameObject name: " + gameObject.name);
        Debug.Log("Transform position: " + transform.position);
        
        // Unity's component system - this script IS a component
        Debug.Log("This script is attached as a component to: " + gameObject.name);
    }
    
    #endregion
    
    #region Public Methods for Inspector Testing
    
    /// <summary>
    /// Public method that can be called from other scripts
    /// Also demonstrates method accessibility
    /// </summary>
    public void PublicMethodExample()
    {
        Debug.Log("This public method was called from outside this script!");
    }
    
    /// <summary>
    /// Method to demonstrate the difference between public and private
    /// This one is private - only usable within this script
    /// </summary>
    private void PrivateMethodExample()
    {
        Debug.Log("This private method can only be called from within CSharpBasics script");
    }
    
    #endregion
}