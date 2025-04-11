using UnityEngine;
using UnityEngine.UIElements;

public class Win : UIElement
{
    private Label _winText;
    private VisualElement _playerImage;

    protected override void Initialize()
    {
        base.Initialize();

        _winText = _UIElement.Q<Label>("PlayerText");
        Button Exit = _UIElement.Q<Button>("Exit");

        Exit.clicked += () => 
        {
            Game.Instance.scenesOpener.LoadMenu();
            Time.timeScale = 1;
        };
    }

    public override void Open()
    {
        base.Open();
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    public void ChangeText(string text)
    {
        _winText.text = text;
    }

    private void ChangeImage(Sprite sprite)
    {
        _playerImage.style.backgroundImage = sprite.texture;
    }
}
