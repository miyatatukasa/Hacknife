using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxInput;

/// <summary>
/// 簡易的なドアの開け閉め
/// </summary>
public class DoorOpenClose : MonoBehaviour {
    [SerializeField] private CharactorType keyType;
    [SerializeField] private bool isOpenWithKey = false; // 開けるときに鍵が必要か
    [SerializeField] private bool isAutoDoor = false; // 自動ドアか

    private Transform[] doors = new Transform[2];
    private Collider coll;

    private Vector3[] firstPos = new Vector3[2];
    private bool isDoorOpen;
    private bool isMove;

    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            doors[i] = gameObject.transform.GetChild(i).transform;
        }
        firstPos[0] = doors[0].localPosition;
        firstPos[1] = doors[1].localPosition;
        coll = GetComponent<Collider>();
    }

    private void OpenClose(bool isOpen) {
        if (isOpen) {
            if (doors[0].localPosition.x == firstPos[0].x - 140f) { isMove = false; coll.isTrigger = true; }
            doors[0].localPosition = Vector3.MoveTowards(doors[0].localPosition, new Vector3(firstPos[0].x - 140f, firstPos[0].y, firstPos[0].z), 300 * Time.deltaTime);
            doors[1].localPosition = Vector3.MoveTowards(doors[1].localPosition, new Vector3(firstPos[1].x + 140f, firstPos[1].y, firstPos[1].z), 300 * Time.deltaTime);
        }
        else {
            if (doors[0].localPosition.x == firstPos[0].x) { if (coll.isTrigger) { coll.isTrigger = false; } return; }
            isMove = false;
            doors[0].localPosition = Vector3.MoveTowards(doors[0].localPosition, new Vector3(firstPos[0].x, firstPos[0].y, firstPos[0].z), 300 * Time.deltaTime);
            doors[1].localPosition = Vector3.MoveTowards(doors[1].localPosition, new Vector3(firstPos[1].x, firstPos[1].y, firstPos[1].z), 300 * Time.deltaTime);
        }
    }

    private void ButtonOpenDoor() {
        OpenClose(true);
    }

    private void AutoOpenDoor() {
        if (doors[0].localPosition.x == firstPos[0].x - 140f) { isMove = false; coll.isTrigger = true; }
        doors[0].localPosition = Vector3.MoveTowards(doors[0].localPosition, new Vector3(firstPos[0].x - 140f, firstPos[0].y, firstPos[0].z), 300 * Time.deltaTime);
        doors[1].localPosition = Vector3.MoveTowards(doors[1].localPosition, new Vector3(firstPos[1].x + 140f, firstPos[1].y, firstPos[1].z), 300 * Time.deltaTime);
    }

    private void CloseDoor() {
        OpenClose(false);
    }


    private void OnCollisionEnter(Collision collision) {
        // FIX: 鍵じゃないタイプで触れたらUIが表示しぱなし
        if (collision.gameObject == PlayerInfo.Instance.PlayerObj) {
            if (!isAutoDoor) { PlayerInfo.Instance.ShouldShowBtnUI = true; }
            else { isMove = true; }
            if (isOpenWithKey && PlayerInfo.Instance.EnemyType == keyType) { isDoorOpen = true; }
            else if (!isOpenWithKey) { isDoorOpen = true; }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == PlayerInfo.Instance.PlayerObj) {
            isDoorOpen = false;
            if (!isAutoDoor) { PlayerInfo.Instance.ShouldShowBtnUI = false; }
        }
    }


    void Update() {
        if (isDoorOpen && XBXInput.PushDown(XBXBtn.B)) {
            isMove = true;
        }
        else if (isDoorOpen && Input.GetKeyDown(KeyCode.Space)) {
            isMove = true;
        }
        else if (!isDoorOpen && doors[0].position != firstPos[0]) {
            CloseDoor();
        }
        if (isMove) {
            if (isAutoDoor) {
                AutoOpenDoor();
            }
            else {
                ButtonOpenDoor();
            }
        }
    }
}
