using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

	public float moveSpeed;

	public float currentHealth;
	public float maxHealth;
	public int lives;

	public Bullet bullet;
	public Enemy enemy;

	public bool isShooting;

	public bool movingLeft;
	public bool movingRight;
	public bool movingUp;
	public bool movingDown;

	private int randomVar;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {

		// lives and death
		if (currentHealth <= 0) {
			lives -= 1;
			currentHealth = maxHealth;
		}

		if (lives == 0) {
			gameObject.SetActive(false);

			// stop spawning enemies

		}

		// shoot
		if (Input.GetKeyDown (KeyCode.R)) {
			Shoot ();
			isShooting = true;
		} else {
			isShooting = false;
		}
		
		// player movement
		// change player movement to addforce
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
			movingUp = true;
		} else {
			movingUp = false;
		}
		
		if (Input.GetKey (KeyCode.S)) {
			transform.position += -transform.forward * Time.deltaTime * moveSpeed;
			movingDown = true;

		} else {
			movingDown = false;
		}
		
		if (Input.GetKey (KeyCode.A)) {
			// change to rotation
			transform.position += -transform.right * Time.deltaTime * moveSpeed;
			movingLeft = true;
		} else {
			movingLeft = false;
		}

		if (Input.GetKey (KeyCode.D)) {
			// change to rotation
			transform.position += transform.right * Time.deltaTime * moveSpeed;
			movingRight = true;
		} else {
			movingRight = false;
		}
		
	}

	void OnCollisionEnter (Collision col){
		
		if (col.collider.tag == "Enemy") {
			currentHealth -= 5;
		}

		if (col.collider.tag == "Bullet") {
			currentHealth -= 5;
		}
	}
	
	void Shoot(){
		// instantiate new bullet and set it equal to newBullet
		Bullet newBullet = (Bullet) Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		//newBullet.direction = transform.forward;

		randomVar = Random.Range (0, 3);
		
		switch (randomVar) {
		case 0:
			newBullet.direction = transform.forward;
			break;
			
		case 1:
			newBullet.direction = -transform.forward;
			break;

		case 2:
			newBullet.direction = transform.right;
			break;

		case 3:
			newBullet.direction = -transform.right;
			break;
		}

	}
}
