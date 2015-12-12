using UnityEngine;
using System.Collections;

public class GhostMonster : MonoBehaviour {
	public bool attack = false;
	public GameObject targer_cross;
	GameObject saveCross;
	public bool crossCheck=false;
	public int monHealth;

	Animator anim;
	
	public static GhostMonster instance;

	void Start () {
		instance = this;
		monHealth += MonsterController.riseMonHealth;
	}
	
	public IEnumerator OnMouseDown(){
		if (CardManager.instance.clickCardNum >= 2) {
			playerController.instance.AnimState = 0;

			saveCross = (GameObject)Instantiate (targer_cross, new Vector3 (this.gameObject.transform.position.x - 0.2f, this.gameObject.transform.position.y, 
		                                                                this.gameObject.transform.position.z - 0.4f), Quaternion.identity);
			saveCross.transform.parent = this.gameObject.transform;

			CardManager.instance.moveCard = true;

			yield return new WaitForSeconds (1.1f);
			CardPoint.instance.clickTarget = true;
			yield return new WaitForSeconds (0.08f);
			Bullet.instance.target = (Transform)this.gameObject.transform; //선택 몬스터 값 넘겨줌

			attack = true;
			crossCheck = false;
		}
	}
	
	void OnCollisionEnter (Collision other)
	{
		Destroy(saveCross);
		Destroy(other.gameObject);
		//상성 체크
		if (other.gameObject.tag == "FireIce")
			monHealth -= 15 + ValueManager.fire + ValueManager.ice;
		else if (other.gameObject.tag == "FireEarth")
			monHealth -= 50 + ValueManager.fire + ValueManager.earth;
		else
			monHealth -= 25;

		if (monHealth <= 0) {
			ValueManager.goldVal += 100;
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
