using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 10;
	public GameObject bullet;
	public float shotDelay;
	public bool canShot;
	// Use this for initialization
	IEnumerator Start () {
		GetComponent<Rigidbody> ().velocity = transform.right * speed;

		if (canShot == false) {
			yield break;
		}
		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild (i);
				Instantiate (bullet, shotPosition.position, shotPosition.rotation);
			}
			yield return new WaitForSeconds (shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
