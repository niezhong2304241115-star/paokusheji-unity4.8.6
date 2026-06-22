using UnityEngine;
using System.Collections;

public class BulletPickup : MonoBehaviour
{
	private bool isPicked = false;    // 防止重复触发
	
	void OnTriggerEnter(Collider col)
	{
		if (isPicked) return;         // 已经拾取过了，直接忽略
		
		// 只响应玩家（按名字或 Tag 判断都可以）
		if (col.name == "Player" || col.CompareTag("Player"))
		{
			isPicked = true;          // 立即上锁
			
			MachineGun gun = GameObject.FindObjectOfType<MachineGun>();
			if (gun != null)
				gun.AddBullets(1);    // 直接写死 +1，不用字段
			
			Destroy(this.gameObject);
		}
	}
}