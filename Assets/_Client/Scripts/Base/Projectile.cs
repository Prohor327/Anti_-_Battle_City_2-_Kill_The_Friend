using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Transform _tilemapDetectorPoint;
    [SerializeField] private Explosion _miniExplosion;

    public void Run()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector3.up) * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enviroment>(out Enviroment env))
        {
            env.DestroyTile(_tilemapDetectorPoint.position);
            Instantiate(_miniExplosion, _tilemapDetectorPoint.position, Quaternion.identity);
        }
        if(collision.TryGetComponent<Health>(out Health unit))
        {
            unit.TakeDamege(_damage);
        }
        Destroy(gameObject);
    }
}