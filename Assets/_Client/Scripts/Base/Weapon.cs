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

    public void Attack(Quaternion rotationProjectile, Unit unit)
    {
        if(_attackTimer > _rate)
        {
            _attackTimer = 0.0f;
            Projectile projectile = MonoBehaviour.Instantiate(_projectile, _bulletSpawnPoint.position, rotationProjectile);
            OnAttack?.Invoke();
            projectile.Run(unit);
        }
    }

    public void OnUpdate()
    {
        _attackTimer += Time.deltaTime;
    }
}