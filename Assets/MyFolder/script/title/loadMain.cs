using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadMain : MonoBehaviour {
	public GameObject exp;
	bool gameStart=false;
	int count = 100;
	public float speed = 0.01f;
	float alfa=0;
	float red,green,blue;
	// Use this for initialization
	void Start () {
		red = GetComponent<Image> ().color.r;
		green = GetComponent<Image> ().color.g;
		blue = GetComponent<Image> ().color.b;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton0)|| Input.GetKeyDown(KeyCode.JoystickButton1)|| Input.GetKeyDown(KeyCode.JoystickButton2)|| Input.GetKeyDown(KeyCode.JoystickButton3)) {
				Instantiate (exp, transform.position, transform.rotation);
				gameStart = true;

		}
		if (gameStart) {
			GetComponent<Image> ().color = new Color(red,green,blue,alfa);
			alfa += speed;
			count--;
			if (count <= 0) {
				Application.LoadLevel ("Main");
			}
		}
	}
}
