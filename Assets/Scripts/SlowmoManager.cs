using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //implement singleton
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
        
    }
}
