using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	[SerializeField] public int nbGrenade = 5;
	[SerializeField] int PlayerHealth = 100;
	[SerializeField] int HealthMax = 100;
	float vari = 200f;

	[SerializeField] GameObject bloodUI;

	void Start(){
		PlayerHealth = HealthMax;
	}

	void Update(){
		if ((PlayerHealth >= 1) && (PlayerHealth < 30)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 1;
		}
		if ((PlayerHealth >= 30) && (PlayerHealth < 60)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.6f;
		}
		if ((PlayerHealth >= 60) && (PlayerHealth < 90)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.3f;
		}
		if (PlayerHealth >= 80) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0f;
		}
	}


	void ApplyDamage(int damage){
		Debug.Log ("Player Total hp" + PlayerHealth);
		PlayerHealth -= damage;
		Debug.Log ("Player HP lost" + damage);
		vari -= 10;
		Debug.Log ("Player HP left" + PlayerHealth);
		if (PlayerHealth <= 0) {
			Dead();
		}
	}

	void ApplyHealing(int heal){
		PlayerHealth += heal;

		if (PlayerHealth > HealthMax) {
			PlayerHealth = HealthMax;
		}
	}

	void Dead(){
		Debug.Log ("Player died");
	}

	void OnGUI(){
		GUI.Box (new Rect (200, Screen.height-20, vari, 25),"");

		GUI.Box (new Rect (500, Screen.height-20, 100, 25)," / ");
	}
}
