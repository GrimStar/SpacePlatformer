using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    [SerializeField]
    GameObject mainMenu;
    string MainMenuScene = "MainMenu";
    [SerializeField]
    GameObject pauseMenu;
    string PauseMenuScene = "SampleScene";
    [SerializeField]
    GameObject instructionsMenu;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();                       
        }
	}
    public void OpenPauseMenu()
    {
               
        if (SceneManager.GetActiveScene().name == PauseMenuScene)
        {
            
            if (pauseMenu.activeSelf)
            {
                if (!LevelControl.instance.gameOver && !LevelControl.instance.endOfLevel)
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
                
            }
            else
            { 
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
               
            }
        }
        

    }
    public void ContinueGame()
    {
        if (SceneManager.GetActiveScene().name == MainMenuScene)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void ClickPlay()
    {
        if(SceneManager.GetActiveScene().name == MainMenuScene)
        {
            Time.timeScale = 1f;
            if (PlayerPrefs.HasKey("Level"))
            {
                PlayerPrefs.SetFloat("Level", 1);
            }
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void ClickInstructions()
    {
        
        if (SceneManager.GetActiveScene().name == MainMenuScene)
        {
            mainMenu.SetActive(false);
            instructionsMenu.SetActive(true);
            
        }
        if (SceneManager.GetActiveScene().name == PauseMenuScene)
        {

            pauseMenu.SetActive(false);
            instructionsMenu.SetActive(true);
            
        }
    }
    public void ClickExit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void ClickMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ClickRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
