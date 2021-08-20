using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �J�����̕ϐ�
    [SerializeField]
   private GameObject mainCamera;
    // �X�N���v�g�̎Q��
    [SerializeField]
   private PlayerInfo playerInfo;
    // �\�����̃��e�B�N��
    [SerializeField]
   private GameObject reticle;
    // �Ǐ]�Ώۂ̃I�u�W�F�N�g
   private GameObject targetObj;
    // �\�����̃J�����ʒu
   private GameObject adsPos;

    /// <summary>
    /// �J�����̈ʒu�ƒǏ]�Ώۂ̏�����
    /// </summary>
    public void InitCameraPos(){
        // �ʏ�ʒu�I�u�W�F�N�g�Q��
        targetObj = playerInfo.PlayerObj.transform.Find("CamPos").gameObject;
        // ���b�q�I�u�W�F�N�g�Q��
        ADSPos = playerInfo.PlayerObj.transform.Find("ADSPos").gameObject;
        // �J�����ʒu��cameraPos�ɂ���
        mainCamera.transform.position = targetObj.transform.position;
    }

    private void ADSControl(){
        mainCamera.transform.position = adsPos.transform.position;
        reticle.SetActive(true);
    }

    void Start(){
        InitCameraPos();
    }


    void FixedUpdate(){
        mainCamera.transform.position += targetObj.transform.position - mainCamera.transform.position;
        if (Input.GetAxis("ADS") >= 0.1){
            ADSControl();
        }
        else{
            reticle.SetActive(false);
        }

    }
}
