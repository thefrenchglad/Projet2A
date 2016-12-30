using UnityEngine;
using System.Collections;

public class ExplosionZone : MonoBehaviour {

	[SerializeField] int timer = 6;
	[SerializeField] private AudioClip nadesound;
	[SerializeField] int onZombie = 40;
	[SerializeField] int onPlayer = 20;
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
		
		if (hit.gameObject.tag == "Zombie1") {
			Debug.Log (hit.name + " hit by " + name+" for "+onZombie);
			hit.gameObject.SendMessage ("ApplyDamage", onZombie);
		}
		if (hit.gameObject.tag == "Player") {
			Debug.Log (hit.name + " hit by " + name+" for "+onPlayer);
			hit.gameObject.SendMessage ("ApplyDamage", onPlayer);
		}
		/*if (hit.gameObject.tag == "Ennemi") {
			hit.gameObject.GetComponent<Enemy> ().Health -= enemyDamage;
		}*/
	}
}
