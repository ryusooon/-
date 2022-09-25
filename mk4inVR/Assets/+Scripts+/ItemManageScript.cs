using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの個数管理
public class ItemManageScript : MonoBehaviour
{
    [SerializeField] ManagerScript manager;

    public bool itemSound_shot { get; set; } = false; //獲得時に一度鳴らす
    public bool checkItem_count { get; set; } = false;
    int itemA_count;
    int itemB_count;
    int itemC_count;

    //[SerializeField] GameObject sFollowerA;
    //[SerializeField] GameObject FollowerA;
    //[SerializeField] GameObject sFollowerB;
    //[SerializeField] GameObject FollowerB;
    //[SerializeField] GameObject sFollowerC;
    //[SerializeField] GameObject FollowerC;
    void Start()
    {
        // アイテム数の把握
        itemA_count = GameObject.FindGameObjectsWithTag("ItemA").Length;
        manager.itemA_count = itemA_count;
        itemB_count = GameObject.FindGameObjectsWithTag("ItemB").Length;
        manager.itemB_count = itemB_count;
        itemC_count = GameObject.FindGameObjectsWithTag("ItemC").Length;
        manager.itemC_count = itemC_count;
    }

    void Update()
    {
        // フィールドにある残りアイテム数を算出
        if (checkItem_count == true)
        {
            itemA_count = GameObject.FindGameObjectsWithTag("ItemA").Length;
            manager.itemA_count = itemA_count;
            itemB_count = GameObject.FindGameObjectsWithTag("ItemB").Length;
            manager.itemB_count = itemB_count;
            itemC_count = GameObject.FindGameObjectsWithTag("ItemC").Length;
            manager.itemC_count = itemC_count;

            itemSound_shot = true;
            checkItem_count = false;
        }

    }

    void SendActiveObj(int number)
    {
        //switch(number)//ひとまずStayFollowerを消して本来のFollowerをActiveにするけどたぶん変更あり
        //{
        //    case 1:
        //        Destroy(sFollowerA);
        //        FollowerA.SetActive(true);
        //        break;

        //    case 2:
        //        Destroy(sFollowerB);
        //        FollowerB.SetActive(true);
        //        break;

        //    case 3:
        //        Destroy(sFollowerC);
        //        FollowerC.SetActive(true);
        //        break;

        //    default:
        //        Debug.Log("値が来てないよ");
        //        break;




        //}

    }



}
