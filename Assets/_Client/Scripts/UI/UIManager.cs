using UnityEngine;

public class UIManager : MonoBehaviour 
{
    public GameUI gameUI { get; private set; }
    public Win win { get; private set; }
    public LevelUpUI levelUpUI { get; private set; }

    private void Start() 
    {
        gameUI = GetComponent<GameUI>();
        levelUpUI = GetComponent<LevelUpUI>();
        Game.Instance.UIManager = this;
        if(TryGetComponent<Win>(out Win winn))
        {
            win = winn;
        }
    }

    private void OnDestroy()
    {
        Game.Instance.UIManager = null;
    }
}