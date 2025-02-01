using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public float maxPower;    // 最高出力トルク
    public float angle;       // ハンドルを切った時の最高角度
    public float breake;      // ブレーキの力
    [SerializeField] WheelCollider wcFR, wcFL, wcRR, wcRL;  // 4輪のWheelCollider
    enum DRIVE { FRONT, REAR }  // 前輪駆動か後輪駆動かを指定する列挙型変数
    DRIVE drive;               // 列挙型変数を管理する変数

    void Start()
    {
        drive = DRIVE.REAR;    // 最初は後輪駆動で検証
    }

    void Drive()
    {
        float power = maxPower * Input.GetAxis("Vertical");     // 前後の力
        float steering = angle * Input.GetAxis("Horizontal");   // ハンドルを切る角度

        wcFR.steerAngle = steering;         // ハンドルの動きを右前タイヤに伝える
        wcFL.steerAngle = steering;         // ハンドルの動きを左前タイヤに伝える
        if (drive == DRIVE.REAR)            // 後輪駆動なら
        {
            wcRR.motorTorque = power;       // トルクを右後タイヤに伝える
            wcRL.motorTorque = power;       // トルクを左後タイヤに伝える
        }
        else                                // 前輪駆動なら
        {
            wcFR.motorTorque = power;       // トルクを右前タイヤに伝える
            wcFL.motorTorque = power;       // トルクを左前タイヤに伝える
        }
    }

    void Breake()
    {
        if (Input.GetKey(KeyCode.LeftShift))    //左シフトが押されたら
        {
            wcFL.brakeTorque = breake;
            wcFR.brakeTorque = breake;
            wcRL.brakeTorque = breake;
            wcRR.brakeTorque = breake;
        }
        else                                   //そうでなければ
        {
            wcFL.brakeTorque = 0;
            wcFR.brakeTorque = 0;
            wcRL.brakeTorque = 0;
            wcRR.brakeTorque = 0;
        }
    }
    void FixedUpdate()
    {
        Drive();    //記述済み
        Breake();   //ブレーキ関数発動
    }

    
}
