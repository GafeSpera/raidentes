using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public GameObject bullet;
	public float shotDelay;
	public bool canShot;
	public GameObject explosion;

	public void Explosion(){
		Instantiate (explosion, transform.position, transform.rotation);
	}

	public void Shot(Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);
	}
}