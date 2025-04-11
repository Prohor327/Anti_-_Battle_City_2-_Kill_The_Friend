using UnityEngine;

public class TankCycleSpawner : TankSpawner 
{
    [SerializeField] private float _rate;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer; 
    private float _currentTime = 0;

    private void Start()
    {
        _currentTime = _rate;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.Play("Idle");
    }

    public override void Spawn()
    {
        Instantiate(_tank, transform.position, transform.rotation).Initialize();
    }
    
    private void Update() 
    {
        _currentTime -= Time.deltaTime;
        if(_currentTime <= 0)
        {
            SpawnNewTank();
            _currentTime = _rate;
        }
    }

    public void SpawnNewTank()
    {
        _animator.Play("Spawn");
    }

    public override void End()
    {

    }
}