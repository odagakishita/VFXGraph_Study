using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireManager : MonoBehaviour
{
        Vector3 pos;        //タイヤの座標を管理する変数
    Quaternion rot;     //タイヤの回転を管理する変数
    WheelCollider wc;   //それぞれのWheelCollider
    Transform spoke;    //それぞれのタイヤの子要素のSpoke
        
    void Start()
    {
        wc = GetComponent<WheelCollider>(); //変数:wcに接続情報を取得し代入
        spoke = transform.GetChild(0);      //変数:spoke に子要素の Spoke を代入
    }

    void FixedUpdate()
    {
        wc.GetWorldPose(out pos, out rot);  //WheelColliderから位置と回転情報を取得
        spoke.transform.position = pos;     //spoke の位置を指定
        spoke.transform.rotation = rot;     //spoke の角度を指定
    }
}
