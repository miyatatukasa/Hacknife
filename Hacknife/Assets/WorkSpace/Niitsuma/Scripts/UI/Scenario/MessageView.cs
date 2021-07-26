﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{
    private Text _messageText;
    
    void Start()
    {
        _messageText = GetComponent<Text>();
    }

    /// <summary>
    /// メッセージテキストをセット
    /// </summary>
    /// <param name="message"></param>
    public void SetMessage(string message)
    {
        _messageText.text = message;
    }

    /// <summary>
    /// メッセージテキストをクリア
    /// </summary>
    public void ClearText()
    {
        _messageText.text = "";
    }
}