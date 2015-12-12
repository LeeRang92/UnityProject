using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public AudioClip jumpSound;
	public AudioSource audio;
	public Rigidbody rb;
	Renderer renderer;

	bool jumping = false, collCehck = true;
	float speed = 3f;
	int upSpeed = 20;

	public static playerMove instance;

	void Awake(){
		renderer = GetComponent<Renderer> ();
		instance = this;
	}
	
	void FixedUpdate () {
		//이동속도 상승
		if (TimeCount_UI.time > upSpeed) {
			upSpeed += 20;
			speed += 0.4f;
		}
		//캐릭터 이동
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
	}

	//캐릭터 점프
	public void Jump(){
		if (jumping) {
			audio.PlayOneShot(jumpSound);
			rb.velocity = new Vector3 (0, 5, 0);
			jumping = false;
		}
	}

	// 점프를 위한 바닥 체크
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Ground") 
			jumping = true;
	}

	//캐릭터 장애물 충돌 체크
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Obstacle") {
			if(collCehck){
				collCehck = false;
				StartCoroutine("BackPlayer",0.2f);
			}
		}
	}

	IEnumerator BackPlayer(float duration){
		//캐릭터 뒤로 물러남
		transform.Translate (new Vector3 (-1.2f, 0.5f, 0));
		//캐릭터 랜더링 On/Off 반복
		while (duration>0f) {
			duration -= Time.deltaTime;
			renderer.enabled = !renderer.enabled;
			yield return new WaitForSeconds(0.2f);
		}
		renderer.enabled = true;
		collCehck = true;
	}

}
