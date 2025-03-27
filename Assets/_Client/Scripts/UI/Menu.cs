using UnityEngine;
using UnityEngine.UIElements;

public class Menu : UIElement
{
    protected override void Initialize()
    {
        base.Initialize();
        Open();

        Button play = _UIElement.Q<Button>("Play");
        Button exit = _UIElement.Q<Button>("Exit");

        play.clicked += () => 
        exit.clicked += () => Application.Quit();
    }

    public override void Open()
    {
        base.Open();
    }
}
