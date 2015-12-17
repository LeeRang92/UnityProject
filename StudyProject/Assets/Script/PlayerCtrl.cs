using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {


    private float speed = 3.0f; // 이동속도
    private float jumpSpeed = 8.0f; // 점프 속도
    private float gravity = 20.0f; // 중력
    private float pushPower = 2.0f; // 미는 힘
    private float inputAxis; // 입력 받는 키의 값

    private Vector3 moveDir = Vector3.zero;
    Animator anim;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

	void Update () {

        Movement();
    }

    public void Movement()
    {
        //이동
        if (controller.isGrounded)
        {
            moveDir = new Vector3(0, 0, inputAxis);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            anim.SetBool("Jump", false);

            if (!ControlMgr.instance.switchControl)
            {
                inputAxis = Input.GetAxis("Horizontal");
                //점프
                if (Input.GetButtonDown("Jump") && !ControlMgr.instance.switchControl)
                {
                    moveDir.y = jumpSpeed;
                    anim.SetBool("Jump", true);
                }
            }
            else
            {
                inputAxis = 0f;
                anim.SetFloat("Speed", 0f);
            }
        }

        //중력 적용 및 이동
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        //anim.SetBool("Jump", false);
        anim.SetFloat("Speed", inputAxis);
    }

   //캐릭터 컨트롤러 충돌
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //오브젝트 밀기
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }
}
