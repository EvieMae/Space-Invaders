using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComp : MonoBehaviour {

	// Use this for initialization
	public float speed;
	private GM gm;
	void Start () {
		gm=GameObject.Find("Game Manager").GetComponent<GM>();
	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.GetAxisRaw ("Hori") == 1f || Input.GetAxisRaw ("Hori") == -1f) {

		if (Input.GetAxis ("Hori") != 0) {
			Debug.Log(Input.GetAxisRaw("Hori"));
			this.gameObject.transform.position = new Vector3(


				Mathf.Clamp(this.gameObject.transform.position.x + 
					(speed * Input.GetAxis ("Hori") * Time.unscaledDeltaTime),-10.5f,10.5f),-5.5f,0);

		}
	

		if (Input.GetButtonDown("Fire1")) {
			Debug.Log ("Draw Bullet");
			GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
			bullet.transform.position = this.transform.position;
			Destroy(bullet, 8);
			if (Optionsloaded.isSFXOn)
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}
		if (Input.GetButtonDown("Pause")) {
			Time.timeScale = (Time.timeScale == 0 ? gm.speed : 0);
		}
	}
}
