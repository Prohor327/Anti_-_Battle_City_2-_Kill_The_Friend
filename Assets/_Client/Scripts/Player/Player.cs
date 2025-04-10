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
    public float speedProjectile;
    public float damage;

    private PlayerControlPreset _controlPreset;
    private int _currentExp = 0;

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
        health = GetComponent<PlayerHealth>();
        health.Initialize(_playerId);
        Game.Instance.UIManager.gameUI.UpdateExp(_playerId, _currentExp, _maxAmountExp);
        Game.Instance.roundManager.StartManager();
    }

    private void Update()
    {
        if(!isInitialized) return;
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
            weapon.Attack(transform.rotation, this, damage, speedProjectile); 
        }
        weapon.OnUpdate();
    }

    protected override void OnDestroy()
    {
        Game.Instance.player1 = null;
        Game.Instance.player2 = null;   
    }

    public AbillitySO[] GetRandomAbillitySOs()
    {
        List<AbillitySO> abillitySOs =  new List<AbillitySO>(_freeAbilities);
        AbillitySO[] result = new AbillitySO[3];

        for(int i = 0; i < 3; i++)
        {
            result[i] = abillitySOs[Random.Range(0, abillitySOs.Count - 1)];
            abillitySOs.Remove(result[i]);
        }

        return result;
    }

    public void AddExp(int amountexp)
    {
        _currentExp += amountexp;
        audioSource.PlayOneShot(_pickUpGear);
        if(_currentExp >= _maxAmountExp)
        {
            _currentExp -= _maxAmountExp;
        }
        Game.Instance.UIManager.gameUI.UpdateExp(_playerId, _currentExp, _maxAmountExp);
    }

    public void PlayLevelUpSound()
    {
        audioSource.PlayOneShot(_levelUpSound);
    }

    public void ImproveSpeed(float value)
    {
        tankMotor.speed += value;
    }

    public override void Die()
    {
        base.Die();
        Game.Instance.roundManager.EndRound(_playerId);
    }
}
