using UnityEngine;
using System.Collections;

public class playExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("Explosion");
	}
	IEnumerator Explosion(){
		yield return new WaitForSeconds(0.5f);
		Destroy (this.gameObject);
	}
}
