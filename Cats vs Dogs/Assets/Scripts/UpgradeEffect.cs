using UnityEngine;

[System.Serializable]
public class UpgradeEffect
{
    UpgradeEffectBase _base;
    int level = 1;

    public UpgradeEffectBase Base => _base;
    public int Level => level;

    public UpgradeEffect(UpgradeEffectBase baseSO)
    {
        _base = baseSO;
    }

    float FinalValue => _base.Value * level;

    public void LevelUp() => level++;

    public string Name => _base.Name;
    public string Description => _base.Description;

    public void Apply(PlayerStats player)
    {
        float amt = FinalValue;

        switch (_base.Type)
        {
            case UpgradeType.MoveSpeed:
                if (_base.IsPercentage) player.MoveSpeed *= (1 + amt);
                else player.MoveSpeed += amt;
                break;

            case UpgradeType.ShootCooldown:
                if (_base.IsPercentage) player.ShootCooldown *= (1 - amt);
                else player.ShootCooldown -= amt;
                break;

            case UpgradeType.BulletSpeed:
                if (_base.IsPercentage) player.BulletSpeed *= (1 + amt);
                else player.BulletSpeed += amt;
                break;

            case UpgradeType.BulletSize:
                if (_base.IsPercentage) player.BulletSize *= (1 + amt);
                else player.BulletSize += amt;
                break;
        }
    }
}
