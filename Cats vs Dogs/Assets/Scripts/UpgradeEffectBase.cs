using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/Create new upgrade")]

public class UpgradeEffectBase : ScriptableObject
{
    [Header("Info")]
    [SerializeField] string upgradeName;

    [TextArea]
    [SerializeField] string description;

    [Header("Effect")]
    [SerializeField] UpgradeType upgradeType;

    [SerializeField] float value;        
    [SerializeField] bool isPercentage;  

    public string Name => upgradeName;
    public string Description => description;
    public UpgradeType Type => upgradeType;
    public float Value => value;
    public bool IsPercentage => isPercentage;
}

public enum UpgradeType
{
    MoveSpeed,
    ShootCooldown,
    BulletSpeed,
    BulletSize,
    ProjectileCount
}
