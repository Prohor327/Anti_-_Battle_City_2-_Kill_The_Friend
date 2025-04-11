using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Pause : UIElement
{
    [SerializeField] private GameUI _gameUI;
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
            _onPause = true;
            Time.timeScale = 0;
            AddElement();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Close()
    {
        _onPause = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _gameUI.Open();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Open();
        }
    }
}
