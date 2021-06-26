using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(30, 40, 100, 20), "êÿÇËë÷Ç¶"))
        {
            StartCoroutine(FadeScene());
        }
    }

    IEnumerator FadeScene()
    {
        float time = GameObject.Find("Fade").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(time);

        Application.LoadLevel("Game");
    }

}
