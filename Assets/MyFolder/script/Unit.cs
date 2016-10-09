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
		if (canShot) {
			Instantiate (bullet, origin.position, origin.rotation);
		}
	}

	public void Damage(){
		//色を赤くする
		iTween.ColorFrom (gameObject, iTween.Hash (
			"color", new Color (255, 0, 0),
			"time", 0.2f,
			"delay", 0.01f
		));
	}
}