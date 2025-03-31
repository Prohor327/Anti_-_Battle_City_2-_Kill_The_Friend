using UnityEngine;
using UnityEngine.Tilemaps;

public class Water : MonoBehaviour 
{
    [SerializeField] private Tilemap _water1;
    [SerializeField] private Tilemap _water2;
    [SerializeField] private float _rate;

    private float _currentTime;

    private void Update()
    {
        if(_currentTime >= _rate)
        {
            if(_water1.gameObject.activeInHierarchy)
            {
                _water1.gameObject.SetActive(false);
                _water2.gameObject.SetActive(true);
            }
            else
            {
                _water2.gameObject.SetActive(false);
                _water1.gameObject.SetActive(true);
            }
            _currentTime = 0;
        }
        _currentTime += Time.deltaTime;
    }
}