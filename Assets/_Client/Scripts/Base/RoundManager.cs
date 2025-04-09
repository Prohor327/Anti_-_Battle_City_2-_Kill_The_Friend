using UnityEngine;
using UnityEngine.Rendering;

public class RoundManager : PersistentSingleton<RoundManager> 
{
    [SerializeField] [Range(0, 200)] private int _roundTime;

    private float _currentTime;
    private bool _isPlaying;

    private void Start() 
    {
        _currentTime = _roundTime;    
    }

    private void Update()
    {
        if(_isPlaying)
        {
            _currentTime -= Time.deltaTime;
            Game.Instance.UIManager.gameUI.UpdateTime((int)_currentTime);
        }

        if(_currentTime <= 0)
        {

        }
    }

    private void EndRound()
    {
        
    }
}