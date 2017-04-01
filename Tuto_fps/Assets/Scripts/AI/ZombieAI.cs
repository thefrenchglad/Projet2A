using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	float Dist;
	[SerializeField] GameObject targetZ;
	[SerializeField] float lookDistance = 20;
	[SerializeField] float chaseRange = 10;
	[SerializeField] float attackRange = 2.2f;
	[SerializeField] float attackDamage = 10f;
	[SerializeField] float moveSpeed = 3;
	[SerializeField] int damping = 6;
	[SerializeField] float attackRepeatTime = 1;

	[SerializeField] public int damage = 10;

	private float attackTime;

	[SerializeField] CharacterController controller;


	private Vector3 moveDirection = Vector3.zero;

	private GameObject[] zturretTab;
	[SerializeField] private GameObject tarPlayer;
	private GameObject closerTar;
	private float closerD = Mathf.Infinity;
	private Vector3 diff;
	private float distCT;

	// Use this for initialization
	void Start () {
		attackTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		zturretTab = GameObject.FindGameObjectsWithTag ("turret");
		tarPlayer = GameObject.FindGameObjectWithTag ("Player");

		targetZ = ClosestTar(zturretTab,tarPlayer);
		if (targetZ == null) {
			closerD = Mathf.Infinity;
			targetZ = ClosestTar(zturretTab,tarPlayer);
		}
		Dist = Vector3.Distance(targetZ.transform.position, transform.position);

		if (Dist < lookDistance) {
			LookAt ();
		}
		if (Dist < attackRange) {
			Attack ();
		} else if (Dist < chaseRange) {
			Chase ();
		}
	}

	void LookAt(){
		Quaternion rotation = Quaternion.LookRotation (targetZ.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void Attack(){
		if (Time.time > attackTime) {
			GetComponent<Animator> ().Play ("attack");

			targetZ.SendMessageUpwards ("ApplyDamage", attackDamage);
			Debug.Log (name+" has attacked "+targetZ.name);
			attackTime = Time.time + attackRepeatTime;
		}
	}

	void Chase(){
		GetComponent<Animator> ().Play ("walk");

		/*moveDirection = transform.forward;
		moveDirection *= moveSpeed;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);*/
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.destination = targetZ.transform.position; 
	}

	void ApplySlow(float slow){
		moveSpeed+= slow;
		Debug.Log (name + " slowed");
	}

	GameObject ClosestTar(GameObject[] zturretTab, GameObject tarPlayer){
		foreach (GameObject tar in zturretTab) {
			diff = tar.transform.position - gameObject.transform.position;
			distCT = diff.sqrMagnitude;
			if (distCT < closerD) {
				closerTar = tar;
				closerD = distCT;
			}
		}
		diff = tarPlayer.transform.position - gameObject.transform.position;
		distCT = diff.sqrMagnitude;
		if (distCT < closerD) {
			closerTar = tarPlayer;
			closerD = distCT;
		}
		return closerTar;
	}
}
