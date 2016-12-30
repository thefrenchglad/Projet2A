using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	[SerializeField] int onZombie = 10;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Zombie1") {
			Debug.Log (col.gameObject.name +" hit by " + name + " for " + onZombie);
			col.gameObject.SendMessageUpwards ("ApplyDamage", onZombie);
		}
	}
}
