using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseAreaScript : MonoBehaviour
{
    [SerializeField] float upSpeed = 1000;
    [SerializeField] ManagerScript manager = null;
    [SerializeField] Rigidbody PlayerRb = null;

    private void Update()
    {
        Debug.Log("riseFlag = " + manager.rise_flag);
        if (manager.rise_flag)
        {
            PlayerRb.AddForce(Vector3.up * upSpeed, ForceMode.Force);
        }
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            manager.rise_flag = true;
            PlayerRb.drag = 20;
            //Player = player.gameObject.GetComponent<GameObject>();
        }
    }

    /*private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
            player.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.up * upSpeed, ForceMode.Force);
    }*/

    public void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            manager.rise_flag = false;
            PlayerRb.drag = 5;
        }
    }
}
