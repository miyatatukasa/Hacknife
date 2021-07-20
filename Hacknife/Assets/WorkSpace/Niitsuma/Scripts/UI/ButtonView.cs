using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Image btnUi;

    void Start()
    {
        btnUi.gameObject.SetActive(false);
    }

    void Update()
    {
        if (PlayerInfo.Instance.CanHacking || PlayerInfo.Instance.ShouldShowBtnUI)
        {
            btnUi.gameObject.SetActive(true);
        }
        else if(!PlayerInfo.Instance.CanHacking && !PlayerInfo.Instance.ShouldShowBtnUI) 
        {
            btnUi.gameObject.SetActive(false);
        }
    }
}
