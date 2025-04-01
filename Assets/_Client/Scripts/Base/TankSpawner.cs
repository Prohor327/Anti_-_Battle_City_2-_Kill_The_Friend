using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tank;

    public void Spawn()
    {
        Instantiate(_tank.gameObject, transform.position, transform.rotation);
    }

    public void End()
    {
        Destroy(gameObject);
    }
}
