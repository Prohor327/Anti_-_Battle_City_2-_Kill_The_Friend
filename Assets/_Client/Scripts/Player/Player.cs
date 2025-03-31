using UnityEngine;

public class Player : Unit
{
    [SerializeField] private PlayerControlPreset _controlPreset;

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
        tankMotor.Move(tankDirection);

        if(Input.GetKeyDown(_controlPreset.shoot))
        {
            weapon.Attack(transform.rotation); 
        }
        weapon.OnUpdate();
    }
}
