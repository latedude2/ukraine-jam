using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject playerEgg;
    [SerializeField] List<Transform> waypoints;
    int followedWaypoint = 0;
    Rigidbody2D rb;
    [SerializeField] List<Sprite> enemySprites;

    EggStats eggStats;

    public float speed = 200f;

    void Start()
    {
        playerEgg = GameObject.Find("Egg - Player");
        rb = GetComponent<Rigidbody2D>();
        eggStats = GetComponent<EggStats>();
        RandomizeSkin();
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

    void RandomizeSkin()
    {
        GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Count)];
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f));
        eggStats.tex = GetComponent<SpriteRenderer>().sprite.texture;
    }

}
