using UnityEngine;
using DG.Tweening;

public class Gear : MonoBehaviour 
{ 
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _followingSpeed;
    [SerializeField] private int _value;

    private Player _player;
    private Transform _target;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Length)];
    }

    public void Run(Vector3 to) 
    {
        transform.DOJump(to, 2, 1, 1.0f, false);
    }

    public void StartFollow(Transform target, Player player)
    {
        _target = target;
        _player = player;
    }

    private void Update()
    {
        if(_target != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _followingSpeed);
        }
    }

    public void PickUp()
    {
        _player.AddExp(_value);
        Destroy(gameObject);
    }
}