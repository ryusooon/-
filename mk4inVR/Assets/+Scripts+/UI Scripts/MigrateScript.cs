using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MigrateScript : MonoBehaviour
{
    GameObject[] manuButtons;

    [SerializeField] CanvasGroup manu;
    [SerializeField] CanvasGroup title;
    [SerializeField] CanvasGroup option;
    [SerializeField] CanvasGroup sound;
    //[SerializeField] CanvasGroup MainC;

    
    [SerializeField] GameObject RotePos;
    [SerializeField] Vector3 EffPos;
    [SerializeField] GameObject DisEff;
    [SerializeField] GameObject kanban;//名前仮
    private GameObject disciple1;//配列にするかも

    private int Rote = 0;
    private bool RoteOk = false;
    private float Rotecount = 0;  //元int
    private float move = 0; //仮

    private bool kanbanmove = false;
    private float kanbanX = -4.0f;
    private float kanbanY = -1.5f;
    private int kanbanmoveCount = 0;

    //public GameObject targetObject;
    //public Slider zoomSlider;
    //public float minDistance = 1;
    //public float maxDistance = 5;

    public GameObject mainCamera;
    public GameObject subCamera;



    // Start is called before the first frame update
    void Start()
    {
        //manuButtons = GameObject.FindGameObjectsWithTag("Scene2");
        disciple1 = GameObject.Find("A");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //Debug.Log("なんか押されたよ");
            //for (int i = 0; i < manuButtons.Length; i++)
            //{
            //    manuButtons[i].SetActive(true);
            //    Debug.Log(manuButtons[i]);
            //}
            CanvasGroupOnOf(manu, true);  //各画面遷移先のButton表示と判定許可
            CanvasGroupOnOf(title, false);//PleaseAnyKey系統のメッセージ消す

        }


        if (kanbanmove)
        {
            kanban.transform.position += new Vector3(kanbanX, kanbanY, 0);
            if (kanbanmoveCount > 27)//無理やり計算
            {
                kanbanmove = false;
            }

            kanbanmoveCount++;
        }


        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainCamera.SetActive(true);
            subCamera.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }

    }


    private void FixedUpdate() //フレームに依存しそうな処理だから用意しといた
    {

        if (RoteOk)
        {

            RotePos.transform.Rotate(new Vector3(0, Rote, 0));
            Rotecount++;
            //if (RotePos.transform.rotation.y > 90)//試し
            //{
            //    RoteOk = false;
            //    Debug.Log("回転完了");
            //}
            //味方Moveに関するやつ(下一行)
            //disciple1.transform.position += new Vector3(move, 0, 0);//座標から無理やり割り算で動かしていることをお忘れなく
            // Debug.Log(RotePos.transform.rotation.y);
            //deltatime??
            if (Rotecount > 90)//回転途中に押すと回転の度合いがバグるのを後で修正しよう
            {
                RoteOk = false;
                Debug.Log("回転完了");

            }
            //if (Rote == -1 && Rotecount > 90) RoteOk = false;

        }






    }

    public void OnGameStart()
    {
        SceneManager.LoadScene("MainScene");//ゲームスタート
    }
    public void BacktoTitle()//Manu開いた状態から戻ったときの処理
    {
        CanvasGroupOnOf(manu, false);
        CanvasGroupOnOf(title, true);
    }

    public void PushtoOption()//Manu開いた状態から戻ったときの処理
    {
        CanvasGroupOnOf(option, true);
        Rote = 1;
        RoteOk = true;
        Rotecount = 0;
        move = 3;

        //Zoom();
    }

    //public void Zoom()
    //{
    //    // 最大距離から見ての目標距離
    //    var targetDistance = maxDistance - (maxDistance - minDistance) * zoomSlider.value;
    //    // playerObject からカメラへの向きと距離
    //    var headingPtoC = mainCamera.transform.position - targetObject.transform.position;
    //    // 方向に距離を掛けて目的の位置を計算
    //    mainCamera.transform.position = headingPtoC.normalized * targetDistance;
    //}


    public void Backtomanu()//Manu開いた状態から戻ったときの処理
    {
        CanvasGroupOnOf(option, false);
        Rote = -1;
        RoteOk = true;
        Rotecount = 0;
        move = -3;

        //Instantiate(DisEff, new Vector3(0.0f,60.0f,0.0f),Quaternion.identity);
        //Instantiate(DisEff, EffPos, Quaternion.identity);
    }

    public void OnSoundmanu()
    {
        kanbanmove = true;

    }



    private void CanvasGroupOnOf(CanvasGroup canvasGroup, bool enable)
    {
        if (enable)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

    }
}
