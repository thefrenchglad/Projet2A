using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour {

	[SerializeField] int ammo = 30;
	//[SerializeField] GameObject eject;

	private FireEject fireEject;
	private SwapWeapon swap;
	[SerializeField] private bool showGUI = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		swap = GameObject.Find("FPSController").GetComponent<SwapWeapon> ();
		if(swap.pri == true){
			fireEject = GameObject.Find("Eject").GetComponent<FireEject> ();
		}
		if (swap.pri == false) {
			fireEject = GameObject.Find("Eject2").GetComponent<FireEject> ();
		}

		if (showGUI == true) {
			if (Input.GetKeyDown ("e")) {
				
				fireEject.mag += ammo;
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
			GUI.Box (new Rect (Screen.width/2-100f, Screen.height/2-12.5f, 200, 25), "Press E to pick up \"Ammo\"");
		}
	}
}
