using UnityEngine;
using System.Collections;

public class playerJump : MonoBehaviour {

	public float speed; // 점프 속도
	public float jumpHight; // 점프 높이
	public float freezJumpHight; // 멈출 점프 높이
	private float jumpCheck;
	private const float maxJump=0f;

	public static int jumpstate; // 점프 상태 저장
	public bool unFreezCheck=false;

	static public playerJump instance;

	enum PlayerState{ // 점프 상태
		IDLE = 0,
		JUMP =1,
		TOP = 2,
		DOWN = 3,
	};

	void Start(){
		jumpHight = 300f;
		instance = this;
		jumpstate = (int)PlayerState.IDLE;
	}

	void Update(){
		if (unFreezCheck) { //카드가 없을 시 내려감		
			Invoke("unFreezJump", 2.0f); // 하강 함수 호출
		}
	}

	void OnCollisionEnter (Collision player) // 현재 바닥에 있는지 체크
	{
		if (player.gameObject.tag == "Ground") {
			jumpCheck = freezJumpHight;
			jumpstate = (int)PlayerState.IDLE;
			NGUITools.SetActive(Shake_Phone.shake, true);
		}
	}

	public void playerJumpStart() //점프 시작
	{
		if (jumpstate == (int)PlayerState.IDLE) {
			Invoke ("playerJumpUp", 5.0f); //바닥에서 n초 후 점프 함수 호출
		}
	}

	public void playerJumpUp() // 점프
	{
		jumpstate = (int)PlayerState.JUMP;
		if (jumpstate == (int)PlayerState.JUMP) {

			Vector3 movement = new Vector3 (0.0f, jumpHight, 0.0f);
			GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
		}
	}
	
	public void freezJump() // 공중에서 머무는 함수
	{
		if (jumpstate == (int)PlayerState.JUMP) {
			Vector3 getY = transform.position; // y값 구함
			if (jumpCheck <= getY.y) {
				jumpstate = (int)PlayerState.TOP;
				//y값 동결
				GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY; //y값 동결
			}
		}
	}
	
	public void unFreezJump(){ // 하강 함수
		if (jumpstate == (int)PlayerState.TOP) {
			unFreezCheck=false;
			//y값 동결 해제
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			jumpCheck = maxJump;
			jumpstate=(int)PlayerState.DOWN;
		}
	}


	public static bool ReturnTop(){
		return jumpstate ==(int)PlayerState.TOP;
	}
	public static bool ReturnJump(){
		return jumpstate ==(int)PlayerState.JUMP;
	}
	public static bool ReturnIdle(){
		return jumpstate ==(int)PlayerState.IDLE;
	}
	public static bool ReturnDown(){
		return jumpstate ==(int)PlayerState.DOWN;
	}

}
