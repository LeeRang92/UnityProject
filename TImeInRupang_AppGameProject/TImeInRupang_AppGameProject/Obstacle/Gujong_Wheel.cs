using UnityEngine;
using System.Collections;

public class Gujong_Wheel : MonoBehaviour {
	private float baseAngle = 0.0f;
	public GameObject stone;


	void Update(){
		if(stone.transform.position.y > 2.3f)
			GetComponent<Collider> ().isTrigger = true;
	}

	//문 열림
	void openStone(float upSpeed){
		if(stone.transform.position.y < 2.45f)
			stone.transform.Translate(Vector3.up * upSpeed);
	}

	void OnMouseDown(){
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		pos = Input.mousePosition - pos;
		baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) *Mathf.Rad2Deg;
	}
	void OnMouseDrag(){
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		pos = Input.mousePosition - pos;
		float ang = Mathf.Atan2(pos.y, pos.x) *Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
		
		if (ang >= 60f && ang <= 100f)
			openStone (0.3f);
	}

}
