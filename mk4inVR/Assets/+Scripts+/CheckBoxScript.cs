using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**inspector上でモード切り替えできるように表示**//
public class CheckBoxScript : MonoBehaviour
{
    [SerializeField] ManagerScript manager;

    [SerializeField] bool debugText = false; //デバッグ用テキストのON/OFF
    [SerializeField] bool debugTextVR = false; //VRデバッグ用テキストのON/OFF
    [SerializeField] bool vrMode = false; //VRカメラのON/OFF
    [SerializeField] bool autoAccelMode = false; //自動前進のON/OFF

    void Update()
    {
        manager.autoAccel_mode = autoAccelMode;
        manager.VR_mode = vrMode;
        manager.debugTextSw = debugText;
        manager.debugTextVRSw = debugTextVR;
    }
}
