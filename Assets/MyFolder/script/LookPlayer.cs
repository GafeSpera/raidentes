using UnityEngine;
using System.Collections;

public class LookPlayer : MonoBehaviour {
	private GameObject player;
	private Vector3 target;

	void Start(){
		player = GameObject.Find("Scroll/Player1");
	}
	void Update () {
		Vector3 sa = transform.position - player.transform.position;
		target = transform.position;
		Vector3 pos = target;
		pos += sa;
		target = pos;
		transform.LookAt (target);
	}
}