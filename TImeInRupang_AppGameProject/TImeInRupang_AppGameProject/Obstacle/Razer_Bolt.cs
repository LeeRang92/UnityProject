using UnityEngine;
using System.Collections;

public class Razer_Bolt : MonoBehaviour {

	float speed = 12.0f;
	Rigidbody rb;
	Vector2 relativePos;
	Transform target;
	
	void Start(){
		rb = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		relativePos = target.position - transform.position; // player의 위치값
		StartCoroutine ("DestroyBolt");

	}
	
	void FixedUpdate() {
		//Quaternion rotation = Quaternion.LookRotation(relativePos);
		//transform.rotation = rotation;
		rb.velocity = relativePos * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision other){
		Destroy (this.gameObject);
	}

	IEnumerator DestroyBolt(){
		yield return new WaitForSeconds (8f);
			Destroy(this.gameObject);
	}
}
