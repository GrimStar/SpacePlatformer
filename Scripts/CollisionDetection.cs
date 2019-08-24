using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    [SerializeField]
    AudioSource _audio;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    float damage = 100f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameData.instance.endOfLevel)
        {
            SelfDestruct();
        }
	}
    private void OnTriggerEnter(Collider collision)
    {
      
        if(collision.transform.tag == "Player")
        {
            if(GameData.instance.gameOver || GameData.instance.endOfLevel)
            {
                return;
            }
            _audio.clip = clips[0];
            _audio.Play();
            PlayerHealth health = collision.transform.GetComponent<PlayerHealth>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }
            else
            {
                health = collision.transform.root.transform.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
           
        }
        if(collision.transform.tag == "Destroy")
        {
            SelfDestruct();
        }
        
    }
    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
