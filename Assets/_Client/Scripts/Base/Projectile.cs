using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [field: SerializeField] public float _damage { get; private set; }
    [field: SerializeField] public float _speed { get; private set; }
    [SerializeField] private float _lifeTime;
    [SerializeField] private Transform[] _tilemapDetectorPoints;
    [SerializeField] private Explosion _miniExplosion;
    [SerializeField] private Unit _myUnit;

    public void Run(Unit unit)
    {
        _myUnit = unit;
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector3.up) * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_myUnit == null)
        {
            return;
        }
        if(_myUnit.transform == collision.transform)
        {
            return;
        }
        if(collision.TryGetComponent<Enviroment>(out Enviroment env))
        {
            foreach(Transform t in _tilemapDetectorPoints)
            {
                env.DestroyTile(t.position);
            }
            Instantiate(_miniExplosion, _tilemapDetectorPoints[1].position, Quaternion.identity);
        }
        if(collision.TryGetComponent<Health>(out Health unit))
        {
            unit.TakeDamege(_damage);
        }
        if(collision.TryGetComponent<Base>(out Base playerBase))
        {
            playerBase.Die();
        }
        Destroy(gameObject);
    }

    public void SetDamage(float newdamage)
    {
        _damage = newdamage;
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}