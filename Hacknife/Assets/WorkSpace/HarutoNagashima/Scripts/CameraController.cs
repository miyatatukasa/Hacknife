using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing; // �J�����ړ��̑��x
    [SerializeField]
    GameObject mainCamera; // �J�����̕ϐ�
    Vector3 cameraPos; // �J�����̈ʒu
    [SerializeField]
    PlayerInfo playerInfo; // �X�N���v�g�̎Q��
    Vector3 camPos;

    void Start()
    {
        InitCameraPos();
    }

    void FixedUpdate()
    {
        // �ΏۂƂ̋�������`��ԂŒǏ]����
        mainCamera.transform.position = 
            Vector3.Lerp(mainCamera.transform.position, playerInfo.PlayerObj.transform.Find("CamPos").position, Time.fixedDeltaTime * followSmoothing);
        mainCamera.transform.eulerAngles = new Vector3(
            mainCamera.transform.eulerAngles.x, playerInfo.PlayerObj.transform.eulerAngles.y, playerInfo.PlayerObj.transform.eulerAngles.z);
    }

    /// <summary>
    /// �J�����̈ʒu�ƒǏ]�Ώۂ̏�����
    /// </summary>
    public void InitCameraPos()
    {
        // �J�����ʒu��cameraPos�ɂ���
        mainCamera.transform.position = playerInfo.PlayerObj.transform.Find("CamPos").transform.position;
        cameraPos = playerInfo.PlayerObj.transform.Find("CamPos").position;
    }
}
