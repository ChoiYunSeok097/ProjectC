using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestory : MonoBehaviour
{
    float time = 0;
    void Update()
    {
        time += Time.deltaTime;
        if (gameObject.GetComponentInChildren<ParticleSystem>().isPlaying == false)
        {
            Destroy(gameObject);
        }
        if (time > 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
