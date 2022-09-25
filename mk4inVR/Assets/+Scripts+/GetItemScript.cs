using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの回収処理
public class GetItemScript : MonoBehaviour
{
    [SerializeField] ItemManageScript itemManager;

    private void OnTriggerEnter(Collider other)
    {
        //アイテムの回収判定
        if (other.gameObject.tag == "ItemA")
        {
            other.gameObject.SetActive(false);
            itemManager.checkItem_count = true;
            //Debug.Log(itemManager.checkItem_count);
        }
        else if (other.gameObject.tag == "ItemB")
        {
            other.gameObject.SetActive(false);
            itemManager.checkItem_count = true;
            //Debug.Log(itemManager.checkItem_count);
        }
        else if (other.gameObject.tag == "ItemC")
        {
            other.gameObject.SetActive(false);
            itemManager.checkItem_count = true;
            //Debug.Log(itemManager.checkItem_count);
        }
    }
}
