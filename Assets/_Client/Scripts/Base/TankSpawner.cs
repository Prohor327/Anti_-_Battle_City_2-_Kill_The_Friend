using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] protected Unit _tank;

    public virtual void Spawn()
    {
        Instantiate(_tank.gameObject, transform.position, transform.rotation);
    }

    public virtual void End()
    {
        Destroy(gameObject);
    }
}
