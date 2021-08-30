using UnityEngine;

public class CameraController : MonoBehaviour
{
    // スクリプトの参照
    [SerializeField]
    private PlayerInfo playerInfo;
    // カメラの変数
    [SerializeField]
    private GameObject mainCamera;
    // 構え時のレティクル
    [SerializeField]
    private GameObject reticle;
    // カメラの高さ
    [SerializeField]
    private float camHeight = 1.0f;
    // 対象とカメラの距離
    [SerializeField]
    private float cameraDistance = 1.0f;
    // 追従対象のオブジェクト
    private GameObject targetObj;
    // 構え時のカメラ位置
    private GameObject adsPos;
    // 追従速度
    [SerializeField]
    private float cameraSpeed = 3.0f;
    // 背面のベクトル
    private Vector3 PosVector;
    // 直前の座標
    private Vector3 prevPlayerPos;
    // 構えのフラグ
    private bool isADS = false;

    /// <summary>
    /// カメラの位置と追従対象の初期化
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

    // 構え時の動作
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
