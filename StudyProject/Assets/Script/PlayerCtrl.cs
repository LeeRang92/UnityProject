using UnityEngine;
using System.Collections;

// 캐릭터 제어를 위한 스크립트

public class PlayerCtrl : MonoBehaviour {

    private float speed = 3.0f; // 이동속도
    private float jumpSpeed = 6.0f; // 점프 속도
    private float gravity = 20.0f; // 중력
    private float pushPower = 2f; // 미는 힘
    private float inputAxis; // 입력 받는 키의 값
    private bool focusRight = true; //우측을 봐라보는 여부

    private Vector3 moveDir = Vector3.zero;

    Animator anim;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
       Movement();
    }

    void Movement()
    {
        if (controller.isGrounded)
        {
            //이동
            moveDir = Vector3.forward * inputAxis;
            moveDir = transform.TransformDirection(moveDir);
            //moveDir *= speed;
            anim.SetBool("Jump", false);
            //현재 컨트롤을 조종하는 상태일 때
            if (!ControlMgr.instance.switchCtrl)
            {
                inputAxis = Input.GetAxis("Horizontal");
                
                if(inputAxis > 0 && !focusRight) { TurnPlayer(); }
                else if(inputAxis < 0 && focusRight) { TurnPlayer(); }
                
                //점프
                if (Input.GetButtonDown("Jump"))
                {
                    moveDir.y = jumpSpeed;
                    anim.SetBool("Jump", true);
                }
                //달리기
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    inputAxis *= 2f;
                    anim.SetFloat("Speed", inputAxis);
                }
            }
            //컨트롤이 대기상태일 때
            else
            {
                inputAxis = 0f;
            }
        }
        
        //중력 및 이동
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * speed * Time.deltaTime);
        anim.SetFloat("Speed", inputAxis / 3f);
    }

    //캐릭터가 봐라보는 방향 회전
    void TurnPlayer()
    {
        focusRight = !focusRight;
        Vector3 scale = transform.localScale;
        scale.z *= -1;
        transform.localScale = scale;
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
