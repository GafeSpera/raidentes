using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	//移動速度
	public float speed = 10;
	//向きを変える速度
	public float rotSpeed = 1.5f;

	public GameObject bullet;

	//Startメソッドをコルーチンとして呼び出す
	IEnumerator Start() {
		while (true) {
			//弾をプレイヤーと同じ位置/角度で作成
			Instantiate(bullet, transform.position, transform.rotation);
			//0.05秒待つ
			yield return new WaitForSeconds(0.1f);
		}
	}

	void Update() {
		//移動
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		rigidbody.AddForce(0, y * speed, x * speed);

		//移動方向に体の向きを変える
		transform.Rotate(0, x * rotSpeed, -y * rotSpeed);
		//体の向きを戻す
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime);


	}
}
