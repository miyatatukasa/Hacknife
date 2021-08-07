using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class HpHandle : MonoBehaviour
{
    public Image hpimage;
    public Image hpEffect;
    [SerializeField]private float hpSpeed;
    public void HpReduce(float hp, float maxHp){
        hpimage.fillAmount = hp / maxHp;

        if (hpEffect.fillAmount > hpimage.fillAmount){
            hpEffect.fillAmount -= hpSpeed;
        }
        else{
            hpEffect.fillAmount = hpimage.fillAmount;
        }
    }
}
