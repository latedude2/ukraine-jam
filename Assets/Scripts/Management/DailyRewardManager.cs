using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardManager : MonoBehaviour
{
    [SerializeField] int playerXP;
    [SerializeField] int PreviousPlayerXP;
    [SerializeField] int playerLevel;
    [SerializeField] int xpForLevelUp = 50;
    [SerializeField] int playerXPPerDay = 10;
    [SerializeField] GameObject RewardEgg;
    [SerializeField] List<GameObject> PreviewEgg = new List<GameObject>();
    [SerializeField] Transform spawnEggTransform;
    [SerializeField] List<Sprite> UnlockEggs;
    [SerializeField] GameObject updateEggParticle;

    [SerializeField] private SerializableList<int> completedDays;
    // Start is called before the first frame update
    void Start()
    {
        completedDays = new SerializableList<int>();
        LoadDataFromPlayerPrefs();
        PreviousPlayerXP = playerXP;
        GiveReward();
    }

    void GiveReward()
    {
        int currentDay = System.DateTime.Now.Day;
        currentDay += System.DateTime.Now.Month * 12;
        currentDay += System.DateTime.Now.Year * 365;
        Debug.Log("Current day: " + currentDay);
        if(completedDays == null)
        {
            completedDays = new SerializableList<int>();
        }
        if (playerLevel !>= UnlockEggs.Count) {
            if (completedDays.list.Contains(currentDay))
            {
                //do nothing
                //Show that the player has already collected the reward
                ShowEggProgress();
            }
            else
            {
                completedDays.list.Add(currentDay);
                GivePlayerXP();
                StartCoroutine(SpawnRewardEggs());
                ShowEggProgress();
                StartCoroutine(UpdateEggProgress());
            }
        }

        
        SaveDataToPlayerPrefs();
    }


    IEnumerator SpawnRewardEggs()
    {
        for(int i = 0; i < playerXPPerDay; i++)
        {
            Instantiate(RewardEgg, spawnEggTransform);
            //play sound
            //particle effect

            yield return new WaitForSeconds(0.5f);
        }
    }

    void ShowEggProgress(){
        for(int i = 0; i < PreviewEgg.Count; i++)
        {
            if (PreviousPlayerXP >= (xpForLevelUp/5)*(i+1)) {
                PreviewEgg[i].SetActive(true);
            }
        }
    }

    IEnumerator UpdateEggProgress(){
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < PreviewEgg.Count; i++)
        {
            if (playerXP >= (xpForLevelUp/5)*(i+1) && !PreviewEgg[i].activeSelf) {
                PreviewEgg[i].SetActive(true);

                GameObject updateParticle = Instantiate(updateEggParticle, PreviewEgg[i].transform.position, Quaternion.identity) as GameObject;
                if (i == PreviewEgg.Count) {
                    PreviewEgg[i].GetComponent<SpriteRenderer>().sprite = UnlockEggs[playerLevel-1]; //REMEMBER TO POPULATE UNLOCKEGGS WITH NEW EGG SKINS
                    updateParticle.transform.localScale *= 4;
                } else {
                    updateParticle.transform.localScale *= 2;
                }
                Destroy(updateParticle, 3f);
            }
        }
    }

    void GivePlayerXP()
    {
        playerXP += playerXPPerDay;
         
        if (playerXP >= xpForLevelUp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        playerLevel++;
        playerXP -= xpForLevelUp;

        if (playerLevel !> UnlockEggs.Count) {
            //Add UnlockEggs[playerLevel] to player eggs
        }
    }

    void LoadDataFromPlayerPrefs()
    {
        playerXP = PlayerPrefs.GetInt("PlayerXP");
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        Debug.Log(PlayerPrefs.GetString("CompletedDays"));
        completedDays = JsonUtility.FromJson<SerializableList<int>>(PlayerPrefs.GetString("CompletedDays"));
        Debug.Log(completedDays);
    }

    void SaveDataToPlayerPrefs()
    {
        PlayerPrefs.SetInt("PlayerXP", playerXP);
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);
        string json = JsonUtility.ToJson(completedDays);
        Debug.Log(json);
        PlayerPrefs.SetString("CompletedDays", json);
    }
}

 [System.Serializable]
 public class SerializableList<T> {
     public List<T> list;

    public SerializableList() {
        list = new List<T>();
    }
 }
