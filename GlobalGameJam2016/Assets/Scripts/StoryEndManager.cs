using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class StoryEndManager : MonoBehaviour {

	public int minimumFlowersForAHappyEnding;
	public GameObject goodEndingPrefab;
	public GameObject baddEndingPrefab;

	//////////////////////////////////////////////
	public AudioClip goodEndingSong;
	public AudioClip badEndingSong;
	//////////////////////////////////////////////
	/// 
	GameObject musicSource;

	void Start () {
		minimumFlowersForAHappyEnding = 8;
		int flowerCount = 0;

		if (GameManager.Instance) {
			flowerCount = GameManager.Instance.GetFlowerCount ();
		} else {
			Debug.Log ("StoryEndManager -- No Manager!");
			return;
		}

		musicSource = GameObject.FindGameObjectWithTag("Music");
		AudioSource audioSource = musicSource.GetComponent<AudioSource> ();
		if (audioSource.isPlaying) {
			audioSource.Stop ();
		}
		if ( flowerCount < minimumFlowersForAHappyEnding) {
			//Bad Ending!!!
			GameObject.Instantiate(baddEndingPrefab);
			if (musicSource) {
				audioSource.clip = badEndingSong;
				audioSource.Play ();
				audioSource.loop = false;
			}
		} else {
			//Happy Ending!!!
			GameObject.Instantiate(goodEndingPrefab);
			if (musicSource) {
				audioSource.clip = goodEndingSong;
				audioSource.Play ();			
				audioSource.loop = false;
			}
		}

		//TODO: do a proper fading here!

		//////////////////////////////////////////////////////////////////////////////////////////
		//Change the main song


		//////////////////////////////////////////////////////////////////////////////////////////

		Camera.main.GetComponent<Animator> ().SetTrigger ("StartCinematic");

	}
}
