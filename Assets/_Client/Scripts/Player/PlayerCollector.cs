using UnityEngine;

public class PlayerCollector : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TryGetComponent<Gear>(out Gear gear))
        {
            gear.Run();
        }
    }
}