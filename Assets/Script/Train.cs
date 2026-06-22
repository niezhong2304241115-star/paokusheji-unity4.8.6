using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour
{
	public static float speed = 0.2f;
	private int hp = 3;
	
	void Update()
	{
		// 只有最前面的新 Train 才更新全局速度，避免多实例重复加速
		if (transform.position.z > 60f)
			speed += Time.deltaTime * 0.002f;
		
		this.transform.position -= new Vector3(0f, 0f, speed);
		if (transform.position.z < -10)
			Destroy(gameObject);
	}
	
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