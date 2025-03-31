using UnityEngine;

public class Level : MonoBehaviour 
{
    [SerializeField] private Player[] players;

    private void Start()
    {
        Game.Instance.SetPlayers(players[0], players[1]);
    }

    private void OnDisable()
    {
        Game.Instance.DeletePlayers();
    }
}