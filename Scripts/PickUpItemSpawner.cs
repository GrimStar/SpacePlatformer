using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] prefabs;
    int itemToSpawn = 0;
    [SerializeField]
    float spawnInterval = 10;
    [SerializeField]
    Transform[] spawnLocations;
    int spawnLocation = 0;
    bool timesUp = false;
    float countdownMulti = 1;
    float zSpeed = 0;
    float curTime = 0;
	// Use this for initialization
	void Start () {
        curTime = spawnInterval;
        //StartCoroutine(SpawnInterval());

	}
	
	// Update is called once per frame
	void Update () {
        SpeedControl();
        Countdown();
	}
    void Countdown()
    {
        if (curTime > 0)
        { 

            timesUp = false;
            curTime -= Time.deltaTime * countdownMulti;
        }
        else
        {
            if (!timesUp)
            {
                timesUp = true;
                SpawnItem();
                curTime = spawnInterval;
            }
        }
    }
    void SpeedControl()
    {
        zSpeed = GameData.instance.zSpeed;
        //Vector3 zVelocity = new Vector3(0, 0, -zSpeed);

        if (zSpeed == 0)
        {
            countdownMulti = 1;

        }
        if (zSpeed > 0)
        {
            countdownMulti = 2;

        }
        if (zSpeed < 0)
        {
            countdownMulti = 0.5f;

        }
    }
    void SpawnItem()
    {
        GameObject _prefab = Instantiate(prefabs[itemToSpawn]);
        _prefab.transform.position = spawnLocations[spawnLocation].position;
        _prefab.transform.rotation = transform.rotation;
        CycleItem();
        CycleSpawnLocation();
        //StartCoroutine(SpawnInterval());
    }
    void CycleSpawnLocation()
    {
        if(spawnLocation < spawnLocations.Length - 1)
        {
            spawnLocation++;
        }
        else
        {
            spawnLocation = 0;
        }
    }
    void CycleItem()
    {
        if (itemToSpawn < prefabs.Length - 1)
        {
            itemToSpawn++;
        }
        else
        {
            itemToSpawn = 0;
        }
    }
    IEnumerator SpawnInterval()
    {
        yield return new WaitForSeconds(spawnInterval);
        SpawnItem();
    }
}
