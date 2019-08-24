using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {

    float currentZSpeed = 1f;
    [SerializeField]
    float zSpeed = 1f;
    Vector3 rightPosition = new Vector3(20, 0, 0);
    Vector3 leftPosition = new Vector3(-20, 0, 0);
    float currentTarget;
    float targetref;
    [SerializeField]
    float xSpeed = 1f;
    [SerializeField]
    float xSmoothSpeed = 2;
    float ratio = 0.5f;
    float curRatio = 0.5f;
    
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.instance.gameOver || GameData.instance.endOfLevel)
        {
            return;
        }
        float zAxis = Input.GetAxis("Vertical");
        if (!GameData.instance.boost)
        {
            currentZSpeed = zSpeed * zAxis;
        }
        if (GameData.instance.boost)
        {
            currentZSpeed = 1;
        }
        //Mathf.Clamp(currentZSpeed, 0, 1);
        GameData.instance.zSpeed = currentZSpeed;
        XMovement();
    }
    public void AddBoost()
    {
        if (!GameData.instance.boost)
        {
            Debug.Log("Boost");
            GameData.instance.boost = true;
            StartCoroutine(BoostTimer());
        }
    }
    IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(GameData.instance.boostTime);
        GameData.instance.boost = false;
    }
    void XMovement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        ratio += Time.deltaTime * xSpeed * xAxis;
        ratio = Mathf.Clamp(ratio, 0, 1);
        
        currentTarget = Mathf.SmoothDamp(currentTarget, ratio, ref targetref, xSmoothSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(leftPosition, rightPosition, currentTarget);
    }
}
