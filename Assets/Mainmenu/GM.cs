using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	// Use this for initialization
	public bool onAnim;
	public float animSpeed;
	public GameObject Music;

	[System.Serializable]
	public struct invader
	{
		public string UID;
		public Sprite off;
		public Sprite on;
		public bool CanFireBack;
		public Color color;
		public System.UInt64 bounty;
	}
	public float pulsetime;
	[System.Serializable]
	public struct Settings
	{
		[TooltipAttribute("The first spawn time encounter")]
		public int UFOSpawnTime;
		[TooltipAttribute("Respawn in seconds after first encounter")]
		public int UFORespawnTime;
		[TooltipAttribute("Amount of seconds it takes for the invaders to move 1 row toward the player")]
		public int MarchSpeed;
	}
	public Settings Config;
	private GameObject UFO;
	public List<invader> invadertypes ;
	public System.UInt64 HighScore;
	public System.UInt64 Score;
	public float speed;
	private bool CanMarch=true;
	void SpawnUFO() {
		GameObject uf = Instantiate (Resources.Load ("UfoSpawn")) as GameObject;

		}

	const float pi = 3.141f;
	void syncAnim () {
		onAnim = !onAnim;

	}

	IEnumerator  SpawnRows() {
		CanMarch = false;
		for (int x = 3; x >= 0; x--) {
			for (int i = -9; i < 10; i++) {
				GameObject ai = Instantiate (Resources.Load ("enemy")) as GameObject;
				ai.GetComponent<Sprite_Alternate> ().XStart = i;
				ai.GetComponent<Sprite_Alternate> ().PosY = x + 1;
				ai.GetComponent<Sprite_Alternate> ().Off = invadertypes [x].off;
				ai.GetComponent<Sprite_Alternate> ().On = invadertypes [x].on;
				ai.GetComponent<Sprite_Alternate> ().bounty = invadertypes [x].bounty;
				ai.GetComponent<SpriteRenderer> ().color = invadertypes [x].color + new Color (0, 0, 0, 255);
				ai.GetComponent<Sprite_Alternate> ().canFire = invadertypes [x].CanFireBack;
				ai.transform.position = new Vector3 (Mathf.Lerp (i - 1, i + 1, pulsetime), x + 1, 0);
				yield return new WaitForSeconds (0.01f);

			}
		}
		CanMarch = true;
	}
	void Start () {
		animSpeed = 0.5f;
		InvokeRepeating ("syncAnim", animSpeed,animSpeed);
		InvokeRepeating ("SpawnUFO", Config.UFOSpawnTime,Config.UFORespawnTime);
		InvokeRepeating ("MarchTowardPlayer", Config.MarchSpeed,Config.MarchSpeed);
		Debug.Log("GM loaded");
		StartCoroutine(SpawnRows());
		Score = 0;
		speed = 1f;
		if (Optionsloaded.isMusicOn)
			Music.GetComponent<AudioSource> ().Play ();

	}
	
	// Update is called once per frame
	void Update () {
		pulsetime=0.5f*(1+Mathf.Sin(2 * 1f //Frequency in Hz
			* pi  * Time.time/4));
		
	}
	void MarchTowardPlayer() {
		if (CanMarch)
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag ("Enemy")) {
			enemy.GetComponent<Sprite_Alternate> ().PosY -= 1;
			//CHECK IF CLOSE TO PLAYER THAN CAUSE GAME END
			};
			
	}
	void FixedUpdate() { 
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= 0) {
			StartCoroutine (SpawnRows ());
			speed += 0.1f;
			Time.timeScale = speed;
		}
	}

}
