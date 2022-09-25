using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPopupScript : MonoBehaviour
{
    public GameObject capsule;
    public GameObject popupObj;
    public Transform popup;

    private Text infoText;

    private void Start()
    {
        //if (popup != null)
        //{
        //    infoText = popup.Find("Text").GetComponent<Text>();
        //}
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == capsule)
            {
                popupObj.SetActive(true);
                if (popup != null)
                {
                    popup.LookAt(camera.position);
                    popup.Rotate(0.0f, 180.0f, 0.0f);
                }
                transform.position = hit.point;
            }
            else
            {
                popupObj.SetActive(false);
            }
        }
    }
}
