using UnityEngine;

public class GearsPicker : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Gear>(out Gear gear))
        {
            gear.PickUp();
        }
    }
}