using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Unit unit;
	public float speed = 10;
	public int hp = 4;
	//ダメージを受けたとき無敵時間を作る
	int damageTime = 10;

	IEnumerator Start () {

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
		if (damageTime <= 0) {
			unit.Damage ();
			damageTime = 10;
		}
		Destroy (col.gameObject);
		hp--;
		if (hp <= 0) {
			//unit.Explosion();
			Destroy (gameObject);
		}
	}

	void Update(){
		damageTime--;
	}
}
