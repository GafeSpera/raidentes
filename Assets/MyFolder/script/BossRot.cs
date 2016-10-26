using UnityEngine;
using System.Collections;

public class BossRot : MonoBehaviour {
	public GameObject player;
	void Start(){
		player = GameObject.Find("Scroll/Player1");
		//Invoke ("LookPl",15);
	}
	void Update () {
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 0.2f);
		transform.LookAt (player.transform.position);
	}
	void LookPl(){
		transform.LookAt (player.transform.position);
	}
}
