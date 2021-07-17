using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleXB : MonoBehaviour
{
    public void Update()
    {
        //XBox��B�������ꂽ��
        if(XboxInput.XBXInput.Push(XboxInput.XBXBtn.B))
        {
            StartCoroutine(FadeScene());
        }
    }

    IEnumerator FadeScene()
    {
        float time = GameObject.Find("Fade").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("MainScene");
    }
}
