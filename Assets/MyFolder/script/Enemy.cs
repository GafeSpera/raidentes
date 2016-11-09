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

	public GameObject deathBoss;
	public GameObject bossObj;
	int expCount = 0;
	public GameObject clearText;
	public GameObject message;
	int loadTitle = 300;

	IEnumerator Start () {

		//Unitコンポーネントを取得
		unit = GetComponent<Unit> ();
		//弾の発射
		if (unit.canShot == false) {
			yield break;
		}
		while (true) {
			for (int i = 0; i < childC; i++) {
				Transform shotPosition = transform.GetChild (i);
				unit.Shot (shotPosition, true);
			}
			yield return new WaitForSeconds (unit.shotDelay);
		}
	}

	void OnTriggerEnter (Collider col) {
		//レイヤー名を取得
		string text = LayerMask.LayerToName (gameObject.layer);
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		//レイヤー名がBullet(Player)以外の時は何も行わない
		if(layerName != "Bullet(Player)")return;
		if (boss == false) {
			hp--;
			if (damageTime <= 0) {
				if (hp > 0) {
					unit.Damage ();
					damageTime = 20;
				}
			}
		} else {
			if (transform.childCount == 12) {
				hp--;
				if (damageTime <= 0) {
					if (hp > 0) {
						unit.Damage ();
						damageTime = 20;
					}
				}
			}
		}
		Destroy (col.gameObject);
		if (hp <= 0) {
			if (boss == false && hp==0) {
				unit.Explosion ();
				if (text != "BossParts") {
					Destroy (gameObject);
				}
			} else if (boss == true) {

				clearText.SetActive (true);
				message.SetActive (true);

				unit.canShot = false;
				Rigidbody rigidbody = bossObj.GetComponent<Rigidbody>();
				rigidbody.useGravity = true;
				rigidbody.constraints = RigidbodyConstraints.None;
			}
		}
	}

	void Update(){
		damageTime--;

		string text = LayerMask.LayerToName (gameObject.layer);
		if (hp <= 0) {
			if (text == "BossParts") {
				par.transform.Translate (0, -1, 0);
				par.transform.parent = null;
			} else if (boss) {
				bossObj.transform.Translate (1,0,0);
				if (expCount == 0) {
					float x = Random.value * 200 - 100;
					float y = Random.value * 200 - 100;
					float z = Random.value * 200 - 100;

					Vector3 pos = transform.position;
					pos.x += x;
					pos.y += y;
					pos.z += z;

					Instantiate (unit.explosion, pos, transform.rotation);
					expCount = 5;
				}
				expCount--;
				loadTitle--;
				if (loadTitle <= 0) {
					Application.LoadLevel ("Title");
				}
			}
		}
	}
}
