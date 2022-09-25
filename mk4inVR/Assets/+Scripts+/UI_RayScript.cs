using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Valve.VR;
//using Valve.VR.InteractionSystem;
//using System;
//using System.Globalization;

public class UI_RayScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MainUIManagerScript mainUI;
    public Camera Camera;
    public GameObject houki;

   // private SteamVR_Action_Boolean Grab = SteamVR_Actions.default_GrabGrip;
    //private Boolean GrabGrip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitObj;

        //if(mainUI.OnPause)
        //{
        //Ray ray = new Ray(Camera.transform.position, Camera.transform.forward);
        Ray ray = new Ray(houki.transform.position, houki.transform.forward);

        if (Physics.Raycast(ray,out hitObj))
            {
                Debug.Log(hitObj);
                Debug.DrawRay(ray.origin,ray.direction*15f,Color.green,5,false);
                
            if(hitObj.collider.gameObject.name == "ExitPauseManu"/*&&GrabGrip*/)
            {
                mainUI.ExitPauseManu();
            }

            }



       // }
    }
}
