using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject playerEgg;
    [SerializeField] List<Transform> waypoints;
    int followedWaypoint = 0;
    Rigidbody2D rb;

    public float speed = 200f;

    void Start()
    {
        playerEgg = GameObject.Find("Egg - Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (waypoints.Count > 0)
        {
            //push egg towards waypoint
            Vector3 direction = waypoints[followedWaypoint].position - transform.position;
            rb.AddForce(direction.normalized * speed);
            if (Vector3.Distance(transform.position, waypoints[followedWaypoint].position) < 0.1f)
            {
                followedWaypoint++;
                if (followedWaypoint >= waypoints.Count)
                {
                    followedWaypoint = 0;
                }
            }
        }
        else Debug.LogError("No waypoints setup for enemy");
        
    }

}
