using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _test_A : _test_Character
{
    private void Awake() 
    {
        CharName = "A";
        MaxHelth = 10;
        Attack = 5;

    }

    private void Start() 
    {
        Debug.Log("A name : "+ CharName + 10 + Attack);
    }


}
