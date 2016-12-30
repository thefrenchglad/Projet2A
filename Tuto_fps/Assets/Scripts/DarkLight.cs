using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Light))]

public class DarkLight : MonoBehaviour {

	public Vector3 newcol;
	public float mult = 10;
	
	// Update is called once per frame
	void Update () {
		var light = GetComponent<Light> ();
		light.color = new Color (newcol.x,newcol.y,newcol.z) * mult;
	}
}
