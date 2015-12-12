using UnityEngine;
using System.Collections;

public class FollowPlayer_Camera : MonoBehaviour {
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	
	void Update () {
		Vector3 point = Camera.main.WorldToViewportPoint(target.position);
		Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0.1f, point.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(destination.x,2.2f,destination.z), ref velocity, dampTime);
	}
}
