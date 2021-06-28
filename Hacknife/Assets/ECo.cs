//using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ECo : MonoBehaviour
{
    //public FlowMachine flow;
    public NavMeshAgent nav;
    public CharacterController ch;
    bool _trigger;

    void EMove()
    {
        var h = Input.GetAxis("L_Stick_H");
        var v = Input.GetAxis("L_Stick_V");
        transform.position += new Vector3(h, 0, v) * (Time.deltaTime * 2);
    }

    private void Update()
    {
        if (_trigger)
        {
            EMove();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            //flow.enabled = false;
            nav.enabled = false;
            ch.enabled = false;
            _trigger = true;
            transform.position = new Vector3(0, 0.194f, 1.289f);

        }
    }
}
