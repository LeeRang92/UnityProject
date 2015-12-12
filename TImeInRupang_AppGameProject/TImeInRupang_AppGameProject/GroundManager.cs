using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundManager : MonoBehaviour {

	public List<GameObject> pastGrounds = new List<GameObject>(); // 과거 Ground
	public List<GameObject> presentGrounds = new List<GameObject>();// 현재 Ground
	public List<GameObject> futureGrounds = new List<GameObject>();// 미래 Ground
	public List<GameObject> backGround = new List<GameObject> (); // 배경
	public List<GameObject> curGround = new List<GameObject> (); // 현재 생성된 Ground
	public List<GameObject> curBackGroud = new List<GameObject> (); // 현재 생성된 BackGround

	public static int stageNum = 0;
	
	Vector3 currentPos;
	int rndIndex =0, temp=0;
	
	public static GroundManager instance;
	
	void Start () {
		instance = this;
		curBackGroud.Add ((GameObject)Instantiate (backGround [stageNum], new Vector3 (20f, 3f, 3f), Quaternion.identity));
	}

	//바닥 생성
	public void CreateGround(){
		int curIndex = curGround.Count;
		Debug.Log (temp);
		if (stageNum == 0) { // 과거
			int rndIndex = Random.Range(0, pastGrounds.Count);
			if(temp == rndIndex){ // 중복 처리
				while(temp!=rndIndex)
					rndIndex = Random.Range(0, futureGrounds.Count);
			}
			temp = rndIndex;
			curGround.Add ((GameObject)Instantiate (pastGrounds [rndIndex], new Vector3 (curGround [curIndex - 1].transform.position.x + 22.7f, curGround [curIndex - 1].transform.position.y, 0), Quaternion.identity));
		}

		else if(stageNum == 1) {//현재
			int rndIndex = Random.Range(0, presentGrounds.Count);
			if(temp == rndIndex){
				while(temp!=rndIndex)
					rndIndex = Random.Range(0, futureGrounds.Count);
			}
			temp = rndIndex;
			curGround.Add((GameObject)Instantiate(presentGrounds[rndIndex],new Vector3(curGround [curIndex - 1].transform.position.x+22.7f,curGround [curIndex - 1].transform.position.y, 0),Quaternion.identity));
		}	

		else if(stageNum == 2){ //미래
			int rndIndex = Random.Range(0, futureGrounds.Count);
			if(temp == rndIndex){
				while(temp!=rndIndex)
				rndIndex = Random.Range(0, futureGrounds.Count);
			}
			temp = rndIndex;
			curGround.Add((GameObject)Instantiate(futureGrounds[rndIndex],new Vector3(curGround [curIndex - 1].transform.position.x+22.7f,curGround [curIndex - 1].transform.position.y, 0),Quaternion.identity));

		}


	//바닥 삭제
		if (curGround.Count >= 3) {
			Destroy (curGround [0].gameObject);
			curGround.RemoveAt (0);
		}
	}

	//배경 생성
	public void CreateBackGround(){
		int curIndex = curBackGroud.Count;
		Vector3 curPos = curBackGroud [curIndex - 1].transform.position;
		curBackGroud.Add ((GameObject)Instantiate (backGround [stageNum], new Vector3 (curPos.x + 82.4f, curPos.y, curPos.z), Quaternion.identity));

		//배경 삭제
		if (curBackGroud.Count > 3) {
			Destroy (curBackGroud [0].gameObject);
			curBackGroud.RemoveAt (0);
		}
	}
}
