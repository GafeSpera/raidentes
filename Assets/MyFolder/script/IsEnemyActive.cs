using UnityEngine;
using System.Collections;

public class IsEnemyActive : MonoBehaviour {

	public GameObject obj;
	private Enemy enemy;
	// Use this for initialization
	void Start () {
		enemy = obj.GetComponent<Enemy> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		if(layerName != "Player")return;
		enemy.enabled = true;
	}
}
