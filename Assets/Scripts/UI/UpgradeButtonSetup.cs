using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonSetup : MonoBehaviour
{
    public Button TipSharpnessButton, ShellTopButton, TopRightShellButton;
    public Button TopLeftShellButton, BottomRightShellButton, BottomLeftShellButton;
    public Button EggSlipButton;

    int upgradesLeft = 5;

    EggUpgrade eggUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        eggUpgrade = GameObject.Find("PlayerStats").GetComponent<EggUpgrade>();
        TipSharpnessButton.onClick.AddListener(UpgradeTipShrapness);
        ShellTopButton.onClick.AddListener(UpgradeShellTop);
        TopRightShellButton.onClick.AddListener(UpgradeTopRightShell);
        TopLeftShellButton.onClick.AddListener(UpgradeTopLeftShell);
        BottomRightShellButton.onClick.AddListener(UpgradeBottomRightShell);
        BottomLeftShellButton.onClick.AddListener(UpgradeBottomLeftShell);
        EggSlipButton.onClick.AddListener(UpgradeEggSlip);
    }

    void UpgradeTipShrapness()
    {
        eggUpgrade.IncreaseEggTipSharpness();
        DoUpgrade();
    }

    void UpgradeShellTop()
    {
        eggUpgrade.IncreaseEggTopThickness();
        DoUpgrade();
    }
    void UpgradeTopRightShell()
    {
        eggUpgrade.IncreaseEggTopRightThickness();
        DoUpgrade();
    }
    void UpgradeTopLeftShell()
    {
        eggUpgrade.IncreaseEggTopLeftThickness();
        DoUpgrade();
    }
    void UpgradeBottomRightShell()
    {
        eggUpgrade.IncreaseEggBottomRightThickness();
        DoUpgrade();
    }
    void UpgradeBottomLeftShell()
    {
        eggUpgrade.IncreaseEggBottomLeftThickness();
        DoUpgrade();
    }
    void UpgradeEggSlip()
    {
        eggUpgrade.IncreaseEggSlipperyness();
        DoUpgrade();
    }

    void DoUpgrade()
    {
        upgradesLeft--;
        if (upgradesLeft == 0)
        {
            Destroy(TipSharpnessButton);
            Destroy(ShellTopButton);
            Destroy(TopRightShellButton);
            Destroy(TopLeftShellButton);
            Destroy(BottomRightShellButton);
            Destroy(BottomLeftShellButton);
            Destroy(EggSlipButton);
        }
    }

}
