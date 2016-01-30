using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class StoryEndManager : MonoBehaviour {

	public int minimumFlowersForAHappyEnding;
	public SpriteRenderer goddessSpriteRenderer;

	//////////////////////////////////////////////
	public AudioClip goodEndingSong;
	public AudioClip badEndingSong;
	//////////////////////////////////////////////
	/// 
	GameObject musicSource;

	void Start () {
		minimumFlowersForAHappyEnding = 10;
		int flowerCount = 11;

//		if (GameManager.Instance) {
//			flowerCount = GameManager.Instance.GetFlowerCount ();
//		} else {
//			Debug.Log ("StoryEndManager -- No Manager!");
//			return;
//		}

		musicSource = GameObject.FindGameObjectWithTag("Music");
		AudioSource audioSource = musicSource.GetComponent<AudioSource> ();
		if (audioSource.isPlaying) {
			audioSource.Stop ();
		}
		if ( flowerCount < minimumFlowersForAHappyEnding) {
			//Bad Ending!!!
			//goddessSpriteRenderer.color = Color.black;
			if (musicSource) {


				audioSource.clip = badEndingSong;
				audioSource.Play ();			
			}
		} else {
			//Happy Ending!!!
			//goddessSpriteRenderer.color = Color.cyan;
			if (musicSource) {


				audioSource.clip = goodEndingSong;
				audioSource.Play ();			
			}
		}

		//TODO: do a proper fading here!

		//////////////////////////////////////////////////////////////////////////////////////////
		//Change the main song


		//////////////////////////////////////////////////////////////////////////////////////////

		Camera.main.GetComponent<Animator> ().SetTrigger ("StartCinematic");

	}
}
