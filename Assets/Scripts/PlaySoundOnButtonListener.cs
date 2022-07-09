using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnButtonListener : MonoBehaviour
{
    public Button button;
    ButtonSoundManager buttonSoundManager;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(PlayThing);
        
        buttonSoundManager = GameObject.FindWithTag("ButtonSoundManager").GetComponent<ButtonSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayThing(){
        buttonSoundManager.PlayOnButtonClick();
    }
}
