using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    Vector3 distance;
    Transform cameraTransform;
    [SerializeField]
    GameObject target;
    Transform targetTransform;

    void Start()
    {
        cameraTransform = this.gameObject.transform;
        targetTransform = target.transform;
        distance = cameraTransform.position - targetTransform.position; // �J�����ƒǏ]�������I�u�W�F�N�g�̋������擾
    }

    void Update()
    {
        Vector3 pos = targetTransform.position + distance;
        gameObject.transform.position = pos;
    }
}
