using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	float Dist;
	[SerializeField] Transform target;
	[SerializeField] float lookDistance = 20;
	[SerializeField] float chaseRange = 10;
	[SerializeField] float attackRange = 2.2f;
	[SerializeField] float moveSpeed = 3;
	[SerializeField] int damping = 6;
	[SerializeField] float attackRepeatTime = 1;

	[SerializeField] public int damage = 10;

	private float attackTime;

	[SerializeField] CharacterController controller;
	[SerializeField] float gravity = 20;

	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		attackTime = Time.time;
		FindHealth ();
	}

	// Update is called once per frame
	void Update () {
		Dist = Vector3.Distance(target.position, transform.position);

		if (Dist < lookDistance) {
			LookAt ();
		}
		if (Dist < attackRange) {
			Attack ();
		} else if (Dist < chaseRange) {
			Chase ();
		}
	}

	void FindHealth(){
		target = GameObject.Find ("PlayerStats").GetComponent<PlayerStats>().transform;
	}

	void LookAt(){
		Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void Attack(){
		if (Time.time > attackTime) {
			GetComponent<Animator> ().Play ("attack");

			target.SendMessage ("ApplyDamage", 10);
			Debug.Log ("The enemy has attacked");
			attackTime = Time.time + attackRepeatTime;
		}
	}

	void Chase(){
		GetComponent<Animator> ().Play ("walk");

		moveDirection = transform.forward;
		moveDirection *= moveSpeed;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}


}
