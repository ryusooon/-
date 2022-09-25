using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAreaScript : MonoBehaviour
{

    public bool OnTriggerFin = false;
    [SerializeField] ManagerScript manager;

    private void OnTriggerEnter(Collider other)
    {
        //&&(manager.getFol_A_Flag == true && manager.getFol_B_Flag == true && manager.getFol_C_Flag == true)
        if (other.gameObject.CompareTag("Player"))
        {
            OnTriggerFin = true;
            Debug.Log("FinAreaに当たったで");
        }
    }
}
