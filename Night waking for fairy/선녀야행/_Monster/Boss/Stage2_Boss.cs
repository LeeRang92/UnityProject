using UnityEngine;
using System.Collections;

public class Stage2_Boss : MonoBehaviour {

	public GameObject targer_cross;
	GameObject saveCross;

	int bossHealth = 50;

	public static int deClick = 0;
	public static bool checkPanel = false; // 순서 틀린지 확인
	
	
	void Update () {


		if (playerJump.ReturnTop ())
			Stage_Panel.spawnPanel = true;
		else if (playerJump.ReturnIdle ()) { 
			Destroy(this.gameObject); //내려 올 때 적 삭제
			Stage_Panel.spawnPanel = false;
		}

		if (deClick == Stage_Panel.list_Panel.Count) { // 패널 삭제
			for(int i=0; i< Stage_Panel.list_Panel.Count; i++)
				Destroy(Stage_Panel.list_Panel[i].gameObject);
			Stage_Panel.list_Panel.Clear();

			if(checkPanel){
				CreateMonBullet.shotBullet = true;
				Stage_Panel.spawnPanel = false;
				checkPanel = false;
			}
		}
	}

	public IEnumerator OnMouseDown(){
		if (Stage_Panel.list_Panel.Count <= 0) {
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
	}

	void OnCollisionEnter (Collision other)
	{
		bossHealth -= 60;
		
		if (bossHealth <= 0) {
			UIManager.uiOn = true;
			playerJump.instance.unFreezCheck = true;
			Destroy (this.gameObject);
		}
		
		Destroy (saveCross);
		
	}
}
