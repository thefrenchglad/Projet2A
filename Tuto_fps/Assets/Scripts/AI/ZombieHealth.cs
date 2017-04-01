using UnityEngine;
using System.Collections;

public class ZombieHealth : MonoBehaviour {

	[SerializeField] public int zombieHealth = 50;
	[SerializeField] int timer = 1;
	public bool zombieD = false;
	public int points = 5;

	private GameObject joueur;
	
	// Update is called once per frame
	void Update () {
		if (zombieHealth <= 0) {
			zombieD = true;
			GetComponent<Animator> ().Play ("back_fall");
			gameObject.GetComponent<ZombieAI>().enabled=false;
			gameObject.GetComponent<CharacterController>().enabled=false;
			gameObject.GetComponent<CapsuleCollider> ().enabled = false;



			Invoke("Dead",timer);
		}
	}

	void ApplyDamage(int damage){
		zombieHealth -= damage;
		Debug.Log (name+" hp left " + zombieHealth);
}

	void Dead(){
		joueur = GameObject.FindGameObjectWithTag ("Player");
		joueur.SendMessageUpwards ("ApplyScore", points);
		Destroy (gameObject);
	}
}
