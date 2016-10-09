using UnityEngine;
using System.Collections;

public class PlayerRot : MonoBehaviour {

	public float rotSpeed = 2f;
	public GameObject par;

	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		transform.Rotate (0, x * rotSpeed, - y * rotSpeed);
		transform.rotation = Quaternion.Slerp(transform.rotation, par.transform.rotation, Time.deltaTime);
	}
}
