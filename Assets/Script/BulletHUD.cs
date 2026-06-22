using UnityEngine;
using System.Collections;

public class BulletHUD : MonoBehaviour
{
	void Start()
	{
		HUDon();
	}

	void HUDon()
	{
		this.guiText.enabled = true;
	}

	void HUDoff()
	{
		this.guiText.enabled = false;
	}

	void ShowBullets(int bullets)
	{
		HUDon();
		if (bullets > 0)
		{
			this.guiText.material.color = Color.white;
			this.guiText.text = "Bullets: " + bullets.ToString();
		}
		else
		{
			this.guiText.material.color = Color.red;
			this.guiText.text = "Out of Ammo!";
		}
	}
}
