using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject m1;
	public GameObject m2;

	public void Jouer () {
		m1.SetActive(false);
		m2.SetActive(true);
	}

	public void Retour(){
		m2.SetActive (false);
		m1.SetActive (true);
	}
}
