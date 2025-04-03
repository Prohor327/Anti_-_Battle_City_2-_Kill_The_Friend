using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIElement
{
    private VisualElement _expPlayer1;
    private VisualElement _expPlayer2;
    private VisualElement _hpPlayer1;
    private VisualElement _hpPlayer2;

    protected override void Initialize()
    {
        base.Initialize();

        _expPlayer1 = _UIElement.Q<VisualElement>("ExperiencePlayer1");
        _expPlayer2 = _UIElement.Q<VisualElement>("ExperiencePlayer2");
        _hpPlayer1 = _UIElement.Q<VisualElement>("HPPlayer1");
        _hpPlayer2 = _UIElement.Q<VisualElement>("HPPlayer2");

        Game.Instance.gameMachine.OnLoadedLevel += Open;
    }

    public override void Open()
    {
        base.Open();
    }

    private void UpdateState(VisualElement _element, float param)
    {
        _element.style.width = param;
    }
}
