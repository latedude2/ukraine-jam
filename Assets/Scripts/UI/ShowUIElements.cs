using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIElements : MonoBehaviour
{
    [SerializeField] List<GameObject> uiElements = new List<GameObject>();
    public GameObject banner;
    public void EnableUIElements()
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(true);
        }
        banner.SetActive(false);
    }
}
