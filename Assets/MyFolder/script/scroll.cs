using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	public float scrollSpeed = 0.05f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//すこしずつ前進
		transform.Translate (-scrollSpeed,0,0);
	}
}
