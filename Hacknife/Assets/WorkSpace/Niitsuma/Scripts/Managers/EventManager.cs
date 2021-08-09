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

    // �o�^���ꂽ�C�x���g
    private Dictionary<int, EventFlag> EventList = new Dictionary<int, EventFlag>();
    // �Ăяo���ꂽ�I�u�W�F�N�g�̓o�^�p
    private List<GameObject> callingList = new List<GameObject>();
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
    /// ����̃I�u�W�F�N�g��͈�x�����Ăяo���Ȃ�
    /// </summary>
    /// <param name="call">�Ăяo�����I�u�W�F�N�g</param>
    public void EventUpdate(GameObject call) {
        if (!callingList.Contains(call)) { callingList.Add(call); }
        else { return; }
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
        }
    }

    protected override void Awake() {
        base.Awake();
        FlagCreate();
    }
}
