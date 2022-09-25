using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//主に変数の受け渡し
public class ManagerScript : MonoBehaviour
{
    public GameObject Player = null;
    public GameObject FollowerA = null;
    public GameObject FollowerB = null;
    public GameObject FollowerC = null;
    public GameObject HitObject { get; set; } = null;

    //待機中の各仲間が切り替わるときのフラグ
    public bool getFol_A_Flag { get; set; } = false;
    public bool getFol_B_Flag { get; set; } = false;
    public bool getFol_C_Flag { get; set; } = false;

    //各アイテムの残り個数
    public int itemA_count { get; set; } = 0;
    public int itemB_count { get; set; } = 0;
    public int itemC_count { get; set; } = 0;

    //依頼のクリア状況
    public bool quest_A_state { get; set; } = false;
    public bool quest_B_state { get; set; } = false;
    public bool quest_C_state { get; set; } = false;

    public int nowQue { get; set; } = 1; //誘導中の依頼番号
    public bool followerState { get; set; } = false; //仲間の状態
    public bool rise_flag { get; set; } = false; //RiseAreaによる上昇中
    public bool brake_event { get; set; } = true; //停止イベント

    public bool VR_mode { get; set; } = false; //VRカメラのON/OFF
    public bool autoAccel_mode { get; set; } = false; //自動前進のON/OFF
    public bool debugTextSw { get; set; } = false; //デバッグ用テキストのON/OFF
    public bool debugTextVRSw { get; set; } = false; //VRデバッグ用テキストのON/OFF

}
