using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestory : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponentInChildren<ParticleSystem>().isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
