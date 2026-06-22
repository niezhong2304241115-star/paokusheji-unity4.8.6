using UnityEngine;
using System.Collections;

public class ShoeHUD : MonoBehaviour {
	int timer;
	// Use this for initialization
	void Start () {
		HUDoff ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void HUDon ()
	{
		this.guiTexture.enabled = true;
		this.guiText.enabled = true;
	}

	void HUDoff()
	{
		this.guiTexture.enabled = false;
		this.guiText.enabled = false;
	}

	void Show(int timer)
	{
		this.guiText.text = "\t\t\t\t" + timer.ToString ();
	}
}
