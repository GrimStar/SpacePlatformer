using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] prefabs;
    int itemToSpawn = 0;
    [SerializeField]
    float spawnInterval = 10;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnInterval());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnItem()
    {
        GameObject _prefab = Instantiate(prefabs[itemToSpawn]);
        _prefab.transform.position = transform.position;
        _prefab.transform.rotation = transform.rotation;
        if(itemToSpawn < prefabs.Length - 1)
        {
            itemToSpawn++;
        }
        else
        {
            itemToSpawn = 0;
        }
        StartCoroutine(SpawnInterval());
    }
    IEnumerator SpawnInterval()
    {
        yield return new WaitForSeconds(spawnInterval);
        SpawnItem();
    }
}
