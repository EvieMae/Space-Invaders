using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	public float speed = 5.2f;
	private GM gm;
	public bool IsAggro;
	void Start () {
		gm=GameObject.Find("Game Manager").GetComponent<GM>();
	
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.CompareTag ("Enemy") && !IsAggro) {
			Destroy (col.gameObject);
			GameObject sfx = Instantiate(Resources.Load("DestroySFX")) as GameObject;
			float alpha = 1.0f;
			var colorGrad = new ParticleSystem.MinMaxGradient();
			sfx.GetComponent<ParticleSystem>().startColor =  col.gameObject.GetComponent<SpriteRenderer> ().color;
			sfx.transform.position = col.gameObject.transform.position;
			if (Optionsloaded.isSFXOn)
			gm.GetComponent<AudioSource> ().Play ();
			gm.Score += col.gameObject.GetComponent<Sprite_Alternate> ().bounty;
			Destroy (this.gameObject);
			Destroy (sfx,1.0f);
			
		}
		if (col.gameObject.CompareTag ("Finish")) {
			Destroy (col.gameObject);
			Debug.Log ("Hit");
			Destroy (this.gameObject);


		}
	}
	// Update is called once per frame
	void Update () {


		this.gameObject.transform.position += new Vector3 (0, speed * Time.unscaledDeltaTime, 0);
	}
}
