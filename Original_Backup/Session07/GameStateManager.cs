using UnityEngine;

/// <summary>
/// Professional game state management system.
/// Handles different game phases: Menu, Playing, Paused, Game Over.
/// </summary>
public class GameStateManager : MonoBehaviour
{
    [Header("Game State Management")]
    [SerializeField] private GameState currentState = GameState.MainMenu;
    [SerializeField] private bool testStateTransitions = false;
    [SerializeField] private bool simulateGameplay = false;
    
    [Header("Game Statistics")]
    [SerializeField] private float gameTime = 0f;
    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;
    [SerializeField] private bool showDebugInfo = true;
    
    [Header("Loading State")]
    private float loadingTime = 0f;
    
    void Start()
    {
        Debug.Log("=== GAME STATE MANAGER INITIALIZED ===");
        InitializeGame();
    }
    
    void Update()
    {
        if (testStateTransitions)
        {
            testStateTransitions = false;
            TestAllStateTransitions();
        }
        
        if (simulateGameplay)
        {
            simulateGameplay = false;
            SimulateCompleteGameSession();
        }
        
        // Update current state
        UpdateCurrentState();
        
        // Handle input based on current state
        HandleStateInput();
        
        // Display debug info if enabled
        if (showDebugInfo && Time.time % 5f < Time.deltaTime)
        {
            DisplayCurrentStateInfo();
        }
    }
    
    #region State Management Core
    
    /// <summary>
    /// Changes to a new game state with proper enter/exit handling
    /// </summary>
    public void ChangeState(GameState newState)
    {
        if (currentState == newState)
        {
            Debug.Log("Already in state: " + newState);
            return;
        }
        
        GameState previousState = currentState;
        
        // Exit current state
        ExitState(currentState);
        
        // Change state
        currentState = newState;
        
        // Enter new state
        EnterState(newState);
        
        Debug.Log("State transition: " + previousState + " → " + newState);
    }
    
    private void EnterState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                Debug.Log("=== ENTERING MAIN MENU ===");
                Time.timeScale = 1f;
                // In real game: Show menu UI, play menu music
                Debug.Log("Main menu displayed. Press 'P' to start playing!");
                break;
                
            case GameState.Loading:
                Debug.Log("=== LOADING GAME ===");
                Time.timeScale = 1f;
                // In real game: Show loading screen, load assets
                Debug.Log("Loading game assets...");
                break;
                
            case GameState.Playing:
                Debug.Log("=== STARTING GAME ===");
                Time.timeScale = 1f;
                // In real game: Hide menu, enable player controls, start gameplay
                Debug.Log("Game started! Use WASD to move, ESC to pause, L to lose life.");
                break;
                
            case GameState.Paused:
                Debug.Log("=== GAME PAUSED ===");
                Time.timeScale = 0f; // Stop time
                // In real game: Show pause menu, disable player input
                Debug.Log("Game paused. Press ESC to resume, Q to quit to menu.");
                break;
                
            case GameState.GameOver:
                Debug.Log("=== GAME OVER ===");
                Time.timeScale = 1f;
                // In real game: Show game over screen, final score
                Debug.Log("Final Score: " + score + " | Time Played: " + gameTime.ToString("F1") + "s");
                Debug.Log("Press R to restart, M for main menu.");
                break;
                
            case GameState.Settings:
                Debug.Log("=== SETTINGS MENU ===");
                Time.timeScale = 1f;
                // In real game: Show settings UI
                Debug.Log("Settings menu opened. Press ESC to return.");
                break;
                
            case GameState.Credits:
                Debug.Log("=== CREDITS ===");
                Time.timeScale = 1f;
                // In real game: Show credits screen
                Debug.Log("Credits rolling... Press ESC to return to menu.");
                break;
                
