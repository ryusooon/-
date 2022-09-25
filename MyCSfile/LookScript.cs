using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    [SerializeField]MoveScript moveScript;
    [SerializeField] Transform Player;
    private bool LookOk = false;
    [SerializeField] new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (moveScript.LookOk) LookOk = true;

        if(LookOk)
        {

            transform.LookAt(Player);

            rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}
