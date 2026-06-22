using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour
{
	public GameObject plane;
	public GameObject wall;
	public GameObject obstacle;
	public GameObject magnet;
	public GameObject train;
	public GameObject coin;
	public GameObject shoe;
	public GameObject bulletPickup;
	public GameObject x2Pickup;            // 新增：x2 道具预制体
	private int trapNum = 0;
	private bool hasSpawnedX2 = false;     // 新增：确保只出现一次
	
	void Start ()
	{
		for (int i=0; i < 5; i++) {
			GameObject p = Instantiate (plane, new Vector3 (0, 0, i * 20), Quaternion.identity) as GameObject;
			p.name = "Plane";
		}
	}
	
	void Update () { }
	
	void Create ()
	{
		float z = 80.0f + 5.0f * trapNum;
		Debug.Log (z);
		GameObject p = Instantiate (plane, new Vector3 (0, 0, z), Quaternion.identity) as GameObject;
		p.name = "Plane";
		
		float r = Random.Range (0f, 1f);
		float posX = Random.Range (-1, 2) * 3f; 
		
		if (r <= 0.2f) { 
			GameObject w = Instantiate (wall, new Vector3 (0, 1, z), Quaternion.identity) as GameObject;
			w.transform.parent = p.transform;
		} else if (r <= 0.5f) {
			GameObject o = Instantiate (obstacle, new Vector3 (posX, 1, z), Quaternion.identity) as GameObject;
			o.transform.parent = p.transform;
		} else if (r <= 0.7f) {
			trapNum++;
		} else {
			GameObject t = Instantiate (train, new Vector3 (posX, 1.6f, z), Quaternion.identity) as GameObject;
			t.transform.parent = p.transform;
		}
		
		// ===== 只生成一次 x2 道具 =====
		if (!hasSpawnedX2)
		{
			float rX2 = Random.Range(0f, 1f);
			if (rX2 < 0.5f)  // 50% 概率在当前这个新 Plane 上出现
			{
				float x2PosX = Random.Range(-1, 2) * 3f;
				GameObject x2 = Instantiate(x2Pickup, new Vector3(x2PosX, 0.5f, z), Quaternion.identity) as GameObject;
				x2.name = "X2";
				x2.transform.parent = p.transform;
				hasSpawnedX2 = true;   // 标记已生成，以后不再出现
			}
		}
		
		for (int i = 1; i <= 3; i++) {
			r = Random.Range (0f, 1f);
			posX = Random.Range (-1, 2) * 3f;
			
			if (r < 0.20f) {
				GameObject m = Instantiate (magnet, new Vector3 (posX, 0.5f, z - i * 3.5f), Quaternion.identity) as GameObject;
				m.transform.parent = p.transform;
			} else if (r < 0.45f) {
				Quaternion rot = new Quaternion ();
				rot.eulerAngles = new Vector3 (90, 0, 0);
				
				GameObject c = Instantiate (coin, new Vector3 (posX, 1f, z - i * 3.5f), rot) as GameObject;
				c.name = "Coin";
				c.transform.parent = p.transform;
			} else if (r < 0.70f) {
				GameObject s = Instantiate (shoe, new Vector3 (posX, 0.5f, z - i * 3.5f), Quaternion.identity) as GameObject;
				s.transform.parent = p.transform;
			} else {
				GameObject b = Instantiate (bulletPickup, new Vector3 (posX, 0.5f, z - i * 3.5f), Quaternion.identity) as GameObject;
				b.transform.parent = p.transform;
			}
		}
	}
}