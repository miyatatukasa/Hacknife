using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;
    SearchTrigger _search;
    IAttackable _attackable;

    /*�����ǉ�*/
    // �ړ����x
    [SerializeField]
    float MoveSpeed;
    private Vector3 velocity;

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
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.localPosition += Vector3.forward * (Time.deltaTime * 2);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.localPosition += Vector3.forward * ((Time.deltaTime * -1) * 2);
        }*/

        /*�����ǉ�*/
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �L�����N�^�[�ړ�����
        velocity = new Vector3(h, 0, v);    // �㉺�̃L�[���͂���Z���̈ړ��ʂ��擾

        if (v > 0.1 || v < 0.1)
        {
            velocity *= MoveSpeed;       // �ړ����x���|����
        }


        // ���f���̃��[�J����Ԃł̕����ɕϊ�
        velocity = transform.TransformDirection(velocity);

        // �L�[���͂ŃL�����N�^�[���ړ�������
        player.transform.localPosition += velocity;
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
