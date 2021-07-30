using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMode : MonoBehaviour
{
    [SerializeField] private GameObject debugUI;
    bool isDebug;
    void Start()
    {
        debugUI.SetActive(false);
    }

    public void OnLoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnLoadTitleScene()
    {
        SceneManager.LoadScene("TitleMenu");
    }

    public void SarchAreaView()
    {
        GameManager.Instance.SearchAreaView = true;
    }

    public void SarchAreaNotView()
    {
        GameManager.Instance.SearchAreaView = false;
    }

    public void OnHackReset()
    {
        PlayerInfo.Instance.CanHacking = false;
        PlayerInfo.Instance.Sortings.Clear();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isDebug = !isDebug;
            debugUI.SetActive(isDebug);
            GameManager.Instance.TimeStop = isDebug;
        }
    }
}
