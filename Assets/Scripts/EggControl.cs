using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{
    float springFrequency = 1f;
    bool eggIsFollowing = false;

    SpringJoint2D spring;
    Rigidbody2D mouseFollower;
    void Start() {
        mouseFollower = GameObject.Find("MouseFollower").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //if mouse hits the egg, then follow the mouse
            if(Physics2D.OverlapCircle(transform.position, 0.1f, 1 << LayerMask.NameToLayer("Egg")))
            {
                eggIsFollowing = true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;        
                //Create 2d spring connecting the mouse position to where the mouse pressed the egg 
                spring = gameObject.AddComponent<SpringJoint2D>();
                spring.connectedBody = mouseFollower;
                Debug.Log("setting anchor to: " + mousePosition);
                spring.anchor = mousePosition;
                spring.dampingRatio = 0.5f;
                spring.frequency = springFrequency;
                spring.distance = 0;
                spring.autoConfigureDistance = false;
            }
        }

        //if mouse is released, stop egg
        if (Input.GetMouseButtonUp(0))
        {
            //remove spring joint
            Destroy(GetComponent<SpringJoint2D>());
            eggIsFollowing = false;
        }

    }

}
