using UnityEngine;

public class GearsCollector : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Gear>(out Gear gear))
        {
            gear.StartFollow(transform.parent, transform.parent.GetComponent<Player>());
        }
    }
}