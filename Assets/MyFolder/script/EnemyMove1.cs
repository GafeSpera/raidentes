using UnityEngine;
using System.Collections;

public class EnemyMove1 : MonoBehaviour {
	//単純に下降する動き

	public bool kakou = false;
	public int count;

	public float speed = 10;
	// Use this for initialization
	void Start () {
		//まっすぐ前方に
		if (kakou) {
			GetComponent<Rigidbody> ().velocity = -transform.up * speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (kakou) {
			count--;
			if (count <= 0) {
				GetComponent<Rigidbody> ().velocity = -transform.up * 0;
			}
		}
	}
}