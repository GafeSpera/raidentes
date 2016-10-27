using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	//通ってゆく地点
	public GameObject[] pos;
	private Vector3[] movePath;
	int currentPath = 0;
	//各地点間をいくらかけて移動するか
	public float time = 30f;
	public bool boss = false;
	private GameObject bossAnima;
	private Enemy enemy;


	void Start () {
		if (boss) {
			bossAnima = transform.FindChild ("BossAnima").gameObject;
			enemy = bossAnima.GetComponent<Enemy> ();
		}
		movePath = new Vector3[pos.Length];
		for (int j = 0; j < pos.Length; j++) {
			movePath [j] = pos [j].transform.position;
		}
		if (boss) {
				iTween.MoveTo (gameObject, iTween.Hash (
					"path", movePath ,
					"orienttopath", false,
					"time", time,
					"easetype", iTween.EaseType.easeInOutQuad,
					"loopType", "loop"
				));
		} else {
			iTween.MoveTo (gameObject, iTween.Hash (
				"path", movePath,
				"orienttopath", true,
				"time", time,
				"easetype", iTween.EaseType.easeInOutQuad
			));
		}
	}

	void Update () {
		if (boss) {
			if (enemy.hp <= 0) {
				iTween.Stop (gameObject, "move");
			}
		}
	}
}
