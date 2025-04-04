using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] [Range(1, 2)] private int _playerId;
    [SerializeField] private PlayerControlPreset _controlPreset;
    [SerializeField] private List<AbillitySO> _freeAbilities;

    public Health health { get; private set; }

    protected override void Start()
    {
        base.Start();
        if(_playerId == 1)
        {
            Game.Instance.player1 = this;
        }
        else if(_playerId == 2)
        {
            Game.Instance.player2 = this;
        }

        health = GetComponent<Health>();
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
            weapon.Attack(transform.rotation); 
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
}
