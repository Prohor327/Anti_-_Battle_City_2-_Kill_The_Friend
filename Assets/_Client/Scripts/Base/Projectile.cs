using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
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
        Destroy(gameObject);
    }
}