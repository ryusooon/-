using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    //待機中の仲間
    [SerializeField] private GameObject StayFollower_A = null;
    [SerializeField] private GameObject StayFollower_B = null;
    [SerializeField] private GameObject StayFollower_C = null;

    //誘導ビーコン
    [SerializeField] private GameObject Beacon_A = null;
    [SerializeField] private GameObject Beacon_B = null;
    [SerializeField] private GameObject Beacon_C = null;

    [SerializeField] private GameObject Carsor = null; //誘導カーソル
    bool carsorSetAc_flag = false;
    public bool setAc_once = false;
    bool popBeacon_flag_A = false;
    bool popBeacon_flag_B = false;
    bool popBeacon_flag_C = false;

    private int questNum = 3;
    private int nowQueNum = 1;

    [SerializeField] ManagerScript manager;

    //誘導中のクエストを選択
    void SeleQuest()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            nowQueNum++;
            setAc_once = true;
        }
        if (nowQueNum > questNum)
        {
            nowQueNum = 1;
            setAc_once = true;
        }

        manager.nowQue = nowQueNum;
    }

    void CarsorSwActive()
    {
        if (setAc_once == true)
        {
            if (carsorSetAc_flag == true)
                Carsor.SetActive(true);
            else
                Carsor.SetActive(false);

            setAc_once = false;
        }
    }

    void Update()
    {
        //Debug.Log("setac :" + carsorSetAc_flag);
        //Debug.Log("once :" + setAc_once);

        SeleQuest();

        //初回SetActive
        if (manager.itemA_count == 0 && !popBeacon_flag_A)
        {
            Carsor.SetActive(true);
            Beacon_A.SetActive(true);
            popBeacon_flag_A = true;
        }
        if (manager.itemB_count == 0 && !popBeacon_flag_B)
        {
            Carsor.SetActive(true);
            Beacon_B.SetActive(true);
            popBeacon_flag_B = true;
        }
        if (manager.itemC_count == 0 && !popBeacon_flag_C)
        {
            Carsor.SetActive(true);
            Beacon_C.SetActive(true);
            popBeacon_flag_C = true;
        }

        //目的地誘導
        switch (nowQueNum)
        {
            case 1:
                if (manager.quest_A_state == false && popBeacon_flag_A)
                {
                    Beacon_A.SetActive(true);
                    carsorSetAc_flag = true;
                    CarsorSwActive();

                    Carsor.transform.LookAt(StayFollower_A.transform);
                }
                else if (manager.quest_A_state || !popBeacon_flag_A)
                {
                    Beacon_A.SetActive(false);
                    carsorSetAc_flag = false;
                    CarsorSwActive();
                }
                Beacon_B.SetActive(false);
                Beacon_C.SetActive(false);
                break;
            case 2:
                if (manager.quest_B_state == false && popBeacon_flag_B)
                {
                    Beacon_B.SetActive(true);
                    carsorSetAc_flag = true;
                    CarsorSwActive();

                    Carsor.transform.LookAt(StayFollower_B.transform);
                }
                else if (manager.quest_B_state || !popBeacon_flag_B)
                {
                    Beacon_B.SetActive(false);
                    carsorSetAc_flag = false;
                    CarsorSwActive();
                }
                Beacon_C.SetActive(false);
                Beacon_A.SetActive(false);
                break;
            case 3:
                if (manager.quest_C_state == false && popBeacon_flag_C)
                {
                    Beacon_C.SetActive(true);
                    carsorSetAc_flag = true;
                    CarsorSwActive();

                    Carsor.transform.LookAt(StayFollower_C.transform);
                }
                else if (manager.quest_C_state || !popBeacon_flag_C)
                {
                    Beacon_C.SetActive(false);
                    carsorSetAc_flag = false;
                    CarsorSwActive();
                }
                Beacon_A.SetActive(false);
                Beacon_B.SetActive(false);
                break;
        }
    }
}
