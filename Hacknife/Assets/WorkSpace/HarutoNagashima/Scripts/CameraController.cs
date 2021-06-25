using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing = 20F; // カメラ移動の速度
    [SerializeField]
    GameObject mainCamera; // カメラの変数
    [SerializeField]
    Transform cameraPos; // カメラの位置

    void Start()
    {
        initCameraPos();
    }

    void FixedUpdate()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPos.position, Time.fixedDeltaTime * followSmoothing); // 対象との距離を線形補間で追従する
    }

    /// <summary>
    /// カメラの位置と追従対象の初期化
    /// </summary>
    public void initCameraPos()
    {
        // カメラ位置の参照
        //cameraPos = mainCamera.transform;
        // カメラ位置をcameraPosにする
        mainCamera.transform.position = cameraPos.position;
    }
}
