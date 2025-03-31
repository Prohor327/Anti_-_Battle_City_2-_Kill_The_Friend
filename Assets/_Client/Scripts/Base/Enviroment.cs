using UnityEngine;
using UnityEngine.Tilemaps;

public class Enviroment : MonoBehaviour 
{
    private Tilemap _tilemap;

    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
    }

    public void DestroyTile(Vector3 tilePos)
    {
        _tilemap.SetTile(_tilemap.WorldToCell(tilePos), null);
    }
}