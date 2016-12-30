using UnityEngine;
using System.Collections;

public class NadeExplosion : MonoBehaviour {

	[SerializeField] int timer = 1;
	[SerializeField] GameObject ExplosionZone;

	// Use this for initialization
	void Start () {
		Invoke ("Appear", timer);
	}
	
	void Appear(){
		Instantiate (ExplosionZone, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
