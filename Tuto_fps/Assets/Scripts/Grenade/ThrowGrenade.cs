using UnityEngine;
using System.Collections;

public class ThrowGrenade : MonoBehaviour {

	int nbg;
	[SerializeField] Rigidbody grenadeCasing;
	[SerializeField] int ejectSpeed = 15;

	// Use this for initialization
	void Start () {
		nbg = GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ().nbGrenade;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("g")){
			if (nbg >= 1) {
				Rigidbody grenade;
				grenade = (Rigidbody)Instantiate (grenadeCasing, transform.position, transform.rotation);
				grenade.velocity = transform.TransformDirection (Vector3.forward * ejectSpeed);
				nbg -= 1;
			}
		}
	}
}