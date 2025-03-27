using UnityEngine;
using UnityEngine.UIElements;

public class UIElement : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _asset;

    protected VisualElement _UIElement;

    private VisualElement _document;

    private void Awake()
    {
        _document = GetComponent<UIDocument>().rootVisualElement;

        Initialize();
    }

    protected virtual void Initialize()
    {
        _UIElement = _asset.CloneTree();
    }

    public virtual void Open()
    {
        _document.Clear();
        _document.Add(_UIElement);
    }
}
