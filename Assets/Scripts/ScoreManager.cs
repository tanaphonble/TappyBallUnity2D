using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	private int score;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncrementScore() {
		score++;
	}

	public void StopScore() {
		saveCurrentPlayerScore ();
		if (hasHighScore ()) {
			if (shouldSaveNewHighScore ()) {
				saveNewHighScore ();
			}
		} else {
			saveNewHighScore ();
		}
	}

	private bool hasHighScore() {
		return PlayerPrefs.HasKey ("HighScore");
	}

	private bool shouldSaveNewHighScore () {
		return score > PlayerPrefs.GetInt ("HighScore");
	}

	private void saveNewHighScore() {
		PlayerPrefs.SetInt ("HighScore", score);
	}

	private void saveCurrentPlayerScore() {
		PlayerPrefs.SetInt ("Score", score);
	}

	public string getScoreText() {
		return score.ToString ();
	}
}
