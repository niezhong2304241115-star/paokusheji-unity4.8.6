using UnityEngine;
using System.Collections;

public class CoinsHUD : MonoBehaviour
{
	public int num;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
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

	void setNum (int num)
	{
		this.num = num;
		Show ();
	}

	void Show ()
	{
		HUDon ();
		this.guiText.text = "\t\t\t\t" + num.ToString ();
	}
}
