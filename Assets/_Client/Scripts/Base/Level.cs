using UnityEngine;

public class Level : MonoBehaviour 
{
    public PlayMode playMode;

    private void Start()
    {
        Game.Instance.level = this;
        if(playMode == PlayMode.Base)
        {
            Game.Instance.UIManager.gameUI.DisableScore();
            Game.Instance.UIManager.gameUI.DisableTimer();
        }
    }

    private void OnDestroy()
    {
        Game.Instance.level = null;
    }
}