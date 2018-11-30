using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class ListWrapper {
	public GameObject Class;
	public List < MenuManager.mainmenubutton > Menus; // Work around for having nested lists
}
public static class Optionsloaded {

	private static bool musicON = true;
	public static bool isMusicOn {
		get {
			return musicON;
		}
		set {
			musicON = value;
		}
	}
	private static bool sfxON = true;
	public static bool isSFXOn {
		get {
			return sfxON;
		}
		set {
			sfxON = value;
		}
	}
}
public class MenuManager: MonoBehaviour {

	// Use this for initialization
	public int ButtonSelected;
	public int MenuOpen;
	private bool debounce = true;
	public GameObject selector;
	[System.Serializable]
	public struct mainmenubutton {
		public GameObject UID;
		public string eventName;
		public int offset;
	}

	[System.Serializable]
	public struct menus {
		//		List<mainmenubutton> buttons;
	}

	private List < mainmenubutton > buttons;

	public List < ListWrapper > Menus;
	void Start() {
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
	}

	void openMenu(int offset) {
		MenuOpen = offset;
		ButtonSelected = 0;
	}

	// Update is called once per frame
	void Update() {

		buttons = Menus[MenuOpen].Menus;

		if (Input.GetButtonDown("Fire1") == true) {

			string ev = buttons[ButtonSelected].eventName.ToLower(); //Event
			if (ev == "play") SceneManager.LoadScene(0);
			if (ev == "openmenu") {
				openMenu(buttons[ButtonSelected].offset);
			}
			if (ev == "setfps") {
				Application.targetFrameRate = Application.targetFrameRate == 60 ? 120 : 60;
				Debug.Log("FPS SET TO" + Application.targetFrameRate.ToString());
				buttons[ButtonSelected].UID.GetComponent < Text > ().text = "Framerate: " + Application.targetFrameRate.ToString();
			}
			if (ev == "setmusic") {
				Optionsloaded.isMusicOn = !Optionsloaded.isMusicOn;
				buttons[ButtonSelected].UID.GetComponent < Text > ().text = "Music: " + (Optionsloaded.isMusicOn ? "On": "Off");

			}
			if (ev == "setsfx") {
				Optionsloaded.isSFXOn = !Optionsloaded.isSFXOn;
				buttons[ButtonSelected].UID.GetComponent < Text > ().text = "SFX: " + (Optionsloaded.isSFXOn ? "On": "Off");
			}
			if (ev == "quitgame") {
				Application.Quit();
			}
		}

		if (Input.GetAxis("Vertical") == 0) debounce = true;
		if (Input.GetAxis("Vertical") != 0 && debounce) {
			debounce = false; // Prevent Menu from detecting contious down
			ButtonSelected += (Input.GetAxis("Vertical") > 0) ? 1 : -1; //determine if down or up and add it to menu
		}

		if (ButtonSelected >= buttons.Count) ButtonSelected = 0;
		if (ButtonSelected < 0) ButtonSelected = buttons.Count - 1;

		int i = 0;
		foreach(mainmenubutton ui in Menus[MenuOpen].Menus) {

			ui.UID.GetComponent < Text > ().color = (i != ButtonSelected) ? new Color(1, 1, 1) : new Color(0.4f, 0.4f, 1);
			i++;
		}

		Menus[MenuOpen].Class.SetActive(true); // Sets Active menu visible
		foreach(ListWrapper ui in Menus) {
			ui.Class.SetActive(false); // Makes all invisible
		}
		Menus[MenuOpen].Class.SetActive(true); // Makes active visible work around	

		selector.GetComponent < RectTransform > ().anchoredPosition = new Vector2(3, buttons[ButtonSelected].UID.GetComponent < RectTransform > ().anchoredPosition.y);
	}

}