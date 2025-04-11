using UnityEngine;

public class Base : MonoBehaviour 
{
    [SerializeField] [Range(1, 2)] private int _playerId;

    public void Die()
    {
        Game.Instance.UIManager.win.Open();
        if(_playerId == 1)
        {
            Game.Instance.UIManager.win.ChangeText($"Player 2 won!");
        }
        else
        {
            Game.Instance.UIManager.win.ChangeText($"Player 1 won!");
        }
    }
}