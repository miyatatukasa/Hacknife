using UnityEngine;

namespace XboxInput
{
    public enum XBXBtn
    {
        A      = KeyCode.JoystickButton0,
        B      = KeyCode.JoystickButton1,
        X      = KeyCode.JoystickButton2,
        Y      = KeyCode.JoystickButton3,
        LB     = KeyCode.JoystickButton4,
        RB     = KeyCode.JoystickButton5,
        View   = KeyCode.JoystickButton6,
        Menu   = KeyCode.JoystickButton7,
        Lstick = KeyCode.JoystickButton8,
        Rstick = KeyCode.JoystickButton9,
    }

    public class XBXInput
    {
        public static bool Push(XBXBtn xb)      { return Input.GetKey((KeyCode)xb);     }
        public static bool PushDown(XBXBtn xb)  { return Input.GetKeyDown((KeyCode)xb); }
        public static bool PushUp(XBXBtn xb)    { return Input.GetKeyUp((KeyCode)xb);   }
    }
}