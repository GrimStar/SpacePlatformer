using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {


    public static GameData instance;
    public float zSpeed = 0f;
    public float spawnInterval = 6;
    public bool endOfLevel = false;
    public bool gameOver = false;
    public bool boost = false;
    public float level = 0;
    public float boostMulti = 2f;
    public float boostTime = 3;
    public float levelSpawnDecrease = 0.5f;

    private void Awake()
    {

        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetFloat("Level");
            spawnInterval -= levelSpawnDecrease * level;
        }
        else
        {
            PlayerPrefs.SetFloat("Level", level);
        }

        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    
}
