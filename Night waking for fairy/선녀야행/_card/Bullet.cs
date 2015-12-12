using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public GameObject bullet;
	public Transform target;
	public static Bullet instance;
	Transform deTarget;
	public GameObject explosition;

	void Start()
	{
		//target = GameObject.FindGameObjectWithTag ("Enemy").transform;
		instance = this;
	}

	void FixedUpdate() 
	{
		if (target != null) { // 타겟 선택 시
			Vector3 relativePos = target.position - transform.position; // 타겟과 나의 거리 차이

			//Vector3.Cross(relativePos,transform.right); 
			//Quaternion rotation = Quaternion.LookRotation (relativePos);
			//transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * speed);
			//transform.LookAt (target);
			//Vector3.Cross(relativePos, transform.right);
			transform.Translate (relativePos.normalized*speed*Time.deltaTime);

		}
	}

	void OnCollisionEnter (Collision other){
		Instantiate (explosition, new Vector3(transform.position.x,transform.position.y, transform.position.z-0.1f), Quaternion.identity);
		Destroy(this.gameObject);
	}

}