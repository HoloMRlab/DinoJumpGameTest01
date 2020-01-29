using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusRandom : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float minX = 0;
    public float maxX = 0;

    private float spawnRate;
    private GameObject cactusSpawn;
    private Vector2 startPosition = new Vector2(3.5f, 0.0f);
    private float timeLastSpawned;

    // Start is called before the first frame update
    private void Start()
    {
        cactusSpawn = (GameObject)Instantiate(cactusPrefab, startPosition, Quaternion.identity);
        spawnRate = 2.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        timeLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver == false && timeLastSpawned >= spawnRate)
        {
            timeLastSpawned = 0;
            float randomRange = Random.Range(startPosition.x + minX, startPosition.x + maxX);
            cactusSpawn.transform.position = new Vector2(randomRange, 0.0f);
        }
    }
}