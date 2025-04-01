using UnityEngine;

public class Enemy : Unit 
{
    [SerializeField] private float _rateChangeDirection;

    private float _currentTime;
    private Vector2 direction;
    
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _rateChangeDirection)
        {
            int i = Random.Range(1, 5);
            switch (i)
            {
                case(1):
                direction = Vector2.up;
                break;
                case(2):
                direction = Vector2.right;
                break;
                case(3):
                direction = Vector2.left;
                break;
                case(4):
                direction = Vector2.down;
                break;
            }
            _currentTime = 0;
        }
        tankMotor.Move(direction);
        weapon.Attack(transform.rotation);
        weapon.OnUpdate();
    }  
}