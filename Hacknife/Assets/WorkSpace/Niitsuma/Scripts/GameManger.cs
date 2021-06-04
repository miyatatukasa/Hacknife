using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameManger Instance { get => _instance; }
    static GameManger _instance;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }
}
