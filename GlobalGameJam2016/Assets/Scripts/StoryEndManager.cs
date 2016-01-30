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
		int flowerCount = 8;

		if (GameManager.Instance) {
			flowerCount = GameManager.Instance.GetFlowerCount ();
		} else {
			Debug.Log ("StoryEndManager -- No Manager!");
			return;
		}

		if ( flowerCount < minimumFlowersForAHappyEnding) {
			//Bad Ending!!!
			goddessSpriteRenderer.color = Color.black;
		} else {
			//Happy Ending!!!
			goddessSpriteRenderer.color = Color.cyan;
		}

		//TODO: do a proper fading here!

		//////////////////////////////////////////////////////////////////////////////////////////
		//Change the main song
		musicSource = GameObject.FindGameObjectWithTag("Music");
		if (musicSource) {
			AudioSource audioSource = musicSource.GetComponent<AudioSource> ();
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}

			audioSource.clip = goodEndingSong;
			audioSource.Play ();			
		}
		//////////////////////////////////////////////////////////////////////////////////////////

		Camera.main.GetComponent<Animator> ().SetTrigger ("StartCinematic");

	}
}
