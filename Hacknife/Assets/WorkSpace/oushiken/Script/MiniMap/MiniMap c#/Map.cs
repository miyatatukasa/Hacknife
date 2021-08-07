using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    RectTransform ditu;
    bool mapFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        ditu = this.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector2 size = ditu.sizeDelta;
            if (mapFlag)
            {
                mapFlag = false;
                size *= 0;
            }
            else
            {
                mapFlag = true;
                size = new Vector2(250,200);
            }
            ditu.sizeDelta = size;
        }

    
        
    }
}
