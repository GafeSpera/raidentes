using UnityEngine;
using System.Collections;

public class JPlayer : MonoBehaviour {

	public float timeOut = 0.05f;
	float timeElapsed = 0;
	public float speed = 60;
	public float rotSpeed = 3;
	Unit unit;
	Rigidbody rb;

	ClientExample cl;
	GameObject ws;

	IEnumerator Start() {
		ws = GameObject.Find("ws");
		cl = ws.GetComponent<ClientExample> ();
		rb = GetComponent<Rigidbody> ();
		//Unitコンポーネントを取得
		unit = GetComponent<Unit> ();
		//chl = transform.FindChild ("bul").gameObject;
		while (true) {
			//弾をプレイヤーと同じ位置/角度で作成
			unit.Shot(transform,false);
			//0.05秒待つ
			yield return new WaitForSeconds(unit.shotDelay);
		}
	}

	void Update(){
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= timeOut) {

			rb.AddForce (transform.right * cl.x1 * 200);
			rb.AddForce (transform.up * cl.y1 * 200);
		}
	}

}
