using UnityEngine;

public class Bootstrap : MonoBehaviour 
{
    private void Start()
    {
        GameMachine.Instance.Initialize();
        GameMachine.Instance.OpenMenu();
    }
}