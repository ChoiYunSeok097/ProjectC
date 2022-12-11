using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _UI_WeaponWindow : MonoBehaviour
{
    
    public void loadSlot()
    {
        //List<GameObject> child = new List<GameObject>();
            
        for(int i=0; i < gameObject.transform.childCount; i++)
        {
            //child.Add(gameObject.transform.GetChild(i).gameObject);
            gameObject.transform.GetChild(i).GetComponent<_UI_WeaponSlot>().LoadSlot();
        }         
    }
}
