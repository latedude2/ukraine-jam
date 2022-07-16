using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    bool isWebGL = false;
    void Start()
    {
        #if UNITY_WEBGL
            isWebGL = true;
        #endif
        #if UNITY_EDITOR
            isWebGL = true;
        #endif
    }
    // Update is called once per frame
    void Update()
    {
        if(isWebGL == true) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        } else if (Input.touchCount > 0) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPosition.z = 0;
            transform.position = touchPosition;
        }
    }
}
