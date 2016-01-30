using UnityEngine;
using System.Collections;

public class FlowerBehaviour : MonoBehaviour {

	public GameObject particlePrefab;
	public Sprite[] spriteList;

	SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
		myRenderer = GetComponentInChildren<SpriteRenderer> ();

		if(spriteList.GetLength(0) > 0){
			
			myRenderer.sprite = spriteList[Random.Range(0, spriteList.GetLength(0) - 1)];

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "Player"){
			if (GameManager.Instance) {
				GameManager.Instance.AddFlowerCount ();
			}
			GameObject particle = Instantiate (particlePrefab, transform.position, Quaternion.identity) as GameObject;
			GameObject.Destroy (gameObject, 0.1f);
			GameObject.Destroy (particle, 1f);
		}
	}
}
