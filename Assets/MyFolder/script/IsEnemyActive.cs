using UnityEngine;
using System.Collections;

public class IsEnemyActive : MonoBehaviour {

	public GameObject obj;
	private Enemy enemy;
	private Collider col;
	// Use this for initialization
	void Start () {
		enemy = obj.GetComponent<Enemy> ();
		col = obj.GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		if(layerName != "Player")return;
		enemy.enabled = true;
		obj.GetComponent<BoxCollider> ().enabled = true;
		col.enabled = true;
	}
}
