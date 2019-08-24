using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldOpacity : MonoBehaviour {

    [SerializeField]
    float maxOpacity = 70f;
    [SerializeField]
    float opacitySpeed = 5f;
    [SerializeField]
    float opacityAmount = 1f;
    Color ogColor;
    Material mat;
    [SerializeField]
    AudioSource _audio;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    bool audioIsPlaying = false;
    // Use this for initialization
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        ogColor = mat.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncreaseOpacity()
    {
        if (mat.color.a < maxOpacity)
        {
            if (!audioIsPlaying)
            {
                _audio.clip = clips[0];
                _audio.Play();
                audioIsPlaying = true;
            }
            
            Color rgb = new Color(0, 0, 0, opacityAmount);
            mat.color += rgb * Time.deltaTime * opacitySpeed;
        }
        else
        {
            if (_audio.isPlaying)
            {
                _audio.Stop();
                audioIsPlaying = false;
            }
        }
    }
    public void ResetOpacity()
    {
        if (audioIsPlaying)
        {
            _audio.Stop();
            audioIsPlaying = false;
        }
        if (!audioIsPlaying)
        {
            audioIsPlaying = true;
            _audio.clip = clips[1];
            _audio.Play();
            StartCoroutine(SoundTimer(_audio.clip.length));
        }

        mat.color = ogColor;
    }
    IEnumerator SoundTimer(float _length)
    {
        yield return new WaitForSeconds(_length);
        audioIsPlaying = false;
    }
}
