using UnityEngine;
using System.Collections;

public class HelathMable : MonoBehaviour {
	public float speed;
	public GameObject hMable;

	Light li;
	
	public Transform target;

	void Start(){
		li = GetComponent<Light> ();
	}
	

	void Update () {
		
		if (target != null) {
			Vector3 relativePos = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
			transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
		}

		// 구슬 색상
		if (playerController.instance.pHealth >= 70) {
			gameObject.renderer.material.color = Color.green;
			li.color = Color.green;
		} else if (playerController.instance.pHealth < 70 && playerController.instance.pHealth >= 30) {
			gameObject.renderer.material.color = Color.yellow;
			li.color = Color.yellow;
		} else if(playerController.instance.pHealth < 30 && playerController.instance.pHealth >= 0){
			gameObject.renderer.material.color = Color.red;
			li.color = Color.red;
		}
		else if (playerController.instance.pHealth <= 0) {
			gameObject.renderer.material.color = Color.gray;
			li.enabled = false;
		}
	}

}
