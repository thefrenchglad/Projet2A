using UnityEngine;
using System.Collections;

public class StopAggroTurret : MonoBehaviour {

	public bool aggro = true;

	void DestAggro(){
		Destroy (gameObject);
	}
	// Use this for initialization
	void Update () {
		if (gameObject.GetComponentInParent<ZombieHealth>().zombieHealth <= 0) {
			
			aggro = false;
			Invoke ("DestAggro", 0f);
		}
	}
}
