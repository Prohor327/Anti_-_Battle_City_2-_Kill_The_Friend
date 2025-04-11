using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class MenuUI : UIElement
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _buttonPressed;

    private Fader _fader;

    private VisualElement _buttonCont2;

    protected override void Initialize()
    {
        base.Initialize();
        _audioSource = GetComponent<AudioSource>();
        _fader = GetComponent<Fader>();

        _buttonCont2 = _UIElement.Q<VisualElement>("ButtonsCotext2");
        Button play = _UIElement.Q<Button>("Play");
        Button exit = _UIElement.Q<Button>("Exit");

        Button confrontation = _UIElement.Q<Button>("Confrontation");
        Button baseButton = _UIElement.Q<Button>("Base");

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
        baseButton.clicked += () =>
        {
            SoundPlay();
            _fader.Fade();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _fader.OnFaded += () => Game.Instance.gameMachine.LoadLevel(Consts.BASE01_SCENE_NAME);
        };
        confrontation.clicked += () =>
        {
            SoundPlay();
            _fader.Fade();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _fader.OnFaded += () => Game.Instance.gameMachine.LoadLevel(Consts.CONF01_SCENE_NAME);
        };
        
        Open();
    }

    public override void Open()
    {
        base.Open();
        _buttonCont2.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    private void SoundPlay()
    {
        _audioSource.PlayOneShot(_buttonPressed);
    }

    private void ChooseGameVariant()
    {
        _buttonCont2.visible = true;
    }
}