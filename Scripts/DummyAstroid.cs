using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAstroid : MonoBehaviour {

    [SerializeField]
    float minSpeed = 1f;
    [SerializeField]
    float maxSpeed = 3f;
    float zSpeed = 1f;
    [SerializeField]
    float zVel = 1f;
    [SerializeField]
    float zAcceleration = 2f;
    [SerializeField]
    float zVelBrakeSpeed = 0.5f;
    float speed = 0f;
    Vector3 newPosition = Vector3.zero;
    float curVelocity = 0f;
    float targetVelocity = 0;
    float velRef = 0;
    [SerializeField]
    float smoothSpeed = 0.5f;
    // Use this for initialization
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Setup()
    {

        speed = 2;
    }
    void Move()
    {
        
        //Vector3 zVelocity = new Vector3(0, 0, -zSpeed);

        if (zSpeed == 0)
        {
            targetVelocity = zVel;

        }
        if (zSpeed > 0)
        {
            targetVelocity = zVel * zAcceleration;

        }
        if (zSpeed < 0)
        {
            targetVelocity = zVelBrakeSpeed;

        }
        curVelocity = Mathf.SmoothDamp(curVelocity, targetVelocity, ref velRef, smoothSpeed * Time.deltaTime);
        //Vector3 newPosition = zVelocity + (transform.forward * speed);
        newPosition = new Vector3(transform.forward.x * speed, transform.forward.y * speed, curVelocity);
        transform.position += newPosition * Time.deltaTime;
    }
}
