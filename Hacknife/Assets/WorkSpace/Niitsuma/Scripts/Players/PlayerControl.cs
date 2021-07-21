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
    private Vector3 playerPos;
    private Vector3 velocity;
    Rigidbody rigidbody;

    void Awake()
    {
        _info = PlayerInfo.Instance;
        // �ŏ��̃v���C���[
        _info.PlayerObj = _playObj;
        // �A�j���[�^�[�擾
        animator = _playObj.GetComponent<Animator>();
    }

    void MovePlayer(GameObject player)
    {
        /*�����ǉ�*/
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigidbody = player.GetComponent<Rigidbody>();

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * v + Camera.main.transform.right * h;
        rigidbody.velocity = moveForward * MoveSpeed + new Vector3(0, rigidbody.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
           player.transform.rotation = Quaternion.LookRotation(moveForward);
        }

        /* // �L�����N�^�[�ړ�����
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

         // �L�����N�^�[��]����
         Vector3 diff = player.transform.position - playerPos;
         if (diff.magnitude > 0.01f)
         {
             player.transform.rotation = Quaternion.LookRotation(diff);
         }*/
    }
    void FixedUpdate()
    {
        /*playerPos = _playObj.transform.position;
        Debug.Log(playerPos);*/
        MovePlayer(PlayerInfo.Instance.PlayerObj);
    }
}
