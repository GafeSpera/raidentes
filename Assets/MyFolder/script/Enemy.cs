using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Unit unit;
	public float speed = 10;
	public int hp = 4;

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

	void OnTriggerEnter (Collider col) {
		//レイヤー名を取得
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		//レイヤー名がBullet(Player)以外の時は何も行わない
		if(layerName != "Bullet(Player)")return;
		iTween.ColorFrom (gameObject, iTween.Hash (
			"color", new Color (255, 0, 0),
			"time", 0.5f,
			"delay", 0.01f
		));
		hp--;
		if (hp <= 0) {
			//unit.Explosion();
			Destroy (gameObject);
		}
	}
}
