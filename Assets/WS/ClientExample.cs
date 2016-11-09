using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class ClientExample: MonoBehaviour {

	WebSocket ws;

	public float timeOut = 0.05f;
	float timeElapsed = 0;
	public float x1,y1,x2,y2;

	void Start()
	{
		ws = new WebSocket("ws://192.168.1.28:12345");
		//ws = new WebSocket("ws://localhost:3000");

		ws.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
		};

		ws.OnMessage += (sender, e) =>
		{
			Debug.Log("WebSocket Message Data: " + e.Data);
			if(e.Data == "1w") y1 = 1f;
			if(e.Data == "1a") x1 = -1f;
			if(e.Data == "1s") y1 = -1f;
			if(e.Data == "1d") x1 = 1f;
			if(e.Data == "1stop"){ x1 = 0; y1 = 0;}

			if(e.Data == "2w") y2 = 1f;
			if(e.Data == "2a") x2 = -1f;
			if(e.Data == "2s") y2 = -1f;
			if(e.Data == "2d") x2 = 1f;
			if(e.Data == "2stop"){ x2 = 0; y2 = 0;}


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
			if (Input.GetKeyUp ("w") || Input.GetKeyUp ("a") || Input.GetKeyUp ("s") || Input.GetKeyUp ("d")) {
				ws.Send ("1stop");
			}

			//x1 = 0;
			//y1 = 0;
		}
	}

	void OnDestroy()
	{
		ws.Close();
		ws = null;
	}
}