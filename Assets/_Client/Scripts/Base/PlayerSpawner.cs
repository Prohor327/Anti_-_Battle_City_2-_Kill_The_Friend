using UnityEngine;
using UnityEngine.Rendering;

public class PlayerSpawner : TankSpawner
{
    [SerializeField] [Range(1, 2)] private int _playerId;
    [SerializeField] private Player _player;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Spawn()
    {
        Player player = Instantiate(_player, transform.position, transform.rotation);
        player.Initialize(_playerId);
    }

    public void SpawnNewPlayer()
    {
        _animator.Play("Spawn");
    }

    public override void End()
    {
    }
}