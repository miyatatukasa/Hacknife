using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing; // �J�����ړ��̑��x
    [SerializeField]
    GameObject mainCamera; // �J�����̕ϐ�
    [SerializeField]
    PlayerInfo playerInfo; // �X�N���v�g�̎Q��
    // �Ǐ]�Ώۂ̃I�u�W�F�N�g
    GameObject targetObj;

    /// <summary>
    /// �J�����̈ʒu�ƒǏ]�Ώۂ̏�����
    /// </summary>
    public void InitCameraPos()
    {
        // �I�u�W�F�N�g�Q��
        targetObj = playerInfo.PlayerObj.transform.Find("CamPos").gameObject;
        // �J�����ʒu��cameraPos�ɂ���
        mainCamera.transform.position = targetObj.transform.position; 
    }

    void Start()
    {
        InitCameraPos();
    }


    void FixedUpdate()
    {
        mainCamera.transform.position+=targetObj.transform.position - mainCamera.transform.position;
        /*// �ΏۂƂ̋�������`��ԂŒǏ]����
        mainCamera.transform.position =
            Vector3.Lerp(mainCamera.transform.position, playerInfo.PlayerObj.transform.Find("CamPos").position, Time.fixedDeltaTime * followSmoothing);
        mainCamera.transform.eulerAngles = new Vector3(
            mainCamera.transform.eulerAngles.x, playerInfo.PlayerObj.transform.eulerAngles.y, playerInfo.PlayerObj.transform.eulerAngles.z);*/

    }
}
