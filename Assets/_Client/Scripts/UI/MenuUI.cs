using UnityEngine;
using UnityEngine.UIElements;

public class MenuUI : UIElement
{
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private AudioClip _buttonPressed;

    private VisualElement _buttonCont2;

    protected override void Initialize()
    {
        base.Initialize();

        _buttonCont2 = _UIElement.Q<VisualElement>("ButtonsCotext2");
        Button play = _UIElement.Q<Button>("Play");
        Button exit = _UIElement.Q<Button>("Exit");

        Button confrontation = _UIElement.Q<Button>("Confrontation");
        Button versus = _UIElement.Q<Button>("1vs1");

        play.clicked += () =>
        {
            SoundPlay();
            ChooseGameVariant();
        };
        exit.clicked += () =>
        {
            SoundPlay();
            Application.Quit();
        };
        confrontation.clicked += () =>
        {
            SoundPlay();
            Game.Instance.gameMachine.LoadLevel();
        };
        
        Open();
    }

    public override void Open()
    {
        base.Open();
        _buttonCont2.visible = false;
    }
    private void SoundPlay()
    {
        _audioSourse.PlayOneShot(_buttonPressed);
    }

    private void ChooseGameVariant()
    {
        _buttonCont2.visible = true;
    }
}
