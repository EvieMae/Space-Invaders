using UnityEngine;
using System.Collections;



public class MuffleAudio : MonoBehaviour {

	private GM gm;
	void Start () {
		gm=GameObject.Find("Game Manager").GetComponent<GM>();
	}
	void Update() {
			this.GetComponent<AudioSource> ().pitch = gm.speed;

		this.GetComponent<AudioLowPassFilter> ().cutoffFrequency = (Time.timeScale == 0 ? 300 : 5000);
	}
	
}
