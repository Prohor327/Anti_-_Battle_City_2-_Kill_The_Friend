using UnityEngine;

public class Game : PersistentSingleton<Game> 
{
    public ScenesOpener scenesOpener { get; private set; }
    public GameMachine gameMachine { get; private set; }
    public Player player1 { get; private set; }
    public Player player2 { get; private set; }

    private void Start()
    {
        scenesOpener = new ScenesOpener();
        gameMachine = new GameMachine();
        gameMachine.Initialize();   
        gameMachine.LoadMenu();
    }

    public void SetPlayers(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    public void DeletePlayers()
    {
        player1 = player2 = null;
    }
}