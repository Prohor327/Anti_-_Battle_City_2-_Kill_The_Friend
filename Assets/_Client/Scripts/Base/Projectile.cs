using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    public void Run()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector3.up) * _speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}