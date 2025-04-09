using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] [Range(0, 200)] private int _roundTime;

    private float _currentTime;
    private bool _isPlaying = false;
    private float a = 1;

    private void Start() 
    {
        Game.Instance.roundManager = this;
        _currentTime = _roundTime;    
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
            a += Time.deltaTime;
            Game.Instance.UIManager.gameUI.UpdateTime((int)a);
        }

        if(a >= 3.5)
        {
            Game.Instance.OnStartRound?.Invoke();
            a = 0;
        }

        if(_currentTime <= 0)
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        Game.Instance.gameMachine.LoadLevel();
    }

    private void OnDestroy()
    {
        Game.Instance.roundManager = null;
    }
}