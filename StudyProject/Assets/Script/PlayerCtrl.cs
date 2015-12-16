using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

   
    float speed = 3.0f;
    float jumpSpeed = 8.0f;
    float gravity = 20.0f;
    float pushPower = 2.0f;

    Animator anim;

    private Vector3 moveDir = Vector3.zero;
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

	void Update () {
        //이동
        if (controller.isGrounded)
        {
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            anim.SetBool("Jump", false);
            //점프
            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
                anim.SetBool("Jump", true);
            }
        
        }
        
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        //anim.SetBool("Jump", false);
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
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
