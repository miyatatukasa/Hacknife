using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing; // カメラ移動の速度
    [SerializeField]
    GameObject mainCamera; // カメラの変数
    [SerializeField]
    PlayerInfo playerInfo; // スクリプトの参照
    // 追従対象のオブジェクト
    GameObject targetObj;

    /// <summary>
    /// カメラの位置と追従対象の初期化
    /// </summary>
    public void InitCameraPos()
    {
        // オブジェクト参照
        targetObj = playerInfo.PlayerObj.transform.Find("CamPos").gameObject;
        // カメラ位置をcameraPosにする
        mainCamera.transform.position = targetObj.transform.position; 
    }

    void Start()
    {
        InitCameraPos();
    }


    void FixedUpdate()
    {
        mainCamera.transform.position+=targetObj.transform.position - mainCamera.transform.position;
        /*// 対象との距離を線形補間で追従する
        mainCamera.transform.position =
            Vector3.Lerp(mainCamera.transform.position, playerInfo.PlayerObj.transform.Find("CamPos").position, Time.fixedDeltaTime * followSmoothing);
        mainCamera.transform.eulerAngles = new Vector3(
            mainCamera.transform.eulerAngles.x, playerInfo.PlayerObj.transform.eulerAngles.y, playerInfo.PlayerObj.transform.eulerAngles.z);*/

    }
}
