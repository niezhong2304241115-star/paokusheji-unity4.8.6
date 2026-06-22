using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour
{
	public static float speed = 0.1f;
	public static float acceleration = 0.001f;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		// 只有最前面的新 Plane（z 最大）才更新全局速度，避免多实例重复加速
		if (transform.position.z > 60f)
			speed += Time.deltaTime * acceleration;
		
		this.transform.position -= new Vector3 (0f, 0f, speed);
		float z = transform.position.z;
		if (z < -20)
			CleanAll ();
	}
	
	void CleanAll ()
	{
		GameObject.Find ("Factory").SendMessage ("Create");
		Destroy (this.gameObject);
	}
	
	void StopMove ()
	{
		acceleration = 0f;
		speed = 0f;
	}
	
	void Move()
	{
		acceleration = 0.001f;
		speed = 0.1f;
	}
}