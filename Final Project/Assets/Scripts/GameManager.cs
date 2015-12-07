using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public Player1 player1;
	public Player2 player2;

	public UpdatedEnemy1 enemy1;
	public UpdatedEnemy2 enemy2;

	public GameObject ammunition;

	public Transform[] spawnPoints;

	private int randomPlace;

	public int totalEnemies;
	public int totalAmmo;

//	private static GameManager instanceRef;

	// to carry information from scene to scene, but to avoid more than 1 gameObject of this.
//	void Awake() {
//
//		if (instanceRef == null) {
//			instanceRef = this;
//			DontDestroyOnLoad (gameObject);
//		} else {
//			DestroyImmediate(gameObject);
//		}
//
//	}

	// Use this for initialization
	void Start () {

		// need to initialize all the variables here to avoid null reference error

		
		InvokeRepeating ("spawnEnemy", 1.0f, 7.0f);
		InvokeRepeating("spawnAmmo", 1.0f, 10.0f);

		// move players to random position
		player1.transform.position = new Vector3 (Random.Range (-7, 7), 1.39f, Random.Range (-7, 7));
		player2.transform.position = new Vector3 (Random.Range (-7, 7), 1.39f, Random.Range (-7, 7));
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel(0);
		}

		if (player1.isDead || player2.isDead) {
			Application.LoadLevel (2);
		} else {

		}

		// cap the number of enemies and ammo
		if (totalAmmo >= 10) {
			CancelInvoke ("spawnAmmo");
			Debug.Log ("spawnAmmo cancelled");
			totalAmmo = 0;

		} else {

		}
	
		if (totalEnemies >= 10) {
			CancelInvoke ("spawnAmmo");
			Debug.Log ("spawnEnemy cancelled");
			totalEnemies = 0;

		} else {

		}
		
	}

	void spawnAmmo() {

		Instantiate(ammunition);
		ammunition.transform.position = new Vector3 (Random.Range (-7, 7), 1.39f, Random.Range (-7, 7));
		ammunition.gameObject.SetActive(true);
		totalAmmo += 1;
	}

	void spawnEnemy() {

		UpdatedEnemy1 newEnemy = (UpdatedEnemy1)Instantiate (enemy1, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);
		UpdatedEnemy2 newEnemy2 = (UpdatedEnemy2)Instantiate (enemy2, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);

		newEnemy.transform.position = new Vector3 (Random.Range (-7, 7), 1.39f, Random.Range (-7, 7));
		newEnemy2.transform.position = new Vector3 (Random.Range (-7, 7), 1.39f, Random.Range (-7, 7));

		newEnemy.gameObject.SetActive (true);
		newEnemy2.gameObject.SetActive (true);

		totalEnemies += 2;

	}
	
}