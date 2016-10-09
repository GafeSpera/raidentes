using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	//スクロールする速度
	public float scrollSpeed = 0.05f;
	//スクロールを繰り返す間隔
	float size = 500f;

	// Update is called once per frame
	void Update () {
		//すこしずつ前進
		transform.Translate (scrollSpeed,0,0);
		if (this.transform.position.x >= size) {
			this.transform.Translate (-3 * size, 0, 0);
		}
	}
}
