using System;
using UnityEngine;

public enum AnimType {
    Idel,
    Walk,
    Run,
}

static class AnimExt {
    static string[] animNames = new string[] { "Idel", "Walk", "Run" };
    public static string AnimName(this AnimType anim) {
        return animNames[(int)anim];
    }
    public static string AnimNum(int n) {
        return animNames[n];
    }
}

public static class AnimationSetter {
    public static void CharaAnimSet(Animator anim, AnimType type) {
        AnimeSet(anim, type);
    }

    private static void AnimeSet(Animator anim, AnimType type) {
        for (int i = 0; i < Enum.GetValues(typeof(AnimType)).Length; i++) {
            if ((int)type == i) { anim.SetBool(type.AnimName(), true); }
            else { anim.SetBool(AnimExt.AnimNum(i), false); }
        }
    }
}

