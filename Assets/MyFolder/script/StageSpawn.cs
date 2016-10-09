using UnityEngine;
using System.Collections;

public class StageSpawn : MonoBehaviour {

	public GameObject stage;
	// Use this for initialization
	void Start () {
		Vector3 pos = transform.position;
		Instantiate (stage, pos, transform.rotation);
		pos.x -= 500;
		Instantiate (stage, pos , transform.rotation);
		pos.x -= 500;
		Instantiate (stage, pos, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
