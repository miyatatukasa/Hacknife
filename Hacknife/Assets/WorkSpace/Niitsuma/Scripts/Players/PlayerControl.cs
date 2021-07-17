using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;

    /*�����ǉ�*/
    // �ړ����x
    [SerializeField]
    float MoveSpeed;
    // �A�j���[�^�[�̎Q��
    private Animator animator;
    // �v���C���[�̃|�W�V����
    //private Vector3 playerPos;
    private Vector3 velocity;

    void Awake()
    {
        _info = PlayerInfo.Instance;
        // �ŏ��̃v���C���[
        _info.PlayerObj = _playObj;
        // �v���C���[�̏������W�擾
        //playerPos = _playObj.transform.position;
        // �A�j���[�^�[�擾
        animator = _playObj.GetComponent<Animator>();
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
        if (velocity.magnitude > 0.1)
        {
            // �A�j���[�^�[�ɑ��x��n��
            animator.SetFloat("Speed", velocity.magnitude);
            // ���͂���������ɃL�����N�^�[���ړ�������
            player.transform.localPosition += velocity;
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        /*// �L�����N�^�[��]����
        Vector3 diff = player.transform.position - playerPos;
        Debug.Log(diff);
        if (diff.magnitude > 0.01f)
        {
            player.transform.rotation = Quaternion.LookRotation(diff);
        }*/
    }
    void FixedUpdate()
    {
        MovePlayer(PlayerInfo.Instance.PlayerObj);
    }
}
