using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	//こんな不要クソスクリプトを追加してごめんなさい

	public int speed = 3;

	//弾を消す時間
	public float lifeTime = 5f;
	float time = 0f;

	// Use this for initialization
	void Start () {
		time = 0;
		GetComponent<Rigidbody>().velocity = -transform.right * speed;
		Destroy (gameObject, lifeTime);
	}

	void Update () {
	}
}
