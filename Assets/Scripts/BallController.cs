using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	
	Rigidbody2D rb; 
	public float upForce;
	bool started;
	bool gameOver;
	public float rotation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (Input.GetMouseButtonDown (0)) {
				started = true;
				rb.isKinematic = false;
				GameManager.instance.GameStart ();
			}
		} else if (isGameStart()) {
			transform.Rotate (0, 0, rotation);
			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = Vector2.zero;
				rb.AddForce (new Vector2 (0, upForce));
			}
		}
	}

	private bool isGameStart() {
		return started && !gameOver;
	}

	void OnCollisionEnter2D(Collision2D col) {
		gameOver = true;
		GameManager.instance.GameOver ();
		GetComponent<Animator> ().Play ("ball");
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (crashPipe(col)) {
			gameOver = true;
			GameManager.instance.GameOver ();

			GetComponent<Animator> ().Play ("ball");
		}
		if (shouldIncreaseScore(col)) {
			ScoreManager.instance.IncrementScore ();
		}
	}

	private bool shouldIncreaseScore(Collider2D col) {
		return col.gameObject.tag == "ScoreChecker" && !gameOver;
	}
			
	private bool crashPipe(Collider2D col) {
		return col.gameObject.tag == "Pipe" && !gameOver;
	}
}
