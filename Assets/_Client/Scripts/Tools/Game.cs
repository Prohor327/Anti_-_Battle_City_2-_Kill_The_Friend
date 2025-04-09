using UnityEngine;
using System;

public class Game : PersistentSingleton<Game> 
{
    public ScenesOpener scenesOpener { get; private set; }
    public GameMachine gameMachine { get; private set; }
    public UIManager UIManager;
    public RoundManager roundManager;
    public Music music;
    public Player player1;
    public Player player2;

    public Action OnStartRound;

    [SerializeField] private RenderTexture _uiRenderTecture;

    private void Start()
    {
        scenesOpener = new ScenesOpener();
        gameMachine = new GameMachine();
        gameMachine.Initialize();   
        gameMachine.LoadMenu();
        CleanRenderTexture();
    }

    public void CleanRenderTexture()
    {
        _uiRenderTecture.Release();
    }
}