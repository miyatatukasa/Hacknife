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
        "�悤����", "�`���[�g���A���J�n", "�}�b�v���������", "�Ď��J�������~����", "��������T��","�R�[�h��j�󂹂�","��",
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
    // ���݂̃C�x���g�ԍ�
    public int EventNum { get; private set; }

    /// <summary>
    /// ���݂̃C�x���g
    /// </summary>
    /// <returns></returns>
    public EventFlag CurrentEvent() {
        return EventList[EventNum];
    }

    /// <summary>
    /// �C�x���g�ԍ��̍X�V
    /// </summary>
    public void EventUpdate() {
        EventNum++;
    }

    /// <summary>
    /// �C�x���g�ԍ����Ƃ̃^�O�̐������\��
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public string EventDescript(int num) {
        return EventList[num].EventDesc();
    }

    // �t���O��ǉ�����
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
