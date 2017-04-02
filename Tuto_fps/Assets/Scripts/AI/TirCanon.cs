using UnityEngine;
using System.Collections;

public class TirCanon : MonoBehaviour {

	float Dist;
	[SerializeField] float attackRange = 2.2f;
	private int t2;
	[SerializeField] GameObject targetT;
	[SerializeField] Transform target2T;

	[SerializeField] Rigidbody bulletCasing;
	[SerializeField] int ejectSpeed = 1;
	[SerializeField] float fireRate = 0.5f;

	[SerializeField] private float nextFire = 0f;

	[SerializeField] private int clip = 200;

	bool tirOk;

	private AudioSource s_AudioSource;
	[SerializeField] private AudioClip shotsound;
	[SerializeField] bool actif = false;


	private bool showGUI = false;
	private int timer = 20;
	private int stopper;
	private int scoring;
	private GameObject joueur;

	void Start () {
		nextFire = Time.time;
		s_AudioSource = GetComponent<AudioSource>();
		joueur = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void Update () {
		if(GameObject.Find("TurretAggro") == true){
			targetT = GameObject.Find ("corps").GetComponent<Canon> ().target;

			tirOk = GameObject.Find ("corps").GetComponent<Canon> ().okTir;
			if (tirOk == true) {
				if (targetT != null) {
					target2T = targetT.transform;
					Dist = Vector3.Distance (target2T.position, transform.position);
					if ((Dist < attackRange) && (Time.time > nextFire)) {
						Attack ();
					}
				}
			}
			if (tirOk == false) {
				Debug.Log ("Can't shoot");
			}
			scoring = GameObject.Find("PlayerStats").GetComponent<PlayerStats> ().score;

		}

		if (showGUI == true) {
			if (Input.GetKeyDown ("e")) {
				if (scoring >= 250) {
					joueur.SendMessageUpwards("TurretActivation", 250);
					actif = true;
					stopper = (int)Time.time + timer;
				}
			}
		}
		if (actif == true) {
			if ((int)Time.time > stopper) {
				actif = false;
			}
		}
	}
		
		
	void Attack(){
		if(actif == true){
			if (targetT.GetComponent<StopAggroTurret> ().aggro == true) {
				if (clip >= 1) {
					nextFire = Time.time + fireRate;
					Rigidbody bulletTurret;
					bulletTurret = (Rigidbody)Instantiate (bulletCasing, transform.position, transform.rotation);
					bulletTurret.velocity = transform.TransformDirection (Vector3.right * ejectSpeed);
					clip -= 1;
					PlayShotSound ();

					//targetT.SendMessageUpwards ("ApplyDamage", damage);
					//Debug.Log (targetT.name+" hit by "+name+" for "+damage);
					nextFire = Time.time + fireRate;
				}
			}
		}
	}

	private void PlayShotSound()
	{
		s_AudioSource.PlayOneShot(shotsound);
	}


	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag =="Player") {
			if (actif == false) {
				showGUI = true;
			}
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag =="Player") {
			showGUI = false;
		}
	}

	void OnGUI(){
		if (showGUI == true) {
			if (scoring >= 250) {
				GUI.Box (new Rect (Screen.width / 2 - 100f, Screen.height / 2 - 12.5f, 200, 25), "Press E to activate");
			} else {
				GUI.Box (new Rect (Screen.width / 2 - 100f, Screen.height / 2 - 12.5f, 200, 25), "You need 250 points to activate");
			}
		}
	}

}
