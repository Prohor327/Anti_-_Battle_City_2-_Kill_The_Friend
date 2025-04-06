using UnityEngine;

public class Unit : MonoBehaviour 
{
    [SerializeField] protected TankMotor tankMotor;
    [SerializeField] protected Weapon weapon;
    [SerializeField] private Explosion _explosion;

    public virtual void Initialize()
    {
        tankMotor.Initialize(transform, GetComponent<Animator>());
    }

    public virtual void Die()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}