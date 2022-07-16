using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        //implement singleton
        if (AudioManager.Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Slowmo(bool on)
    {
        Slowmo(on, .5f);
    }

    public void Slowmo(bool on, float transitionTime)
    {
        mixer.FindSnapshot("Default").TransitionTo(Time.timeScale * transitionTime);
    }
}
