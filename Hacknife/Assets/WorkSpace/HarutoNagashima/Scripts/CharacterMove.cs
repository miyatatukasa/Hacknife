using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMove : MonoBehaviour
{
    // �ړ����x
    [SerializeField]
    float MoveSpeed;
    // ���񑬓x
    [SerializeField]
    float rotateSpeed;
    // �J�v�Z���R���C�_�̎Q��
    private CapsuleCollider col;
    // ���W�b�h�{�f�B�̎Q��
    private Rigidbody rb;
    // �J�v�Z���R���C�_�̈ړ���
    private Vector3 velocity;

    void Start()
    {
        // �J�v�Z���R���C�_�\�R���|�[�l���g���擾����
        col = GetComponent<CapsuleCollider>();
        // ���W�b�h�{�f�B�R���|�[�l���g���擾����
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log(MoveSpeed);

        // �L�����N�^�[�ړ�����
        velocity = new Vector3(0, 0, v);    // �㉺�̃L�[���͂���Z���̈ړ��ʂ��擾

        if (v > 0.1 || v < 0.1)
        {
            velocity *= MoveSpeed;       // �ړ����x���|����
        }


        // ���f���̃��[�J����Ԃł̕����ɕϊ�
        velocity = transform.TransformDirection(velocity);

        //�㉺�̃L�[���͂ŃL�����N�^�[���ړ�������
        transform.localPosition += velocity * Time.fixedDeltaTime;
        // ���E�̃L�[���͂ŃL�����N�^��Y���Ő��񂳂���
        transform.Rotate(0, h * rotateSpeed, 0);
    }
}
