using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_SingleTon<T> where T : class, new()
{
    static T inst;

    public static T instance
    {
        get
        {
            if(inst == null)
                inst = new T();
            return inst;
        }
    }


}
