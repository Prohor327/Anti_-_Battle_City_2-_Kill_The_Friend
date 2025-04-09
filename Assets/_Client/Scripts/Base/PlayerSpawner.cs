using UnityEngine;

public class PlayerSpawner : TankSpawner
{
    [SerializeField] [Range(1, 2)] private int _playerId;
    [SerializeField] private Player player;

    public override void Spawn()
    {
        Player playera = Instantiate(player, transform.position, transform.rotation);
        Game.Instance.OnStartRound += () => playera.Initialize(_playerId);
    }
}