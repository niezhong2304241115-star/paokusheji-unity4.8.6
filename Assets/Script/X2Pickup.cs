using UnityEngine;
using System.Collections;

public class X2Pickup : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		// 碰到玩家就开启双倍火力
		MachineGun gun = GameObject.FindObjectOfType<MachineGun>();
		if (gun != null)
			gun.EnableDoubleFire();
		
		Destroy(this.gameObject);
	}
}