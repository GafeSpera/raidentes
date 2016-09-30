using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

	void OnTriggerExit(Collider col){
		Destroy (col.gameObject);
	}
}
