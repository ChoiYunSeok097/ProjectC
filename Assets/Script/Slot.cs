using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image Icon;
    public RectTransform rcTransform;
    Rect rc;
    // Start is called before the first frame update
    void Start()
    {
        rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
        rc.y = rcTransform.position.x + rcTransform.rect.height * 0.5f;
        rc.xMin = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;
        rc.width = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
