using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	private bool statue = true;
	//public Text time;
	public int t = 0;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("countDown");
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
	
	void HUDoff ()
	{
		this.guiTexture.enabled = false;
		this.guiText.enabled = false;
	}

	IEnumerator countDown ()
	{
		while (statue) {
			this.guiText.text = t.ToString ();
			yield return new WaitForSeconds (1.0f);
			t++;
		}
	}

	void StopMove ()
	{
		statue = false;
	}
}
