using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
	public float x = 0f;
	public float y = 0f;
	public float z = 0f;

	//弾を消す時間
	public float lifeTime = 30f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.right * z;
		GetComponent<Rigidbody>().velocity = transform.up * y;
		GetComponent<Rigidbody>().velocity = transform.forward * x;
		Destroy (gameObject, lifeTime);
	}
}
