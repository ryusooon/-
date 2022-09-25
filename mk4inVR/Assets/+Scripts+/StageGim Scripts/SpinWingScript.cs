using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//風車の回転
public class SpinWingScript : MonoBehaviour
{
    [SerializeField] private float spin_speed_A = 3.0f;
    [SerializeField] private float spin_speed_B = 5.0f;
    private Quaternion rot;
    private Quaternion now_q;

    void Update()
    {
        rot = Quaternion.AngleAxis(spin_speed_A, Vector3.forward/*(軸)*/);
        now_q = this.transform.rotation;

        this.transform.rotation = now_q * rot;

        rot = Quaternion.AngleAxis(spin_speed_B, Vector3.left/*(軸)*/);
        now_q = this.transform.rotation;

        this.transform.rotation = now_q * rot;
    }
}