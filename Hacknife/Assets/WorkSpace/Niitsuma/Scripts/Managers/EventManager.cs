using System.Collections.Generic;

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

    private Dictionary<int, EventFlag> EventList = new Dictionary<int, EventFlag>();
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
    /// </summary>
    public void EventUpdate() {
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
            //Debug.LogError(EventList[i].EventDesc());
        }
    }

    protected override void Awake() {
        base.Awake();
        FlagCreate();
    }
}
