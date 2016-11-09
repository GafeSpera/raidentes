using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tenmetsu : MonoBehaviour {
	public float speed = 0.01f;
	float alfa=0;
	float red,green,blue;
	bool plus = true;

	// Use this for initialization
	void Start () {
		red = GetComponent<Image> ().color.r;
		green = GetComponent<Image> ().color.g;
		blue = GetComponent<Image> ().color.b;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Image> ().color = new Color(red,green,blue,alfa);
		if (plus) {
			alfa += speed;
		} else {
			alfa -= speed;
		}
		if (alfa <= 0) {
			plus = true;
		} else if (alfa >= 1) {
			plus = false;
		}
	
	}
}
