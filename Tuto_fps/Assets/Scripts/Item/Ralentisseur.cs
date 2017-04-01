using UnityEngine;
using System.Collections;

public class Ralentisseur : MonoBehaviour {
	[SerializeField] private float onZombie = 1;

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Zombie1") {
			Debug.Log (hit.gameObject.name + " enter " + name);
			hit.gameObject.SendMessageUpwards ("ApplySlow", -onZombie);
		}
	}
	void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag == "Zombie1") {
			Debug.Log (hit.gameObject.name + " exit " + name);
			hit.gameObject.SendMessageUpwards ("ApplySlow", onZombie);
		}
	}

}
