using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerManager : MonoBehaviour
{
    public bool VolumeIncreasing = false;
    float peakVolume = 0.4f;
    float volumeIncreaseSpeed = 0.5f;
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
            if(GetComponent<AudioSource>().volume < peakVolume)
            {
                GetComponent<AudioSource>().volume += volumeIncreaseSpeed * Time.deltaTime;
            }
            if(GetComponent<AudioSource>().volume >= peakVolume)
            {
                VolumeIncreasing = false;
            }
        }
        if(GetComponent<AudioSource>().volume > 0.1f && !VolumeIncreasing)
        {
            GetComponent<AudioSource>().volume -= volumeDecreaseSpeed * Time.deltaTime;
        }
    }

    public void PlayCheer()
    {
        if(!VolumeIncreasing) VolumeIncreasing = true;
    }
}
