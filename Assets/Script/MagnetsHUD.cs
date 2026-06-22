using UnityEngine;
using System.Collections;

public class MagnetsHUD : MonoBehaviour
{
	int timer;
	// Use this for initialization
	void Start ()
	{
		HUDoff ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void HUDon ()
	{
		this.guiTexture.enabled = true;
		this.guiText.enabled = true;
		GameObject.Find ("TextHint").SendMessage ("HUDon");
	}
	
	void HUDoff ()
	{
		this.guiTexture.enabled = false;
		this.guiText.enabled = false;
		GameObject.Find ("TextHint").SendMessage ("HUDoff");
	}

	void Show (int timer)
	{
		this.guiText.text = "\t\t\t\t" + timer.ToString ();
	}
}
