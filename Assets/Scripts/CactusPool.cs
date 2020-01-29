using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusPool : MonoBehaviour
{
    //Global variables
    //선인장 갯수=poolSize
    public int poolSize = 1;

    //obstaclePrefab라는 프리팹형태 정보 저장
    public GameObject obstaclePrefab;

    //????
    public float spawnRate = 4.0f;

    //최소 위치
    public float cactusMin = 3.0f;

    //최대 위치
    public float cactusMax = 5.0f;

    //Local variables
    //Gameobject 배열, cactusObstacles라는 배열 선언
    private GameObject[] cactusObstacles;

    //선인장 시작점
    private Vector2 poolPosition = new Vector2(3.5f, 0.0f);

    //마지막에 나타난 선인장 시간
    private float timeSinceLastSpawned;

    private int currentCactus = 0;

    // Start is called before the first frame update
    private void Start()
    {
        cactusObstacles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            cactusObstacles[i] = (GameObject)Instantiate(obstaclePrefab, poolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnXposition = Random.Range(cactusMin, cactusMax);
            cactusObstacles[currentCactus].transform.position = new Vector2(spawnXposition, 0.0f);

            currentCactus++;
            if (currentCactus >= poolSize)
            {
                currentCactus = 0;
            }
        }
    }
}