using UnityEngine;
using System.Collections;

public class SecondTarget : MonoBehaviour {
	public GameObject pl;
	public GameObject tar;

	Vector3 plPos;
	Vector3 taPos;
	Vector3 pos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		plPos = pl.transform.position;
		taPos = tar.transform.position;
		pos = plPos / 2 + taPos / 2;
		transform.position = pos;
	}
}
