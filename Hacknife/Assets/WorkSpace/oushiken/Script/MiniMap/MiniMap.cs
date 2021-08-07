using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private RectTransform playerInMap;
    [SerializeField] private RectTransform map2dEnd;
    [SerializeField] private Transform map3dParent;
    [SerializeField] private Transform map3dEnd;
    [SerializeField] private Transform minimapplayerIcom;
    private Transform player;
    
    private Vector3 normalized, mapped;
  
    private void Start()
    {
        player = PlayerInfo.Instance.PlayerObj.transform;
    }

    void Update()
    {
        if(player.gameObject != PlayerInfo.Instance.PlayerObj) { player = PlayerInfo.Instance.PlayerObj.transform; }
        minimapplayerIcom.transform.position = player.position;
        minimapplayerIcom.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y + 90);

        normalized = Divide(
               map3dParent.InverseTransformPoint(player.position),
               map3dEnd.position - map3dParent.position);
        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
        playerInMap.localPosition = mapped;
    }
    private Vector3 Divide(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);

    }
    private Vector3 Multiply(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
   
}
