using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Unit unit;
	public float speed = 10;
	public int hp = 4;
	//ダメージを受けたとき無敵時間を作る
	int damageTime = 20;
	public bool boss = false;
	public int childC = 9;
	public GameObject par;

	public float shotStart;
	public float shotEnd;
	public int count = 0;

	IEnumerator Start () {

		//Unitコンポーネントを取得
		unit = GetComponent<Unit> ();
		//弾の発射
		if (unit.canShot == false) {
			yield break;
		}
		if (shotStart <= count && count <= shotEnd) {
			while (true) {
				for (int i = 0; i < childC; i++) {
					Transform shotPosition = transform.GetChild (i);
					unit.Shot (shotPosition, true);
				}
				yield return new WaitForSeconds (unit.shotDelay);
			}
		}
	}

	void OnTriggerEnter (Collider col) {
		//レイヤー名を取得
		string text = LayerMask.LayerToName (gameObject.layer);
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		//レイヤー名がBullet(Player)以外の時は何も行わない
		if(layerName != "Bullet(Player)")return;
		hp--;
		if (boss == false) {
			if (damageTime <= 0) {
				unit.Damage ();
				damageTime = 20;
			}
		}
		Destroy (col.gameObject);
		if (hp == 0) {
			unit.Explosion ();
			if (boss == false && text != "BossParts") {
				Destroy (gameObject);
			}
		}
	}

	void Update(){
		count++;
		damageTime--;

		string text = LayerMask.LayerToName (gameObject.layer);
		if (hp <= 0) {
			if (text == "BossParts") {
				par.transform.Translate (0, -1, 0);
				par.transform.parent = null;
			}
		}
	}
}
