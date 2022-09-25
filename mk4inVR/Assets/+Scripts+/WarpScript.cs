using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour //エリア端から反対側へのワープ機能
{
    ManagerScript manager;
    GameObject player = null;
    GameObject followerA = null;
    GameObject followerB = null;
    GameObject followerC = null;

    Vector2 pPos_xz;
    Vector3 pRota;
    float p_dis;　                   //中央からの距離
    Vector3 warpPos = Vector3.zero;  //転移先座標
    [SerializeField] float warpRange = 7500;   //移動可能範囲の半径

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<ManagerScript>();
        player = manager.Player;
        followerA = manager.FollowerA;
        followerB = manager.FollowerB;
    }

    // Update is called once per frame
    void Update()
    {
        pPos_xz = new Vector2 (player.transform.position.x, player.transform.position.z);
        p_dis = Vector2.Distance(pPos_xz, Vector2.zero);
        if(p_dis > warpRange)
        {
            warpPos.x = -player.transform.position.x;
            warpPos.z = -player.transform.position.z;
            warpPos.y =  player.transform.position.y;

            if (warpPos.x > 0) warpPos.x = warpPos.x - 500;
                          else warpPos.x = warpPos.x + 500;
            if (warpPos.z > 0) warpPos.z = warpPos.z - 500;
                          else warpPos.z = warpPos.z + 500;

            player.transform.position = warpPos;

            followerA.transform.position = player.transform.position;
            followerB.transform.position = player.transform.position;
        }
    }
}
