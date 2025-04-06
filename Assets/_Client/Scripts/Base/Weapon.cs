using UnityEngine;
using System;

[Serializable]
public class Weapon
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _rate;
    [SerializeField] private Projectile _projectile;

    private float _attackTimer;

    public Action OnAttack;

    public void Attack(Quaternion rotationProjectile, Unit unit, float damage = 0, float speed = 0)
    {
        if(_attackTimer > _rate)
        {
            _attackTimer = 0.0f;
            Projectile projectile = MonoBehaviour.Instantiate(_projectile, _bulletSpawnPoint.position, rotationProjectile);
            if(damage != 0)
            {
                projectile.SetDamage(damage);
            }
            if(speed != 0)
            {
                projectile.SetSpeed(speed);
            }
            OnAttack?.Invoke();
            projectile.Run(unit);
        }
    }

    public void OnUpdate()
    {
        _attackTimer += Time.deltaTime;
    }
}