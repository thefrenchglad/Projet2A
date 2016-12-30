using UnityEngine;
using System.Collections;

public class spawnZombie : MonoBehaviour {

	[SerializeField] float debut = 5f;
	[SerializeField] float timer = 5f;
	[SerializeField] GameObject spawnType;
	[SerializeField] bool actif = true;
	[SerializeField] float ran = 0f;
	private Vector3 pos;

	// Use this for initialization
	void Update () {
		if (actif == true) {
			if (Time.time % timer == 0) {
				InvokeRepeating ("spawn", debut, timer);
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