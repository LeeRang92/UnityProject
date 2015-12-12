using UnityEngine;
using System.Collections;

public class monBullet : MonoBehaviour {
	float speed=3.0f;
	public GameObject bullet;
	//public Transform delPosition;

	Transform target;
	
	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void FixedUpdate() 
	{
		if (target != null) {
			Vector3 relativePos = target.position - transform.position;
			transform.Translate (relativePos.normalized*speed*Time.deltaTime);

			//player 충돌 체크
			if(this.gameObject.transform.position.y <= playerController.instance.currentPos.transform.position.y){
				Destroy(this.gameObject); // bullet 오브젝트 파괴
				CameraShake.shake = 1f; // 카메라 흔들기

				if(playerController.instance.pHealth <= 0){
					playerController.instance.AnimState = 2;
					playerJump.instance.unFreezCheck=true;
				}
				else{
					playerJump.instance.unFreezCheck=true; // 충돌 후 하강
					playerController.instance.pHealth -= 10;
					playerController.instance.AnimState = 1;
				}
			}
		}
	}
}
