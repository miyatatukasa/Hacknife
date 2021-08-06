using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour {
    private Text messageText;

    void Start() {
        messageText = GetComponent<Text>();
    }

    /// <summary>
    /// メッセージテキストをセット
    /// </summary>
    /// <param name="message"></param>
    public void SetMessage(string message) {
        messageText.text = message;
    }

    /// <summary>
    /// メッセージテキストをクリア
    /// </summary>
    public void ClearText() {
        messageText.text = "";
    }
}
