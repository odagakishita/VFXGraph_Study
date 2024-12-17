using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    public CinemachineFreeLook freeLookCamera; // FreeLookCamera��Transform
    public float walkSpeed = 5f; // �������x
    public float runSpeed = 10f; // ���葬�x

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalking = Input.GetKey(KeyCode.W); // W�L�[�������Ă��邩
        bool IsRunning = IsWalking && Input.GetKey(KeyCode.LeftShift); // Shift + W �ő���

        if (IsWalking)
        {
            RotatePlayerToCamera();

            if (IsRunning)
            {
                MoveForward(runSpeed);
                anim.SetBool("isRunning", true);
                //anim.SetBool("isWalking", false); // "walking"���I�t
            }
            else
            {
                MoveForward(walkSpeed);
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false); // "running"���I�t
            }
        }
        else
        {
            // �A�j���[�V�������~
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }


    void RotatePlayerToCamera()
    {
        // Cinemachine FreeLook��X_Axis�̒l���擾
        float cameraRotationY = freeLookCamera.m_XAxis.Value;

        // �v���C���[��Y����]�𑦍��ɕύX
        transform.rotation = Quaternion.Euler(0, cameraRotationY, 0);
    }

    void MoveForward(float _speed)
    {
        // ���݂̑��x�Ńv���C���[��O�i������
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
