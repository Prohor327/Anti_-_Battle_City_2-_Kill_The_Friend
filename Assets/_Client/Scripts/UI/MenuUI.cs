using UnityEngine;
using UnityEngine.UIElements;

public class MenuUI : UIElement
{
    [SerializeField] private VisualTreeAsset _menuButtonsVariantsAsset;
    [SerializeField] private VisualTreeAsset _gameButtonsVariantsAsset;

    private VisualElement _buttonCont;

    private VisualElement _gameVariantsMenu;
    private VisualElement _menuVariantsMenu;

    protected override void Initialize()
    {
        base.Initialize();
        _gameVariantsMenu = _gameButtonsVariantsAsset.CloneTree();
        _menuVariantsMenu = _menuButtonsVariantsAsset.CloneTree();

        _buttonCont = _UIElement.Q<VisualElement>("ButtonsCotext");
        Button play = _menuVariantsMenu.Q<Button>("Play");
        Button exit = _menuVariantsMenu.Q<Button>("Exit");

        Button versus = _gameVariantsMenu.Q<Button>("1vs1");
        Button confrontation = _gameVariantsMenu.Q<Button>("Confrontation");

        play.clicked += ChooseGameVariant;
        exit.clicked += Application.Quit;
        versus.clicked += () => Game.Instance.gameMachine.LoadLevel();
        
        Open();
    }

    public override void Open()
    {
        base.Open();
        _buttonCont.Add(_menuVariantsMenu);
        
    }

    private void ChooseGameVariant()
    {
        _buttonCont.Clear();
        _buttonCont.Add(_gameVariantsMenu);
    }
}
