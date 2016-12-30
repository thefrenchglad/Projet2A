using UnityEngine;
using System.Collections;

public class TurretStats : MonoBehaviour {

	[SerializeField] private int turretHealth = 50;
	[SerializeField] int timer = 2;
	public bool turretD = false;

	// Update is called once per frame
	void Update () {
		if (turretHealth <= 0) {
			turretD = true;
			gameObject.GetComponentInChildren<Canon> ().enabled = false;
			Invoke("Dead",timer);
		}
	}

	void ApplyDamage(int damage){
		turretHealth -= damage;
		Debug.Log (name+" hp left " + turretHealth);
	}

	void Dead(){
		Destroy (gameObject);
	}
}