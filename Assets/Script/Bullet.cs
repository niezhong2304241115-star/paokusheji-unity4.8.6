using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	// 移动由 MachineGun 的 Rigidbody.velocity 驱动，此处不再自己 Translate
	// 销毁也由 MachineGun 的 Destroy(bullet, 2f) 负责
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Obstacle") || other.CompareTag("Train") || other.CompareTag("Wall"))
		{
			other.SendMessage("TakeDamage");
			Destroy(gameObject);
		}
	}
}