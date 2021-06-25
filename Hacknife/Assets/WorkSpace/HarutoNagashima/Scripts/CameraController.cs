using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing = 20F; // �J�����ړ��̑��x
    [SerializeField]
    GameObject mainCamera; // �J�����̕ϐ�
    [SerializeField]
    Transform cameraPos; // �J�����̈ʒu

    void Start()
    {
        initCameraPos();
    }

    void FixedUpdate()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPos.position, Time.fixedDeltaTime * followSmoothing); // �ΏۂƂ̋�������`��ԂŒǏ]����
    }

    /// <summary>
    /// �J�����̈ʒu�ƒǏ]�Ώۂ̏�����
    /// </summary>
    public void initCameraPos()
    {
        // �J�����ʒu�̎Q��
        //cameraPos = mainCamera.transform;
        // �J�����ʒu��cameraPos�ɂ���
        mainCamera.transform.position = cameraPos.position;
    }
}
