using UnityEngine;

public class Enemy : Unit 
{
    [SerializeField] private float _rateChangeDirection;
    [SerializeField] private Gear _gear;
    [SerializeField] private int _amountGears;
    [SerializeField] private Vector3 _gearsSpawnBoxSize;

    private float _currentTime;
    private Vector2 direction;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _gearsSpawnBoxSize);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _rateChangeDirection)
        {
            int i = Random.Range(1, 5);
            switch (i)
            {
                case(1):
                direction = Vector2.up;
                break;
                case(2):
                direction = Vector2.right;
                break;
                case(3):
                direction = Vector2.left;
                break;
                case(4):
                direction = Vector2.down;
                break;
            }
            _currentTime = 0;
        }
        tankMotor.Move(direction);
        weapon.Attack(transform.rotation);
        weapon.OnUpdate();
    }

    public override void Die()
    {
        base.Die();

        for(int i = 0; i < _amountGears; i++)
        {
            Gear gear = Instantiate(_gear, transform.position, Quaternion.identity);
            gear.Run(new Vector3(Random.Range(transform.position.x - (_gearsSpawnBoxSize.x / 2), transform.position.x + (_gearsSpawnBoxSize.x / 2)),
            Random.Range(transform.position.y - (_gearsSpawnBoxSize.y / 2), transform.position.y + (_gearsSpawnBoxSize.y / 2)), 0));
        }
    }
}