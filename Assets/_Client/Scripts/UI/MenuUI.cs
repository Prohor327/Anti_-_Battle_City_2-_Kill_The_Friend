using System.Collections;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class MenuUI : UIElement
{
    [SerializeField] private AudioClip _buttonPressed;

    private AudioSource _audioSource;

    private Fader _fader;

    private VisualElement _buttonCont2;
    private VisualElement _chooseMapCont;

    private PlayMode _playMode;

    protected override void Initialize()
    {
        base.Initialize();
        _audioSource = GetComponent<AudioSource>();
        _fader = GetComponent<Fader>();

        _buttonCont2 = _UIElement.Q<VisualElement>("ButtonsCotext2");
        _chooseMapCont = _UIElement.Q<VisualElement>("ChoosePanel");
        Button play = _UIElement.Q<Button>("Play");
        Button exit = _UIElement.Q<Button>("Exit");

        Button map1 = _UIElement.Q<Button>("1");
        Button map2 = _UIElement.Q<Button>("2");
        Button map3 = _UIElement.Q<Button>("3");

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

        confrontation.clicked += () =>
        {
            _playMode = PlayMode.Conf;
            _chooseMapCont.visible = true;
        };

        baseButton.clicked += () =>
        {
            _playMode = PlayMode.Base;
            _chooseMapCont.visible = false;
        };

        map1.clicked += () => ChooseMap(1);
        map2.clicked += () => ChooseMap(2);
        map3.clicked += () => ChooseMap(3);
        
        Open();
    }

    public override void Open()
    {
        base.Open();
        _buttonCont2.visible = false;
        _chooseMapCont.visible = false;
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

    private void ChooseMap(int indexMap)
    {
        if (_playMode == PlayMode.Conf)
        {
            switch (indexMap)
            {
                case 1:
                    StartGame(Consts.CONF01_SCENE_NAME);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        else
        {
            switch (indexMap)
            {
                case 1:
                    StartGame(Consts.BASE01_SCENE_NAME);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }

    private void StartGame(string consts)
    {
        SoundPlay();
        _fader.Fade();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _fader.OnFaded += () => Game.Instance.gameMachine.LoadLevel(consts.ToString());
    }
}