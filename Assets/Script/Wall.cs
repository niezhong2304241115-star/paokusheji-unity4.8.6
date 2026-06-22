using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    private int hp = 1;

    public void TakeDamage()
    {
        hp--;
        if (hp <= 0)
        {
            GameObject.Find("Player").SendMessage("AddDestroyScore");
            Destroy(gameObject);
        }
    }
}
