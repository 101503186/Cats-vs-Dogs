using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerMovement movement;
    PlayerCombat combat;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
    }

    public float MoveSpeed
    {
        get => movement.MoveSpeed;
        set => movement.MoveSpeed = value;
    }

    public float ShootCooldown
    {
        get => combat.ShootCooldown;
        set => combat.ShootCooldown = value;
    }

    public float BulletSpeed
    {
        get => combat.BulletSpeed;
        set => combat.BulletSpeed = value;
    }

    public float BulletSize
    {
        get => combat.BulletSize;
        set => combat.BulletSize = value;
    }

    public int ProjectileCount
    {
        get => combat.ProjectileCount;
        set => combat.ProjectileCount = value;
    }

}
