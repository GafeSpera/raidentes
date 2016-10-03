using UnityEngine;
using System.Collections;

public class EnemyMove1 : MonoBehaviour {

	public float speed = 10;
	// Use this for initialization
	void Start () {
		//まっすぐ前方に
		GetComponent<Rigidbody> ().velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}