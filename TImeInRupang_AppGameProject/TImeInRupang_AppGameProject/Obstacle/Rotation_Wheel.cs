using UnityEngine;
using System.Collections;

public class Rotation_Wheel : MonoBehaviour {
	private float baseAngle = 0.0f;
	public GameObject door, rot;
	
	void Update(){
		rot.transform.Rotate (new Vector3 (0, 0, 1));
		if (door.transform.position.y > 3.5f)
			GetComponent<Collider> ().isTrigger = true;
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
			openDoor (0.3f);
	}
	//문 열림
	void openDoor(float upSpeed){
		door.transform.Translate(Vector3.up * upSpeed);
	}
}

