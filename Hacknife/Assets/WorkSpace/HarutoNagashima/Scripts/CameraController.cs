using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �X�N���v�g�̎Q��
    [SerializeField]
    private PlayerInfo playerInfo;
    // �J�����̕ϐ�
    [SerializeField]
    private GameObject mainCamera;
    // �\�����̃��e�B�N��
    [SerializeField]
    private GameObject reticle;
    // �J�����̍���
    [SerializeField]
    private float camHeight = 1.0f;
    // �ΏۂƃJ�����̋���
    [SerializeField]
    private float cameraDistance = 1.0f;
    // �Ǐ]�Ώۂ̃I�u�W�F�N�g
    private GameObject targetObj;
    // �\�����̃J�����ʒu
    private GameObject adsPos;
    // �Ǐ]���x
    [SerializeField]
    private float cameraSpeed = 3.0f;
    // �w�ʂ̃x�N�g��
    private Vector3 PosVector;
    // ���O�̍��W
    private Vector3 prevPlayerPos;
    // �\���̃t���O
    private bool isADS = false;

    /// <summary>
    /// �J�����̈ʒu�ƒǏ]�Ώۂ̏�����
    /// </summary>
    public void InitCameraPos()
    {
        adsPos = playerInfo.PlayerObj.transform.Find("ADSPos").gameObject;
    }

    private void FollowCamera(GameObject player)
    {
        targetObj = playerInfo.PlayerObj.transform.Find("CamPos").gameObject;

        Vector3 currentPlayerPos = targetObj.transform.position;
        Vector3 backVector = (prevPlayerPos - currentPlayerPos).normalized;
        PosVector = (backVector == Vector3.zero) ? PosVector : backVector;
        Vector3 targetPos = currentPlayerPos + cameraDistance * PosVector;
        targetPos.y = targetPos.y + camHeight;
        mainCamera.transform.position = Vector3.Lerp(
            mainCamera.transform.position, targetPos, cameraSpeed * Time.deltaTime);

        mainCamera.transform.LookAt(targetObj.transform.position);
        prevPlayerPos = targetObj.transform.position;
    }

    // �\�����̓���
    private void ADSControl()
    {
        mainCamera.transform.position = adsPos.transform.position;
        reticle.SetActive(true);
    }

    void Start()
    {
        InitCameraPos();
        prevPlayerPos = Vector3.back;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("ADS") >= 0.1)
        {
            ADSControl();
            isADS = true;
        }
        else
        {
            reticle.SetActive(false);
            isADS = false;
        }

        if (isADS == false)
        {
            FollowCamera(playerInfo.PlayerObj);
        }

    }
}
