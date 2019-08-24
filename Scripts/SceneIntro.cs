using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneIntro : MonoBehaviour {

    [SerializeField]
    float startFOV = 0;
    [SerializeField]
    float endFOV = 0;
    float curFOV = 0;
    float ratioFov = 0;
    [SerializeField]
    float speed = 10;
    bool go = false;
    [SerializeField]
    float startDelay = 5;
    [SerializeField]
    Camera cam;
    [SerializeField]
    Text _go;
    [SerializeField]
    Text getReady;
    [SerializeField]
    Text levelText;
    bool intro = false;
	// Use this for initialization
	void Start () {
        levelText.text = "Level " + Mathf.Round(GameData.instance.level).ToString();
        StartCoroutine(StartCountdown());
	}
	
	// Update is called once per frame
	void Update () {
        if (go)
        {
            LerpFOV();
        }
	}
    void LerpFOV()
    {
        if (ratioFov < 1)
        {
            ratioFov += speed * Time.deltaTime;
        }
        curFOV = Mathf.Lerp(startFOV, endFOV, ratioFov);
        if(cam != null)
        {
            cam.fieldOfView = curFOV;
        }
        if(ratioFov >= 1)
        {
            if (!intro)
            {
                intro = true;
                StartCoroutine(LevelOne());
            }
        }
    }
    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0);
        go = true;
    }
    IEnumerator LevelOne()
    {
        levelText.enabled = true;
        yield return new WaitForSeconds(2);
        levelText.enabled = false;
        StartCoroutine(GetReady());
    }
    IEnumerator GetReady ()
    {
        getReady.enabled = true;
        yield return new WaitForSeconds(2);
        getReady.enabled = false;
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        _go.enabled = true;
        yield return new WaitForSeconds(2);
        _go.enabled = false;
    }
}
