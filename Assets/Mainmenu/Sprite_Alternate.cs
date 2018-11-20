using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Alternate : MonoBehaviour {

	public Sprite Off;
	public Sprite On;
	public float XStart;
	public int PosY;
	public int boundary = 1;
	public  System.UInt64 bounty = 100; //Reward for killing
	public bool canFire;
	private GM gm;
	// Use this for initialization
	void Start () {
		gm=GameObject.Find("Game Manager").GetComponent<GM>();
	}

	public void Update () {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = gm.onAnim ? Off : On;
		this.gameObject.transform.position = new Vector3(Mathf.Lerp(XStart-boundary,XStart+boundary,gm.pulsetime),PosY,0);
	}
	void FixedUpdate () {
		if (Random.Range (1, 1000)==1 && canFire) {
			GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
			bullet.transform.position = this.transform.position;
			bullet.GetComponent<Bullet> ().speed *= -1.5f;
			bullet.GetComponent<Bullet> ().IsAggro = true;
			bullet.GetComponent<SpriteRenderer> ().color = this.gameObject.GetComponent<SpriteRenderer> ().color;
			Destroy(bullet, 8);
		}
	}
}
