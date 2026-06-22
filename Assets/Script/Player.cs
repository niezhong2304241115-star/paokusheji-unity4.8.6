using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// ===== 三车道系统 =====
	private int currentLane = 1;                    // 0=左, 1=中, 2=右
	private float[] laneX = new float[] { -3f, 0f, 3f }; // 三个固定 x 坐标
	
	private Rigidbody playerRB;
	public float jumpForce = 10;
	
	private int jumpCount = 0;
	public int maxJumpCount = 2;
	
	private Renderer playerRenderer;
	private Color originalColor;
	public Color pinkColor = new Color(1f, 0.8f, 0.9f);
	public float colorTime = 2f;
	
	public int hp = 100;
	public int damageWall = 20;
	public int damageTrain = 40;
	private GUIText hpText;
	
	private bool isDead = false;
	
	void Start()
	{
		playerRB = GetComponent<Rigidbody>();
		playerRenderer = GetComponent<Renderer>();
		originalColor = playerRenderer.material.color;
		playerRB.freezeRotation = true;
		
		// 强制对齐到中间车道
		Vector3 pos = transform.position;
		pos.x = laneX[currentLane];
		transform.position = pos;
		
		hpText = GameObject.Find("hp").GetComponent<GUIText>();
		if (hpText != null)
			UpdateHPUI();
	}
	
	void Update()
	{
		if (isDead) return;
		
		// 跳跃
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
		{
			if (jumpCount < maxJumpCount)
				MoveUp();
		}
		
		// ===== S 键：空中主动下降 =====
		if (Input.GetKeyDown(KeyCode.S))
		{
			if (jumpCount > 0)  // 在空中才能俯冲
			{
				playerRB.velocity = new Vector3(
					playerRB.velocity.x, 
					-jumpForce, 
					playerRB.velocity.z
					);
			}
		}
		// =============================
		
		// 三车道左右移动
		if (Input.GetKeyDown(KeyCode.A))
			MoveLeft();
		else if (Input.GetKeyDown(KeyCode.D))
			MoveRight();
		
		// 掉出地图
		if (this.transform.position.z < -0.5f || this.transform.position.y < 0)
			Stop();
	}
	
	// 保险：每帧强制同步 HP 显示
	void LateUpdate()
	{
		if (isDead && hpText != null)
			hpText.text = "HP: 0%";
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		if (isDead) return;
		
		jumpCount = 0;
		
		if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Obstacle"))
		{
			TakeDamage(damageWall);
			Destroy(collision.gameObject);
		}
		else if (collision.collider.CompareTag("Train"))
		{
			TakeDamage(damageTrain);
			Destroy(collision.gameObject);
		}
	}
	
	void TakeDamage(int dmg)
	{
		if (isDead) return;
		
		hp -= dmg;
		if (hp < 0) hp = 0;
		UpdateHPUI();
		
		if (hp <= 0)
		{
			isDead = true;
			hp = 0;
			UpdateHPUI();
			StartCoroutine(ForceHPZero());
			
			Stop();
			
			Collider col = GetComponent<Collider>();
			if (col != null) col.enabled = false;
			if (playerRenderer != null) playerRenderer.enabled = false;
			
			Destroy(gameObject, 3.5f);
		}
	}
	
	IEnumerator ForceHPZero()
	{
		while (true)
		{
			if (hpText != null)
				hpText.text = "HP: 0%";
			else
				yield break;
			yield return null;
		}
	}
	
	void UpdateHPUI()
	{
		if (hpText != null)
			hpText.text = "HP: " + hp + "%";
	}
	
	void MoveUp()
	{
		playerRB.velocity = Vector3.up * jumpForce;
		jumpCount++;
	}
	
	void PickingCoin()
	{
		StartCoroutine(ChangeColor());
	}
	
	IEnumerator ChangeColor()
	{
		playerRenderer.material.color = pinkColor;
		yield return new WaitForSeconds(colorTime);
		playerRenderer.material.color = originalColor;
	}
	
	// ===== 左中右车道移动 =====
	void MoveLeft()
	{
		if (currentLane > 0)
		{
			currentLane--;
			Vector3 pos = transform.position;
			pos.x = laneX[currentLane];
			transform.position = pos;
		}
	}
	
	void MoveRight()
	{
		if (currentLane < 2)
		{
			currentLane++;
			Vector3 pos = transform.position;
			pos.x = laneX[currentLane];
			transform.position = pos;
		}
	}
	// ==========================
	
	void SetJumpForce(float jumpForce)
	{
		this.jumpForce = jumpForce;
	}
	
	void Stop()
	{
		GameObject plane = GameObject.Find("Plane");
		if (plane != null) plane.SendMessage("StopMove");
		
		GameObject timer = GameObject.Find("Timer");
		if (timer != null)
		{
			timer.SendMessage("StopMove");
			timer.SendMessage("HUDoff");
		}
		
		GameObject shoe = GameObject.Find("Shoe");
		if (shoe != null) shoe.SendMessage("HUDoff");
		
		GameObject coins = GameObject.Find("Coins");
		if (coins != null) coins.SendMessage("HUDoff");
		
		GameObject magnet = GameObject.Find("Magnet");
		if (magnet != null) magnet.SendMessage("HUDoff");
		
		Inventory inv = GetComponent<Inventory>();
		if (inv != null)
			inv.StartCoroutine("StopMove");
	}
	
	public void AddDestroyScore()
	{
	}
}