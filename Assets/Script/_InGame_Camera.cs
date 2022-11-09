using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _InGame_Camera : MonoBehaviour
{
    public void cameraPosition(List<GameObject> charList)
    {
        if(charList.Count >0)
        {
            Vector3 position = transform.position;
            position.z = 0;
            byte count = 0;
            foreach(GameObject one in charList)
            {
                if(one.activeSelf != false)
                {
                    position.z += one.transform.position.z;
                    count++;
                }
            }
            if(count>0)
            {
                position.z = position.z/count;
                transform.position = position;
            }
            
        }
    }
}
