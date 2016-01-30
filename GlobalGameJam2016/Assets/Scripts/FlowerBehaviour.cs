using UnityEngine;
using System.Collections;

public class FlowerBehaviour : MonoBehaviour {

	public GameObject particlePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "Player"){
			GameManager.Instance.AddFlowerCount ();
			GameObject particle = Instantiate (particlePrefab, transform.position, Quaternion.identity) as GameObject;
			GameObject.Destroy (gameObject, 0.1f);
			GameObject.Destroy (particle, 1f);
		}
	}
}
