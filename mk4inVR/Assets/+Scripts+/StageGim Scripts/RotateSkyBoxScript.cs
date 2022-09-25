using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBoxScript : MonoBehaviour
{
    //回転スピード
    [SerializeField] private float rotateSpeed = 0.5f;
    //スカイボックスのマテリアル
    private Material skyboxMaterial;

    void Start()
    {
        //　Lighting Settingsで指定したスカイボックスのマテリアルを取得
        skyboxMaterial = RenderSettings.skybox;
    }

    void Update()
    {
        //　スカイボックスマテリアルのRotationを操作して角度を変化させる
        skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") + rotateSpeed * Time.deltaTime, 360f));
    }
}

