using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject[] wallReference;

    private int randomIndex;

    private GameObject spawnedwallUp;
    private GameObject spawnedwallDown;

    private float offset;

    private float gap;

    private float speed = 4;

    //testej
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWall());
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator SpawnWall()
    {
        while (true)
        {
        yield return new WaitForSeconds(2.5f);

        randomIndex = Random.Range(0, wallReference.Length);

        spawnedwallUp = Instantiate(wallReference[randomIndex]);

        spawnedwallDown = Instantiate(wallReference[randomIndex]);
        
        //gap = Random.Range(10,12);
        offset = Random.Range(-9f,-4f);
        //Debug.Log(offset);

        Vector3 spawnUp = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
        Vector3 spawnDown = new Vector3(transform.position.x, transform.position.y - offset - 10f , transform.position.z);

        spawnedwallUp.GetComponent<Wall>().speed = speed;
        spawnedwallUp.transform.position = spawnUp;
        spawnedwallUp.GetComponent<SpriteRenderer>().flipY = true;        
        
        spawnedwallDown.GetComponent<Wall>().speed = speed;
        spawnedwallDown.transform.position = spawnDown;
        }
    }

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);

            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        

            foreach (GameObject wall in walls)
            {
                Wall wallScript = wall.GetComponent<Wall>();

                    if (wallScript != null)
                    {
                        wallScript.speed += 0.1f;                    
                    }
        }

        speed += 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
