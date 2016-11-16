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
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Primary.SetActive(true);
			Secondary.SetActive(false);
			pri = true;
		}
		if(Input.GetKey(KeyCode.Alpha2)){
			Primary.SetActive(false);
			Secondary.SetActive(true);
			pri = false;
		}
	}
}
