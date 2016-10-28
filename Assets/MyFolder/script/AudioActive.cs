using UnityEngine;
using System.Collections;

public class AudioActive : MonoBehaviour {

	public int count = 1000;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		count--;
		if (count <= 0) {
			audioSource.enabled = true;
		}
	}
}
