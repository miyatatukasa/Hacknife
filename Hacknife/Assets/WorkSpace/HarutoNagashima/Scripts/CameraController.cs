using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing; // �J�����ړ��̑��x
    [SerializeField]
    GameObject mainCamera; // �J�����̕ϐ�
    // �Ǐ]�Ώۂ̃I�u�W�F�N�g
    GameObject playerObj;
    GameObject targetObj;

    /// <summary>
    /// �J�����̈ʒu�ƒǏ]�Ώۂ̏�����
    /// </summary>
    public void InitCameraPos()
    {
        playerObj = PlayerInfo.Instance.PlayerObj;
        // �I�u�W�F�N�g�Q��
        targetObj = PlayerInfo.Instance.PlayerObj.transform.Find("CamPos").gameObject;
        // �J�����ʒu��cameraPos�ɂ���
        mainCamera.transform.position = targetObj.transform.position;
        mainCamera.transform.rotation = Quaternion.Euler(targetObj.transform.eulerAngles.x, playerObj.transform.eulerAngles.y, playerObj.transform.eulerAngles.z);
    }

    void Start()
    {
        InitCameraPos();
    }


    void FixedUpdate()
    {
        if(playerObj != PlayerInfo.Instance.PlayerObj) { InitCameraPos(); }
        mainCamera.transform.position+=targetObj.transform.position - mainCamera.transform.position;
        mainCamera.transform.rotation = Quaternion.Euler(
            targetObj.transform.eulerAngles.x, playerObj.transform.eulerAngles.y, playerObj.transform.eulerAngles.z);
        //mainCamera.transform.rotation = PlayerInfo.Instance.PlayerObj.transform.rotation;
        /*// �ΏۂƂ̋�������`��ԂŒǏ]����
        mainCamera.transform.position =
            Vector3.Lerp(mainCamera.transform.position, playerInfo.PlayerObj.transform.Find("CamPos").position, Time.fixedDeltaTime * followSmoothing);
        mainCamera.transform.eulerAngles = new Vector3(
            mainCamera.transform.eulerAngles.x, playerInfo.PlayerObj.transform.eulerAngles.y, playerInfo.PlayerObj.transform.eulerAngles.z);*/

    }
}
