using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;
using System;
using System.Globalization;


public class MainUIManagerScript : MonoBehaviour
{

    [SerializeField] CanvasGroup Pausemanu;
    [SerializeField] CanvasGroup Soundmanu;
    [SerializeField] CanvasGroup Contllolmanu;
    [SerializeField] CanvasGroup MainCanvas;
    [SerializeField] CanvasGroup ResultCanvas;
    [SerializeField] FinishAreaScript FinScript;


    public Camera Camera;
    public GameObject houki;
    [SerializeField] GameObject FakeRay;

    public bool OnPause = false;
    private SteamVR_Action_Boolean Grab = SteamVR_Actions.default_GrabGrip;
    private SteamVR_Action_Boolean Trigger = SteamVR_Actions._default.InteractUI;
    private Boolean GrabGrip;
    private Boolean TriggerOn;

    private bool OnTriggerHR = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GrabGrip = Grab.GetState(SteamVR_Input_Sources.RightHand);
        TriggerOn = Trigger.GetState(SteamVR_Input_Sources.RightHand);

        if(GrabGrip) //横ボタンでTrueになる
        {
            OnTriggerHR = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape)||OnTriggerHR /*|| GrabGrip*/)//取りあえずいったんEscapeKeyでManuを開くようにする
        {

            Debug.Log("Pause押したよ");
            //CanvasGroupOnOf(Pausemanu, true);
            //CanvasGroupOnOf(MainCanvas, false);
            OnPause = true;

        }

        if(OnPause)
        {
            CanvasGroupOnOf(Pausemanu, true);
            CanvasGroupOnOf(MainCanvas, false);

            if (GrabGrip || Input.GetKeyDown(KeyCode.Escape))//中に入れる状態で再度押したらfalseになるようにしてみる
            {
               // OnTriggerHR = false;
               // OnPause = false;
            }


            RaycastHit hitObj;
            Ray ray = new Ray(houki.transform.position, houki.transform.forward);
            FakeRay.SetActive(true);
            if (Physics.Raycast(ray, out hitObj))
            {
                //Debug.Log(hitObj);
                //Debug.DrawRay(ray.origin, ray.direction * 15f, Color.green, 5, false);

                if (hitObj.collider.gameObject.name == "ExitPauseManu" && TriggerOn /*|| GrabGrip*/)
                {
                    ExitPauseManu();
                }


                if (hitObj.collider.gameObject.name == "BackTitle" && TriggerOn /*|| GrabGrip*/)
                {
                    BackTitle();
                }

                if (hitObj.collider.gameObject.name == "GoSoundManu" && TriggerOn /*|| GrabGrip*/)
                {
                    pushSoundButton();
                }

                if (hitObj.collider.gameObject.name == "GoContllol" && TriggerOn /*|| GrabGrip*/)
                {
                    pushContllolButton();
                }

                if (hitObj.collider.gameObject.name == "ExitthisManu" && TriggerOn /*|| GrabGrip*/)
                {
                    BackPauseManu1();
                }

                if (hitObj.collider.gameObject.name == "ExitCManu" && TriggerOn /*|| GrabGrip*/)
                {
                    BackPauseManu2();
                }

                if (hitObj.collider.gameObject.name == "BackTitle1" && TriggerOn /*|| GrabGrip*/)
                {
                    BackTitle();
                }

                if (hitObj.collider.gameObject.name == "ExitResult" && TriggerOn /*|| GrabGrip*/)
                {
                    ExitResultCanvas();
                }


            }
        }
        else
        {
            CanvasGroupOnOf(Pausemanu, false);
            CanvasGroupOnOf(MainCanvas, true);
        }

        if(FinScript.OnTriggerFin)
        {
            CanvasGroupOnOf(MainCanvas, false);
            CanvasGroupOnOf(ResultCanvas, true);
            FakeRay.SetActive(true);
        }

        

        //if(mainUI.OnPause)
        //{
        //Ray ray = new Ray(Camera.transform.position, Camera.transform.forward);
        



        // }
    }

    public void ExitPauseManu()//Pause画面→元の状態へ　　　　あとでゲーム自体の停止も加える？
    {

        CanvasGroupOnOf(Pausemanu, false);
        CanvasGroupOnOf(MainCanvas, true);
        OnPause = false;
        FakeRay.SetActive(false);
    }

    public void ExitResultCanvas()
    {
        CanvasGroupOnOf(MainCanvas, true);
        CanvasGroupOnOf(ResultCanvas, false);
        FakeRay.SetActive(false);

    }

    public void BackTitle()//タイトル画面に戻る
    {
        //SceneManager.LoadScene("TitleScene");
        SceneManager.LoadScene("MainScene");
    }

    public void pushSoundButton()
    {
        CanvasGroupOnOf(Soundmanu, true);
        CanvasGroupOnOf(Pausemanu, false);
    }
    public void pushContllolButton()
    {
        CanvasGroupOnOf(Contllolmanu, true);
        CanvasGroupOnOf(Pausemanu, false);
    }
    public void BackPauseManu1()
    {
        CanvasGroupOnOf(Soundmanu, false);
        CanvasGroupOnOf(Pausemanu, true);
    }

    public void BackPauseManu2()
    {
        CanvasGroupOnOf(Contllolmanu, false);
        CanvasGroupOnOf(Pausemanu, true);

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
