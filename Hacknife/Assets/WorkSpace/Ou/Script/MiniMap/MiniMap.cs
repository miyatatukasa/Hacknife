using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public RectTransform playerInMap;
    public RectTransform map2dEnd;
    public Transform map3dParent;
    public Transform map3dEnd;
    public Transform player;
    public Transform minimapplayerIcom;
    
    private Vector3 normalized, mapped;
  
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       

    }
    // Update is called once per frame
    void Update()
    {


        minimapplayerIcom.transform.position = new Vector3(player.position.x, player.transform.position.y, player.position.z);
        minimapplayerIcom.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y + 90);



        normalized = Divide(
               map3dParent.InverseTransformPoint(this.transform.position),
               map3dEnd.position - map3dParent.position);
        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
        playerInMap.localPosition = mapped;
    }
    private static Vector3 Divide(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);

    }
    private static Vector3 Multiply(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
   
}
