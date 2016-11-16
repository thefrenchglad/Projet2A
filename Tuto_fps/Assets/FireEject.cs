using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

[RequireComponent(typeof (AudioSource))]

public class FireEject : MonoBehaviour {



	[SerializeField] Rigidbody bulletCasing;
	[SerializeField] int ejectSpeed = 100;
	[SerializeField] float fireRate = 0.5f;

	[SerializeField] private float nextFire = 0f;
	[SerializeField] private bool fullAuto = false;

	private int clip;
	[SerializeField] int maxClip = 30;
	[SerializeField] public int mag = 90;


	[SerializeField] private AudioClip shotsound;
	[SerializeField] private AudioClip[] reloadsound;


	private AudioSource s_AudioSource;
	private AudioSource r_AudioSource;
	private Boolean b_shot;
	private Boolean b_reload;


	void Start(){
		r_AudioSource = GetComponent<AudioSource>();
		s_AudioSource = GetComponent<AudioSource>();
		clip = maxClip;
	}



	// Update is called once per frame
	void Update () {
		
		if (Input.GetButton ("Fire1") & Time.time > nextFire) {
			Fire();
		}

		if ((Input.GetKeyDown ("r")) & (b_shot == false)) {
			Reload ();
		}
	
		if (Input.GetKeyDown ("v")) {
			fullAuto = !fullAuto;
		}

		if (fullAuto == true) {
			fireRate = 0.10f;
		} else {
			fireRate = 0.5f;
		}
	}

	void Fire(){
		if ((clip >= 1) && (b_reload==false)) {
			b_shot = true;
			nextFire = Time.time + fireRate;

			Rigidbody bullet;
			bullet = (Rigidbody)Instantiate (bulletCasing, transform.position, transform.rotation);
			bullet.velocity = transform.TransformDirection (Vector3.left * ejectSpeed);

			clip -= 1;


			PlayShotSound ();
			b_shot = false;
		}
	}

	void Reload(){
		b_reload = true;
		if (mag > 0) {
			if (clip < maxClip) {
				StartCoroutine (PlayReloadSound ());
				if (clip + mag > maxClip) {
					mag -= maxClip - clip;
					clip += maxClip - clip;
				}else{
					clip += mag;
					mag = 0;
				}  

			}
		}

	}

	void OnGUI(){
		GUI.Box (new Rect (10, Screen.height-20, 130, 25),clip+" / "+mag);
	}


	private void PlayShotSound()
	{
		//s_AudioSource.clip = shotsound;
		s_AudioSource.PlayOneShot(shotsound);
	}

	IEnumerator PlayReloadSound()
	{
		r_AudioSource.clip = reloadsound[0];
		r_AudioSource.Play();
		yield return new WaitForSeconds(reloadsound[0].length+0.3f);
		r_AudioSource.clip = reloadsound[1];
		r_AudioSource.Play();

		yield return new WaitForSeconds(reloadsound[1].length+0.3f);
		r_AudioSource.clip = reloadsound[2];
		r_AudioSource.Play();
		yield return new WaitForSeconds(reloadsound[2].length+0.3f);
		b_reload = false;
	}
}