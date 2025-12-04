using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/Create new upgrade")]

public class UpgradeEffectBase : ScriptableObject
{
    [Header("Info")]
    [SerializeField] string upgradeName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite icon;

    [Header("Effect")]
    [SerializeField] UpgradeType upgradeType;

    [SerializeField] float value;        
    [SerializeField] bool isPercentage;  

    public string Name => upgradeName;
    public string Description => description;
    public Sprite Icon => icon;
    public UpgradeType Type => upgradeType;
    public float Value => value;
    public bool IsPercentage => isPercentage;
}

public enum UpgradeType
{
    MoveSpeed,
    ShootCooldown,
    BulletSpeed,
    BulletSize
}
