using System;
using System.Collections;
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
    private Label _centerMessage;

    protected override void Initialize()
    {
        base.Initialize();

        _lvlUpPanel = _UIElement.Q<VisualElement>("LvlUpPanel");

        _expPlayer1 = _UIElement.Q<ProgressBar>("ExperienceBar1");
        _expPlayer2 = _UIElement.Q<ProgressBar>("ExperienceBar2");
        _hpPlayer1 = _UIElement.Q<ProgressBar>("HPPlayer1");
        _hpPlayer2 = _UIElement.Q<ProgressBar>("HPPlayer2");

        _scorePlayer1 = _UIElement.Q<Label>("ScorePlayer1");
        _scorePlayer2 = _UIElement.Q<Label>("ScorePlayer2");
        _timer = _UIElement.Q<Label>("Timer");
        _centerMessage = _UIElement.Q<Label>("CenterMessage");
        _centerMessage.text = "";
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

    public void UpdateScore(int player1, int player2)
    {
        Game.Instance.CleanRenderTexture();
        _scorePlayer1.text = player1.ToString();
        _scorePlayer2.text = player2.ToString();
    }

    public void UpdateTime(int time)
    {
        _timer.text = time.ToString();
    }

    public void ThrowMessageOnCenterScreen(string message, float duration)
    {
        StopCoroutine(ThrowMessageOnCenterScreenCoroutine(message, duration));
        StartCoroutine(ThrowMessageOnCenterScreenCoroutine(message, duration));
    }

    private IEnumerator ThrowMessageOnCenterScreenCoroutine(string message, float duration)
    {
        _centerMessage.text = message;
        yield return new WaitForSeconds(duration);
        _centerMessage.text = "";
        Game.Instance.CleanRenderTexture();
    }

    public void DisableTimer()
    {
        _timer.visible = false;
        Game.Instance.CleanRenderTexture();
    }

    public void DisableScore()
    {
        _scorePlayer1.visible = false;
        _scorePlayer2.visible = false;
        Game.Instance.CleanRenderTexture();
    }
}