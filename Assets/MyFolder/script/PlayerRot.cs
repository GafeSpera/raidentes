using UnityEngine;
using System.Collections;

public class PlayerRot : MonoBehaviour {

	public float rotSpeed = 2f;
	public GameObject par;
	public bool p2;

	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		//if(Input.GetKey("KeyCode.J")){
		//	transform.Rotate (0, rotSpeed, 0);
		//}
		if (p2 == false) {
			transform.Rotate (-y * rotSpeed, x * rotSpeed, 0);
		} else {
			if(Input.GetKey(KeyCode.J)){
				transform.Rotate (0, -rotSpeed, 0);
			}
			if(Input.GetKey(KeyCode.L)){
				transform.Rotate (0, rotSpeed, 0);
			}
			if(Input.GetKey(KeyCode.I)){
				transform.Rotate (-rotSpeed, 0, 0);
			}
			if(Input.GetKey(KeyCode.K)){
				transform.Rotate (rotSpeed, 0, 0);
			}
		}
		transform.rotation = Quaternion.Slerp(transform.rotation, par.transform.rotation, Time.deltaTime);
	}
}