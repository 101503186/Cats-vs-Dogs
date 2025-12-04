using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject upgradePanel;

    [SerializeField] TMP_Text upgradeDescriptionOne;
    [SerializeField] TMP_Text upgradeDescriptionTwo;
    [SerializeField] TMP_Text upgradeDescriptionThree;

    [Header("Upgrade Pool")]
    [SerializeField] List<UpgradeEffectBase> upgradePool;

    PlayerStats playerStats;

    UpgradeEffect option1;
    UpgradeEffect option2;
    UpgradeEffect option3;

    private void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        upgradePanel.SetActive(false);
    }

    public void ShowPanel()
    {
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);

        option1 = CreateFromRandomSO();
        option2 = CreateFromRandomSO();
        option3 = CreateFromRandomSO();

        upgradeDescriptionOne.text = $"{option1.Name}\n{option1.Description}";
        upgradeDescriptionTwo.text = $"{option2.Name}\n{option2.Description}";
        upgradeDescriptionThree.text = $"{option3.Name}\n{option3.Description}";
    }

    UpgradeEffect CreateFromRandomSO()
    {
        UpgradeEffectBase baseSO = upgradePool[Random.Range(0, upgradePool.Count)];
        return new UpgradeEffect(baseSO);
    }

    // BUTTON EVENTS
    public void ChooseUpgradeOne() => ApplyAndClose(option1);
    public void ChooseUpgradeTwo() => ApplyAndClose(option2);
    public void ChooseUpgradeThree() => ApplyAndClose(option3);

    void ApplyAndClose(UpgradeEffect chosen)
    {
        chosen.Apply(playerStats);

        Time.timeScale = 1f;
        upgradePanel.SetActive(false);
    }
}
