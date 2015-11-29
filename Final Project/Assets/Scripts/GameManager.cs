using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public Player1 player1;
	public Player2 player2;
	
	public Enemy1 enemy1;
	public Enemy2 enemy2;
	
	public Transform[] spawnPoints;

	private int randomPlace;
	
	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("spawnEnemy", 1.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel(0);
		}
		
	}
	
	void spawnEnemy() {
		//we could randomize between basic enemy and fierce enemy

		//something irrelevant for now, that we can potentially use later
		randomPlace = Random.Range (0, 1);
		switch (randomPlace) {
		case 0:


			break;
		case 1:


			break;
		}
		
		Enemy1 newEnemy = (Enemy1)Instantiate (enemy1, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);
		Enemy2 newEnemy2 = (Enemy2)Instantiate (enemy2, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);

		newEnemy.gameObject.SetActive (true);
		newEnemy2.gameObject.SetActive (true);

	}
}