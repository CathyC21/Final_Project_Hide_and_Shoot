using UnityEngine;
using System.Collections;

public class UpdatedEnemy1 : MonoBehaviour {
	
	public float rotationSpeed; // should be the same as the player rotation speed;
	public float moveSpeed; // how quickly enemies will move, should be identical to the player's moveSpeed
	public float laziness; // how likely an emeny is to notmove from 0 to 1
	public float fidelity; // how likely an enemy is to move in the same direction as the player from 0 to 1
	public float jitters; //  how likey an enemy is move on there own from 0 to 1 (unimplemented)
	private int forward = 0;
	private int turn  = 0;

	public Bullet bullet;
	public Player1 player1;

	
	// Use this for initialization
	
	void Start () {

	}
	
	// Update is called once per frame
	
	void Update () {

		if (player1.isShooting && player1.canShoot) {
			Shoot ();
		} else  {
			
		}

		if (Input.GetKeyDown(KeyCode.W)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					forward = 1;
					
				}
				
				else {
					
					forward = -1;
					
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.W)) {
			
			forward = 0;
			
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					forward = -1;
					
				}
				
				else {
					
					forward = 1;
					
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.D)) {
			
			forward = 0;
			
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					turn = 1;
					
				}
				
				else {
					
					turn = -1;	
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.D)) {
			
			turn = 0;
			
		}
		
		if (Input.GetKeyUp (KeyCode.D)) {
			
			forward = 0;
			
		}

		if (Input.GetKeyDown(KeyCode.A)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					turn = -1;
					
				}
				
				else {
					
					turn = 1;
					
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.A)) {
			
			turn = 0;
			
		}
	
		transform.position += transform.forward * Time.deltaTime * moveSpeed * forward;
		transform.RotateAround(transform.position, transform.up, rotationSpeed*turn);
		
	}

	void Shoot(){
		// instantiate new bullet and set it equal to newBullet
		Bullet newBullet = (Bullet) Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet.direction = transform.forward;
		
	}
	
	void OnCollisionEnter (Collision col){
		
		if (col.collider.tag == "Bullet") {
			gameObject.SetActive (false);
		}
	}
	
}
