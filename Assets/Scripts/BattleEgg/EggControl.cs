using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{

    public float eggFollowForce = 1f;
    public float eggSlipperyness = 1f; //The bigger the slipperyness the less force for the spring to break

    [SerializeField] float damping = 0.7f;
    bool eggIsFollowing = false;
    bool eggIsHovered = false;

    SpringJoint2D spring;
    Rigidbody2D mouseFollower;
    void Start() {
        mouseFollower = GameObject.Find("MouseFollower").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && eggIsHovered)
        {
            eggIsFollowing = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;        
            //Create 2d spring connecting the mouse position to where the mouse pressed the egg 
            spring = gameObject.AddComponent<SpringJoint2D>();
            spring.connectedBody = mouseFollower;
            //Debug.Log("setting anchor to: " + mousePosition);
            //convert mouse position to local space
            spring.anchor = transform.InverseTransformPoint(mousePosition);
            //Debug.Log("Anchor position: " + mousePosition);
            spring.dampingRatio = damping;
            spring.frequency = eggFollowForce;
            spring.breakForce = 1000/eggSlipperyness;
            spring.distance = 0;
            spring.autoConfigureDistance = false;
        }

        //if mouse is released, stop egg
        if (Input.GetMouseButtonUp(0) && eggIsFollowing)
        {
            //remove spring joint
            Destroy(GetComponent<SpringJoint2D>());
            eggIsFollowing = false;
        }

    }

    void OnMouseEnter()
    {
        eggIsHovered = true;
    }

    void OnMouseExit() {
        eggIsHovered = false;
    }

}
