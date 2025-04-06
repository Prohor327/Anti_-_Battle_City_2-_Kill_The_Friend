using UnityEngine;

public class PlayerSpawner : TankSpawner
{
    [SerializeField] [Range(1, 2)] private int _playerId;
    [SerializeField] private Player player;

    public override void Spawn()
    {
        Instantiate(player, transform.position, transform.rotation).Initialize(_playerId);
    }
}