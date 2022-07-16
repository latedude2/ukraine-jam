using UnityEngine;

public class PositionWalls : MonoBehaviour
{
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject leftWall;
    public GameObject rightWall;

    // Start is called before the first frame update
    void Start()
    {
        //position top wall at the top of the screen
        Vector2 topPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height));
        topWall.transform.position = topPosition + new Vector2(0, topWall.GetComponent<Collider2D>().bounds.extents.y);
        
        //position bottom wall at the bottom of the screen
        Vector2 bottomPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height*0.2f));
        bottomWall.transform.position = bottomPosition + new Vector2(0, -topWall.GetComponent<Collider2D>().bounds.extents.y);

        //position left wall at the left of the screen
        Vector2 leftPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height/2));
        leftWall.transform.position = leftPosition + new Vector2(-leftWall.GetComponent<Collider2D>().bounds.extents.x, 0);

        //position right wall at the right of the screen
        Vector2 rightPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height/2));
        rightWall.transform.position = rightPosition + new Vector2(rightWall.GetComponent<Collider2D>().bounds.extents.x, 0);
        
    }
}
