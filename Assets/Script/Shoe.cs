using UnityEngine;
using System.Collections;

public class Shoe : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		GameObject.Find("Player").SendMessage("PickingShoe");
		Destroy(this.gameObject);
	}
}