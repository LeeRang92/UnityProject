using UnityEngine;
using System.Collections;

public class CountDown_Cloud : MonoBehaviour {

	public UILabel _uiLabel;
	GameObject countUI;
	float countDown;

	// Use this for initialization
	void Start () {
		countDown = 5f;
		_uiLabel = GetComponent<UILabel> ();
		countUI = GameObject.Find ("CountDown");
	}
	
	// Update is called once per frame
	void Update () {
			//카운트 다운 시작
			if (countDown >= 0) {
				countDown -= Time.deltaTime;
				_uiLabel.text = countDown.ToString ("0");
			}
			//카운트 다운 종료
			if(soloBoss_Manager.instance.saveCloud.Count <= 0|| countDown <= 0 ){
				if(soloBoss_Manager.instance.saveCloud.Count>0){
					CreateMonBullet.shotBullet = true;
					CreateMonBullet.cnt = true;
					for(int i=0; i<soloBoss_Manager.instance.saveCloud.Count; i++)
						Destroy(soloBoss_Manager.instance.saveCloud[i].gameObject);
					soloBoss_Manager.instance.saveCloud.Clear();
				}

			Destroy(this.gameObject);
		}
	}
}
