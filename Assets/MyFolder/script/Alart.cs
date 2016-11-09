using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Alart : MonoBehaviour {
	private AudioSource plAudioSource;
	public GameObject se;
	private GameObject panel;
	private GameObject ui;
	float alfa=0;
	bool alart = false;
	int count=0;
	bool alfaPlus = true;
	float red,green,blue;

	void Start(){
		panel = GameObject.Find("Canvas/Panel");
		ui = GameObject.Find("Canvas/Alart");
	}
		
	void OnTriggerEnter(Collider col){
		string layerName = LayerMask.LayerToName (col.gameObject.layer);
		if (layerName != "Player") return;
		plAudioSource = col.GetComponent<AudioSource> ();
		alart = true;
		Instantiate (se, transform.position, transform.rotation);
	}
	void Update(){
		panel.GetComponent<Image> ().color = new Color (255, 0, 0, alfa);
		ui.GetComponent<Image> ().color = new Color (0, 0, 0, alfa * 2);
		if (alart) {
			plAudioSource.volume -= 0.005f;
			if (alfaPlus) {
				alfa += 0.03f;
			} else {
				alfa -= 0.03f;
			}
			if (alfa <= 0 && count < 5) {
				alfaPlus = true;
				count++;
			} else if (alfa >= 0.5f) {
				alfaPlus = false;
				count++;
			}
		}
	}
}
