using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {

	[SerializeField] private Vector3 NormalPos;
	[SerializeField] private Vector3 Aimpos;

	// Use this for initialization
	void Start () {
		transform.localPosition = NormalPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire2")) {
			transform.localPosition = Aimpos;
		} else {
			transform.localPosition = NormalPos;
		}

	}
}
