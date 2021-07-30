using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float followSmoothing; // カメラ移動の速度
    [SerializeField]
    GameObject mainCamera; // カメラの変数
    // 追従対象のオブジェクト
    GameObject playerObj;
    GameObject targetObj;

    /// <summary>
    /// カメラの位置と追従対象の初期化
    /// </summary>
    public void InitCameraPos()
    {
        playerObj = PlayerInfo.Instance.PlayerObj;
        // オブジェクト参照
        targetObj = PlayerInfo.Instance.PlayerObj.transform.Find("CamPos").gameObject;
        // カメラ位置をcameraPosにする
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
        /*// 対象との距離を線形補間で追従する
        mainCamera.transform.position =
            Vector3.Lerp(mainCamera.transform.position, playerInfo.PlayerObj.transform.Find("CamPos").position, Time.fixedDeltaTime * followSmoothing);
        mainCamera.transform.eulerAngles = new Vector3(
            mainCamera.transform.eulerAngles.x, playerInfo.PlayerObj.transform.eulerAngles.y, playerInfo.PlayerObj.transform.eulerAngles.z);*/

    }
}
