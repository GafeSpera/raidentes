using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class ClientExample: MonoBehaviour {

	WebSocket ws;

	void Start()
	{
		ws = new WebSocket("ws://localhost:3000/");

		ws.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
		};

		ws.OnMessage += (sender, e) =>
		{
			Debug.Log("WebSocket Message Data: " + e.Data);
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
		if (Input.GetKeyDown("w"))
		{
			ws.Send("w");
		}
		if (Input.GetKeyDown("a"))
		{
			ws.Send("a");
		}
		if (Input.GetKeyDown("s"))
		{
			ws.Send("s");
		}
		if (Input.GetKeyDown("d"))
		{
			ws.Send("d");
		}
	}

	void OnDestroy()
	{
		ws.Close();
		ws = null;
	}
}