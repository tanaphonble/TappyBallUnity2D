using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public static UIManager instance;

	public GameObject gameOverPanel;
	public GameObject startUI;
	public GameObject gameOverText;
	public Text scoreText;
	public Text highScoreText;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
		updateCurrentScoreText ();
	}

	public void GameStart() {
		startUI.SetActive (false);
	}
		
	private void updateCurrentScoreText() {
		scoreText.text = ScoreManager.instance.getScoreText ();
	}

	public void GameOver () {
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt ("HighScore");
		gameOverPanel.SetActive (true);
		gameOverText.SetActive (true);
	}

	public void Replay () {
		SceneManager.LoadScene ("level1");
	}

	public void Menu () { 
		SceneManager.LoadScene ("Menu");
	}

}
