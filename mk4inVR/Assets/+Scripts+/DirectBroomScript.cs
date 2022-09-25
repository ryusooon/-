using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectBroomScript : MonoBehaviour
{
    [SerializeField] GameObject ControllerR = null;
    [SerializeField] MainUIManagerScript mainUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (mainUI.OnPause == true)
        //{
            transform.rotation = ControllerR.transform.rotation;
       // }
    }
}
