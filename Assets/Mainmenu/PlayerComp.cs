using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComp: MonoBehaviour {

	// Use this for initialization
	public float speed;
	private GM gm;
	void Start() {
		gm = GameObject.Find("Game Manager").GetComponent < GM > ();
	}

	// Update is called once per frame
	void Update() {
		Debug.Log (Input.GetAxis ("Hori2"));
		if ( Input.GetAxis("Hori") != 0 || Input.GetAxisRaw("Hori2") != 0 ) {
			if (gm.GameState == GM.state.start) {	
				gm.GameState = GM.state.playing;
				gm.gameStateChangedToPlay();
				Time.timeScale = 1;
			}
		}

		if (gm.GameState != GM.state.playing) return;
		if (Input.GetAxis("Hori") != 0 ) {
			Debug.Log(Input.GetAxisRaw("Hori"));
			this.gameObject.transform.position = new Vector3(

				Mathf.Clamp(this.gameObject.transform.position.x + (speed * Input.GetAxis("Hori") * ((Time.timeScale != 0) ? Time.unscaledDeltaTime: 0)), -10.5f, 10.5f), -5.5f, 0);

		}

		 if (Input.GetAxis("Hori2") != 0) {
			Debug.Log(Input.GetAxisRaw("Hori2"));
			this.gameObject.transform.position = new Vector3(

				Mathf.Clamp(this.gameObject.transform.position.x + (speed * Input.GetAxis("Hori2") * ((Time.timeScale != 0) ? Time.unscaledDeltaTime: 0)), -10.5f, 10.5f), -5.5f, 0);

		}
		if (Input.GetButtonDown("Fire1")) {
			Debug.Log("Draw Bullet");
			GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
			bullet.transform.position = this.transform.position;
			Destroy(bullet, 8);
			if (Optionsloaded.isSFXOn) this.gameObject.GetComponent < AudioSource > ().Play();
		}
		if (Input.GetButtonDown("Pause")) {
			Time.timeScale = (Time.timeScale == 0 ? gm.speed: 0);
		}
	}
}