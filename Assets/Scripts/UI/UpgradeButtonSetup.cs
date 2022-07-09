using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonSetup : MonoBehaviour
{
    public Button TipSharpnessButton, ShellTopButton, TopRightShellButton;
    public Button TopLeftShellButton, BottomRightShellButton, BottomLeftShellButton;
    public Button EggSlipButton;

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
    }

    void UpgradeShellTop()
    {
        eggUpgrade.IncreaseEggTopThickness();
    }
    void UpgradeTopRightShell()
    {
        eggUpgrade.IncreaseEggTopRightThickness();
    }
    void UpgradeTopLeftShell()
    {
        eggUpgrade.IncreaseEggTopLeftThickness();
    }
    void UpgradeBottomRightShell()
    {
        eggUpgrade.IncreaseEggBottomRightThickness();
    }
    void UpgradeBottomLeftShell()
    {
        eggUpgrade.IncreaseEggBottomLeftThickness();
    }
    void UpgradeEggSlip()
    {
        eggUpgrade.IncreaseEggSlipperyness();
    }

}
