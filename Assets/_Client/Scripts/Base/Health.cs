using System.ComponentModel.Design;
using UnityEngine;

public class Health : MonoBehaviour 
{
    [SerializeField] protected float maxHealth;
    [SerializeField] private Explosion _explosion;

    protected float health = 0;

    private void Start()
    {
        Heal(maxHealth);
    }

    public virtual void TakeDamege(float damage)
    {
        health -= damage;
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