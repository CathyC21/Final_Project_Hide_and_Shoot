using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

	public float moveSpeed;
	
	public float currentHealth;
	public float maxHealth;
	public int lives;

	public Bullet bullet;
	public Enemy2 enemy2;

	public bool isShooting;

	public bool movingLeft;
	public bool movingRight;
	public bool movingUp;
	public bool movingDown;

	public float rotationSpeed;

	public int bulletCounter;
	public bool canShoot = true;

	public float maxBullets2;
	public float bulletPower2;

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
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			Shoot ();
			isShooting = true;
		} else {
			isShooting = false;
		}

		// track how many bullets player has used
		if (bulletCounter >= maxBullets2) {
			canShoot = false;
		}


		// player movement
		// change player movement to addforce
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
			movingUp = true;
		} else {
			movingUp = false;
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += -transform.forward * Time.deltaTime * moveSpeed;
			movingDown = true;
		} else {
			movingDown = false;
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.RotateAround(transform.position, transform.up, -rotationSpeed);
			movingLeft = true;
		} else {
			movingLeft = false;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.RotateAround(transform.position, transform.up, rotationSpeed);
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
			currentHealth -= bulletPower2;
		}
	}
	
	void Shoot(){
		// instantiate new bullet and set it equal to newBullet
		if (canShoot == true) {
			
			// instantiate new bullet and set it equal to newBullet
			Bullet newBullet = (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
			newBullet.direction = transform.forward;
			bulletCounter += 1;
			
		} else {
			
		}
	}
}
