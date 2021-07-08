using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour, IHackable
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

    bool _isRelease = true;

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

    void Teleport()
    {
        transform.position = _startPos;
        _isRelease = true;
    }

    Quaternion LookTarget(Vector3 tar)
    {
        Vector3 targetDir = new Vector3(tar.x, transform.position.y, tar.z) - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, _rotateSpeed * Time.deltaTime, 0f);
        return  Quaternion.LookRotation(newDir);
    }

    void Patrol(System.Action call = null)
    {
        var targetPos = new Vector3(_turningPos[_goPos].position.x, transform.position.y, _turningPos[_goPos].position.z);
        if (transform.position != targetPos && !_isStop)
        {
            transform.rotation = LookTarget(_turningPos[_goPos].position);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * _speed);
        }
        else
        {
            if (!_isStop) { _goPos = _goPos < _posLength - 1 ? _goPos += 1 : 0; _isStop = true; }

            if(null != call) { call(); }
            else
            {
                if (_nowTime < _stopTime && _isStop) { _nowTime += Time.deltaTime; }
                else { _isStop = false; _nowTime = 0; }
            }
        }
    }

    void PlayerLook()
    {
        transform.rotation = LookTarget(PlayerInfo.Instance.PlayerObj.transform.position);
        //transform.position = Vector3.MoveTowards(transform.position, PlayerInfo.Instance.PlayerObj.transform.position, Time.deltaTime * 3);
    }
    // �n�b�L���O����̉��
    void Hackingrelease()
    {

    }
    /// <summary>
    /// �n�b�L���O���ꂽ�ۂɏ���������
    /// </summary>
    void HackInit()
    {
        _goPos = 0;
        _nowTime = 0;
        _isStop = false;
        _searchTrigger.SearchReset();
    }
    void Update()
    {
        if(PlayerInfo.Instance.PlayerObj != this.gameObject)
        {
            if (!_isRelease)
            {
                Invoke("Teleport", 2f); // ���ԂȂ�����
            }
            else
            {
                if (!_searchTrigger.IsSearch) Patrol();
                else PlayerLook();
            }
        }
        else
        {
            if (_isRelease) { HackInit(); _isRelease = false; } // �n�b�L���O���
        }
    }
}