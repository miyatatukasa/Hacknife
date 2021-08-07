using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
  public class CameraRotate : MonoBehaviour{

    [SerializeField]  private float speed;

    [SerializeField] private float angle;
   private Vector3 dir; 
    void Start() {
        dir = Vector3.up;
    } 
    void Update() { 
        if (CheckAngle(transform.eulerAngles.y) <= -angle) {
            dir = Vector3.up; 
        } 
        if (CheckAngle(transform.eulerAngles.y) >= angle) {
            dir = Vector3.down;
        } 
        transform.Rotate(dir,30 * Time.deltaTime * speed); 
    } 
    private float CheckAngle(float value) { 
       float  angle = value - 180; 
        if (angle > 0) {
            return angle - 180;
        } 
        return angle + 180; 
    }
}

 