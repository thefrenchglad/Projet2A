using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, transform.eulerAngles.z);
	}
}
