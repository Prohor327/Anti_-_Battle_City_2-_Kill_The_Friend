using UnityEngine;

public class Health : MonoBehaviour 
{
    [SerializeField] protected float maxHealth;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private AudioClip _hit;

    private AudioSource _audioSource;
    public float health { get; private set; }

    public virtual void Initialize()
    {
        _audioSource = GetComponent<AudioSource>();
        Heal(maxHealth);
    }

    public virtual void TakeDamege(float damage)
    {
        health -= damage;
        _audioSource.PlayOneShot(_hit);
        if(health <= 0)
        {
            GetComponent<Unit>().Die();
        }
    }    

    public virtual void Heal(float points)
    {
        health += points;
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void ImproveMaxHealth(float points)
    {
        maxHealth += points;
    }
}