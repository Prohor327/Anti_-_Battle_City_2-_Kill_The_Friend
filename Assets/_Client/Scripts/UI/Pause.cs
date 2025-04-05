using UnityEngine;
using UnityEngine.UIElements;

public class Pause : UIElement
{
    protected override void Initialize()
    {
        base.Initialize();

        Button Continue = _UIElement.Q<Button>("Continue");

        Continue.clicked += Close;
    }

    public override void Open()
    {
        Time.timeScale = 0;
        AddElement();
    }

    private void Close()
    {
        Time.timeScale = 1;
        RemoveComponent();
    }
}
