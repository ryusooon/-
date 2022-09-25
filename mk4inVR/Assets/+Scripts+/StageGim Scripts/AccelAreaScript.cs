using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelAreaScript : MonoBehaviour
{
    [SerializeField] float axel = 10000;

    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
          player.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward  * axel, ForceMode.Force);
    }
}
