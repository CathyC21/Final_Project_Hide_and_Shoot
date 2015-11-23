using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public Player1 player1;
	public Player2 player2;
	
	public Enemy enemy1;
	public Enemy2 enemy2;
	
	public Transform[] spawnPoints;
	
	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("spawnEnemy", 1.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void spawnEnemy() {
		//we could randomize between basic enemy and fierce enemy
		
		Enemy newEnemy = (Enemy)Instantiate (enemy1, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);

		Enemy2 newEnemy2 = (Enemy2)Instantiate (enemy2, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);

		newEnemy.gameObject.SetActive (true);
		newEnemy2.gameObject.SetActive (true);

	}
}