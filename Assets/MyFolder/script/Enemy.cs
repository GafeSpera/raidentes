using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Unit unit;
	public float speed = 10;
	//public GameObject bullet;
	//public float shotDelay;
	//public bool canShot;

	IEnumerator Start () {
		//移動
		GetComponent<Rigidbody> ().velocity = transform.right * speed;

		//Unitコンポーネントを取得
		unit = GetComponent<Unit> ();
		//弾の発射
		if (unit.canShot == false) {
			yield break;
		}
		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild (i);
				unit.Shot (shotPosition);
			}
			yield return new WaitForSeconds (unit.shotDelay);
		}
	}

	void Update () {
	}
}
