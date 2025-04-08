using UnityEngine;
using UnityEngine.UIElements;

public class Pause : UIElement
{
    private bool _onPause;
    protected override void Initialize()
    {
        base.Initialize();

        Button Continue = _UIElement.Q<Button>("Continue");
        Button Exit = _UIElement.Q<Button>("Exit");

        Continue.clicked += Close;
        Exit.clicked += () =>
        {
            Close();
            Game.Instance.scenesOpener.LoadMenu();
        };
        _onPause = false;
    }

    public override void Open()
    {
        if (!_onPause)
        {
            Time.timeScale = 0;
            AddElement();
            _onPause = true;
        }
    }

    private void Close()
    {
        Time.timeScale = 1;
        RemoveComponent();
        _onPause = false;
    }
}
