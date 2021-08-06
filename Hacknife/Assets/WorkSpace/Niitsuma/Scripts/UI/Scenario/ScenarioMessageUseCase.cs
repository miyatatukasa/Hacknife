using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxInput;

public class ScenarioMessageUseCase : MonoBehaviour {
    [SerializeField] private List<ScenarioData> data;
    [SerializeField] private ShiyuuMessage shiyuu; // 試遊会用
    [SerializeField] private List<ScenarioMessageControl> messageControls;
    [SerializeField] private GameObject textBoxUI;
    List<ScenarioDataParem> message;

    int _count = 0;
    bool startMessage = false;

    IEnumerator Start() {
        message = data[0].ScenarioList;
        yield return new WaitForSeconds(0.2f);
        MessageDisplay();
    }

    public void MessageSet(int id) {
        //_message = data[id].ScenarioList;
        message = shiyuu.Shiyuu;
        _count = 0;
        textBoxUI.SetActive(true);
        messageControls[(int)TextType.NameText].SetName(message[_count].name);
        messageControls[(int)TextType.MessageText].SetMessage(message[_count].message,
                    () => _count = _count < message.Count - 1 ? _count + 1 : _count = -1);
        //_messageControls[(int)TextType.NameText].SetName("");
        //_messageControls[(int)TextType.MessageText].SetName("");
        startMessage = true;
    }

    void MessageDisplay() {
        if (!messageControls[(int)TextType.MessageText].IsCheck) {
            if (0 <= _count) {
                messageControls[(int)TextType.NameText].SetName(message[_count].name);
                messageControls[(int)TextType.MessageText].SetMessage(message[_count].message,
                    () => _count = _count < message.Count - 1 ? _count + 1 : _count = -1);
            }
            else {
                textBoxUI.SetActive(false);
                Debug.Log("終了");
                startMessage = false;
                if (message == shiyuu.Shiyuu) {
                    GameManager.Instance.GameOver = true;
                }
                GameManager.Instance.TimeStop = false; // 一次的に
            }
            if (!messageControls[(int)TextType.MessageText].IsCheck) { messageControls[(int)TextType.MessageText].IsCheck = true; }
        }
        else {
            if (messageControls[(int)TextType.MessageText].IsCheck) { messageControls[(int)TextType.MessageText].IsAllDisplay = true; }
        }

    }
    void Update() {
        //if (startMessage)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space) || XBXInput.PushDown(XBXBtn.B))
        //    {
        //        MessageDisplay();
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space) || XBXInput.PushDown(XBXBtn.B)) {
            MessageDisplay();
        }
    }
}
