using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessStarSheet : MonoBehaviour {


    [SerializeField]
    float zStartPos = 45f;
    [SerializeField]
    float zEndPos = -45f;
    [SerializeField]
    float speed = 1f;
   
    float zSpeed = 0;
    [SerializeField]
    float zVel = 1f;
    [SerializeField]
    float zAcceleration = 3f;
    [SerializeField]
    float zVelBrakeSpeed = 0.5f;
    float targetVelocity = 0f;
    float zVelRef = 0;
    float curVel = 0;
    [SerializeField]
    float smoothSpeed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        zSpeed = GameData.instance.zSpeed;
        Go();
        VelocityControl();
        CheckPosition();
        
    }
    void Go()
    {
        curVel = Mathf.SmoothDamp(curVel, targetVelocity, ref zVelRef, smoothSpeed * Time.deltaTime);
        Vector3 newPos = new Vector3(0, 0, -curVel);
        transform.position += newPos * Time.deltaTime;
    }
    void VelocityControl()
    {
        if (zSpeed == 0)
        {
            targetVelocity = zVel;

        }
        if (zSpeed > 0)
        {
            if (GameData.instance.boost)
            {
                targetVelocity = zVel * GameData.instance.boostMulti * zAcceleration;
            }
            else
            {
                targetVelocity = zVel * zAcceleration;
            }

        }
        if (zSpeed < 0)
        {
            if (GameData.instance.boost)
            {
                targetVelocity = zVelBrakeSpeed / GameData.instance.boostMulti;
            }
            else
            {
                targetVelocity = zVelBrakeSpeed;
            }

        }
    }
    void CheckPosition()
    {
        if(transform.position.z <= zEndPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zStartPos);
        }
    }
}
