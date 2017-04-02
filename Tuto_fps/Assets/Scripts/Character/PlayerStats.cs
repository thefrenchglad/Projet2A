using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

	[SerializeField] public int nbGrenade = 5;
	[SerializeField] int PlayerHealth = 100;
	[SerializeField] int HealthMax = 100;
	private GameObject fpsc;
	public int score = 0;

	bool mort = false;

	[SerializeField] GameObject bloodUI;

	void Start(){
		PlayerHealth = HealthMax;
		fpsc = GameObject.Find ("FirstPersonController");
		score = 0;
	}

	void Update(){
		if ((PlayerHealth >= 1) && (PlayerHealth < 10)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.9f;
		}
		if ((PlayerHealth >= 10) && (PlayerHealth < 20)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.8f;
		}
		if ((PlayerHealth >= 20) && (PlayerHealth < 30)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.7f;
		}
		if ((PlayerHealth >= 30) && (PlayerHealth < 40)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.6f;
		}
		if ((PlayerHealth >= 40) && (PlayerHealth < 50)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.5f;
		}
		if ((PlayerHealth >= 50) && (PlayerHealth < 60)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.4f;
		}
		if ((PlayerHealth >= 60) && (PlayerHealth < 70)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.3f;
		}
		if ((PlayerHealth >= 70) && (PlayerHealth < 80)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.2f;
		}
		if ((PlayerHealth >= 80) && (PlayerHealth < 90)) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0.1f;
		}
		if (PlayerHealth >= 90) {
			bloodUI.GetComponent<CanvasGroup>().alpha = 0f;
		}


		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				Screen.lockCursor = false;
			} else {
				Time.timeScale = 1;
				Screen.lockCursor = true;
			}
		}

	}


	void ApplyDamage(int damage){
		Debug.Log ("Player Total hp" + PlayerHealth);
		PlayerHealth -= damage;
		Debug.Log ("Player HP lost" + damage);
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

	void ApplyScore(int points){
		score += points;
	}
	public void TurretActivation(int points){
		score -= points;
	}

	void Dead(){
		Debug.Log ("Player died");
		mort = true;
	}

	void OnGUI(){
		//GUI.Box (new Rect (200, Screen.height-20, vari, 25),"");

		GUI.Box (new Rect (-10+Screen.width/2, Screen.height-40, 100, 25),"Score : "+score);

		if (mort == true) {
			SceneManager.LoadScene(2);
		}
	}
}
