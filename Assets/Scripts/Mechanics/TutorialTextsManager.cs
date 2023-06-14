using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialTextsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject KeyboardObject;
    [SerializeField]
    private GameObject GamepadObject;

    public static event System.Action<string> OnDeviceChange;

    void Update()
    {
        // Get the keyboard input action
        if (Keyboard.current.anyKey.isPressed)
        {
            KeyboardObject.SetActive(true);
            GamepadObject.SetActive(false);
        }

        // Get the gamepad input action
        if (Gamepad.current != null && Gamepad.current.allControls.Any(control => control.IsPressed()))
        {
            KeyboardObject.SetActive(false);
            GamepadObject.SetActive(true);
        }
    }

}
