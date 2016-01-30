using UnityEngine;
using System.Collections;

public class PlatformIgnore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (9,10, true);
		Physics2D.IgnoreLayerCollision (10,9, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
