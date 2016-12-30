using UnityEngine;
using System.Collections;

public class HpBox : MonoBehaviour {

	private bool showGUI = false;

	[SerializeField] Transform target;
	[SerializeField] public int healing = 50;

	void Start(){
		FindHealth ();
	}

	void FindHealth(){
		target = GameObject.Find ("PlayerStats").GetComponent<PlayerStats>().transform;
	}

	void Update () {
		if (showGUI == true) {
			if (Input.GetKeyDown ("e")) {
				target.SendMessage ("ApplyHealing", healing);
				Destroy (gameObject);	
			}
		}
	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag =="Player") {
			showGUI = true;

		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag =="Player") {
			showGUI = false;
		}
	}

	void OnGUI(){
		if (showGUI == true) {
			GUI.Box (new Rect (Screen.width/2-100f, Screen.height/2-12.5f, 200, 25), "Press E to pick up \"Health\"");
		}
	}
}