using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour, IHackable
{
    enum PatorolType
    { 
        NORMAL, //AHO
        SLIGHTLYCAUTION,
        CAUTION, // KEIKAI MAX 
    }

    public bool IsFound { get; private set; } // playerを見つけたら有効化

    public GameObject MyObj { get; private set; }

    [SerializeField] private GameObject _turningParent;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _stopTime = 2f;
    [SerializeField] private PatorolType _patorolType;
    [SerializeField] private float _rotateSpeed = 3f;

    SearchTrigger _searchTrigger;
    Transform[] _turningPos;
    Vector3 _startPos; // 初期位置
    int _goPos = 0;
    int _posLength = 0;
    float _nowTime = 0;
    bool _isStop = false;

    void Awake()
    {
        Init();
        MyObj = this.gameObject;
        _searchTrigger = GetComponent<SearchTrigger>();
    }

    void Init()
    {
        _turningPos = new Transform[_turningParent.transform.childCount]; // 子要素取得
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
        _goPos = 0;
    }

    Quaternion LookTarget(Vector3 tar)
    {
        Vector3 targetDir = new Vector3(tar.x, transform.position.y, tar.z) - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, _rotateSpeed * Time.deltaTime, 0f);
        return  Quaternion.LookRotation(newDir);
    }

    void Patrol(System.Action call = null)
    {
        if(transform.position != _turningPos[_goPos].position && !_isStop)
        {
            transform.rotation = LookTarget(_turningPos[_goPos].position);
            transform.position = Vector3.MoveTowards(transform.position, _turningPos[_goPos].position, Time.deltaTime * _speed);
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

    void PatrolMove(PatorolType pat)
    {
        switch (pat)
        {
            case PatorolType.NORMAL:            Patrol(); break;
            case PatorolType.SLIGHTLYCAUTION:   Patrol(); break;
            case PatorolType.CAUTION:           Patrol(); break;
        }
    }

    
    void Update()
    {
        if(PlayerInfo.Instance.PlayerObj != this.gameObject)
        {
            if (Input.GetKeyDown(KeyCode.A)) { Teleport(); }
            if(!_searchTrigger.IsSearch) PatrolMove(_patorolType);
            else PlayerLook();
        }
    }
}