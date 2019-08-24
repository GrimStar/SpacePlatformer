using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelControl : MonoBehaviour {

    public static LevelControl instance;
    public bool gameOver = false;
    public bool endOfLevel = false;
    [SerializeField]
    GameObject gameOverMenu;
    [SerializeField]
    float levelInterval = 10f;
    [SerializeField]
    float curLevelTime = 30f;
    [SerializeField]
    float levelTimeIncrease = 10f;
    
    
    [SerializeField]
    float levelCountdown = 5f;
    float speed = 0;
    [SerializeField]
    float baseLevelTime = 20f;
    float level = 1;
    [SerializeField]
    Text levelTimeText;
    [SerializeField]
    Text go;
    [SerializeField]
    Text getReady;
    [SerializeField]
    Text levelComplete;
    [SerializeField]
    Text nextLevel;
    // Use this for initialization
    void Start () {
		
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        level = GameData.instance.level;

        if (level > 1)
        {
            curLevelTime = baseLevelTime + (levelTimeIncrease * level);
        }
        else
        {
            curLevelTime = baseLevelTime;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            return;
        }
        SpeedControl();
        TravelDistance();
	}
    void TravelDistance()
    {
        if (curLevelTime > 0)
        {
            if (!endOfLevel)
            {
                curLevelTime -= speed * Time.deltaTime;
                levelTimeText.text = "Remaining Distance: " + Mathf.Round(curLevelTime).ToString();
            }
        }
        else
        {
            if (!endOfLevel)
            {
                EndOfLevel();
                GameData.instance.endOfLevel = true;
                endOfLevel = true;
                
            }
        }
    }
    public void GameOver()
    {
        Debug.Log("GAMEOVER");
        PlayerPrefs.SetFloat("Level", level);
          
        gameOver = true;
        GameData.instance.gameOver = true;
        if (!gameOverMenu.activeSelf)
        {
            gameOverMenu.SetActive(true);
        }
    }
    void EndOfLevel()
    {
        Debug.Log("EndOfLevel");
        if(GameData.instance.spawnInterval - GameData.instance.levelSpawnDecrease >= 1)
        {
            GameData.instance.spawnInterval -= GameData.instance.levelSpawnDecrease;
        }
        level++;
        GameData.instance.level = level;
        curLevelTime = baseLevelTime + (levelTimeIncrease * level);
        levelTimeText.text = "Remaining Distance: " + Mathf.Round(curLevelTime).ToString();
        StartCoroutine(LevelComplete());
    }
    void SpeedControl()
    {
        if(GameData.instance.zSpeed > 0)
        {
            speed = 2f;
        }
        if(GameData.instance.zSpeed == 0)
        {
            speed = 1f;
        }
        if(GameData.instance.zSpeed < 0)
        {
            speed = 0.5f;
        }
    }
    IEnumerator LevelComplete()
    {
        levelComplete.enabled = true;
        yield return new WaitForSeconds(1.5f);
        levelComplete.enabled = false;
        StartCoroutine(ShortWait());

    }
    IEnumerator ShortWait()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(LevelIntervalTimer());
    }
    IEnumerator LevelIntervalTimer()
    {
        nextLevel.text = "Level " + Mathf.Round(level).ToString();
        nextLevel.enabled = true;
        yield return new WaitForSeconds(levelInterval);
        nextLevel.enabled = false;
        GameData.instance.endOfLevel = false;
        StartCoroutine(LevelCountdown());
    }
    IEnumerator LevelCountdown()
    {
        getReady.enabled = true;
        yield return new WaitForSeconds(levelCountdown);
        getReady.enabled = false;
        StartCoroutine(GoTime());
        endOfLevel = false;
    }
    IEnumerator GoTime()
    {
        go.enabled = true;
        yield return new WaitForSeconds(1f);
        go.enabled = false;
    }
    
}
