using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Character
{
    public string Name;
    public int Level;
    public int Exp;
    public bool weapon;
    public int job;

    public int star;
}


public class _Data_Character<T> : MonoBehaviour
{
    public T data;

}
