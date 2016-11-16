using UnityEngine;
using System.Collections;

public class ExplosionZone : MonoBehaviour {

	[SerializeField] int timer = 6;
	[SerializeField] private AudioClip nadesound;
	[SerializeField] int damage = 50;
	private AudioSource n_AudioSource;

	// Use this for initialization
	void Start () {
		n_AudioSource = GetComponent<AudioSource>();
		n_AudioSource.PlayOneShot (nadesound);
		Invoke ("DestExplo", timer);
	}

	void DestExplo(){
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Ennemi") {
			hit.gameObject.GetComponent<Enemy> ().Health -= damage;
		}
	}
}
