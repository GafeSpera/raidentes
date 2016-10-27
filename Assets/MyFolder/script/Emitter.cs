﻿using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	public GameObject[] waves;
	//現在のWave
	private int currentWave;

	// Use this for initialization
	IEnumerator Start () {
		if (waves.Length == 0) {
			yield break;
		}

		while (true) {
			GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, transform.rotation);
			wave.transform.parent = transform;

			while (wave.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}

			Destroy (wave);

			if (currentWave < waves.Length-1) {
				currentWave++;
			}
		}
	}
}
