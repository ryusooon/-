using System.Collections.Generic;
using UnityEngine;

public class InOutScript : MonoBehaviour
{
    MoveScript moveScript1;
    MoveScript moveScript2;
    MoveScript moveScript3;
    public GameObject M1;
    public GameObject M2;
    public GameObject M3;
    //bool test = true;
    public bool Areas = true;
    // Start is called before the first frame update
    void Start()
    {
        moveScript1 = M1.transform.root.GetComponent<MoveScript>();
        moveScript2 = M2.transform.root.GetComponent<MoveScript>();
        moveScript3 = M3.transform.root.GetComponent<MoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(gameObject.transform.root.name);
    }

    public void OnTriggerStay(Collider c)
    {
        //if (c.gameObject.tag == "NavArea")
        //{
        //    Debug.Log("mikataIn");
        //    moveScript.test = true;
        //}
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "NavArea")
        {
            Debug.Log("mikataIn");

            moveScript1.test = true;
            moveScript2.test = true;
            moveScript3.test = true;

            Areas = true;
        }
    }

    public void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "NavArea")
        {
            Debug.Log("mikataOut");
            moveScript1.test = false;
            moveScript2.test = false;
            moveScript3.test = false;
            Areas = false;
        }
    }
}
