// Unityでシリアル通信、Arduinoと連携する雛形

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomethingFromSerial : MonoBehaviour
{
    // 制御対象のオブジェクト用に宣言しておいて、Start関数内で名前で検索
    GameObject targetObject;
    //Player targetScript; // UnityプロジェクトにPlayerオブジェクトがいる前提

    [SerializeField] ManagerScript manager = null;

    // シリアル通信のクラス、クラス名は正しく書くこと
    [SerializeField] SerialHandlerScript serialHandler;

    Renderer _renderer;

  void Start()
    {
        // 制御対象のオブジェクトを取得
        //targetObject = GameObject.Find("Player");
        // 制御対象に関連付けられたスクリプトを取得、一般的にはこのスクリプトのメンバにアクセスして処理をすることが多いと思うので。
        // 大文字、小文字を区別するので、player.csを作ったのなら「p」layer。
        //targetScript = targetObject.GetComponent<Player>();

        // 信号受信時に呼ばれる関数としてOnDataReceived関数を登録
        serialHandler.OnDataReceived += OnDataReceived;

        _renderer = this.gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (!manager.brake_event)
        {
            _renderer.enabled = true;
            Debug.Log("Powaaaaaaaaaaaaaaaaaaaa");
        }
        else
        {
            _renderer.enabled = false;
            Debug.Log("Nooooooooooooooooooooooon");
        }
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        if (message == null)
            return;

        // 受け取ったデータを数値に変換 
        if (message[0] == 'S' && message[message.Length - 1] == 'E')
        {
            #region 必要に応じて変更すべき箇所

            string receivedData;
            int event_data;

            // 必要な文字部分のバイト数（範囲）は常に把握する
            //receivedData = message.Substring(x, y); // x文字目からy文字数を変換
            receivedData = message.Substring(1, 1);

            // 必要な文字部分を抽出したら、データ形式に合わせてデコード、例えば以下のように。
            //float.TryParse(receivedData, out data);
            int.TryParse(receivedData, out event_data);

            if (event_data == 1)
                manager.brake_event = true;
            else
                manager.brake_event = false;

            #endregion
        }
    }
}
