using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{

    public float eggFollowForce = 1f;
    public float eggGrip = 1f; //The bigger the grip the more force for the spring to break

    [SerializeField] float damping = 0.7f;
    bool eggIsFollowing = false;
    bool eggIsHovered = false;

    SpringJoint2D spring;
    Rigidbody2D mouseFollower;
    bool isWebGL = false;
    float touchDist = 1.5f;
    public SpriteRenderer cursorAssist;
    void Start() {
        #if UNITY_WEBGL
            isWebGL = true;
        #endif
        #if UNITY_EDITOR
            isWebGL = true;
        #endif
        eggGrip = GameObject.Find("PlayerStats").GetComponent<EggManager>().EggGrip;
        mouseFollower = GameObject.Find("MouseFollower").GetComponent<Rigidbody2D>();
        cursorAssist = Instantiate(cursorAssist, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {   
        CheckTouchDist();

        if((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && eggIsHovered && !eggIsFollowing)
        {
            eggIsFollowing = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(!isWebGL)
                mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);  
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
            spring.breakForce = eggGrip * 1000f;
            spring.distance = 0;
            spring.autoConfigureDistance = false;
            cursorAssist.enabled = true;
        }
        
        
        Vector3 mousePositionUhh = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!isWebGL)
            mousePositionUhh = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);  
        mousePositionUhh.z = 0;
        cursorAssist.transform.position = mousePositionUhh;

        if (spring == null) {
            cursorAssist.enabled = false;
        }
        

        //if mouse is released, stop egg
        if ((Input.GetMouseButtonUp(0) || (!isWebGL && Input.touchCount == 0)) && eggIsFollowing)
        {
            //remove spring joint
            Destroy(GetComponent<SpringJoint2D>());
            eggIsFollowing = false;
            cursorAssist.enabled = false;
        }

    }

    void CheckTouchDist(){
        if(isWebGL == false)
        {
            float dist = Vector3.Distance(transform.position, mouseFollower.transform.position);
            if (dist < touchDist)
            {
                eggIsHovered = true;
            } else {
                eggIsHovered = false;
            }
        }
    }

    void OnMouseEnter()
    {
        if(isWebGL == true)
        {
            eggIsHovered = true;
        }
    }

    void OnMouseExit() {
        if(isWebGL == true) 
        {
            eggIsHovered = false;
        }
    }
}
