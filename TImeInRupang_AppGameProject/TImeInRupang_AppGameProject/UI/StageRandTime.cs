using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class StageRandTime : MonoBehaviour {
	public Text[] text;
	int rndTime1, rndTime2, rndTime3;

	void Update () {

		rndTime1 = Random.Range (0, 9);
		rndTime2 = Random.Range (0, 9);
		rndTime3 = Random.Range (0, 9);
		text [0].text = rndTime1.ToString ("0");
		text [1].text = rndTime2.ToString ("0");
		text [2].text = rndTime3.ToString ("0");
		text [3].text = rndTime1.ToString ("0");
		text [4].text = rndTime2.ToString ("0");
		text [5].text = rndTime3.ToString ("0");
		Thread.Sleep (15);
	}
}
