using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerControlPreset _controlPreset;
    [SerializeField] private TankMotor _tankMotor;

    private void Start()
    {
        _tankMotor.Initialize(transform, GetComponent<Animator>());
    }

    private void Update()
    {
        Vector2 tankDirection = Vector2.zero;
        if(Input.GetKey(_controlPreset.moveDown))
        {
            tankDirection = Vector2.down;
        }
        else if(Input.GetKey(_controlPreset.moveLeft))
        {
            tankDirection = Vector2.left;
        }
        else if(Input.GetKey(_controlPreset.moveRight))
        {
            tankDirection = Vector2.right;
        }
        else if(Input.GetKey(_controlPreset.moveUp))
        {
            tankDirection = Vector2.up;
        }
        _tankMotor.Move(tankDirection);
    }
}
