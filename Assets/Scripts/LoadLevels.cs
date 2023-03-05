using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose");
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("Win");
    }

    public void LoadUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeEgg");
    }

    public void LoadBattleScene()
    {
        if(!GameObject.Find("GameModeManager").GetComponent<GameModeManager>().isStoryMode)
        SceneManager.LoadScene("Battle");
        else LoadNextBattleStory();
    }

    public void LoadChooseScene()
    {
        GameObject.Find("GameModeManager").GetComponent<GameModeManager>().SetModeToStory(false);
        SceneManager.LoadScene("ChooseEgg");
    }

    public void LoadChooseSceneAsStoryMode()
    {
        GameObject.Find("GameModeManager").GetComponent<GameModeManager>().SetModeToStory(true);
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
        GameObject playerStats = GameObject.Find("PlayerStats");
        if(playerStats != null) playerStats.GetComponent<Progression>().Level = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadDailyChallenge()
    {
        SceneManager.LoadScene("DailyChallenge");
    }
}
