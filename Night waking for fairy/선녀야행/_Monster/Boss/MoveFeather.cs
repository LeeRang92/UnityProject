using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveFeather : MonoBehaviour{

	public GameObject ga;
	float speed = 1f;
	Transform target;
	Transform dTarget;
	Vector3 startPosition;
	Transform startParent;

	Vector3 objPosition;

	bool dragCheck = true;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}


	void Update () {

		if (target != null) { // 타겟 선택 시
			if(dragCheck){
			Vector3 relativePos = target.position - transform.position; // 타겟과 나의 거리 차이
			transform.Translate (relativePos.normalized * speed * Time.deltaTime);
			}
			else if(!dragCheck){
				if(objPosition.x >= 0)
					dTarget = GameObject.FindGameObjectWithTag ("FeatherPos1").transform;
				else
					dTarget = GameObject.FindGameObjectWithTag ("FeatherPos2").transform;

				Vector3 relativePos = dTarget.position - transform.position; // 타겟과 나의 거리 차이
				transform.Translate (relativePos.normalized * speed * Time.deltaTime);
			}
		}
	}

	void OnMouseDrag(){

		float distance = Camera.main.WorldToScreenPoint (ga.transform.position).z;
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

		transform.position = objPosition;

		dragCheck = false;
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "FeatherPos1" || 
		    other.gameObject.tag == "FeatherPos2") {

			Destroy(this.gameObject);
		}

		Destroy(this.gameObject);
	}
}
