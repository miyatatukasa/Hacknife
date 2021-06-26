using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTrigger : MonoBehaviour
{
    public bool IsSearch { get; private set; }
    private List<GameObject> _targets = new List<GameObject>();

    private void Awake()
    {
        var searching = GetComponentInChildren<SearchingBehavior>();
        searching.onFound += OnFound;
        searching.onLost += OnLost;
    }

    private void OnFound(GameObject i_foundObject)
    {
        // サーチしているオブジェクトがプレイヤー以外の場合
        if(this.gameObject != PlayerInfo.Instance.PlayerObj)
        {
            if (i_foundObject == PlayerInfo.Instance.PlayerObj)
            {
                _targets.Add(i_foundObject);
                PlayerInfo.Instance.Sortings.Add(this.gameObject);
                IsSearch = true;
            }
        }
        else
        {
            var hit = i_foundObject.GetComponent<IHackable>();
            if(hit != null)
            {
                _targets.Add(i_foundObject);
                PlayerInfo.Instance.Hack = hit;
                IsSearch = true;
            }
        }
        
    }

    private void OnLost(GameObject i_lostObject)
    {
        if(this.gameObject != PlayerInfo.Instance.PlayerObj)
        {
            _targets.Remove(i_lostObject);
            PlayerInfo.Instance.Sortings.Remove(this.gameObject);
            IsSearch = false;
        }
        else
        {
            _targets.Remove(i_lostObject);
            PlayerInfo.Instance.Hack = null;
            IsSearch = false;
        }
    }
}
