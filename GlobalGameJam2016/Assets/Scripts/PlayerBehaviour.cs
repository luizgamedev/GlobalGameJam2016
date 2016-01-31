using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	Vector3 startposition;
	Rigidbody2D myRigidBody;
	SpriteRenderer myRenderer;
	AudioSource myAudio;


	// Use this for initialization
	void Start () {
		myRenderer = GetComponentInChildren<SpriteRenderer> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		GameEventManager.GamePause += GamePause;
		startposition = transform.localPosition;
		myRenderer.enabled = false;
		myRigidBody.isKinematic = true;
		enabled = false;
		myAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GameStart(){
		transform.localPosition = startposition;
		myRenderer.enabled = true;
		myRigidBody.isKinematic = false;
		enabled = true;
	}

	void GameOver(){
		myRenderer.enabled = false;
		myRigidBody.isKinematic = true;
		enabled = false;
	}

	void GamePause(){
		myRenderer.enabled = false;
		myRigidBody.isKinematic = true;
		enabled = false;
	}

	public void Die(GameManager.DeathType deathType){
		if (myAudio) {
			myAudio.Play ();
		}
		GameManager.Instance.SetGameOverScreen (deathType);
		GameEventManager.TriggerGameOver();
		GameManager.Instance.PrepareRestart ();
	}

}
