using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // �ړ����x
    [SerializeField]
    float MoveSpeed;
//     // �J�v�Z���R���C�_�̎Q��
//     private CapsuleCollider col;
//     // ���W�b�h�{�f�B�̎Q��
//     private Rigidbody rb;
     // �J�v�Z���R���C�_�̈ړ���
    private Vector3 velocity;
    // �X�N���v�g�̎Q��
    [SerializeField]
    private PlayerManagement playerManagement;
    // ���ݑ��삵�Ă���L�����N�^�[
    private GameObject nowPlayCharacter;

    void Start()
    {
        playerManagement = GetComponent<PlayerManagement>();

        nowPlayCharacter = playerManagement.NOW_PLAYCHARACTER;
    }
    void FixedUpdate()
    {
        nowPlayCharacter = playerManagement.NOW_PLAYCHARACTER;

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
        nowPlayCharacter.transform.localPosition += velocity * Time.fixedDeltaTime; // ������nowPlayCharacter��null�ɂȂ� �L�����N�^�[���₵�Ď���
    }
}