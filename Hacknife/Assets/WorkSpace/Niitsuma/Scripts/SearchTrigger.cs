using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTrigger : MonoBehaviour {
    public bool IsSearch { get; private set; }
    public GameObject GetSearchObj { get => targets; }
    private GameObject targets;

    //private void Start()
    //{
    //    var searching = GetComponentInChildren<SearchingBehavior>();
    //    searching.onFound += OnFound;
    //    searching.onLost += OnLost;
    //}
    private IEnumerator Start() {
        yield return PlayerInfo.Instance.PlayerObj != null;
        var searching = GetComponentInChildren<SearchingBehavior>();
        searching.onFound += OnFound;
        searching.onLost += OnLost;
    }

    public void SearchReset() {
        var searching = GetComponentInChildren<SearchingBehavior>();
        searching.ResetList();
    }
    private void OnFound(GameObject i_foundObject) {
        // サーチしているオブジェクトがプレイヤー以外の場合
        if (this.gameObject != PlayerInfo.Instance.PlayerObj) {
            if (i_foundObject == PlayerInfo.Instance.PlayerObj) {
                targets = i_foundObject;
                PlayerInfo.Instance.Sortings.Add(this.gameObject);
                IsSearch = true;
            }
        }
        else {
            var hit = i_foundObject.GetComponent<IHackable>();
            if (hit != null) {
                targets = i_foundObject;
                IsSearch = true;
            }
        }

    }

    private void OnLost(GameObject i_lostObject) {
        if (this.gameObject != PlayerInfo.Instance.PlayerObj) {
            targets = null;
            PlayerInfo.Instance.Sortings.Remove(this.gameObject);
            IsSearch = false;
        }
        else {
            targets = null;
            IsSearch = false;
        }
    }
}
