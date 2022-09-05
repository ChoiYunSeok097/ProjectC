using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _test_A : _test_Character
{
    private void Awake() 
    {
        Debug.Log("사실 잘 모름");

    }

    private void Start() 
    {
        Debug.Log("A name : "+ CharName + 10 + Attack);
    }


}
