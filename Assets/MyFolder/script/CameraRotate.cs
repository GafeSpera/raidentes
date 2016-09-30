using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

    public float rotSpeed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //移動方向に体の向きを変える
        transform.Rotate(0, x * rotSpeed, -y * rotSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime);
    }
}
