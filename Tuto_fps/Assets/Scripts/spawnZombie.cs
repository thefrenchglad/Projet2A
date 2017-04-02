using UnityEngine;
using System.Collections;

public class spawnZombie : MonoBehaviour {

	[SerializeField] int debut = 5;
	[SerializeField] int timer = 5;
	[SerializeField] GameObject spawnType;
	[SerializeField] bool actif = true;
	[SerializeField] float ran = 0f;
	private Vector3 pos;

	// Use this for initialization
	void Update () {
		if (actif == true) {
			if ((int)Time.time % timer == 0) {
				Invoke ("spawn", debut);
				timer += 2;
			}
		}
	}

	void spawn(){
		ran = Random.Range (-20, 20); 
		pos = transform.position;
		pos.x += ran;
		ran = Random.Range (-20, 20); 
		pos.z += ran;
		Instantiate (spawnType,pos, transform.rotation);
	}
}

	