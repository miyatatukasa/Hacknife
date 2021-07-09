using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chara : MonoBehaviour
{
    RectTransform Cha;
    bool chaFlag = false;
    void Start()
    {
        Cha = this.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector2 size = Cha.sizeDelta;
            if (chaFlag)
            {
                chaFlag = false;
                size *= 0;
            }
            else
            {
                chaFlag = true;
                size = new Vector2(30, 30);
            }
            Cha.sizeDelta = size;
        }
    }
}
