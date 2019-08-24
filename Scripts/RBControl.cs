using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBControl : MonoBehaviour {

    [SerializeField]
    Vector3 directionOfForce = Vector3.zero;
    bool go = false;
    Rigidbody rb;
    [SerializeField]
    float forceAmount = 50f;
    [SerializeField]
    float torqueAmount = 20f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (go)
        {
            ApplyForce();
            go = false;
        }
	}
    public void GO()
    {
        go = true;
    }
    void ApplyForce()
    {
        rb.AddForce(directionOfForce * forceAmount, ForceMode.Impulse);
        rb.AddTorque(directionOfForce * torqueAmount, ForceMode.Impulse);
    }
}
