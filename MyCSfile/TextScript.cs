using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField] ManagerScript manager;
    public GameObject questTxtOb = null;

    int reqNumA = 9;//3
    int reqNumB = 9;//2
    int reqNumC = 9;//2

    void Update()
    {
        Text quest_text = questTxtOb.GetComponent<Text>();

        StringBuilder builder = new StringBuilder();
        builder.Append("アイテムを集めろ");
        builder.Append(Environment.NewLine);
        if (manager.nowQue == 1)
            builder.Append(">>  ");
        else
            builder.Append("    ");
        builder.Append("ItemA　　" + (reqNumA - manager.itemA_count) + '/' + reqNumA + ' ');
        builder.Append(Environment.NewLine);
        if (manager.nowQue == 2)
            builder.Append(">>  ");
        else
            builder.Append("    ");
        builder.Append("ItemB　　" + (reqNumB - manager.itemB_count) + '/' + reqNumB + ' ');
        builder.Append(Environment.NewLine);
        if (manager.nowQue == 3)
            builder.Append(">>  ");
        else
            builder.Append("    ");
        builder.Append("ItemC　　" + (reqNumC - manager.itemC_count) + '/' + reqNumC + ' ');

        quest_text.text = builder.ToString();
    }
}
