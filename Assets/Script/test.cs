using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class test : MonoBehaviour
{
    AudioSource source;
    public AudioClip a, b;
    float times = 0f;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = a;
        source.Play();
    }

    private void Update()
    {
        times += Time.deltaTime;
        if(times>= 2.0f)
            source.clip = b;
    }
}
