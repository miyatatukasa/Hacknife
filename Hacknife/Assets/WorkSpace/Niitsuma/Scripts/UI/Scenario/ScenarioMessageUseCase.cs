using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxInput;

public class ScenarioMessageUseCase : MonoBehaviour
{
    [SerializeField] private List<ScenarioData> data;
    [SerializeField] private ShiyuuMessage shiyuu; // 試遊会用
    [SerializeField] private List<ScenarioMessageControl> _messageControls;
    [SerializeField] private GameObject textBoxUI;
    List<ScenarioDataParem> _message;

    int _count = 0;
    bool startMessage = false;

    IEnumerator Start()
    {
        _message = data[0].ScenarioList;
        yield return new WaitForSeconds(0.2f);
        MessageDisplay();
    }

    public void MessageSet(int id)
    {
        //_message = data[id].ScenarioList;
        _message = shiyuu.Shiyuu;
        _count = 0;
        textBoxUI.SetActive(true);
        _messageControls[(int)TextType.NameText].SetName(_message[_count].name);
        _messageControls[(int)TextType.MessageText].SetMessage(_message[_count].message,
                    () => _count = _count < _message.Count - 1 ? _count + 1 : _count = -1);
        //_messageControls[(int)TextType.NameText].SetName("");
        //_messageControls[(int)TextType.MessageText].SetName("");
        startMessage = true;
    }

    void MessageDisplay()
    {
        if (!_messageControls[(int)TextType.MessageText].IsCheck)
        {
            if(0 <= _count)
            {
                _messageControls[(int)TextType.NameText].SetName(_message[_count].name);
                _messageControls[(int)TextType.MessageText].SetMessage(_message[_count].message,
                    () => _count = _count < _message.Count - 1 ? _count + 1 : _count = -1);
            }
            else
            {
                textBoxUI.SetActive(false);    
                Debug.Log("終了");
                startMessage = false;
                if(_message == shiyuu.Shiyuu)
                {
                    GameManager.Instance.GameOver = true;
                }
                GameManager.Instance.TimeStop = false; // 一次的に
            }
            if (!_messageControls[(int)TextType.MessageText].IsCheck) { _messageControls[(int)TextType.MessageText].IsCheck = true; }
        }
        else
        {
            if (_messageControls[(int)TextType.MessageText].IsCheck) { _messageControls[(int)TextType.MessageText].IsAllDisplay = true; }
        }

    }
    void Update()
    {
        //if (startMessage)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space) || XBXInput.PushDown(XBXBtn.B))
        //    {
        //        MessageDisplay();
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space) || XBXInput.PushDown(XBXBtn.B))
        {
            MessageDisplay();
        }
    }
}
