using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    GameObject continueButton;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Level"))
        {
            continueButton.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
