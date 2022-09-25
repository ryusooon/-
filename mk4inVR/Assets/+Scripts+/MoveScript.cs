using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum MoveMode
{
    Idle = 1,
    Follow = 2,
    Wait = 0
}

public class MoveScript : MonoBehaviour
{
    InOutScript IoS;
    public float move_speed = 100f;

    public GameObject M1;
    public GameObject M2;
    public GameObject M3;

    public GameObject M1s;
    public GameObject M2s;
    public GameObject M3s;

    protected Rigidbody rb;
    protected Transform followTarget;
    protected MoveMode currentMoveMode;
    bool pattern = false;  //trueだとNavから？？？
    public bool test;
    public bool AreaIn;
    private bool NavDet = false;
    //public GameObject player1;
    [SerializeField]

    Transform target;
    public Transform Player;
    NavMeshAgent agent;
    NavMeshHit hit;


    [SerializeField] ManagerScript manager;
    private bool ActiveFlag = false;
    int objNum = 0;


    private string Pos;
    public bool LookOk = false;
    [SerializeField] FinishAreaScript Finish;
    [SerializeField] Transform Lpos1;

    [SerializeField] GameObject CheckArea;
    [SerializeField] GameObject ShowTextArea;
    private bool CanDestroyStayState = true;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "FollowerA")
        {
            agent = M1.GetComponent<NavMeshAgent>();
            IoS = M1s.GetComponent<InOutScript>();
            objNum = 1;
            Pos = "Pos1";
        }

        if (this.gameObject.tag == "FollowerB")
        {
            agent = M2.GetComponent<NavMeshAgent>();
            IoS = M2s.GetComponent<InOutScript>();
            objNum = 2;
            Pos = "Pos2";

        }
        if (this.gameObject.tag == "FollowerC")
        {
            agent = M3.GetComponent<NavMeshAgent>();
            IoS = M3s.GetComponent<InOutScript>();
            objNum = 3;
            Pos = "Pos3";
        }


        rb = this.GetComponent<Rigidbody>();
        currentMoveMode = MoveMode.Follow;
        //followTarget = Player;
        followTarget = target;
   
        
        move_speed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        //if(AreaIn==true)
        //{
        //    if (test == true)
        //    {
        //        Debug.Log("両方In");
        //        pattern = true;
        //        agent.enabled = true;
        //    }

        //    if (test == false)
        //    {
        //        Debug.Log("プレイヤーだけIn");
        //        followTarget = target;
        //        agent.enabled = false;
        //        pattern = false;
        //    }



        //}

        //if(AreaIn==false)
        //{
        //    if (test == true)
        //    {
        //        agent.enabled = false;
        //        followTarget = target;
        //        pattern = false;
        //    }

        //}

        //if(Input.GetKey(KeyCode.B))
        //{
        //    agent.enabled = false;
        //    agent.SetDestination(target.position);
        //}


        //if (Input.GetKey(KeyCode.V))
        //{
        //    agent.enabled = true;
        //    agent.SetDestination(target.position);
        //}


        //Debug.Log(test);


        //if (NavDet = true)
        //{
        //    if (test == true)
        //    {
        //        Debug.Log("a");
        //        agent.enabled = false;
        //        followTarget = target;
        //        pattern = false;
        //    }
        //}

        //if (NavDet = false)
        //{

        //    if (test == true)
        //    {
        //        Debug.Log("両方In");
        //        pattern = true;
        //        agent.enabled = true;
        //        //agent.SetDestination(target.position);
        //    }


        //    if (test == false)
        //    {
        //        Debug.Log("プレイヤーだけIn");
        //        followTarget = target;
        //        agent.enabled = false;
        //        pattern = false;
        //    }

        //}

        if (objNum == 1 && manager.getFol_A_Flag) ActiveFlag = true;
        if (objNum == 2 && manager.getFol_B_Flag) ActiveFlag = true;
        if (objNum == 3 && manager.getFol_C_Flag) ActiveFlag = true;

       // if (ActiveFlag)
       // {
            if (CanDestroyStayState) DestroyObj();
            NavDet = true;
            if (pattern == true)
            {
                //if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
                //{
                //    // 位置をNavMesh内に補正
                //    transform.position = hit.position;
                //}
                //Debug.Log("Navでついてくる");
                agent.SetDestination(target.position);
                //agent.destination = player.transform.position;
                // agent.destination = target.transform.position;
            }

            if (pattern == false)
            {
                //Debug.Log("気合でついてくる");
                agent.enabled = false;
                DoAutoMovement();
                //if (NavDet == true)
                //{
                //    transform.LookAt(target.transform);
                //    rb.AddForce(transform.forward * move_speed, ForceMode.Force);
                //}
            }
       // }
        //else
       // {
        //    this.transform.LookAt(target);
        //}

        if (Finish.OnTriggerFin)
        {
            target = Lpos1;
            move_speed = 100f;
        }
        //DoAutoMovement();
        
    }

    public void AreaExitDetection()
    {
        //Debug.Log("Exit");
        //if (IoS.Areas == false)
        //{
        //    agent.enabled = false;
        //    followTarget = target;
        //    pattern = false;
        //}


        //NavDet = true;

        if (test == true)
        {
            Debug.Log("a");
            agent.enabled = false;
            followTarget = target;
            pattern = false;
        }

    }



    public void AreaInDetection()
    {
        Debug.Log("In");
        //NavDet = false;

        //if (test == true)
        //{
        //    Debug.Log("両方In");
        //    pattern = true;
        //    agent.enabled = true;
        //    //agent.SetDestination(target.position);
        //}

        //if (test == false)
        //{
        //    Debug.Log("プレイヤーだけIn");
        //    followTarget = target;
        //    agent.enabled = false;
        //    pattern = false;
        //}
        //if (test == false)
        //{
        //    Debug.Log("プレイヤーだけIn");
        //    pattern = true;
        //    agent.enabled = true;
        //}
    }



    public void OnEnterFollowTarget()
    {
        if (pattern == false)
        {
            followTarget = null;

            if (currentMoveMode == MoveMode.Follow)
            {
                currentMoveMode = MoveMode.Wait;
                Debug.Log("Nomal");
            }
        }
    }

    public void OnExitFollowTarget()
    {
        if (pattern == false)
        {
            followTarget = target;

            if (currentMoveMode == MoveMode.Wait)
            {
                currentMoveMode = MoveMode.Follow;
                Debug.Log("Move");
            }
        }
    }

    public void OnTriggerEnter(Collider c)
    {
        if (pattern == false)
        {
            //  if (this.gameObject.tag == "M1")
            //  {
            if (c.gameObject.tag == Pos)
            {
                OnEnterFollowTarget();
                // Debug.Log("In");
            }
            //  }
        }



        if (c.gameObject.tag == "StopArea") rb.velocity = transform.forward * 0;
        if (c.gameObject.tag == "outagesPos")
        {
            //rb.velocity = transform.forward * 0;
            //ActiveFlag = false;
            //move_speed = 0f;
            //Debug.Log("さいごのPos");
            LookOk = true;
            this.GetComponent<MoveScript>().enabled = false;
        }

        

    }

    public void OnTriggerExit(Collider c)
    {
        if (pattern == false)
        {
            // if (this.gameObject.tag == "M1")
            //{
            if (c.gameObject.tag == Pos)
            {
                OnExitFollowTarget();
                // Debug.Log("Exit");
            }
            // }
        }

        if (c.gameObject.tag == "SlowArea") move_speed = 1500.0f;

        if (c.gameObject.tag == "Freeza")
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public void OnTriggerStay(Collider c)
    {
        //if (c.gameObject.tag == Pos)
        //{
        //    NavDet = false;
        //    rb.velocity = Vector3.zero;
        //}

        if (c.gameObject.tag == "SlowArea") move_speed = 100.0f;

        if (c.gameObject.tag == "Freeza")
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
    }

    protected void DoAutoMovement()
    {
        switch (currentMoveMode)
        {
            case MoveMode.Wait:
                this.transform.LookAt(target);
                rb.velocity = transform.forward * 0;
              //  rb.constraints = RigidbodyConstraints.FreezePosition;
             //   rb.constraints = RigidbodyConstraints.FreezeRotation;
                break;
            case MoveMode.Follow:
                if (followTarget != null)
                {
                  //  rb.constraints = RigidbodyConstraints.None;
                    //Quaternion move_rotation = Quaternion.LookRotation(followTarget.transform.position - transform.position, Vector3.up);
                    //transform.rotation = Quaternion.Lerp(transform.rotation, move_rotation, 0.1f);
                    //rb.velocity = transform.forward * move_speed;
                    transform.LookAt(target.transform);
                    rb.AddForce(transform.forward * move_speed, ForceMode.Force);
                }

                break;
        }
    }

    private void DestroyObj()
    {
        Destroy(ShowTextArea);
        Destroy(CheckArea);

        CanDestroyStayState = false;
    }

}
