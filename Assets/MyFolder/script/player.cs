using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	Unit unit;
	//移動速度
	public float speed = 10;
	//向きを変える速度
	public float rotSpeed = 1.5f;
	int hp = 5;
	//ダメージを受けたとき無敵時間を作る
	int damageTime = 10;
	bool live = true;

	//Startメソッドをコルーチンとして呼び出す
	IEnumerator Start() {
		//Unitコンポーネントを取得
		unit = GetComponent<Unit> ();
		while (true) {
			//弾をプレイヤーと同じ位置/角度で作成
			unit.Shot(transform);
			//0.05秒待つ
			yield return new WaitForSeconds(unit.shotDelay);
		}
	}

	void Update() {

		damageTime--;
		//移動
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if (unit.canShot) {
			rigidbody.AddForce (0, y * speed, x * speed);
			//移動方向に体の向きを変える
			transform.Rotate (0, x * rotSpeed, -y * rotSpeed);
			//体の向きを戻す
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.identity, Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider col){
		//hp --;
		//unit.Explosion ();
		if (hp == 0) {
			//Destroy (gameObject);
		}
	}
	void OnCollisionEnter(Collision col){
		if(damageTime <= 0){
			//衝突したものが弾だった場合、弾を削除
			string layerName = LayerMask.LayerToName (col.gameObject.layer);
			if (layerName == "Bullet(Enemy)") {
				Destroy (col.gameObject);
			}
			unit.Damage();
				
			//hp --;
			//unit.Explosion ();
			if (hp <= 0) {
				unit.canShot = false;
				Rigidbody rigidbody = GetComponent<Rigidbody>();
				rigidbody.useGravity = true;
				rigidbody.constraints = RigidbodyConstraints.None;
				//Destroy (gameObject);
			}
			damageTime = 10;
		}
	}
}
