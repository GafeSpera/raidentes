using UnityEngine;
using System.Collections;

public class EnemyMoveCtrl : MonoBehaviour {
	Rigidbody mb;
	private float time;

	// Use this for initialization
	void Start () {
		time = 0;
		mb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time <= 2) {
			mb.velocity = new Vector3 (2, 2, 0);
		} else if (time <= 6) {
			//mb.isKinematic = true;
			mb.velocity = new Vector3 (0, 0, 0);
		} else {
			//mb.isKinematic = false;
			mb.velocity = new Vector3 (2, 2, 0);
		}
	}
}
