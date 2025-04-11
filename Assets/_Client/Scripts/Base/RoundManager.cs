using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] [Range(0, 200)] private int _roundTime;
    [SerializeField] private PlayerSpawner[] _playerSpawners;

    private float _currentTime;
    private bool _isPlaying = false;
    private float _count = 1;

    private int _player1Count = 0;
    private int _player2Count = 0;

    public List<Enemy> _enemies;

    private void Start() 
    {
        Game.Instance.roundManager = this;
        _currentTime = _roundTime;   
        Game.Instance.UIManager.gameUI.UpdateScore(_player1Count, _player2Count);
    }

    public void StartManager()
    {
        _isPlaying = true;
    }

    private void Update()
    {
        if(_isPlaying)
        {
            _currentTime -= Time.deltaTime;
            Game.Instance.UIManager.gameUI.UpdateTime((int)_currentTime);
        }
        else
        {
            _count += Time.deltaTime;
            Game.Instance.UIManager.gameUI.UpdateTime((int)_count);
        }

        if(_count >= 3.5)
        {
            _count = 0;
        }

        if(_currentTime <= 0)
        {
            TimeRunOut();
        }
    }

    private void TimeRunOut()
    {
        if(Game.Instance.player1.health.health == Game.Instance.player2.health.health)
        {
            Game.Instance.UIManager.gameUI.ThrowMessageOnCenterScreen("Draw", 1.5f);
            Destroy(Game.Instance.player1.gameObject);
            Destroy(Game.Instance.player2.gameObject);
            for(int i = 0; i < _playerSpawners.Length; i++)
            {
                _playerSpawners[i].SpawnNewPlayer();
            }
            _currentTime = _roundTime;
        }
        if(Game.Instance.player1.health.health < Game.Instance.player2.health.health)
        {
            EndRound(2);
        }
        else if(Game.Instance.player1.health.health > Game.Instance.player2.health.health)
        {
            EndRound(1);
        }
    }

    public void EndRound(int playerId)
    {
        if(playerId == 1)
        {
            _player1Count++;
            Game.Instance.UIManager.gameUI.ThrowMessageOnCenterScreen("Player 1 won", 1.5f);
        }
        else
        {   
            _player2Count++;
            Game.Instance.UIManager.gameUI.ThrowMessageOnCenterScreen("Player 2 won", 1.5f);
        }
        Game.Instance.UIManager.gameUI.UpdateScore(_player1Count, _player2Count);
        Destroy(Game.Instance.player1.gameObject);
        Destroy(Game.Instance.player2.gameObject);
        for(int i = 0; i < _playerSpawners.Length; i++)
        {
            _playerSpawners[i].SpawnNewPlayer();
        }
        _currentTime = _roundTime;
    }

    private void OnDestroy()
    {
        Game.Instance.roundManager = null;
    }
}