using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    Transform[] spawners;
    [SerializeField]
    float spawnInterval = 1f;
    int prevSpawner = 0;
    [SerializeField]
    GameObject astroidPrefab;
    Transform currentSpawner;
    [SerializeField]
    float startDelay = 1f;
    // Use this for initialization
    void Start()
    {
        currentSpawner = spawners[0];
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnAstroid()
    {
        if (!GameData.instance.endOfLevel)
        {
            GameObject astroid = Instantiate(astroidPrefab);
            astroid.transform.position = currentSpawner.transform.position;
            astroid.transform.rotation = currentSpawner.transform.rotation;
        }
        StartCoroutine(SpawnInterval());
    }
    void RandomSpawner()
    {
        int rand = Random.Range(0, spawners.Length - 1);
        if (rand != prevSpawner)
        {
            currentSpawner = spawners[rand];
            prevSpawner = rand;
            SpawnAstroid();
        }
        else
        {
            RandomSpawner();
        }
    }
    IEnumerator SpawnInterval()
    {
        yield return new WaitForSeconds(GameData.instance.spawnInterval);
        RandomSpawner();
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        SpawnAstroid();
    }
}
