using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float bulletSpeed = 20f;
	public Transform firePoint;
	public int maxBullets = 60;
	private int currentBullets;
	
	public float fireRate = 0.15f;       // 连发间隔
	private float nextFireTime = 0f;
	
	// 双排射击相关
	private bool isDoubleFire = false;
	public float doubleFireDuration = 10f;   // x2 持续 10 秒
	public float doubleFireOffset = 0.3f;    // 两排子弹左右间距
	
	void Start()
	{
		currentBullets = maxBullets;
		UpdateBulletHUD();
	}
	
	void Update()
	{
		// 左键：点按单发
		if (Input.GetMouseButtonDown(0))
		{
			if (currentBullets > 0)
				Shoot();
			else
				UpdateBulletHUD();
		}
		
		// 右键：按住连发
		if (Input.GetMouseButton(1))
		{
			if (Time.time >= nextFireTime && currentBullets > 0)
			{
				Shoot();
				nextFireTime = Time.time + fireRate;
			}
			else if (currentBullets <= 0)
			{
				UpdateBulletHUD();
			}
		}
	}
	
	void Shoot()
	{
		if (isDoubleFire)
		{
			// 双排模式：一次射两颗，扣 2 发子弹
			if (currentBullets >= 2)
			{
				currentBullets -= 2;
				UpdateBulletHUD();
				
				// 左排
				Vector3 leftPos = firePoint.position - firePoint.right * doubleFireOffset;
				GameObject bullet1 = (GameObject)Instantiate(bulletPrefab, leftPos, firePoint.rotation);
				Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
				rb1.velocity = firePoint.forward * bulletSpeed;
				rb1.freezeRotation = true;
				Destroy(bullet1, 2f);
				
				// 右排
				Vector3 rightPos = firePoint.position + firePoint.right * doubleFireOffset;
				GameObject bullet2 = (GameObject)Instantiate(bulletPrefab, rightPos, firePoint.rotation);
				Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
				rb2.velocity = firePoint.forward * bulletSpeed;
				rb2.freezeRotation = true;
				Destroy(bullet2, 2f);
			}
			else if (currentBullets == 1)
			{
				// 只剩 1 发，降级为单发
				currentBullets--;
				UpdateBulletHUD();
				FireSingle();
			}
		}
		else
		{
			// 单排模式
			currentBullets--;
			UpdateBulletHUD();
			FireSingle();
		}
	}
	
	// 单发一颗子弹
	void FireSingle()
	{
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
		bulletRB.velocity = firePoint.forward * bulletSpeed;
		bulletRB.freezeRotation = true;
		Destroy(bullet, 2f);
	}
	
	// 外部调用：开启双倍火力
	public void EnableDoubleFire()
	{
		if (!isDoubleFire)
		{
			isDoubleFire = true;
			StartCoroutine(DoubleFireTimer());
		}
	}
	
	IEnumerator DoubleFireTimer()
	{
		yield return new WaitForSeconds(doubleFireDuration);
		isDoubleFire = false;
	}
	
	// 拾取弹药用
	public void AddBullets(int amount)
	{
		currentBullets += amount;
		if (currentBullets > maxBullets)
			currentBullets = maxBullets;
		UpdateBulletHUD();
	}
	
	void UpdateBulletHUD()
	{
		GameObject hud = GameObject.Find("BulletHUD");
		if (hud != null)
			hud.SendMessage("ShowBullets", currentBullets);
	}
}