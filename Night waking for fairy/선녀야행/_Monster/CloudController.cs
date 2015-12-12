using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	public TweenAlpha ta;

	void Awake(){
		ta = GetComponent<TweenAlpha> ();
	}


	void Start(){
		ta.from = 0f;
		ta.to = 1f;
		ta.duration = 1f;
		ta.enabled = true;
	}


	void Update () {
		if (this.gameObject.transform.position.x < -0.4f || this.gameObject.transform.position.x > 1.4f) {
			for (int i=0; i< soloBoss_Manager.instance.saveCloud.Count; i++) {
				if (this.gameObject == soloBoss_Manager.instance.saveCloud [i].gameObject){
					Destroy (this.gameObject);
					soloBoss_Manager.instance.saveCloud.RemoveAt (i);
				}
			}
		}
	}
}
