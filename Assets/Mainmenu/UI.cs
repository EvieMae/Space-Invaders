using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI: MonoBehaviour {

	public string Prefix;
	public string Suffix;
	public bool hiscore;
	public bool PAUSED;
	private GM gm;

	// Use this for initialization
	void Start() {
		gm = GameObject.Find("Game Manager").GetComponent < GM > ();
	}

	// Update is called once per frame
	//			
	void Update() {
		if (PAUSED) this.GetComponent < Text > ().text = Time.timeScale == 0 ? (gm.GameState == GM.state.start ? "Move To Start": "PAUSED"

		) : gm.GameState == GM.state.playerdied ? "You Died": "";

		else this.GetComponent < Text > ().text = Prefix + gm.Score + Suffix;
	}
}