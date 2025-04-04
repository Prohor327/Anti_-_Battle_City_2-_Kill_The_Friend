using UnityEngine;

public class Game : PersistentSingleton<Game> 
{
    public ScenesOpener scenesOpener { get; private set; }
    public GameMachine gameMachine { get; private set; }
    public UIManager UIManager;
    public Player player1;
    public Player player2;

    private void Start()
    {
        scenesOpener = new ScenesOpener();
        gameMachine = new GameMachine();
        gameMachine.Initialize();   
        gameMachine.LoadMenu();
    }
}