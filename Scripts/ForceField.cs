using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForceField : MonoBehaviour {
    [SerializeField]
    const float maxEnergy = 4;
    float energy = 4;
    public float bonusEnergy = 0;
    const float maxBonusEnergy = 3;
    [SerializeField]
    float energyConsumptionRate = 1f;
    [SerializeField]
    float energyRegenerationRate = 2f;
    bool isActive = false;
    ForceFieldOpacity _opacity;
    MeshRenderer _renderer;
    [SerializeField]
    GameObject[] energyBarIcons;
    [SerializeField]
    AudioSource _audio;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    bool audioIsPlaying = false;
    bool coolingDown = false;
    private void Start()
    {
        _opacity = GetComponent<ForceFieldOpacity>();
        energy = maxEnergy;
        _renderer = GetComponent<MeshRenderer>();
        _renderer.enabled = false;
    }

    private void Update()
    {
        if (GameData.instance.gameOver || GameData.instance.endOfLevel)
        {
            return;
        }
        CheckForInput();
        UpdateEnergyBar();
        if (!isActive)
        {
            RegenerateEnergy();
        }
    }
    void CheckForInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (energy > 0)
            {
                if (!coolingDown)
                {
                    ConsumeEnergy();
                    isActive = true;
                    _renderer.enabled = true;
                    _opacity.IncreaseOpacity();
                }
            }
            else
            {
                if (!coolingDown)
                {
                    StartCoroutine(CoolDown());
                    coolingDown = true;
                }
                if (isActive)
                {
                    _opacity.ResetOpacity();
                }
                isActive = false;
                _renderer.enabled = false;
                
            }
        }
        else
        {
            if (isActive)
            {
                isActive = false;
                _renderer.enabled = false;
                _opacity.ResetOpacity();
            }
            
            
        }
    }
    public void AddBonusEnergy(float _amount)
    {
        if(bonusEnergy + _amount <= maxBonusEnergy)
        {
            bonusEnergy += _amount;
        }
        else
        {
            bonusEnergy = maxBonusEnergy;
        }
    }
    void ConsumeEnergy()
    {
        if(energy > 0)
        {
            energy -= energyConsumptionRate * Time.deltaTime;
        }
    }
    void RegenerateEnergy()
    {
        if (energy < maxEnergy)
        {
            energy += energyRegenerationRate * Time.deltaTime;
        }
    }
    void UpdateEnergyBar()
    {
        if(energy > 3)
        {
            if (!energyBarIcons[3].GetComponent<Image>().IsActive())
            {
                energyBarIcons[3].GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            if (energyBarIcons[3].GetComponent<Image>().IsActive())
            {
                energyBarIcons[3].GetComponent<Image>().enabled = false;
            }
        }
        if (energy > 2)
        {
            if (!energyBarIcons[2].GetComponent<Image>().IsActive())
            {
                energyBarIcons[2].GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            if (energyBarIcons[2].GetComponent<Image>().IsActive())
            {
                energyBarIcons[2].GetComponent<Image>().enabled = false;
            }
        }
        if (energy > 1)
        {
            if (!energyBarIcons[1].GetComponent<Image>().IsActive())
            {
                energyBarIcons[1].GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            if (energyBarIcons[1].GetComponent<Image>().IsActive())
            {
                energyBarIcons[1].GetComponent<Image>().enabled = false;
            }
        }
        if (energy > 0)
        {
            if (!energyBarIcons[0].GetComponent<Image>().IsActive())
            {
                energyBarIcons[0].GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            if (energyBarIcons[0].GetComponent<Image>().IsActive())
            {
                energyBarIcons[0].GetComponent<Image>().enabled = false;
            }
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        coolingDown = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.tag == "Enemy")
            {
                _audio.clip = clips[0];
                _audio.Play();
                Destroy(other.gameObject);
            }
        }
    }
}
