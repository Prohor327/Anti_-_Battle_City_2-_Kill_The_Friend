using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIElement
{
    private VisualElement _expPlayer1;
    private VisualElement _expPlayer2;
    private VisualElement _hpPlayer1;
    private VisualElement _hpPlayer2;
    private Label _scorePlayer1;
    private Label _scorePlayer2;
    private Label _timer;

    protected override void Initialize()
    {
        base.Initialize();

        _expPlayer1 = _UIElement.Q<VisualElement>("ExperiencePlayer1");
        _expPlayer2 = _UIElement.Q<VisualElement>("ExperiencePlayer2");
        _hpPlayer1 = _UIElement.Q<VisualElement>("HPPlayer1");
        _hpPlayer2 = _UIElement.Q<VisualElement>("HPPlayer2");
        _scorePlayer1 = _UIElement.Q<Label>("ScorePlayer1");
        _scorePlayer1 = _UIElement.Q<Label>("ScorePlayer2");
        _timer = _UIElement.Q<Label>("Timer");

        Game.Instance.gameMachine.OnLoadedLevel += Open;
    }

    public override void Open()
    {
        base.Open();
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
