using UnityEngine;
using System.Collections;

public class Bridge_Wheel : MonoBehaviour {
	private float baseAngle = 0.0f;
	public GameObject right, left;
	
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
		
		if (ang >= 60f && ang <= 100f) {
			DownBridgeRight (10f);
			DownBridgeLeft (10f);
		}
	}
	//문 열림
	void DownBridgeRight(float upSpeed){
		if(right.transform.rotation.z < 0f)
		right.transform.Rotate (new Vector3 (0, 0, upSpeed));

	}
	void DownBridgeLeft(float upSpeed){
		if(left.transform.rotation.z > 0.0f)
			left.transform.Rotate (new Vector3 (0, 0, -upSpeed));
	}
}
