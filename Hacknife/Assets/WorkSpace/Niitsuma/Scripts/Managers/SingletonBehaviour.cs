using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance {
        get {
            if (instance == null) {
                Type t = typeof(T);
                instance = (T)FindObjectOfType(t);
            }

            return instance;
        }
    }

    private static T instance;

    virtual protected void Awake() {
        // 他のゲームオブジェクトにアタッチされているか調べる
        CheckInstance();
    }

    protected bool CheckInstance() {
        if (instance == null) {
            instance = this as T;
            return true;
        }
        else if (Instance == this) {
            return true;
        }
        Destroy(this);
        return false;
    }
}
