using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // �ړ����x
    [SerializeField]
    float MoveSpeed;
    // �X�N���v�g�̎Q��
    PlayerInfo playerInfo;
    // ���쒆�̃L�����N�^�[
    GameObject Player;
    private Vector3 velocity;
    

    void FixedUpdate()
    {

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
    }
}