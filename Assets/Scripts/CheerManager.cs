using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerManager : MonoBehaviour
{
    bool VolumeIncreasing = false;
    float peakVolume = 0.3f;
    float volumeIncreaseSpeed = 1f;
    float volumeDecreaseSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(VolumeIncreasing)
        {
            if(AudioListener.volume < peakVolume)
            {
                AudioListener.volume += volumeIncreaseSpeed * Time.deltaTime;
            }
            if(AudioListener.volume >= peakVolume)
            {
                VolumeIncreasing = false;
            }
        }
        if(GetComponent<AudioSource>().volume > 0 && !VolumeIncreasing)
        {
            GetComponent<AudioSource>().volume -= volumeDecreaseSpeed * Time.deltaTime;
        }
    }

    public void PlayCheer()
    {
        if(!VolumeIncreasing) VolumeIncreasing = true;
    }
}
