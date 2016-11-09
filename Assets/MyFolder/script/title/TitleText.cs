using UnityEngine;
using System.Collections;

public class TitleText : MonoBehaviour {

	private GameObject textObject; //点滅させたい文字

	private float nextTime;
	public float interval = 0.8f; //点滅周期


	// Use this for initialization
	void Start()
	{
		textObject= GameObject.Find("text"); 

		nextTime = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		//一定時間ごとに点滅
		if ( Time.time > nextTime ) {
			float alpha = GetComponent<CanvasRenderer>().GetAlpha();
			if (alpha == 1.0f)
				GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			else
				GetComponent<CanvasRenderer>().SetAlpha(1.0f);

			nextTime += interval;
		}

	}
}
