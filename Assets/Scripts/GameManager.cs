using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
//	bool gameOver;

	void Awake() {
		DontDestroyOnLoad (this.gameObject);
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart() {
		UIManager.instance.GameStart ();
		GameObject.Find ("PipeSpawner").GetComponent <PipeSpawner> ().StartSpawningPipes ();
	}

	public void GameOver() {
//		gameOver = false;
		GameObject.Find ("PipeSpawner").GetComponent <PipeSpawner> ().StopSpawningPipes ();
		ScoreManager.instance.StopScore (); 
		UIManager.instance.GameOver();
	}
}
