using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopWater : MonoBehaviour {

	[SerializeField] private GameObject joueur;
	private float move;
	private bool dam = false;

	void Start () {
		joueur = GameObject.FindGameObjectWithTag ("Player");
	}

	void update(){
		while(dam == true){
			joueur.SendMessageUpwards ("ApplyDamage", 5);
		}
	}

	void OnTriggerExit(Collider hit){
		if(hit.gameObject.tag == "Player") {
			dam = true;
		}
	}
	void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == "Player") {
			dam = false;
		}
	}
}
	
