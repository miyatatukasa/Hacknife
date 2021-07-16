using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyOpen : MonoBehaviour
{
    Vector3 vecAdd;
    bool trigger = false;

    private void Start()
    {
        vecAdd = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10f);
    }
    void Open()
    {
        transform.position = Vector3.MoveTowards(transform.position, vecAdd, Time.deltaTime * 3f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject.GetComponent<IHackable>();
        if(null != hit) { if(hit.GetEnemyType == CharactorType.KeyMan) { trigger = true; } }
    }
    // Update is called once per frame
    bool isOpen;
    void Update()
    {
        if (trigger && Input.GetKeyDown(KeyCode.F)) isOpen = true;
        if (isOpen) { Open(); }
    }
}
