using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    
    // �v���C���[�̕ύX�����̃e���v��

    void Start()
    {
        // �v���C���[�I�u�W�F�N�g�������ɐݒ�
        // �ŏ��̃v���C���[��Start�Ŏg��
        PlayerInfo.Instance.PlayerObj = this.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // �����菈���̃e���v��
            PlayerInfo.Instance.PlayerObj = collision.gameObject;
        }
    }
    
}
