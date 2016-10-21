using UnityEngine;
using System.Collections;

public class EnemyBox : MonoBehaviour {

	public GameObject enemy;
	void OnTriggerEnter(Collider col){
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		//衝突したものが敵以外の時は何も行わない
		if(layerName != "Player")return;
		Instantiate (enemy, transform.position, transform.rotation);
	}
}
