using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		GameObject.Find("Player").SendMessage("PickingMagnet");
		Destroy(this.gameObject);
	}
}