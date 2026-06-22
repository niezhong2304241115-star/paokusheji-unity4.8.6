using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	public float rotationSpeed = 100.0f;
	private Inventory playerInventory;
	
	void Start()
	{
		GameObject player = GameObject.Find("Player");
		if (player != null)
			playerInventory = player.GetComponent<Inventory>();
	}
	
	void Update()
	{
		transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
		
		if (playerInventory != null && playerInventory.magnetTime > 0f && this.transform.position.z <= 15f)
			PickCoins();
	}
	
	void OnTriggerEnter(Collider col)
	{
		PickCoins();
	}
	
	void PickCoins()
	{
		GameObject player = GameObject.Find("Player");
		if (player != null)
			player.SendMessage("PickingCoin");
		Destroy(this.gameObject);
	}
}