using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
	public float x = 0f;
	public float y = 0f;
	public float z = 0f;

	public float lifeTime = 30f;

	void Start(){
		Destroy (gameObject, lifeTime);
	}
	// Use this for initialization
	void Update(){
		transform.Translate (x,y,z);
	}
}