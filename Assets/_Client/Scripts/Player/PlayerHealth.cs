using UnityEngine;

public class PlayerHealth : Health 
{
    private int _playerId;

    public void Initialize(int playerId)
    {
        _playerId = playerId;
        base.Initialize();
    }

    public override void Heal(float points)
    {
        base.Heal(points);
        Game.Instance.UIManager.gameUI.UpdateHP(_playerId, health, maxHealth);
    }

    public override void ImproveMaxHealth(float points)
    {
        base.ImproveMaxHealth(points);
        Game.Instance.UIManager.gameUI.UpdateHP(_playerId, health, maxHealth);
    }

    public override void TakeDamege(float damage)
    {
        base.TakeDamege(damage);
        Game.Instance.UIManager.gameUI.UpdateHP(_playerId, health, maxHealth);
    }
}