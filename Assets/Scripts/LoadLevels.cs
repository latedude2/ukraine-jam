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

    public void LoadChooseScene()
    {
        SceneManager.LoadScene("ChooseEgg");
    }

    public void LoadChooseSceneAsStoryMode()
    {
        GameObject.Find("GameModeManager").GetComponent<GameModeManager>().SetModeToStory();
        SceneManager.LoadScene("ChooseEgg");
    }

    public void LoadNextBattleStory()
    {
        SceneManager.LoadScene("StoryBattle " + (GameObject.Find("PlayerStats").GetComponent<Progression>().Level + 1));
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
