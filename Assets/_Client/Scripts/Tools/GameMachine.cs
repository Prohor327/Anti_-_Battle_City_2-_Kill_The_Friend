using System;

public class GameMachine
{
    public GameState state { get; private set; } = GameState.None;

    public Action OnLoadedLevel;

    public void Initialize()    
    {
        Game.print("Game Machine Is Initializing");
        state = GameState.Bootstrap;
        Game.Instance.scenesOpener.Initialize();
        Game.print("Game Machine Initialized");
    }

    public void LoadMenu()
    {
        Game.print("Game Machine Is Opening Menu");
        Game.Instance.scenesOpener.LoadMenu();
        state = GameState.Menu;
        Game.Instance.CleanRenderTexture();
    }

    public void LoadLevel(string name)
    {
        Game.print("Game Machine Is Loading Level");
        Game.Instance.scenesOpener.LoadLevel(name);
        OnLoadedLevel?.Invoke();
        state = GameState.Game;
    }
}