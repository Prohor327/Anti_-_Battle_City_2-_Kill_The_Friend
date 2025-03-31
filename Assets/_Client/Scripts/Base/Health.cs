using UnityEngine;

public class Health : MonoBehaviour 
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Explosion _explosion;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamege(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Die();
        }
    }    

    public void Heal(float points)
    {
        _health += points;
        if(_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void Die()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}