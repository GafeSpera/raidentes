using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float timeOut = 0.05f;
	float timeElapsed = 0;
	Unit unit;
	//移動速度
	public float speed = 60;
	public int hp = 5;
	//ダメージを受けたとき無敵時間を作る
	int damageTime = 60;
	public GameObject chl;
	public bool p2 = false;

	//Startメソッドをコルーチンとして呼び出す
	IEnumerator Start() {
		//Unitコンポーネントを取得
		unit = GetComponent<Unit> ();
		//chl = transform.FindChild ("bul").gameObject;
		while (true) {
			//弾をプレイヤーと同じ位置/角度で作成
			unit.Shot(chl.transform);
			//0.05秒待つ
			yield return new WaitForSeconds(unit.shotDelay);
		}
	}

	void Update() {
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= timeOut) {

			damageTime--;
			Rigidbody rb = GetComponent<Rigidbody> ();

			if (p2 == false) {
				//移動
				float x = Input.GetAxis ("Horizontal");
				float y = Input.GetAxis ("Vertical");
				rb.AddForce (transform.up * y * speed);
				rb.AddForce (transform.forward * x * speed);
				//transform.Translate (0, y * speed, x * speed);
			}

			if (p2) {
				//2P操作
				if (Input.GetKey (KeyCode.J)) {
					//transform.Translate (0, 0, -speed);
					rb.AddForce (transform.forward * -speed);
				}
				if (Input.GetKey (KeyCode.L)) {
					//transform.Translate (0, 0, speed);
					rb.AddForce (transform.forward * speed);
				}
				if (Input.GetKey (KeyCode.I)) {
					//transform.Translate (0, speed, 0);
					rb.AddForce (transform.up * speed);
				}
				if (Input.GetKey (KeyCode.K)) {
					//transform.Translate (0, -speed, 0);
					rb.AddForce (transform.up * -speed);
				}
			}
			timeElapsed = 0.0f;
		}

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
		if(layerName != "Bullet(Enemy)" && layerName != "Enemy" && layerName != "Terrain")return;
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
