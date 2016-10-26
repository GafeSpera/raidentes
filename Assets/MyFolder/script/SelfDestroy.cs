using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {
	public float lifeTime = 5f;
	void Start () {
		Destroy (gameObject, lifeTime);
	}
}