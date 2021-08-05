using UnityEngine;

public class CameraController : MonoBehaviour
{
    // カメラの変数
    [SerializeField]
    GameObject mainCamera;
    // スクリプトの参照
    [SerializeField]
    PlayerInfo playerInfo;
    // 構え時のレティクル
    [SerializeField]
    GameObject reticle;
    // 追従対象のオブジェクト
    GameObject targetObj;
    // 構え時のカメラ位置
    GameObject ADSPos;

    /// <summary>
    /// カメラの位置と追従対象の初期化
    /// </summary>
    public void InitCameraPos()
    {
        // 通常位置オブジェクト参照
        targetObj = playerInfo.PlayerObj.transform.Find("CamPos").gameObject;
        // 鎌叡智オブジェクト参照
        ADSPos = playerInfo.PlayerObj.transform.Find("ADSPos").gameObject;
        // カメラ位置をcameraPosにする
        mainCamera.transform.position = targetObj.transform.position;
    }

    private void ADSControl()
    {
        mainCamera.transform.position = ADSPos.transform.position;
        reticle.SetActive(true);
    }

    void Start()
    {
        InitCameraPos();
    }


    void FixedUpdate()
    {
        mainCamera.transform.position += targetObj.transform.position - mainCamera.transform.position;
        if (Input.GetAxis("ADS") >= 0.1)
        {
            ADSControl();
        }
        else
        {
            reticle.SetActive(false);
        }

    }
}
