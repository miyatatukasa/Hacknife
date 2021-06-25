using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    [SerializeField]
    private Material m_defaultMaterial = null;
    [SerializeField]
    private Material m_foundMaterial = null;

    private Renderer m_renderer = null;
    private List<GameObject> m_targets = new List<GameObject>();


    private void Awake()
    {
        m_renderer = GetComponentInChildren<Renderer>();

        var searching = GetComponentInChildren<SearchingBehavior>();
        searching.onFound += OnFound;
        searching.onLost += OnLost;
    }

    /// <summary>
    /// 範囲内にはいったら
    /// </summary>
    /// <param name="i_foundObject">オブジェクトが入ったら</param>
    private void OnFound(GameObject i_foundObject)
    {
        m_targets.Add(i_foundObject);
        m_defaultMaterial = m_renderer.material;
        m_renderer.material = m_foundMaterial;
    }

    /// <summary>
    /// 範囲内を出たら
    /// </summary>
    /// <param name="i_lostObject">オブジェクトが出たら</param>
    private void OnLost(GameObject i_lostObject)
    {
        m_targets.Remove(i_lostObject);

        if (m_targets.Count == 0)
        {
            m_renderer.material = m_defaultMaterial;
        }
    }
}
