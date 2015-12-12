using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {
	private float dist;
	private Vector3 v3Offset;
	private Plane plane;
	GameObject blackHole;
	Rigidbody rb;

	void Start(){
		blackHole = GameObject.Find ("BlackHole_In");
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		if (transform.position.x <= blackHole.transform.position.x+1.3f) {
			rb.useGravity = false;
			transform.localScale += new Vector3 (-0.1f * Time.deltaTime, -0.1f * Time.deltaTime, 0);
			if(transform.localScale.x <= 0f){
				BlackHole_Obstacle.count--;
				Destroy(this.gameObject);
			}
		}
	}
	
	void OnMouseDown() {
		plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float dist;
		plane.Raycast (ray, out dist);
		v3Offset = transform.position - ray.GetPoint (dist);         
	}
	void OnMouseDrag() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float dist;
		plane.Raycast (ray, out dist);
		Vector3 v3Pos = ray.GetPoint (dist);
		transform.position = v3Pos + v3Offset;    
	}
}

