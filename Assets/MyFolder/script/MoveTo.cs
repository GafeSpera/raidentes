using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

	//通ってゆく地点
	public GameObject pos;
	private Vector3 movePath;
	public float time = 30f;
	private CameraMove cameraMove;

	void Start () {
		movePath = pos.transform.position;
		cameraMove = GetComponent<CameraMove> ();

			iTween.MoveTo (gameObject, iTween.Hash (
				"position", movePath ,
				"orienttopath", false,
				"time", time
			));
	}

	void Update () {
		if (transform.position == movePath) {
			cameraMove.enabled = true;
		}
	}
}