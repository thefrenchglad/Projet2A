using UnityEngine;
using System;

public class SwapWeapon : MonoBehaviour {

	[SerializeField] GameObject Primary = null;
	[SerializeField] GameObject Secondary = null;
	[SerializeField] public bool pri = true;

	// Use this for initialization
	void Start () {
		Primary.SetActive (true);
		Secondary.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Alpha1)) && (pri == false)){
			activePri();
		}
		if((Input.GetKey(KeyCode.Alpha2)) && (pri == true)){
			activeSec();
		}
	}

	void activePri(){
		GameObject.Find("Eject2").GetComponent<FireEject> ().b_reload = false;
		GameObject.Find ("Eject2").GetComponent<AudioSource> ().clip = null;
		Primary.SetActive(true);
		Secondary.SetActive(false);
		pri = true;
	}
	void activeSec(){
		GameObject.Find("Eject").GetComponent<FireEject> ().b_reload = false;
		GameObject.Find ("Eject").GetComponent<AudioSource> ().clip = null;
		Secondary.SetActive(true);
		Primary.SetActive(false);
		pri = false;
	}
}
