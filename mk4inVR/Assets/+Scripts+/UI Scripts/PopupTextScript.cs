using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//近づいた時の吹き出しの表示
public class PopupTextScript : MonoBehaviour
{
    [SerializeField] ManagerScript manager = null;
    [SerializeField] GameObject Camera = null;

    public GameObject popupObj;
    public GameObject popupCanvas;
    public Transform popup;

    private void Update()
    {
        if (popupObj.activeSelf)
        {
            Transform camera = Camera.transform;
            if (popup != null)
            {
                popup.LookAt(camera.position);
                popup.Rotate(0.0f, 180.0f, 0.0f);
            }
            popupCanvas.transform.position = transform.root.gameObject.transform.position;
        }
    }

    //表示
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popupObj.SetActive(true);
        }
    }

    //非表示
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popupObj.SetActive(false);
        }
    }
}