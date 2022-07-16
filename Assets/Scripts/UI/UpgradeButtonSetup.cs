using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonSetup : MonoBehaviour
{
    public Button TipSharpnessButton, ShellTopButton, TopRightShellButton;
    public Button TopLeftShellButton, BottomRightShellButton, BottomLeftShellButton;
    public Button EggGripButton;
    public Button nextBattleButton;

    int upgradesLeft = 1;

    EggUpgrade eggUpgrade;
    
    ButtonSoundManager buttonSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        eggUpgrade = GameObject.Find("PlayerStats").GetComponent<EggUpgrade>();
        TipSharpnessButton.onClick.AddListener(UpgradeTipShrapness);
        ShellTopButton.onClick.AddListener(UpgradeShellTop);
        TopRightShellButton.onClick.AddListener(UpgradeTopRightShell);
        BottomRightShellButton.onClick.AddListener(UpgradeBottomRightShell);
        EggGripButton.onClick.AddListener(UpgradeEggGrip);
        
        buttonSoundManager = GameObject.FindWithTag("ButtonSoundManager").GetComponent<ButtonSoundManager>();
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
        eggUpgrade.IncreaseEggTopSideThickness();
        DoUpgrade();
    }
    void UpgradeBottomRightShell()
    {
        eggUpgrade.IncreaseEggBottomSideThickness();
        DoUpgrade();
    }
    void UpgradeEggGrip()
    {
        eggUpgrade.IncreaseEggGrip();
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
            Destroy(EggGripButton);
            nextBattleButton.interactable = true;
            buttonSoundManager.PlayOnButtonClick();
        }
    }

}
