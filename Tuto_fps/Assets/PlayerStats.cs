using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	[SerializeField] public int nbGrenade = 2;
	[SerializeField] private int HealthBase;
	[SerializeField] int HealthMax = 100;
	float vari = 200f;

	// Use this for initialization



	void ApplyDamage(int damage){
		HealthBase -= damage;
		vari -= 10;
		if (HealthBase <= 0) {
			Dead();
		}
	}

	void Dead(){
		Debug.Log ("Player died");
	}

	void OnGUI(){
		GUI.Box (new Rect (200, Screen.height-20, vari, 25),"");
	}
}
