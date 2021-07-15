using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchT : MonoBehaviour
{
    public Transform target;
    private List<GameObject> m_targets = new List<GameObject>();
    public float speed = 1f;


    private void Awake()
    {
        var searching = GetComponentInChildren<SearchingBehavior>();
        searching.onFound += OnFound;
        
    }


    private void OnFound(GameObject i_foundObject)
    {
        Debug.Log("vkmfvldd@");
    }
}
