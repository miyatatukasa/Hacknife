using System.Collections.Generic;
using UnityEngine;

public enum EventFlag {
    START_EVENT,
    TUTORIAL_EVENT,
    MAP_EVENT,
    CAMERA_STOP_EVENT,
    KEY_HACK_EVENT,
    CORD_DESTRUCT_EVENT,
    CORD_DESTRUCT_END_EVENT,
    EVENT_MAX,
}

static class EventExt {
    static string[] eventDescript = new string[] { 
        "ようこそ", "チュートリアル開始", "マップを回収せよ", "監視カメラを停止せよ", "鍵もちを探せ","コードを破壊せよ","乙",
    };
    public static string EventDesc(this EventFlag eve) {
        return eventDescript[(int)eve];
    }
    public static string EventNum(int n) {
        return eventDescript[n];
    }
}
public class EventManager : SingletonBehaviour<EventManager> {

    // 登録されたイベント
    private Dictionary<int, EventFlag> EventList = new Dictionary<int, EventFlag>();
    // 呼び出されたオブジェクトの登録用
    private List<GameObject> callingList = new List<GameObject>();
    // 現在のイベント番号
    public int EventNum { get; private set; }

    /// <summary>
    /// 現在のイベント
    /// </summary>
    /// <returns></returns>
    public EventFlag CurrentEvent() {
        return EventList[EventNum];
    }

    /// <summary>
    /// イベント番号の更新
    /// 同一のオブジェクトらは一度しか呼び出せない
    /// </summary>
    /// <param name="call">呼び出したオブジェクト</param>
    public void EventUpdate(GameObject call) {
        if (!callingList.Contains(call)) { callingList.Add(call); }
        else { return; }
        EventNum++;
    }

    /// <summary>
    /// イベント番号ごとのタグの説明分表示
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public string EventDescript(int num) {
        return EventList[num].EventDesc();
    }

    // フラグを追加する
    private void FlagCreate() {
        for (int i = 0; i < (int)EventFlag.EVENT_MAX; i++) {
            EventList.Add(i, (EventFlag)i);
        }
    }

    protected override void Awake() {
        base.Awake();
        FlagCreate();
    }
}
