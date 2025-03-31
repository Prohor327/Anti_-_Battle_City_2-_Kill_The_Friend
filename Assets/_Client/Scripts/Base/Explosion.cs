using UnityEngine;

public class Explosion : MonoBehaviour 
{
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}