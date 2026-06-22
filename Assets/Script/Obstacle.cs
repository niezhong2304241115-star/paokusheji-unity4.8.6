using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
	private int hp = 2;

	public void TakeDamage()
	{
		hp--;
		if (hp <= 0)
		{
			GameObject.Find("Player").SendMessage("AddDestroyScore");
			Destroy(gameObject);
		}
	}
}
