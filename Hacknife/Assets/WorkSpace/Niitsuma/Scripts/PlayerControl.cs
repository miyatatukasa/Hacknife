using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;
    SearchTrigger _search;
    IAttackable _attackable;

    void Awake()
    {
        _info = PlayerInfo.Instance;
        // �ŏ��̃v���C���[
        _info.PlayerObj = _playObj;
        // �ŏ��Ƀv���C���[�ƂȂ�I�u�W�F�N�g�̍U���������Ă�
        _attackable = _info.Attack = _playObj.GetComponent<IAttackable>();
        _search = _info.PlayerObj.GetComponent<SearchTrigger>();
    }


    void Hacking(GameObject hitObj)
    {
        _info.PlayerObj = hitObj;
        _playObj = _info.PlayerObj;
        _attackable = _playObj.GetComponent<IAttackable>();
    }


    void MovePlayer(GameObject player)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.localPosition += Vector3.forward * (Time.deltaTime * 2);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.localPosition += Vector3.forward * ((Time.deltaTime * -1) * 2);
        }
    }
    void FixedUpdate()
    {
        MovePlayer(_playObj);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_info.Sortings.Count == 0)
            {
                if (_search.IsSearch)
                {
                    Debug.Log("hack");
                    Hacking(PlayerInfo.Instance.Hack.MyObj);
                }
            }
        }
    }
}
