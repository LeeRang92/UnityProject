using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public Transform currentPos; // 현재 위치값 (몬스터 공격 충돌 위치)

	public int pHealth = 100; // player Health
	public int AnimState = -1;

	Animator anim;
	public static bool start = false;
	public static playerController instance;

	enum playerAimation{
		FIREATTACK,
		HIT,
		DIE,
	};

	void Start(){
		instance = this;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		if (start) {
			Jump ();
			PlayAnimation ();
		}
	}

	void Jump(){
		playerJump.instance.playerJumpStart();
		if(playerJump.ReturnJump())
			playerJump.instance.playerJumpUp();
		playerJump.instance.freezJump ();
	}

	//애니메이션 재생
	void PlayAnimation(){
		if (AnimState == (int)playerAimation.FIREATTACK) {
			anim.Play ("FireAttack");
			AnimState = -1;
		} else if (AnimState == (int)playerAimation.HIT) {
			anim.Play ("Hit");
			AnimState = -1;
		} else if (AnimState == (int)playerAimation.DIE) {
			anim.SetFloat ("Die", -1.0f);
		}
	}
}