using UnityEngine;
using System.Collections;

public class Chiken_Boss : MonoBehaviour {

	public GameObject targer_cross;
	GameObject saveCross;

	int bossHealth = 50;
	
	void Update () {
		if (playerJump.ReturnTop ())
			CreateFeather.spawnFeather = true;
		else if(playerJump.ReturnIdle())
			CreateFeather.spawnFeather = false;
	}

	public IEnumerator OnMouseDown(){

		playerController.instance.AnimState = 0;
			
		saveCross = (GameObject)Instantiate (targer_cross, new Vector3 (this.gameObject.transform.position.x+0.1f, this.gameObject.transform.position.y+0.5f, 
			                                                            this.gameObject.transform.position.z - 0.5f), Quaternion.identity);
		saveCross.transform.localScale = new Vector3(0.5f,0.5f,1f);
		saveCross.transform.parent = this.gameObject.transform;
			
		CardManager.instance.moveCard = true;
			
		yield return new WaitForSeconds (1.1f);
		CardPoint.instance.clickTarget = true;
		yield return new WaitForSeconds (0.08f);
		Bullet.instance.target = (Transform)this.gameObject.transform; //선택 몬스터 값 넘겨줌

	}
	
	void OnCollisionEnter (Collision other)
	{
		
		bossHealth -= 60;
		
		if (bossHealth <= 0) {
			
			playerJump.instance.unFreezCheck = true;
			Destroy (this.gameObject);
		}
		
		Destroy (saveCross);
		
	}
}
