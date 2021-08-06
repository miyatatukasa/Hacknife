using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScenarioMessageView))]
public class ScenarioMessageControl : MonoBehaviour {

    [SerializeField] private float messageSpeed = 0.5f;
    public float MessageSpeed { set { messageSpeed = value; } }

    public bool IsCheck { get; set; } = false;
    public bool IsAllDisplay { get; set; } = false;

    private ScenarioMessageView _textView;

    private string originalMessage = "";
    private string dispMessage = "";
    private int messageCount = 0;
    private float timer = 0;
    private System.Action callback = null;

    public void SetName(string name) {
        _textView.SetMessage(name);
    }
    public void SetMessage(string message, System.Action callback = null) {
        this.callback = callback;
        originalMessage = message;
        dispMessage = "";
        messageCount = 0;
        timer = 0;
        StartCoroutine(MessageDisp());
    }

    private void Start() {
        _textView = GetComponent<ScenarioMessageView>();

    }

    IEnumerator MessageDisp() {
        GameManager.Instance.TimeStop = true;
        while (messageCount < originalMessage.Length) {
            timer += Time.deltaTime;
            if (timer >= messageSpeed && !IsAllDisplay) {
                timer = 0;
                messageCount++;
                // 元のメッセージから指定部分を引き出す(０～_messageCount)
                dispMessage = originalMessage.Substring(0, messageCount);
                _textView.SetMessage(dispMessage);
            }
            else if (IsAllDisplay) {
                timer = 0;
                dispMessage = originalMessage;
                messageCount = originalMessage.Length;
                _textView.SetMessage(dispMessage);
                IsCheck = false;
            }
            yield return null;
        }
        IsAllDisplay = false;
        IsCheck = false;
        // ループを抜けたらcallback
        if (callback != null) callback();
    }
}
