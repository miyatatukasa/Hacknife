using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XboxInput;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private FadeControl fade;
    [SerializeField] private Image startUI;
    [SerializeField] private Image exitUI;

    private int select = 0;
    private bool isPush;

    public void PlayGame()
    {
        fade.Fade(false, () => SceneManager.LoadScene("MainScene"));
    }

    private void Update()
    {
        //float inp = Input.GetAxis("RX_Vertical");
        float inp = Input.GetAxis("Vertical");
        if(inp != 0)
        {
            if (inp < 0) { select += select == 1 ? 0 : 1; }
            else { select += select == 0 ? 0 : -1; }
        }
        
        if(select == 0)
        {
            startUI.rectTransform.localScale = new Vector3(1.3f, 1.3f, 0);
            exitUI.rectTransform.localScale = new Vector3(1f, 1f, 0); 
        }
        else
        {
            exitUI.rectTransform.localScale = new Vector3(1.3f, 1.3f, 0);
            startUI.rectTransform.localScale = new Vector3(1f, 1f, 0);
        }

        if (XBXInput.PushDown(XBXBtn.B) && !isPush)
        {
            if (select == 0) fade.Fade(false, () => SceneManager.LoadScene("MainScene"));
            else QuitGame();
            isPush = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isPush)
        {
            if (select == 0) fade.Fade(false, () => SceneManager.LoadScene("MainScene"));
            else QuitGame();
            isPush = true;
        }
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
