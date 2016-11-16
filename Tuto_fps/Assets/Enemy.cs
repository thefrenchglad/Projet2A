using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[SerializeField] public int Health = 100;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Bullet") {
			Health -= 10;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Destroy (gameObject);
		}
	}
}
