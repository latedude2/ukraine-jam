using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] List<GameObject> updateEggParticle = new List<GameObject>();

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
        if (playerLevel < UnlockEggs.Count) {
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
            if (PreviousPlayerXP >= (xpForLevelUp/PreviewEgg.Count)*(i+1)) {
                PreviewEgg[i].SetActive(true);
                if (i+1 == PreviewEgg.Count) {
                    PreviewEgg[i].GetComponent<Image>().sprite = UnlockEggs[playerLevel]; //REMEMBER TO POPULATE UNLOCKEGGS WITH NEW EGG SKINS
                    //updateParticle.GetComponent<RectTransform>().localScale *= 4;
                }
            }
        }
    }

    IEnumerator UpdateEggProgress(){
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < PreviewEgg.Count; i++)
        {
            if (playerXP >= (xpForLevelUp/PreviewEgg.Count)*(i+1) && !PreviewEgg[i].activeSelf) {
                PreviewEgg[i].SetActive(true);
                updateEggParticle[i].SetActive(true);

                //GameObject updateParticle = Instantiate(updateEggParticle, PreviewEgg[i].GetComponent<RectTransform>().position, Quaternion.identity) as GameObject;
                if (i+1 == PreviewEgg.Count) {
                    PreviewEgg[i].GetComponent<Image>().sprite = UnlockEggs[playerLevel]; //REMEMBER TO POPULATE UNLOCKEGGS WITH NEW EGG SKINS
                    //updateParticle.GetComponent<RectTransform>().localScale *= 4;
                } else {
                    //updateParticle.GetComponent<RectTransform>().localScale *= 2;
                }
                //Destroy(updateParticle, 3f);
            }   
        }
        LevelUp();
    }

    void GivePlayerXP()
    {
        playerXP += playerXPPerDay;
         
        
    }

    void LevelUp()
    {
        if (playerXP >= xpForLevelUp)
        {

            playerLevel++;
            playerXP -= xpForLevelUp;


            SaveDataToPlayerPrefs();
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
