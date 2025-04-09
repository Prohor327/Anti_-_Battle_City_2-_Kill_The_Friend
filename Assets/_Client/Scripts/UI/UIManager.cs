using UnityEngine;

public class UIManager : MonoBehaviour 
{
    public GameUI gameUI { get; private set; }

    private void Start() 
    {
        gameUI = GetComponent<GameUI>();
        Game.Instance.UIManager = this;
    }

    private void OnDestroy()
    {
        Game.Instance.UIManager = null;
    }
}