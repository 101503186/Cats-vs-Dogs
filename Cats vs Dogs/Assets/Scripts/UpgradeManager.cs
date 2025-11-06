using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{

    [SerializeField] GameObject upgradePanel;
    [SerializeField] GameObject bulletPrefab;

    PlayerCombat playerCombat;
    BulletBehavior bulletBehavior;

    private void Start()
    {
        playerCombat = FindFirstObjectByType<PlayerCombat>();
        bulletBehavior = FindFirstObjectByType<BulletBehavior>();

        upgradePanel.SetActive(false);
    }

    public void ShowPanel()
    {
        upgradePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void IncreaseAttackSpeed()
    {
        playerCombat.shootCooldown = playerCombat.shootCooldown * 0.90f;
        Time.timeScale = 1.0f;
        upgradePanel.SetActive(false);
    }

    public void IncreaseBulletSize()
    {
        playerCombat.bulletSize = playerCombat.bulletSize * 1.10f;
        Time.timeScale = 1.0f;
        upgradePanel.SetActive(false);
    }

    public void IncreaseBulletSpeed()
    {
        playerCombat.bulletSpeed = playerCombat.bulletSpeed * 1.10f;
        Time.timeScale = 1.0f;
        upgradePanel.SetActive(false);
    }
}
