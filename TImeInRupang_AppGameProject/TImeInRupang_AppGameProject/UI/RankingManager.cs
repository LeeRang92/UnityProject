using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RankingManager : MonoBehaviour {

	public List<Text> rankText = new List<Text>();
	public static List<float> rankScore = new List<float>();

	void Start () {
		sorting ();
		SetScore ();
	}

	void Update () {
		for (int i=0; i<rankScore.Count; i++)
			rankText [i].text = rankScore[i].ToString ("0.0");
		if (rankScore.Count >= 11)
			rankScore.RemoveAt (10);

		if(Application.platform == RuntimePlatform.Android){
			if(Input.GetKey(KeyCode.Escape)){
				ExitMenu();
			}
		}
	}
	//점수 저장
	public static void SetScore(){
		for(int i=0; i<rankScore.Count; i++)
			PlayerPrefs.SetFloat("Score"+i, rankScore[i]);
	}
	//점수 불러오기
	public static void GetScore(){
		for(int i=0; i<rankScore.Count; i++)
			rankScore[i] = PlayerPrefs.GetFloat("Score"+i);
	}

	//메뉴 나가기
	public void ExitMenu(){
		gameObject.SetActive (false);
	}
	

	void sorting()
	{
		int first = 0;
		int last = rankScore.Count -1;
		quickSort(first, last);
	}

	void quickSort(int first, int last)
	{
		if(first < last){
			int pIndex = partition(first, last);
			quickSort(first,pIndex-1);
			quickSort(pIndex+1, last);
		}
	}

	int partition(int first, int last)
	{
		int low, high;
		float temp;
		low = first-1;
		high = last;
		float pivot = rankScore[last];
		
		while(low < high){
			while(pivot > rankScore[++low]); 
			while(pivot < rankScore[--high]);
			if(low<high){
				temp = rankScore[low];
				rankScore[low] = rankScore[high];
				rankScore[high] = temp;
			}
		}
		temp = rankScore[low];
		rankScore[low] = rankScore[high];
		rankScore[high] = temp;
		
		return low;
	}

}
