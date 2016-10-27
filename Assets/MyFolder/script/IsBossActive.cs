using UnityEngine;
using System.Collections;

public class IsBossActive : MonoBehaviour {
	public GameObject boss;

	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		if(layerName != "Player")return;
		boss.SetActive (true);

	}
}
