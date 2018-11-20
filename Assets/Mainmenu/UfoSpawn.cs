using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoSpawn : MonoBehaviour {

	// Use this for initialization#
	public int boundary = 10;
	private GM gm;
	void createUFO() {
		GameObject uf = Instantiate (Resources.Load ("UFO")) as GameObject;
		Destroy (uf, 9.2f);
		Destroy (this.gameObject);
	}
	void Start () {
		gm=GameObject.Find("Game Manager").GetComponent<GM>();
		Invoke ("createUFO", 4);

	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector3(Mathf.Lerp(0-boundary,0+boundary,gm.pulsetime),5,0);
	}
}
