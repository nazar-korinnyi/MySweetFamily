﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [Header("Joystick Input")]
    public KeyCode Jump = KeyCode.Joystick1Button2;
    public KeyCode Fire1 = KeyCode.Joystick1Button4;
    public KeyCode Fire2 = KeyCode.Joystick1Button5;
    public KeyCode Fire1T = KeyCode.Joystick1Button11;
    public KeyCode Fire2T = KeyCode.Joystick1Button10;

    public string Horizontal = "";
    public string Vertical = "";

    public string AimHorizontal = "";
    public string AimVertical = "";



}
