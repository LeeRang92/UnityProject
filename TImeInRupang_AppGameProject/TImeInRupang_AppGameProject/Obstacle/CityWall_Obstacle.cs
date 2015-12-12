using UnityEngine;
using System.Collections;

public class CityWall_Obstacle : MonoBehaviour {

	public AudioClip effectSound;
	public AudioSource audio;
	public GameObject door_1, door_2;
	public Transform arrowPos;
	public GameObject arrow;

	Transform target;
	float shotTime = 5f;
	bool shot = false;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		if (door_1.transform.rotation.y < -0.5f)
			GetComponent<Collider> ().isTrigger = true;

		if (shot) {
			if (transform.position.x - 10f > target.transform.position.x) {
				shotTime += Time.deltaTime;
				if (shotTime >= 4f) {
					Instantiate (arrow, arrowPos.position, arrowPos.rotation);
					shotTime = 0f;
				}
			}
		}
	}

	void OnMouseDown(){
		//문 회전
		if (door_1.transform.rotation.y > -0.7f) {
			audio.PlayOneShot(effectSound);
			door_1.transform.Rotate (new Vector3 (0, -8, 0));
			door_2.transform.Rotate (new Vector3 (0, 8, 0));
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
				shot = true;
		}
	}
}
