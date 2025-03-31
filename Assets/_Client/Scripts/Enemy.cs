using UnityEngine;

public class Enemy : Unit 
{
    [SerializeField] private float _detectedWallsLength;

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + _detectedWallsLength, transform.position.z), Color.red, 0.1f);       
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - _detectedWallsLength, transform.position.z), Color.red, 0.1f);       
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + _detectedWallsLength, transform.position.y, transform.position.z), Color.red, 0.1f);       
        Debug.DrawLine(transform.position, new Vector3(transform.position.x - _detectedWallsLength, transform.position.y, transform.position.z), Color.red, 0.1f);       
    }

    private void Update()
    {

        //tankMotor.Move()
        //weapon.Attack(transform.rotation);
        //weapon.OnUpdate();
    }  
}