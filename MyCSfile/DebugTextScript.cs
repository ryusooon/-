using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//**ゲーム画面にデバッグ用テキストを表示**//
public class DebugTextScript : MonoBehaviour
{
    ManagerScript manager;
    public GameObject debugTxtOb = null;
    public GameObject debugTxtVROb = null;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.debugTextSw || manager.debugTextVRSw)
        {
            if (manager.debugTextSw)
            {
                debugTxtOb.SetActive(true);
            }
            else if (manager.debugTextVRSw)
            {
                debugTxtVROb.SetActive(true);
            }

            Text debug_text    = debugTxtOb.GetComponent<Text>();
            Text debug_text_VR = debugTxtVROb.GetComponent<Text>();

            // テキストの表示
            StringBuilder builder = new StringBuilder();
            //各残りアイテム数
            builder.Append("ItemA：" + manager.itemA_count);
            builder.Append(Environment.NewLine); //改行
            builder.Append("ItemB：" + manager.itemB_count);
            builder.Append(Environment.NewLine); //改行
            builder.Append("ItemC：" + manager.itemC_count);
            builder.Append(Environment.NewLine); //改行

            builder.Append("FollowerState：" + manager.followerState);
            debug_text.text    = builder.ToString();
            debug_text_VR.text = builder.ToString();
        }
        else if (!manager.debugTextSw)
        {
            debugTxtOb.SetActive(false);
        }
    }
}
