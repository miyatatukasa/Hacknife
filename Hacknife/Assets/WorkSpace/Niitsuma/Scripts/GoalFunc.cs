using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxInput;

public class GoalFunc : MonoBehaviour {
    [SerializeField] private ScenarioMessageUseCase scenario;

    bool trigger = false;
    bool goal = false;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == PlayerInfo.Instance.PlayerObj) {
            trigger = true;
            PlayerInfo.Instance.ShouldShowBtnUI = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == PlayerInfo.Instance.PlayerObj) {
            trigger = false;
            PlayerInfo.Instance.ShouldShowBtnUI = false;
        }
    }

    private void Update() {
        if (trigger && XBXInput.PushDown(XBXBtn.B) && !goal) {
            scenario.MessageSet(1);
            goal = true;
        }
    }
}
