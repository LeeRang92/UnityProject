using UnityEngine;
using System.Collections;

public class Razer_Obstacle : MonoBehaviour {

	public Transform raserPoint;
	public GameObject bolt;

	Transform target;
	float shotTime = 5f;
	bool shot = false;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		if (shot) {
				Vector3 diff = Camera.main.ScreenToWorldPoint (target.position) - transform.position;
				diff.Normalize ();
			
				float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);

			shotTime += Time.deltaTime;
			if (shotTime >= 4f) {
				Instantiate(bolt, raserPoint.position, raserPoint.rotation);
				shotTime = 0f;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
			shot = true;
	}
}
