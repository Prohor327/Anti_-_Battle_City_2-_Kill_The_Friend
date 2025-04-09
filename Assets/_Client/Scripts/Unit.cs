using UnityEngine;

public class Unit : MonoBehaviour 
{
    [SerializeField] protected TankMotor tankMotor;
    [SerializeField] protected Weapon weapon;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private AudioClip _shoot;
    
    protected AudioSource audioSource;

    protected bool isInitialized = false;

    public virtual void Initialize()
    {
        tankMotor.Initialize(transform, GetComponent<Animator>());
        weapon.OnAttack += () => audioSource.PlayOneShot(_shoot);
        audioSource = GetComponent<AudioSource>();
        isInitialized = true;
    }

    public virtual void Die()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}