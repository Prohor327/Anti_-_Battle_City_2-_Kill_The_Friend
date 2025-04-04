using UnityEngine;
using DG.Tweening;

public class Gear : MonoBehaviour 
{ 
    [SerializeField] private Sprite[] _sprites;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Length)];
    }

    public void Run(Vector3 to) 
    {
        transform.DOJump(to, 2, 1, 1.0f, false);
    }
}