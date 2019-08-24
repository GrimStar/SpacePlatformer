using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolishShip : MonoBehaviour {

    [SerializeField]
    GameObject mainBody;
    [SerializeField]
    GameObject[] parts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Demolish()
    {
        foreach(GameObject _part in parts)
        {
            _part.transform.parent = null;
            Rigidbody rb = _part.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            
            _part.GetComponent<RBControl>().GO();
        }
        Rigidbody _rb = mainBody.GetComponent<Rigidbody>();
        _rb.isKinematic = false;
       
        mainBody.GetComponent<RBControl>().GO();
    }
}
