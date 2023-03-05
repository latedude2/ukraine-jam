using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceEgg : MonoBehaviour
{
    [SerializeField] List<Sprite> possibleSprites;
    // Start is called before the first frame update
    void Start()
    {
        RandomizeSkin();
    }

    void RandomizeSkin()
    {
        GetComponent<SpriteRenderer>().sprite = possibleSprites[Random.Range(0, possibleSprites.Count)];
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.7f, 1f), Random.Range(0.7f, 1f), Random.Range(0.7f, 1f));
    }
}
