using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform m_transform;
    float m_movSpeed = 10.0f;
    float gravity = 10.0f;
    public int m_life = 5;
    public float m_jumpSpeed = 8.0f;
    private Vector3 m_movDerection = Vector3.zero;
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_life <= 5)
        {
            return;
        }
    }
    void Control()
    {
        float xm = 0, ym = 0, zm = 0;
        ym -= gravity * Time.deltaTime;
        if(Input.GetKey(KeyCode.W))
        {
            zm += m_movSpeed * Time.deltaTime;
        }

    }
}