            default:
                Debug.LogError("Unknown game state: " + state);
                break;
        }
    }
    
    private void ExitState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                Debug.Log("Leaving main menu...");
                // In real game: Hide menu UI, stop menu music
                break;
                
            case GameState.Loading:
                Debug.Log("Loading complete.");
                break;
                
            case GameState.Playing:
                Debug.Log("Stopping gameplay...");
                // In real game: Save game state, disable controls
                break;
                
            case GameState.Paused:
                Debug.Log("Unpausing game...");
                // In real game: Hide pause menu, re-enable controls
                break;
                
            case GameState.GameOver:
                Debug.Log("Leaving game over screen...");
                // In real game: Clear final score, reset game variables
                break;
                
            case GameState.Settings:
                Debug.Log("Closing settings menu...");
                // In real game: Save settings, hide settings UI
                break;
                
            case GameState.Credits:
                Debug.Log("Ending credits...");
                break;
        }
    }
    
    private void UpdateCurrentState()
    {
        switch (currentState)
        {
            case GameState.Loading:
                UpdateLoadingState();
                break;
                
            case GameState.Playing:
                UpdatePlayingState();
                break;
                
            case GameState.Paused:
                UpdatePausedState();
                break;
                
            case GameState.GameOver:
                UpdateGameOverState();
                break;
                
            // Other states don't need continuous updates
        }
    }
    
    private void UpdateLoadingState()
    {
        // Simulate loading progress
        loadingTime += Time.deltaTime;
        
        if (loadingTime >= 2f) // 2 second loading time
        {
            loadingTime = 0f;
            ChangeState(GameState.Playing);
        }
    }
    
    private void UpdatePlayingState()
    {
        // Update game time and score
        gameTime += Time.deltaTime;
        score += Mathf.RoundToInt(Time.deltaTime * 10); // 10 points per second
        
        // Simulate random events
        if (Random.Range(0, 1000) < 1) // Very rare random event
        {
            Debug.Log("Bonus points earned! +100");
            score += 100;
        }
    }
    
    private void UpdatePausedState()
    {
        // Game is paused, no game time updates
        // But we can still update UI animations, etc.
    }
    
    private void UpdateGameOverState()
    {
        // Could animate score display, handle high scores, etc.
    }
    
    #endregion
    
    #region Input Handling
    
    private void HandleStateInput()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                HandleMainMenuInput();
                break;
                
            case GameState.Playing:
                HandleGameplayInput();
                break;
                
            case GameState.Paused:
                HandlePauseInput();
                break;
                
            case GameState.GameOver:
                HandleGameOverInput();
                break;
                
            case GameState.Settings:
                HandleSettingsInput();
                break;
                
            case GameState.Credits:
                HandleCreditsInput();
                break;
        }
    }
    
    private void HandleMainMenuInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeState(GameState.Loading);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeState(GameState.Settings);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeState(GameState.Credits);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
    }
    
    private void HandleGameplayInput()
    {
        // Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState(GameState.Paused);
        }
        
        // Simulate player movement (for demonstration)
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
                       Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        
        if (isMoving)
        {
            // Movement bonus
            score += Mathf.RoundToInt(Time.deltaTime * 5);
        }
        
        // Simulate losing a life
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoseLife();
        }
        
        // Simulate gaining points
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += 50;
            Debug.Log("Action performed! +50 points. Total: " + score);
        }
    }
    
    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState(GameState.Playing);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(GameState.MainMenu);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeState(GameState.Settings);
        }
    }
    
    private void HandleGameOverInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeState(GameState.MainMenu);
        }
    }
    
    private void HandleSettingsInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Return to previous state (could be menu or paused game)
            if (gameTime > 0) // If we were in a game
            {
                ChangeState(GameState.Paused);
            }
            else
            {
                ChangeState(GameState.MainMenu);
            }
        }
        
        // Simulate settings changes
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Volume setting changed!");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Graphics quality changed!");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Controls remapped!");
        }
    }
    
    private void HandleCreditsInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(GameState.MainMenu);
        }
    }
    
    #endregion
    
    #region Game Logic
    
    private void InitializeGame()
    {
        ResetGameData();
        ChangeState(GameState.MainMenu);
    }
    
    private void ResetGameData()
    {
        gameTime = 0f;
        score = 0;
        lives = 3;
        Debug.Log("Game data reset. Lives: " + lives + ", Score: " + score);
    }
    
    private void LoseLife()
    {
        lives--;
        Debug.Log("Life lost! Remaining lives: " + lives);
        
        if (lives <= 0)
        {
            ChangeState(GameState.GameOver);
        }
        else
        {
            // In a real game, you might respawn the player or restart the level
            Debug.Log("Respawning player...");
        }
    }
    
    private void RestartGame()
    {
        Debug.Log("Restarting game...");
        ResetGameData();
        ChangeState(GameState.Loading);
    }
    
    private void QuitGame()
    {
        Debug.Log("Quitting game...");
        // In a real build: Application.Quit();
        // In editor: UnityEditor.EditorApplication.isPlaying = false;
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
    private void DisplayCurrentStateInfo()
    {
        string stateInfo = currentState switch
        {
            GameState.MainMenu => "Main Menu - Ready to start",
            GameState.Loading => "Loading - Please wait",
            GameState.Playing => $"Playing - Score: {score}, Lives: {lives}, Time: {gameTime:F1}s",
            GameState.Paused => "Paused - Game suspended",
            GameState.GameOver => $"Game Over - Final Score: {score}",
            GameState.Settings => "Settings - Configuring options",
            GameState.Credits => "Credits - Showing acknowledgments",
            _ => "Unknown State"
        };
        
        Debug.Log("Current State: " + stateInfo);
    }
    
    #endregion
    
    #region Testing Methods
    
    private void TestAllStateTransitions()
    {
        Debug.Log("\n=== TESTING ALL STATE TRANSITIONS ===");
        
        // Test each state transition
        ChangeState(GameState.MainMenu);
        ChangeState(GameState.Settings);
        ChangeState(GameState.MainMenu);
        ChangeState(GameState.Credits);
        ChangeState(GameState.MainMenu);
        ChangeState(GameState.Loading);
        ChangeState(GameState.Playing);
        ChangeState(GameState.Paused);
        ChangeState(GameState.Settings);
        ChangeState(GameState.Paused);
        ChangeState(GameState.Playing);
        ChangeState(GameState.GameOver);
        ChangeState(GameState.MainMenu);
        
        Debug.Log("State transition testing complete!");
    }
    
    private void SimulateCompleteGameSession()
    {
        Debug.Log("\n=== SIMULATING COMPLETE GAME SESSION ===");
        
        // Start game session
        ChangeState(GameState.MainMenu);
        
        // Start playing
        ChangeState(GameState.Loading);
        ChangeState(GameState.Playing);
        
        // Simulate some gameplay time
        gameTime = 45f;
        score = 1250;
        
        // Check settings
        ChangeState(GameState.Settings);
        ChangeState(GameState.Playing);
        
        // Pause game
        ChangeState(GameState.Paused);
        ChangeState(GameState.Playing);
        
        // Lose all lives and end game
        lives = 1;
        LoseLife();
        
        Debug.Log("Complete game session simulation finished!");
    }
    
    #endregion
    
    #region Public Interface (for other scripts to use)
    
    public GameState GetCurrentState()
    {
        return currentState;
    }
    
    public bool IsGameActive()
    {
        return currentState == GameState.Playing;
    }
    
    public bool IsGamePaused()
    {
        return currentState == GameState.Paused;
    }
    
    public float GetGameTime()
    {
        return gameTime;
    }
    
    public int GetScore()
    {
        return score;
    }
    
    public int GetLives()
    {
        return lives;
    }
    
    public void AddScore(int points)
    {
        if (IsGameActive())
        {
            score += points;
            Debug.Log("Score added: +" + points + " (Total: " + score + ")");
        }
    }
    
    #endregion
}

/// <summary>
/// Enum defining all possible game states
/// </summary>
public enum GameState
{
    MainMenu,
    Loading,
    Playing,
    Paused,
    GameOver,
    Settings,
    Credits
}