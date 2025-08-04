using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// Demonstrates basic file I/O operations in Unity
/// Covers reading, writing, and managing files in persistent data path
/// Essential for save systems and data persistence
/// </summary>
public class FileManager : MonoBehaviour
{
    [Header("File Operations Demo")]
    [SerializeField] private string fileName = "gamedata.txt";
    [SerializeField] private string testMessage = "Hello from Unity file system!";
    
    [Header("File Status")]
    [SerializeField] private bool fileExists = false;
    [SerializeField] private string filePath = "";
    [SerializeField] private string lastFileContent = "";

    /// <summary>
    /// Unity Start method - runs when the GameObject becomes active
    /// Initialises file system demo and displays current status
    /// </summary>
    void Start()
    {
        Debug.Log("=== FILE MANAGER DEMO STARTED ===");
        
        // Get the full file path
        filePath = Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log($"File will be saved to: {filePath}");
        
        // Check if file already exists
        CheckFileExists();
        
        // Display current file system information
        DisplayFileSystemInfo();
        
        Debug.Log("Press SPACE to write file, R to read file, D to delete file");
    }

    /// <summary>
    /// Unity Update method - handles user input for file operations
    /// </summary>
    void Update()
    {
        // Write file when SPACE is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WriteToFile();
        }
        
        // Read file when R is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadFromFile();
        }
        
        // Delete file when D is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteFile();
        }
        
        // Check file status continuously
        CheckFileExists();
    }

    /// <summary>
    /// Writes text data to a file in the persistent data path
    /// Includes error handling for robust file operations
    /// </summary>
    private void WriteToFile()
    {
        try
        {
            Debug.Log($"Writing to file: {fileName}");
            
            // Add timestamp to make each write unique
            string contentToWrite = $"{testMessage}\nWritten at: {DateTime.Now}\nRandom number: {UnityEngine.Random.Range(1, 1000)}";
            
            // Write all text to file (overwrites existing content)
            File.WriteAllText(filePath, contentToWrite);
            
            Debug.Log("✅ File written successfully!");
            Debug.Log($"Content written: {contentToWrite}");
            
            CheckFileExists();
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error writing file: {ex.Message}");
        }
    }

    /// <summary>
    /// Reads text data from a file and displays it
    /// Includes error handling for missing files
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                Debug.Log($"Reading from file: {fileName}");
                
                // Read all text from file
                string fileContent = File.ReadAllText(filePath);
                lastFileContent = fileContent;
                
                Debug.Log("✅ File read successfully!");
                Debug.Log($"File content:\n{fileContent}");
            }
            else
            {
                Debug.LogWarning("⚠️ File does not exist. Press SPACE to create it first.");
                lastFileContent = "File not found";
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error reading file: {ex.Message}");
            lastFileContent = "Error reading file";
        }
    }

    /// <summary>
    /// Deletes the file if it exists
    /// Includes confirmation and error handling
    /// </summary>
    private void DeleteFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("✅ File deleted successfully!");
                lastFileContent = "";
                CheckFileExists();
            }
            else
            {
                Debug.LogWarning("⚠️ File does not exist, nothing to delete.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"❌ Error deleting file: {ex.Message}");
        }
    }

    /// <summary>
    /// Checks if the file exists and updates the status
    /// </summary>
    private void CheckFileExists()
    {
        fileExists = File.Exists(filePath);
    }

    /// <summary>
    /// Displays useful information about Unity's file system
    /// </summary>
    private void DisplayFileSystemInfo()
    {
        Debug.Log("=== UNITY FILE SYSTEM INFO ===");
        Debug.Log($"Persistent Data Path: {Application.persistentDataPath}");
        Debug.Log($"Data Path: {Application.dataPath}");
        Debug.Log($"Streaming Assets Path: {Application.streamingAssetsPath}");
        Debug.Log($"Temporary Cache Path: {Application.temporaryCachePath}");
        Debug.Log("================================");
    }
}