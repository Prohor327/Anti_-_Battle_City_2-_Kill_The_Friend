using UnityEngine;
using UnityEngine.UIElements;

public class Win : UIElement
{
    [SerializeField] private Sprite[] _winSprite;

    private Label _winText;
    private VisualElement _playerImage;

    protected override void Initialize()
    {
        base.Initialize();

        _winText = _UIElement.Q<Label>("PlayerText");
        _playerImage = _UIElement.Q<VisualElement>("PlayerImage");
    }

    public override void Open()
    {
        base.Open();
    }

    private void ChangeText(string text)
    {
        _winText.text = text;
    }

    private void ChangeImage(Sprite sprite)
    {
        _playerImage.style.backgroundImage = sprite.texture;
    }
}
