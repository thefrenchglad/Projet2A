using UnityEngine;
using System.Collections;

public class ZombieHealth : MonoBehaviour {

	[SerializeField] public int zombieHealth = 50;
	[SerializeField] int timer = 5;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Bullet") {
			zombieHealth -= 10;
			Debug.Log ("Zombie damaged");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (zombieHealth <= 0) {
			GetComponent<Animator> ().Play ("back_fall");
			gameObject.GetComponent<ZombieAI>().enabled=false;
			gameObject.GetComponent<CharacterController>().enabled=false;
			gameObject.GetComponent<CapsuleCollider>().enabled=false;
			Invoke("Dead",timer);
		}
	}

	void Dead(){
		Destroy (gameObject);
	}
}
