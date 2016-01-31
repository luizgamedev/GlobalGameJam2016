using UnityEngine;
using System.Collections;

public class FlowerBehaviour : MonoBehaviour {

	public GameObject particlePrefab;
	public Sprite[] spriteList;

	SpriteRenderer myRenderer;
	BoxCollider2D myCollider;
	AudioSource myAudio;

	// Use this for initialization
	void Start () {
		myRenderer = GetComponentInChildren<SpriteRenderer> ();
		myCollider = GetComponent<BoxCollider2D> ();
		myAudio = GetComponent<AudioSource> ();

		if(spriteList.GetLength(0) > 0){
			
			myRenderer.sprite = spriteList[Random.Range(0, spriteList.GetLength(0) - 1)];

		}

		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		GameEventManager.GamePause += GamePause;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "Player"){
			if (GameManager.Instance) {
				GameManager.Instance.AddFlowerCount ();
			}
			myAudio.Play ();
			myAudio.loop = false;
			GameObject particle = Instantiate (particlePrefab, transform.position, Quaternion.identity) as GameObject;
			GameObject.Destroy (particle, 1f);
			enabled = false;
			myRenderer.enabled = false;
			myCollider.enabled = false;

		}
	}

	void GameStart(){
		myRenderer.enabled = true;
		enabled = true;
		myCollider.enabled = true;
	}

	void GameOver(){
		myRenderer.enabled = false;
		enabled = false;
		myCollider.enabled = false;
	}

	void GamePause(){
		myRenderer.enabled = false;
		enabled = false;
		myCollider.enabled = false;
	}
}
