using System;
using UnityEngine;

[Serializable]
public class TankMotor
{
    [SerializeField] private float _speed;

    private Transform _movableTransform;
    private Quaternion _rot;
    private Vector2 _previousDirection;
    private Animator _animator;

    public void Initialize(Transform movableTransform, Animator tankAnimator)
    {
        _movableTransform = movableTransform;
        _animator = tankAnimator;
    }

    public void Move(Vector2 normalizedDirection)
    {   
        if(_previousDirection != normalizedDirection)
        {
            if(normalizedDirection == Vector2.zero)
            {
                _animator.Play("Idle");
                _previousDirection = normalizedDirection;
                return;
            }
            else
            {
                _animator.Play("Move");
            }
        }

        if(normalizedDirection.x == 1)
        {
            _rot = Quaternion.Euler(0, 0, -90);
        }
        else if (normalizedDirection.x == -1) 
        {
            _rot = Quaternion.Euler(0, 0, 90);
        }
        else if (normalizedDirection.y == 1)
        {
            _rot = Quaternion.Euler(0, 0, 0);
        }
        else if (normalizedDirection.y == -1)
        {
            _rot = Quaternion.Euler(0, 0, 180);
        }
        _movableTransform.rotation = _rot;
        _movableTransform.position += new Vector3(normalizedDirection.x * _speed * Time.deltaTime, normalizedDirection.y * _speed * Time.deltaTime, 0);
        _previousDirection = normalizedDirection;
    } 
}