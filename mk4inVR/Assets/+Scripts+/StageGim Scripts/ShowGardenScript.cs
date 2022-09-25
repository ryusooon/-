using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//花畑に近づいたときの表示切り替え
public class ShowGardenScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Garden")
        {
            GameObject[] child = new GameObject[4];

            for (int i = 0; i < 4; i++)
                child[i] = other.transform.GetChild(i).gameObject;

            for(int i = 0; i < 4; i++)
            {
                Renderer renderer = child[i].gameObject.GetComponent<Renderer>();
                renderer.enabled = true;
            }
            //Renderer renderer = other.gameObject.child.GetComponent<Renderer>();
            
            //other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Garden")
        {
            GameObject[] child = new GameObject[4];

            for (int i = 0; i < 4; i++)
                child[i] = other.transform.GetChild(i).gameObject;

            for (int i = 0; i < 4; i++)
            {
                Renderer renderer = child[i].gameObject.GetComponent<Renderer>();
                renderer.enabled = false;
            }
            //Renderer renderer = other.gameObject.GetComponent<Renderer>();
            //other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
