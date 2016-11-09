using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class ClientExample: MonoBehaviour {

	WebSocket ws;

	public float timeOut = 0.05f;
	float timeElapsed = 0;
	float x;
	float y;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		//ws = new WebSocket("ws://192.168.1.28:12345");
		ws = new WebSocket("ws://localhost:3000");

		ws.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
		};

		ws.OnMessage += (sender, e) =>
		{
			Debug.Log("WebSocket Message Data: " + e.Data);
			if(e.Data == "1w") y += 1f;
			if(e.Data == "1a") x += -1f;
			if(e.Data == "1s") y += -1f;
			if(e.Data == "1d") x += 1f;

			
		};

		ws.OnError += (sender, e) =>
		{
			Debug.Log("WebSocket Error Message: " + e.Message);
		};

		ws.OnClose += (sender, e) =>
		{
			Debug.Log("WebSocket Close");
		};

		ws.Connect();

	}

	void Update()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= timeOut) {
			if (Input.GetKey ("w"))
				ws.Send ("1w");
			if (Input.GetKey ("a"))
				ws.Send ("1a");
			if (Input.GetKey ("s"))
				ws.Send ("1s");
			if (Input.GetKey ("d"))
				ws.Send ("1d");
			//transform.Translate (x, y, 0);
			rb.AddForce (transform.right * x * 200);
			rb.AddForce (transform.up * y * 200);

			x = 0;
			y = 0;
		}
	}

	void OnDestroy()
	{
		ws.Close();
		ws = null;
	}
}