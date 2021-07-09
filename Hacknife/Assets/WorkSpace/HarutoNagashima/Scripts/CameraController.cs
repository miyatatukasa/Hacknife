using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing; // カメラ移動の速度
    [SerializeField]
    GameObject mainCamera; // カメラの変数
    Vector3 cameraPos; // カメラの位置
    [SerializeField]
    PlayerInfo playerInfo; // スクリプトの参照
    Vector3 camPos;

    void Start()
    {
        InitCameraPos();
    }

    void FixedUpdate()
    {
        // 対象との距離を線形補間で追従する
        mainCamera.transform.position = 
            Vector3.Lerp(mainCamera.transform.position, playerInfo.PlayerObj.transform.Find("CamPos").position, Time.fixedDeltaTime * followSmoothing);
        mainCamera.transform.eulerAngles = new Vector3(
            mainCamera.transform.eulerAngles.x, playerInfo.PlayerObj.transform.eulerAngles.y, playerInfo.PlayerObj.transform.eulerAngles.z);
    }

    /// <summary>
    /// カメラの位置と追従対象の初期化
    /// </summary>
    public void InitCameraPos()
    {
        // カメラ位置をcameraPosにする
        mainCamera.transform.position = playerInfo.PlayerObj.transform.Find("CamPos").transform.position;
        cameraPos = playerInfo.PlayerObj.transform.Find("CamPos").position;
    }
}
