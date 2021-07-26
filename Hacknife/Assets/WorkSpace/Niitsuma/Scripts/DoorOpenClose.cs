using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxInput;

/// <summary>
/// 簡易的なドアの開け閉め
/// </summary>
public class DoorOpenClose : MonoBehaviour
{
    [SerializeField] private CharactorType _keyType;
    [SerializeField] private bool _isOpenWithKey = false; // 開けるときに鍵が必要か
    [SerializeField] private bool _isAutoDoor = false; // 自動ドアか
    
    private Transform[] _doors = new Transform[2];
    private Collider coll;

    private Vector3[] _firstPos = new Vector3[2];
    private bool _isDoorOpen;
    private bool _isMove;

    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            _doors[i] = gameObject.transform.GetChild(i).transform;
        }
        _firstPos[0] = _doors[0].localPosition;
        _firstPos[1] = _doors[1].localPosition;
        coll = GetComponent<Collider>();
    }

    private void OpenClose(bool isOpen)
    {
        if (isOpen)
        {
            if (_doors[0].localPosition.x == _firstPos[0].x - 140f) { _isMove = false; coll.isTrigger = true; }
            _doors[0].localPosition = Vector3.MoveTowards(_doors[0].localPosition, new Vector3(_firstPos[0].x - 140f, _firstPos[0].y, _firstPos[0].z), 300 * Time.deltaTime);
            _doors[1].localPosition = Vector3.MoveTowards(_doors[1].localPosition, new Vector3(_firstPos[1].x + 140f, _firstPos[1].y, _firstPos[1].z), 300 * Time.deltaTime);
        }
        else
        {
            if (_doors[0].localPosition.x == _firstPos[0].x) { if (coll.isTrigger) { coll.isTrigger = false; } return; }
            _isMove = false;
            _doors[0].localPosition = Vector3.MoveTowards(_doors[0].localPosition, new Vector3(_firstPos[0].x, _firstPos[0].y, _firstPos[0].z), 300 * Time.deltaTime);
            _doors[1].localPosition = Vector3.MoveTowards(_doors[1].localPosition, new Vector3(_firstPos[1].x, _firstPos[1].y, _firstPos[1].z), 300 * Time.deltaTime);
        }
    }

    private void ButtonOpenDoor()
    {
        OpenClose(true);
    }

    private void AutoOpenDoor()
    {
        if (_doors[0].localPosition.x == _firstPos[0].x - 140f) { _isMove = false; coll.isTrigger = true; }
        _doors[0].localPosition = Vector3.MoveTowards(_doors[0].localPosition, new Vector3(_firstPos[0].x - 140f, _firstPos[0].y, _firstPos[0].z), 300 * Time.deltaTime);
        _doors[1].localPosition = Vector3.MoveTowards(_doors[1].localPosition, new Vector3(_firstPos[1].x + 140f, _firstPos[1].y, _firstPos[1].z), 300 * Time.deltaTime);
    }

    private void CloseDoor()
    {
        OpenClose(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // FIX: 鍵じゃないタイプで触れたらUIが表示しぱなし
        if(collision.gameObject == PlayerInfo.Instance.PlayerObj)
        {
            if (!_isAutoDoor) { PlayerInfo.Instance.ShouldShowBtnUI = true; }
            else { _isMove = true; }
            if (_isOpenWithKey && PlayerInfo.Instance.EnemyType == _keyType) { _isDoorOpen = true; }
            else if (!_isOpenWithKey) { _isDoorOpen = true; }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == PlayerInfo.Instance.PlayerObj)
        {
            _isDoorOpen = false;
            if (!_isAutoDoor) { PlayerInfo.Instance.ShouldShowBtnUI = false; }
        }
    }


    void Update()
    {
        if (_isDoorOpen && XBXInput.PushDown(XBXBtn.B))
        {
            _isMove = true;
        }
        else if (_isDoorOpen && Input.GetKeyDown(KeyCode.Space))
        {
            _isMove = true;
        }
        else if(!_isDoorOpen && _doors[0].position != _firstPos[0])
        {
            CloseDoor();
        }
        if (_isMove)
        {
            if (_isAutoDoor)
            {
                AutoOpenDoor();
            }
            else
            {
                ButtonOpenDoor();
            }
        }
    }
}
