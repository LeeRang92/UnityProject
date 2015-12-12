using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MonsterInfo : MonoBehaviour {
	
	public bool attack;
	public GameObject targer_cross;
	public GameObject saveCross;
	public bool crossCheck=false;

	public static MonsterInfo instance;

	// Use this for initialization
	void Start () {
		instance = this;
		attack = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnMouseDown(){
		if (soloBoss_Manager.instance.saveCloud [0] == null) { //구름 생성 없을 시 -0.2f + 0.3f
			saveCross = (GameObject)Instantiate (targer_cross, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y , this.gameObject.transform.position.z - 0.2f), 
		                                     Quaternion.identity);
			saveCross.transform.parent = this.gameObject.transform;
			Bullet.instance.target = (Transform)this.gameObject.transform;
			attack = true;
			crossCheck = false;
		}
	}
	
	void OnCollisionEnter (Collision other)
	{
		
		Destroy (other.gameObject);
		Destroy (this.gameObject);
		
	}
}
