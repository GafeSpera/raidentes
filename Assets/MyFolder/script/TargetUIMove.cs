using UnityEngine;
using System.Collections;

public class TargetUIMove : MonoBehaviour {
	public float speed = 200;
	Rigidbody rb;
	void Start(){
		rb = GetComponent<Rigidbody> (); 
	}
	// Update is called once per frame
	void Update () {
		float mx = Input.GetAxis ("Mouse X");
		float my = Input.GetAxis ("Mouse Y");
		//transform.Translate(0,Input.GetAxis("Mouse Y")*2,Input.GetAxis("Mouse X")*2);
		rb.AddForce (transform.right * mx * speed);
		rb.AddForce (transform.up * my * speed);
	}
}