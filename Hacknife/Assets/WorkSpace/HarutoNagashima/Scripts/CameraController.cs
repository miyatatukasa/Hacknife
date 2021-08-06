using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �J�����̕ϐ�
    [SerializeField]
    GameObject mainCamera;
    // �X�N���v�g�̎Q��
    [SerializeField]
    PlayerInfo playerInfo;
    // �\�����̃��e�B�N��
    [SerializeField]
    GameObject reticle;
    // �Ǐ]�Ώۂ̃I�u�W�F�N�g
    GameObject targetObj;
    // �\�����̃J�����ʒu
    GameObject ADSPos;

    /// <summary>
    /// �J�����̈ʒu�ƒǏ]�Ώۂ̏�����
    /// </summary>
    public void InitCameraPos()
    {
        // �ʏ�ʒu�I�u�W�F�N�g�Q��
        targetObj = playerInfo.PlayerObj.transform.Find("CamPos").gameObject;
        // ���b�q�I�u�W�F�N�g�Q��
        ADSPos = playerInfo.PlayerObj.transform.Find("ADSPos").gameObject;
        // �J�����ʒu��cameraPos�ɂ���
        mainCamera.transform.position = targetObj.transform.position;
    }

    private void ADSControl()
    {
        mainCamera.transform.position = ADSPos.transform.position;
        reticle.SetActive(true);
    }

    void Start()
    {
        InitCameraPos();
    }


    void FixedUpdate()
    {
        mainCamera.transform.position += targetObj.transform.position - mainCamera.transform.position;
        if (Input.GetAxis("ADS") >= 0.1)
        {
            ADSControl();
        }
        else
        {
            reticle.SetActive(false);
        }

    }
}
