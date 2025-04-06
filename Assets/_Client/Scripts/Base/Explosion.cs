using UnityEngine;

public class Explosion : MonoBehaviour 
{
    [SerializeField] private AudioClip _sound;

    private void Start() 
    {
        GetComponent<AudioSource>().PlayOneShot(_sound);
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}