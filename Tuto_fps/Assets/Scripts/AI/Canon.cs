using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {

	private float Dist;
	private float closerD = Mathf.Infinity;

	[SerializeField] public GameObject target;
	[SerializeField] private GameObject closerTar;
	[SerializeField] private GameObject[] tarTab;
	private Vector3 diff;
	private float distCT;

	[SerializeField] public Transform target2;
	[SerializeField] public Transform closeTar2;
	[SerializeField] float lookDistance = 9999;
	[SerializeField] float damping = 6f;
	[SerializeField] public bool okTir = false;

	void start(){
		target = ClosestTar(tarTab);
	}
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("TurretAggro") == true){
			tarTab = GameObject.FindGameObjectsWithTag ("TurretAg");

			target = ClosestTar(tarTab);

			if (target == null) {
				closerD = Mathf.Infinity;
				target = ClosestTar(tarTab);
			}
			target2 = target.transform;
			Dist = Vector3.Distance(target2.position, transform.position);

			if (Dist < lookDistance) {
				LookAt ();
				okTir = true;
			}
			if (Dist > lookDistance) {
				okTir = false;
			}
		}
	}


	void LookAt(){
		Quaternion rotation = Quaternion.LookRotation (target2.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	GameObject ClosestTar(GameObject[] tarTab){
		foreach (GameObject tar in tarTab) {
			diff = tar.transform.position - gameObject.transform.position;
			distCT = diff.sqrMagnitude;
			if (distCT < closerD) {
				closerTar = tar;
				closerD = distCT;
			}
		}

		return closerTar;
	}
	
}