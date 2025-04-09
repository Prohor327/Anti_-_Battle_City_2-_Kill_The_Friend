using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIElement
{
    private VisualElement _lvlUpPanel;

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

        _expPlayer1 = _UIElement.Q<ProgressBar>("ExperienceBar1");
        _expPlayer2 = _UIElement.Q<ProgressBar>("ExperienceBar2");
        _hpPlayer1 = _UIElement.Q<ProgressBar>("HPPlayer1");
        _hpPlayer2 = _UIElement.Q<ProgressBar>("HPPlayer2");

        _scorePlayer1 = _UIElement.Q<Label>("ScorePlayer1");
        _scorePlayer1 = _UIElement.Q<Label>("ScorePlayer2");
        _timer = _UIElement.Q<Label>("Timer");
        Open();
    }

    public override void Open()
    {
        Game.Instance.CleanRenderTexture();
        base.Open();
    }

    public void UpdateHP(int playerIndex, float hp, float maxhp)
    {
        if (playerIndex == 1)
        {
            _hpPlayer1.value = hp;
            _hpPlayer1.highValue = maxhp;
            _hpPlayer1.title = $"{hp}/{maxhp}";
        }
        else
        {
            _hpPlayer2.value = hp;
            _hpPlayer2.highValue = maxhp;
            _hpPlayer2.title = $"{hp}/{maxhp}";
        }
    }

    public void UpdateExp(int playerIndex, float param, float maxparam)
    {
        if (playerIndex == 1)
        {
            _expPlayer1.value = param;
            _expPlayer1.highValue = maxparam;
            _expPlayer1.title = $"{param}/{maxparam}";
        }
        else
        {
            _expPlayer2.value = param;
            _expPlayer2.highValue = maxparam;
            _expPlayer2.title = $"{param}/{maxparam}";
        }
    }

    public void UpdateScore(int playerIndex, float param)
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

    public void UpdateTime(int time)
    {
        _timer.text = time.ToString();
    }
}
