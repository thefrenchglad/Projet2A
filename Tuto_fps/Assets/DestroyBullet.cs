using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	[SerializeField] float timer = 3f;

	void DestBul(){
		Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
		Invoke("DestBul",timer);
	}

}
