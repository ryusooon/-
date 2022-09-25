using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAreaDetectionScript : MonoBehaviour
{
    public GameObject M1;
    public GameObject M2;
    //  public GameObject M3;

    MoveScript moveScript;
    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("Sphere");
        moveScript = gameObject.transform.root.GetComponent<MoveScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "NavArea")
        {
            M1.GetComponent<MoveScript>().AreaExitDetection();
            M2.GetComponent<MoveScript>().AreaExitDetection();
            //M3.GetComponent<MoveScript>().AreaExitDetection();
            //moveScript.AreaIn = false;
        }
    }

    //public void OnTriggerEnter(Collider c)
    //{
    //    if (c.gameObject.tag == "NavArea")
    //    {
    //        obj.GetComponent<MoveScript>().AreaInDetection();
    //        //moveScript.AreaIn = true;
    //    }
    //}

    public void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "NavArea")
        {
            M1.GetComponent<MoveScript>().AreaInDetection();
            M2.GetComponent<MoveScript>().AreaInDetection();
            // M3.GetComponent<MoveScript>().AreaExitDetection();
        }
    }


}
