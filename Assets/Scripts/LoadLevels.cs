using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose");
    }

    public void LoadUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeEgg");
    }

    public void LoadBattleScene()
    {
        SceneManager.LoadScene("Battle");
    }
}