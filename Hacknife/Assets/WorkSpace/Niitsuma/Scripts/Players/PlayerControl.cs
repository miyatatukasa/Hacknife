using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;

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
    }

    void MovePlayer(GameObject player)
    {
        /*�����ǉ�*/
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �L�����N�^�[�ړ�����
        velocity = new Vector3(h, 0, v);    // �㉺�̃L�[���͂���Z���̈ړ��ʂ��擾

        if (v > 0.1 || v < 0.1)
        {
            velocity *= MoveSpeed;       // �ړ����x���|����
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.eulerAngles += Vector3.up * 2f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.eulerAngles -= Vector3.up * 2f;
        }


        // ���f���̃��[�J����Ԃł̕����ɕϊ�
        velocity = player.transform.TransformDirection(velocity);

        // �L�[���͂ŃL�����N�^�[���ړ�������
        player.transform.localPosition += velocity;
    }
    void FixedUpdate()
    {
        MovePlayer(PlayerInfo.Instance.PlayerObj);
    }
}
