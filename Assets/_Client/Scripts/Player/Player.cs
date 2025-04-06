using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] [Range(1, 2)] private int _playerId;
    [SerializeField] private RuntimeAnimatorController _animatorController1;
    [SerializeField] private RuntimeAnimatorController _animatorController2;
    [SerializeField] private PlayerControlPreset _controlPreset1;
    [SerializeField] private PlayerControlPreset _controlPreset2;
    [SerializeField] private List<AbillitySO> _freeAbilities;
    [SerializeField] private int _maxAmountExp;
    [SerializeField] private AudioClip _pickUpGear;
    [SerializeField] private AudioClip _levelUpSound;
    [SerializeField] private AudioClip _shoot;

    private PlayerControlPreset _controlPreset;
    private int _currentExp = 0;
    private AudioSource _audioSource;

    public PlayerHealth health { get; private set; }

    public void Initialize(int playerId)
    {
        _playerId = playerId;
        base.Initialize();
        if(_playerId == 1)
        {
            Game.Instance.player1 = this;
            GetComponent<Animator>().runtimeAnimatorController = _animatorController1;
            _controlPreset = _controlPreset1;
        }
        else if(_playerId == 2)
        {
            Game.Instance.player2 = this;
            GetComponent<Animator>().runtimeAnimatorController = _animatorController2;
            _controlPreset = _controlPreset2;
        }
        weapon.OnAttack += () => _audioSource.PlayOneShot(_shoot);
        health = GetComponent<PlayerHealth>();
        health.Initialize(_playerId);
        _audioSource = GetComponent<AudioSource>();
        Game.Instance.UIManager.gameUI.UpdateExp(_playerId, _currentExp, _maxAmountExp);
    }

    private void Update()
    {
        Vector2 tankDirection = Vector2.zero;
        if(Input.GetKey(_controlPreset.moveDown))
        {
            tankDirection = Vector2.down;
        }
        else if(Input.GetKey(_controlPreset.moveLeft))
        {
            tankDirection = Vector2.left;
        }
        else if(Input.GetKey(_controlPreset.moveRight))
        {
            tankDirection = Vector2.right;
        }
        else if(Input.GetKey(_controlPreset.moveUp))
        {
            tankDirection = Vector2.up;
        }
        tankMotor.Move(tankDirection);

        if(Input.GetKeyDown(_controlPreset.shoot))
        {
            weapon.Attack(transform.rotation, this); 
        }
        weapon.OnUpdate();
    }

    private void OnDisable()
    {
        if(_playerId == 1)
        {
            Game.Instance.player1 = null;
        }
        else if(_playerId == 2)
        {
            Game.Instance.player2 = null;
        }       
    }

    public bool TryGetRandomAbility(out AbillitySO abillitySO)
    {
        abillitySO = null;
        if(!_freeAbilities.Any())
        {
            return false;
        }

        abillitySO = _freeAbilities[Random.Range(0, _freeAbilities.Count)];
        _freeAbilities.Remove(abillitySO);
        return true;
    }

    public void AddExp(int amountexp)
    {
        _currentExp += amountexp;
        _audioSource.PlayOneShot(_pickUpGear);
        if(_currentExp >= _maxAmountExp)
        {
            _currentExp -= _maxAmountExp;
        }
        Game.Instance.UIManager.gameUI.UpdateExp(_playerId, _currentExp, _maxAmountExp);
    }

    public void PlayLevelUpSound()
    {
        _audioSource.PlayOneShot(_levelUpSound);
    }
}
