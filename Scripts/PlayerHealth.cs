using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    const float maxHealth = 100f;
    float currentHealth = 0f;
    [SerializeField]
    float menuDelay = 3f;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(float _amount)
    {
        currentHealth -= _amount;
        if(currentHealth <= 0)
        {
            GetComponent<DemolishShip>().Demolish();
            StartCoroutine(MenuDelay());

        }
    }
    IEnumerator MenuDelay()
    {
        yield return new WaitForSeconds(menuDelay);
        LevelControl.instance.GameOver();
    }
}
