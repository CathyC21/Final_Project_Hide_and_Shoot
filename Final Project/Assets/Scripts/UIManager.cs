using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Slider player1health;
	public Slider player2health;

	public Image fill1;
	public Image fill2;

	public Gradient healthColors;

	public Player1 player1;
	public Player2 player2;

	public Image[] p1lives;
	public Image[] p2lives;

	public Image[] p1bullets;
	public Image[] p2bullets;


	// Use this for initialization
	void Start () {
	
		player1health.value = 100.0f;
		player2health.value = 100.0f;

	}
	
	// Update is called once per frame
	void Update () {
	
		// if player loses health, change the value of the sliding handle
		player1health.value = player1.currentHealth;
		player2health.value = player2.currentHealth;

		// if the player loses health, change the color of the slider fill
		fill1.color = healthColors.Evaluate (player1.currentHealth / player1.maxHealth);
		fill2.color = healthColors.Evaluate (player2.currentHealth / player2.maxHealth);

		// if player1 dies, lose one of the heart images
		if (player1.lives == 3) {
			// don't do anything

		} else if (player1.lives == 2) {
			p1lives[0].enabled = false;
		} else if (player1.lives == 1) {
			p1lives[1].enabled = false;
		} else if (player1.lives == 0) {
			p1lives[2].enabled = false;
			player1.currentHealth = 0;
			fill1.color = Color.gray;

		}

		// if player2 dies, lose one of the heart images
		if (player2.lives == 3) {
			// don't do anything
			
		} else if (player2.lives == 2) {
			p2lives[0].enabled = false;
		} else if (player2.lives == 1) {
			p2lives[1].enabled = false;
		} else if (player2.lives == 0) {
			p2lives[2].enabled = false;
			player2.currentHealth = 0;
			fill2.color = Color.gray;
			
		}

		// if player1 uses bullet, remove from UI
		if (player1.bulletCounter == 1) {
			p1bullets[0].enabled = false;

		} else if (player1.bulletCounter == 2) {
			p1bullets[1].enabled = false;

		} else if (player1.bulletCounter == 3) {
			p1bullets[2].enabled = false;

		} else if (player1.bulletCounter == 4) {
			p1bullets[3].enabled = false;
		}

		// if player2 uses bullet, remove from UI
		if (player2.bulletCounter == 1) {
			p2bullets[0].enabled = false;
			
		} else if (player2.bulletCounter == 2) {
			p2bullets[1].enabled = false;
			
		} else if (player2.bulletCounter == 3) {
			p2bullets[2].enabled = false;
			
		} else if (player2.bulletCounter == 4) {
			p2bullets[3].enabled = false;
		}

	}

	void OnTrigerEnter(Collider myTrigger) {
		// if a player collects a life, restore 20 health

	}
}
