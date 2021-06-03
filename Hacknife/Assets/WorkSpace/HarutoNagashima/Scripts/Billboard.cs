using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]
    GameObject[] CamelaList;

    Transform TargetPos;
    Vector3 activeCameraPos;

    GameObject ActiveCamera;

    void Update()
    {
        for (int i = 0; i < CamelaList.Length; i++)
        {
            if (CamelaList[i].activeSelf)
            {
                ActiveCamera = CamelaList[i];
            }
        }
        transform.LookAt(ActiveCamera.transform);
    }
}
