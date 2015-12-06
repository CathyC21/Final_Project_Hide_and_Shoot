using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public GameObject panel;
	public Text text;

	private bool loadingScene;
	private bool sceneLoaded;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitToLoad ());
		loadingScene = false;
		sceneLoaded = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (sceneLoaded && loadingScene) {
			Application.LoadLevel (1);
		}

		if (Input.anyKeyDown) {
			Debug.Log ("anyKeyDown");

			text.text = "Loading...";
			Application.LoadLevel (1);
		}

	}

	// triggered in button onclick events
	public void StartScene(string _sceneName) {

		panel.GetComponent<Image> ().CrossFadeColor (Color.white, 3.0f, false, true); // this isn't working

		text.text = "Loading...";
		loadingScene = true;

	}

	protected IEnumerator WaitToLoad(){

		yield return new WaitForSeconds (3.0f);
		sceneLoaded = true;

	}
}
