using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CharactorType
{
    StartPlayer,        // �ŏ��̃v���C���[
    Normal,             // AHO
    SlightlyCaution,    // ����Ȃ�Ɍx�����Ă���
    Caution,            // KEIKAI MAX 
    KeyMan,             // ���̖��������G�l�~�[
}

public abstract class BasePatrol : MonoBehaviour, IHackable
{

    public bool IsFound { get; private set; } // player����������L����

    public CharactorType GetEnemyType { get => _enemyType; }

    [SerializeField] private GameObject _turningParent;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _stopTime = 2f;
    [SerializeField] private CharactorType _enemyType;
    [SerializeField] private float _rotateSpeed = 3f;

    SearchTrigger _searchTrigger;
    Transform[] _turningPos;
    Vector3 _startPos; // �����ʒu
    int _goPos = 0;
    int _posLength = 0;
    float _nowTime = 0;
    bool _isStop = false;

    bool isRelease = true; // �n�b�L���O�������

    void Awake()
    {
        if (this.gameObject != PlayerInfo.Instance.PlayerObj) { Init(); }
        _searchTrigger = GetComponent<SearchTrigger>();
    }

    void Init()
    {
        _turningPos = new Transform[_turningParent.transform.childCount]; // �q�v�f�擾
        for (int i = 0; i < _turningParent.transform.childCount; i++)
        {
            _turningPos[i] = _turningParent.transform.GetChild(i).gameObject.transform;
        }
        _startPos = transform.position;
        _goPos = 0;
        _posLength = _turningPos.Length;
    }
    /// <summary>
    /// �����ʒu�ɖ߂�
    /// </summary>
    protected void Teleport()
    {
        transform.position = _startPos;
        _goPos = 0;
    }

    protected Quaternion LookTarget(Vector3 tar)
    {
        Vector3 targetDir = new Vector3(tar.x, transform.position.y, tar.z) - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, _rotateSpeed * Time.deltaTime, 0f);
        return Quaternion.LookRotation(newDir);
    }
    /// <summary>
    /// ���񏈗�
    /// </summary>
    protected virtual void Patrol()
    {
        var targetPos = new Vector3(_turningPos[_goPos].position.x, transform.position.y, _turningPos[_goPos].position.z);
        // �f�t�H���g�ł͏��񂷂邾��
        if (transform.position != targetPos && !_isStop)
        {
            transform.rotation = LookTarget(_turningPos[_goPos].position);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * _speed);
        }
        else
        {
            StopFunc();
        }
    }
    /// <summary>
    /// ����ʒu�ɒ������ۂ̏���
    /// </summary>
    protected virtual void StopFunc()
    {
        // �f�t�H���g�ł͈�莞�Ԏ~�܂邾��
        if (!_isStop) { _goPos = _goPos < _posLength - 1 ? _goPos += 1 : 0; _isStop = true; }
        if (_nowTime < _stopTime && _isStop) { _nowTime += Time.deltaTime; }
        else { _isStop = false; _nowTime = 0; }
    }

    void PlayerLook()
    {
        transform.rotation = LookTarget(PlayerInfo.Instance.PlayerObj.transform.position);
        //transform.position = Vector3.MoveTowards(transform.position, PlayerInfo.Instance.PlayerObj.transform.position, Time.deltaTime * 3);
    }



    protected virtual void Update()
    {
        if (PlayerInfo.Instance.PlayerObj != this.gameObject)
        {
            if (Input.GetKeyDown(KeyCode.A) && !IsFound) { Teleport(); }
            if (!_searchTrigger.IsSearch) { Patrol(); }
            else { PlayerLook(); }
        }
    }
}
