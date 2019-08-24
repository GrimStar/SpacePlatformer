using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour {

    [SerializeField]
    int id = 0;
 
    const float amount = 3;
    GameObject ship;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ship = other.transform.root.gameObject;
            AddItem(id);
            
        }
    }
    void AddItem(int _id)
    {
        if(_id == 0)
        {
            AddEnergyBonus();
        }
        if(_id == 1)
        {
            AddBoost();
        }
    }
    void AddEnergyBonus()
    {
        ForceField _forcefield = ship.transform.GetChild(0).GetComponent<ForceField>();
        _forcefield.AddBonusEnergy(amount);
    }
    void AddBoost()
    {
        
        ///
        ShipControl _shipControl = ship.GetComponent<ShipControl>();
        if(_shipControl != null)
        {
            _shipControl.AddBoost();
        }
    }
}
