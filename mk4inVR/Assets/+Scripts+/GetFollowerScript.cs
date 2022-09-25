using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムを集めた後の仲間の切り替え（待機->追尾）
public class GetFollowerScript : MonoBehaviour
{
    [SerializeField] ManagerScript manager;
    [SerializeField] QuestScript quest;

    [SerializeField] GameObject popupText_SF_A;
    [SerializeField] GameObject popupText_SF_B;
    [SerializeField] GameObject popupText_SF_C;


    private void OnTriggerEnter(Collider other)
    {
        GameObject rootOther = other.transform.root.gameObject;

        Debug.Log(other.name);
        Debug.Log(rootOther.gameObject.tag);

        if (other.gameObject.tag == "QuestArea")
        {

            if (rootOther.tag == "FollowerA" && manager.itemA_count == 0)
            {
                manager.followerState = true;
                Debug.Log(manager.followerState);

                manager.quest_A_state = true;
                quest.setAc_once = true;
                manager.getFol_A_Flag = true;
                popupText_SF_A.SetActive(false);
                //other.transform.root.gameObject.SetActive(false);
            }
            else if (rootOther.tag == "FollowerB" && manager.itemB_count == 0)
            {
                manager.followerState = true;
                Debug.Log(manager.followerState);

                manager.quest_B_state = true;
                quest.setAc_once = true;
                manager.getFol_B_Flag = true;
                popupText_SF_B.SetActive(false);
                other.transform.root.gameObject.SetActive(false);
            }
            else if (rootOther.tag == "FollowerC" && manager.itemC_count == 0)
            {
                manager.followerState = true;
                Debug.Log(manager.followerState);

                manager.quest_C_state = true;
                quest.setAc_once = true;
                manager.getFol_C_Flag = true;
                popupText_SF_C.SetActive(false);
                other.transform.root.gameObject.SetActive(false);
            }

        }
    }
}
