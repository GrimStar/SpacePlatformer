using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipFX : MonoBehaviour {

    [SerializeField]
    GameObject camHolder;
    [SerializeField]
    float camSpeed = 1;
    Vector3 brakePos;
    Vector3 accelPos;
    [SerializeField]
    float brakeAmount = 2;
    [SerializeField]
    float accelAmount = 2;
    float camLerpRatio = 0.5f;
    float targetRatio = 0.5f;
    float ratioRef = 0;
	// Use this for initialization
	void Start () {
        Vector3 brakeOffset = new Vector3(0, 0, brakeAmount);
        Vector3 accelOffset = new Vector3(0, 0, accelAmount);
        brakePos = camHolder.transform.position + brakeOffset;
        accelPos = camHolder.transform.position - accelOffset;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameData.instance.zSpeed < 0)
        {
            targetRatio = 1f;
        }
        if(GameData.instance.zSpeed == 0)
        {
            targetRatio = 0.5f;
        }
        if(GameData.instance.zSpeed > 0)
        {
            targetRatio = 0f;
        }
        camLerpRatio = Mathf.SmoothDamp(camLerpRatio, targetRatio, ref ratioRef, camSpeed);
        MoveCamera();
	}
    void MoveCamera()
    {
        camHolder.transform.position = Vector3.Lerp(accelPos, brakePos, camLerpRatio);
    }
}
