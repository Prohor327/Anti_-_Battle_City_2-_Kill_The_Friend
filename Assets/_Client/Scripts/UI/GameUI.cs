using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIElement
{
    private VisualElement _lvlUpPanel;

    private Button[] _Choose;

    private ProgressBar _expPlayer1;
    private ProgressBar _expPlayer2;
    private ProgressBar _hpPlayer1;
    private ProgressBar _hpPlayer2;

    private Label _scorePlayer1;
    private Label _scorePlayer2;
    private Label _timer;

    protected override void Initialize()
    {
        base.Initialize();

        _lvlUpPanel = _UIElement.Q<VisualElement>("LvlUpPanel");

        _Choose[1] = _UIElement.Q<Button>("1");
        _Choose[2] = _UIElement.Q<Button>("2");
        _Choose[3] = _UIElement.Q<Button>("3");

        _expPlayer1 = _UIElement.Q<ProgressBar>("ExperiencePlayer1");
        _expPlayer2 = _UIElement.Q<ProgressBar>("ExperiencePlayer2");
        _hpPlayer1 = _UIElement.Q<ProgressBar>("HPPlayer1");
        _hpPlayer2 = _UIElement.Q<ProgressBar>("HPPlayer2");

        _scorePlayer1 = _UIElement.Q<Label>("ScorePlayer1");
        _scorePlayer1 = _UIElement.Q<Label>("ScorePlayer2");
        _timer = _UIElement.Q<Label>("Timer");

        Game.Instance.gameMachine.OnLoadedLevel += Open;
    }

    public override void Open()
    {
        CloseLvlUp();
        base.Open();
    }
    
    public void OpenLvlUp()
    {
        Time.timeScale = 0;
        _lvlUpPanel.visible = true;
    }

    private void CloseLvlUp()
    {
        UnsubscribeLvlUpButtons();
        Time.timeScale = 1;
        _lvlUpPanel.visible = false;
    }

    public void SubscribeLvlUpButton(int index, Action perk)
    {
        _Choose[index].clicked += perk;
    }

    private void UnsubscribeLvlUpButtons()
    {
        _Choose[1].clicked -= () => { };
        _Choose[2].clicked -= () => { };
        _Choose[3].clicked -= () => { };
    }

    private void UpdateHP(int playerIndex, float param)
    {
        if (playerIndex == 1)
        {
            _hpPlayer1.style.width = param;
        }
        else
        {
            _hpPlayer2.style.width = param;
        }
    }

    private void UpdateExp(int playerIndex, float param)
    {
        if (playerIndex == 1)
        {
            _expPlayer1.style.height = param;
        }
        else
        {
            _expPlayer2.style.height = param;
        }
    }

    private void UpdateScore(int playerIndex, float param)
    {
        if (playerIndex == 1)
        {
            _scorePlayer1.text = param.ToString();
        }
        else
        {
            _scorePlayer2.text = param.ToString();
        }
    }

}
