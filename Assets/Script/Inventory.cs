using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
	private int coinNum = 0;
	private float shoeTime = 0f;
	public float magnetTime = 0f;
	private int destroyScore = 6;
	
	private bool isGameOver = false;
	private bool isShoeRunning = false;
	private bool isMagnetRunning = false;
	
	private Timer timerComp;
	
	void Start()
	{
		GameObject timerObj = GameObject.Find("Timer");
		if (timerObj != null)
			timerComp = timerObj.GetComponent<Timer>();
	}
	
	void Update()
	{
		if (isGameOver) return;
		
		// 调试按键
		if (Input.GetKeyDown(KeyCode.Z))
			StartCoroutine("PickingMagnet");
		if (Input.GetKeyDown(KeyCode.X))
			StartCoroutine("PickingShoe");
		
		int timeScore = (timerComp != null) ? timerComp.t : 0;
		int totalScore = timeScore + destroyScore;
		
		if (coinNum >= 30 || totalScore >= 60)
		{
			isGameOver = true;
			StartCoroutine(WinGame());
		}
	}
	
	void PickingCoin()
	{
		coinNum++;
		GameObject coins = GameObject.Find("Coins");
		if (coins != null)
			coins.SendMessage("setNum", coinNum);
	}
	
	void AddDestroyScore()
	{
		destroyScore++;
	}
	
	IEnumerator PickingShoe()
	{
		if (isShoeRunning)
		{
			shoeTime += 5;
			yield break;
		}
		
		isShoeRunning = true;
		shoeTime = 5;
		SendMessage("SetJumpForce", 12f);
		
		GameObject shoe = GameObject.Find("Shoe");
		if (shoe != null) shoe.SendMessage("HUDon");
		
		while (shoeTime >= 0)
		{
			if (shoe != null) shoe.SendMessage("Show", shoeTime);
			yield return new WaitForSeconds(1.0f);
			shoeTime--;
		}
		
		if (shoe != null) shoe.SendMessage("HUDoff");
		SendMessage("SetJumpForce", 10f);   // 恢复默认 10，而不是 7
		
		isShoeRunning = false;
	}
	
	IEnumerator PickingMagnet()
	{
		if (isMagnetRunning)
		{
			magnetTime += 5;
			yield break;
		}
		
		isMagnetRunning = true;
		magnetTime = 5;
		
		GameObject magnet = GameObject.Find("Magnet");
		if (magnet != null) magnet.SendMessage("HUDon");
		
		while (magnetTime >= 0)
		{
			if (magnet != null) magnet.SendMessage("Show", magnetTime);
			yield return new WaitForSeconds(1.0f);
			magnetTime--;
		}
		
		if (magnet != null) magnet.SendMessage("HUDoff");
		
		isMagnetRunning = false;
	}
	
	// 死亡结束
	public IEnumerator StopMove()
	{
		isGameOver = true;
		
		GameObject hint = GameObject.Find("TextHint");
		if (hint != null)
		{
			hint.SendMessage("HUDon");
			int t = (timerComp != null) ? timerComp.t : 0;
			object[] a = new object[3];
			a[0] = coinNum;
			a[1] = t;
			a[2] = destroyScore;
			hint.SendMessage("ShowEnd", a);
		}
		
		yield return new WaitForSeconds(3f);
		Application.LoadLevel("menu");
	}
	
	// 胜利结束
	IEnumerator WinGame()
	{
		isGameOver = true;
		
		GameObject plane = GameObject.Find("Plane");
		if (plane != null) plane.SendMessage("StopMove");
		
		GameObject timerObj = GameObject.Find("Timer");
		if (timerObj != null)
		{
			timerObj.SendMessage("StopMove");
			timerObj.SendMessage("HUDoff");
		}
		
		GameObject shoe = GameObject.Find("Shoe");
		if (shoe != null) shoe.SendMessage("HUDoff");
		
		GameObject coins = GameObject.Find("Coins");
		if (coins != null) coins.SendMessage("HUDoff");
		
		GameObject magnet = GameObject.Find("Magnet");
		if (magnet != null) magnet.SendMessage("HUDoff");
		
		GameObject hint = GameObject.Find("TextHint");
		if (hint != null)
		{
			hint.SendMessage("HUDon");
			int t = (timerComp != null) ? timerComp.t : 0;
			object[] a = new object[3];
			a[0] = coinNum;
			a[1] = t;
			a[2] = destroyScore;
			hint.SendMessage("ShowWin", a);
		}
		
		yield return new WaitForSeconds(3f);
		Application.LoadLevel("menu");
	}
}