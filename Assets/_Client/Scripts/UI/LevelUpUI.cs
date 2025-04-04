using System;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelUpUI : UIElement
{
    private VisualElement _lvlUpPanel;
    private Button[] _abillityButtons = new Button[3]; 
    private Label[] _abillityTexts = new Label[3]; 
    private Label _title;
    private AbillitySO[] _abillitiesSO = new AbillitySO[3]; 
    private Player _currentPlayer;
    private GameUI gameUI;

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
        Time.timeScale = 0;
    }

    public void Open(int playerId)
    {
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

        for(int i = 0; i < 3; i++)
        {
            if(_currentPlayer.TryGetRandomAbility(out AbillitySO abillitySO))
            {
                _abillitiesSO[i] = abillitySO;
                _abillityButtons[i].style.backgroundImage = abillitySO.texture;
                _abillityTexts[i].text = abillitySO.description;
                SubscribeLvlUpButton(_abillityButtons[i]);
            }
            else
            {
                return;
            }
        }
        Open();
    }

    public void Close()
    {
        UnsubscribeLvlUpButtons();
        Time.timeScale = 1;
    }

    public void SubscribeLvlUpButton(Button button)
    {
        button.clicked += () => OnButtonPressed(button);
    }

    private void UnsubscribeLvlUpButtons()
    {
        _abillityButtons[0].clicked -= () => { };
        _abillityButtons[1].clicked -= () => { };
        _abillityButtons[2].clicked -= () => { };
    }

    private void OnButtonPressed(Button button)
    {
        AbillitySO abillitySO = _abillitiesSO[Convert.ToInt32(button.name) - 1];

        switch (abillitySO.abillityType)
        {
            case AbillityType.DamageUp:
            break;
            case AbillityType.SpeedUp:
            break;
            case AbillityType.HPUp:
                _currentPlayer.health.ImproveMaxHealth(abillitySO.value);
            break;
            case AbillityType.ProjectileSpeedUp:
            break;
        }
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
