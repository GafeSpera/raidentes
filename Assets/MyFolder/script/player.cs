﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	Unit unit;
	//移動速度
	public float speed = 40;
	public int hp = 5;
	//ダメージを受けたとき無敵時間を作る
	int damageTime = 60;
	private GameObject chl;

	//Startメソッドをコルーチンとして呼び出す
	IEnumerator Start() {
		//Unitコンポーネントを取得
		unit = GetComponent<Unit> ();
		chl = transform.FindChild ("row_test01").gameObject;
		while (true) {
			//弾をプレイヤーと同じ位置/角度で作成
			unit.Shot(chl.transform);
			//0.05秒待つ
			yield return new WaitForSeconds(unit.shotDelay);
		}
	}

	void Update() {

		damageTime--;

		//移動
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		transform.Translate (0, y * speed, x * speed);

	}

	void OnTriggerEnter(Collider col){
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		//衝突したものが敵以外の時は何も行わない
		if(layerName != "Bullet(Enemy)" && layerName != "Enemy")return;
		//衝突したものが弾だった場合、弾を削除
		if (layerName == "Bullet(Enemy)") {
			Destroy (col.gameObject);
		}
		if(damageTime <= 0){
			unit.Damage();
			hp --;
			if (hp <= 0) {
				unit.Explosion ();
				unit.canShot = false;
				Rigidbody rigidbody = GetComponent<Rigidbody>();
				rigidbody.useGravity = true;
				rigidbody.constraints = RigidbodyConstraints.None;
			}
			damageTime = 60;
		}
	}

	void OnCollisionEnter(Collision col){
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		//衝突したものが敵以外の時は何も行わない
		if(layerName != "Bullet(Enemy)" && layerName != "Enemy")return;
		//衝突したものが弾だった場合、弾を削除
		if (layerName == "Bullet(Enemy)") {
			Destroy (col.gameObject);
		}
		if(damageTime <= 0){
			unit.Damage();
			hp --;
			if (hp <= 0) {
				unit.Explosion ();
				unit.canShot = false;
				Rigidbody rigidbody = GetComponent<Rigidbody>();
				rigidbody.useGravity = true;
				rigidbody.constraints = RigidbodyConstraints.None;
			}
			damageTime = 60;
		}
	}
}
