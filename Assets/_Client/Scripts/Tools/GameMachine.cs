public class GameMachine : PersistentSingleton<GameMachine>
{
    public GameState state { get; private set; } = GameState.None;

    public void Initialize()    
    {
        print("Game Machine Is Initializing");
        state = GameState.Bootstrap;
        ScenesOpener.Instance.Initialize();
        print("Game Machine Initialized");
    }

    public void OpenMenu()
    {
        print("Game Machine Is Opening Menu");
        ScenesOpener.Instance.LoadMenu();
        state = GameState.Menu;
    }
}