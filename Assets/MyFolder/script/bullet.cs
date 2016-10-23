using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public int speed = 3;

	//弾を消す時間
	public float lifeTime = 5f;
	float time = 0f;

	// Use this for initialization
	void Start () {
		time = 0;
		GetComponent<Rigidbody>().velocity = -transform.forward * speed;
		Destroy (gameObject, lifeTime);
    }

	void Update () {
	}
}
