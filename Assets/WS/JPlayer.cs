using UnityEngine;
using System.Collections;

public class JPlayer : MonoBehaviour {

	public float timeOut = 0.05f;
	float timeElapsed = 0;
	public float speed = 60;
	public float rotSpeed = 3;
	Unit unit;

	IEnumerator Start() {
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

}
