using UnityEngine;

public class RenderTextureCleaner : MonoBehaviour   
{
    [SerializeField] private RenderTexture _renderTexture;

    private void Start() 
    {
        _renderTexture.Release();    
    }
}