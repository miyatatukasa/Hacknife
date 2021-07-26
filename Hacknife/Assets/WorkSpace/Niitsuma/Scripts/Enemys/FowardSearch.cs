using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FowardSearch : MonoBehaviour
{
    [SerializeField]
    private SphereCollider searchArea;
    [SerializeField]
    private float searchAngle = 130f;

    public bool IsSearch { get; private set; }
    public GameObject GetSearchObj { get => _targets; }
    private GameObject _targets;

    private void OnTriggerStay(Collider other)
    {
        if(this.gameObject != PlayerInfo.Instance.PlayerObj)
        {
            if (other.gameObject == PlayerInfo.Instance.PlayerObj)
            {
                //　プレイヤーの方向
                var playerDirection = other.transform.position - transform.position;
                //　敵の前方からの主人公の方向
                var angle = Vector3.Angle(transform.forward, playerDirection);
                //　サーチする角度内だったら発見
                if (angle <= searchAngle)
                {
                    //Debug.Log("発見");
                    IsSearch = true;
                    _targets = other.gameObject;
                    PlayerInfo.Instance.Sortings.Add(this.gameObject);
                }
            }
        }
        else
        {
            var hit = other.gameObject.GetComponent<IHackable>();
            if (hit != null)
            {
                _targets = other.gameObject;
                IsSearch = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject != PlayerInfo.Instance.PlayerObj)
        {
            if (other.gameObject == PlayerInfo.Instance.PlayerObj)
            {
                _targets = null;
                PlayerInfo.Instance.Sortings.Remove(this.gameObject);
                IsSearch = false;
            }
        }
        else
        {
            _targets = null;
            IsSearch = false;
        }
        
    }

    public void SearchActiveSet(bool t)
    {
        searchArea.enabled = t;
        PlayerInfo.Instance.Sortings.Remove(this.gameObject);
        IsSearch = false;
        _targets = null;
    }

#if UNITY_EDITOR
    //　サーチする角度表示
    private void OnDrawGizmos()
    {
        Handles.color = new Vector4(1, 0, 0, 0.5f);
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAngle, 0f) * transform.forward, searchAngle * 2f, searchArea.radius);
    }
#endif
}
