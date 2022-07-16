using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    GameObject playerEgg;
    [SerializeField] List<Transform> waypoints;
    int followedWaypoint = 0;
    Rigidbody2D rb;
    [SerializeField] List<Sprite> enemySprites;

    EggStats eggStats;

    public float speed = 200f;
    public float wayPointProgressDist = 0.1f;
    public float targetPlayerChance = 20f;
    bool isPlayerTarget = false;
    Vector3 playerPrevPosition;
    bool isPlayerIdle = false;
    void Start()
    {
        playerEgg = GameObject.Find("Egg - Player");
        rb = GetComponent<Rigidbody2D>();
        eggStats = GetComponent<EggStats>();
        
        if (!GameObject.Find("GameModeManager").GetComponent<GameModeManager>().isStoryMode)
        {
            RandomizeSkin();
        }
        StartCoroutine(DetectPlayerIdle());
    }

    void FixedUpdate()
    {
        if (waypoints.Count > 0)
        {

            if (isPlayerTarget){
                Vector3 direction = playerEgg.transform.position - transform.position;
                rb.AddForce(direction.normalized * speed);
            } else {
                //push egg towards waypoint
                Vector3 direction = waypoints[followedWaypoint].position - transform.position;
                rb.AddForce(direction.normalized * speed);
                if (Vector3.Distance(transform.position, waypoints[followedWaypoint].position) < wayPointProgressDist)
                {
                    if(isPlayerIdle == false){
                        followedWaypoint++;
                        if (followedWaypoint >= waypoints.Count)
                        {
                            followedWaypoint = 0;
                        }
                        if(Random.Range(0,100) < targetPlayerChance)
                        {
                            isPlayerTarget = true;
                        }
                    }
                }
            }
        }
        else Debug.LogError("No waypoints setup for enemy");
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg")
        {
            isPlayerTarget = false;
            isPlayerIdle = false;
        }
    }

    void RandomizeSkin()
    {
        GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Count)];
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.7f, 1f), Random.Range(0.7f, 1f), Random.Range(0.7f, 1f));
        eggStats.tex = GetComponent<SpriteRenderer>().sprite.texture;

        GameObject.Find("EnemyEggStatus").GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("EnemyEggStatus").GetComponent<Image>().color = GetComponent<SpriteRenderer>().color;
    }

    IEnumerator DetectPlayerIdle(){
        Debug.Log(Vector3.Distance(playerEgg.transform.position, playerPrevPosition));
        if (Vector3.Distance(playerEgg.transform.position, playerPrevPosition) < .4f){
            isPlayerIdle = true;
        } else {
            isPlayerIdle = false;
        }
        playerPrevPosition = playerEgg.transform.position;
        yield return new WaitForSeconds(2);
        StartCoroutine(DetectPlayerIdle());
    }

}
