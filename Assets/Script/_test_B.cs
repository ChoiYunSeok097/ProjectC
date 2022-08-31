using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _test_B : _test_Character
{
    
private void Awake() 
    {
        CharName = "B";
        MaxHelth = 20;

    }

    private void Start() 
    {
        Debug.Log("B name : "+ CharName + 20);
    }
    
}
