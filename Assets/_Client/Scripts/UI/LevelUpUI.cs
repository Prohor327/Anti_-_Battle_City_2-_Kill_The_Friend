using System;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class LevelUpUI : UIElement
{
    private VisualElement _lvlUpPanel;
    private Button[] _abillityButtons = new Button[3]; 
    private Label[] _abillityTexts = new Label[3]; 
    private Label _title;
    private AbillitySO[] _abillitiesSO = new AbillitySO[3]; 
    private Player _currentPlayer;
    private GameUI gameUI;
    private bool isOpen = false;

    private int _i;

    protected override void Initialize()
    {
        base.Initialize();

        gameUI = GetComponent<GameUI>();

        _lvlUpPanel = _UIElement.Q<VisualElement>("LvlUpPanel");
        _abillityButtons = new Button[3];
        _abillityButtons[0] = _UIElement.Q<Button>("1");
        _abillityButtons[1] = _UIElement.Q<Button>("2");
        _abillityButtons[2] = _UIElement.Q<Button>("3");


        _abillityTexts = new Label[3];
        _abillityTexts[0] = _UIElement.Q<Label>("1t");
        _abillityTexts[1] = _UIElement.Q<Label>("2t");
        _abillityTexts[2] = _UIElement.Q<Label>("3t");

        _title = _UIElement.Q<Label>("Title");
    }

    public override void Open()
    {
        base.Open();
        isOpen = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Game.Instance.music.SetToLowVolume();
    }

    public void Open(int playerId)
    {
        _i = 0;
        if(isOpen)
        {
            return;
        }
        if(playerId == 1)
        {
            _title.text = "Player 1 choose one";
            _currentPlayer = Game.Instance.player1;
        }
        else
        {
            _title.text = "Player 2 choose one";
            _currentPlayer = Game.Instance.player2;
        }

        _abillitiesSO = _currentPlayer.GetRandomAbillitySOs();

        for(int i = 0; i < 3; i++)
        {
            _abillityButtons[i].style.backgroundImage = _abillitiesSO[i].texture;
            _abillityTexts[i].text = _abillitiesSO[i].description;
        }
        SubscribeButton();
        Open();
    }

    public void Close()
    {
        UnsubscribeLvlUpButtons();
        _currentPlayer.PlayLevelUpSound();
        isOpen = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Game.Instance.music.SetToHighVolume();
    }

    private void SubscribeButton()
    {
        _abillityButtons[0].clicked += () => OnButtonPressed(_abillityButtons[0]);
        _abillityButtons[1].clicked += () => OnButtonPressed(_abillityButtons[1]);
        _abillityButtons[2].clicked += () => OnButtonPressed(_abillityButtons[2]);
    }

    private void UnsubscribeLvlUpButtons()
    {
        print("000");
        _abillityButtons[0].clicked -= () => OnButtonPressed(_abillityButtons[0]);
        _abillityButtons[1].clicked -= () => OnButtonPressed(_abillityButtons[1]);
        _abillityButtons[2].clicked -= () => OnButtonPressed(_abillityButtons[2]);
    }

    private void OnButtonPressed(Button button)
    {
        AbillitySO abillitySO = _abillitiesSO[Convert.ToInt32(button.name) - 1];
        if (_i >= 1) return;
        switch (abillitySO.abillityType)
        {
            case AbillityType.DamageUp:
                _currentPlayer.damage += abillitySO.value;
            break;
            case AbillityType.SpeedUp:
                _currentPlayer.ImproveSpeed(abillitySO.value);
            break;
            case AbillityType.HPUp:
                _currentPlayer.health.ImproveMaxHealth(abillitySO.value);
            break;
            case AbillityType.ProjectileSpeedUp:
                _currentPlayer.speedProjectile += abillitySO.value;
            break;
        }
        _i++;
        Close();
        gameUI.Open();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Open(1);
        }   
    }
}
