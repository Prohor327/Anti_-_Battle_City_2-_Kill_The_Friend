using UnityEngine;

public class Unit : MonoBehaviour 
{
    [SerializeField] protected TankMotor tankMotor;
    [SerializeField] protected Weapon weapon;

    private void Start()
    {
        tankMotor.Initialize(transform, GetComponent<Animator>());
    }
}