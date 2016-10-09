using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	//通ってゆく地点
	public GameObject[] pos;
	public Vector3[] movePath;
	int currentPath = 0;
	//各地点間をいくらかけて移動すか
	public float time = 50f;

	void Start () {
		for (int j = 0; j < pos.Length; j++) {
			movePath [j] = pos [j].transform.position;
		}

		//for(int i=0; i<pos.Length; i++) {
			iTween.MoveTo (gameObject, iTween.Hash (
				"path", movePath,
				"orienttopath", true,
				"time", time,
				"easetype", iTween.EaseType.easeInOutQuad
			));
			//if (pos.Length <= currentPath) {
			//	currentPath = 0;
			//}
		//}
	}

	void Update () {
	}
}
