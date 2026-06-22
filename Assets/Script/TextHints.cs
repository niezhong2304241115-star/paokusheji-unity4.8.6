using UnityEngine;
using System.Collections;

public class TextHints : MonoBehaviour
{
    void HUDon()
    {
        guiText.enabled = true;
    }

    void HUDoff()
    {
        guiText.enabled = false;
    }

    void Show(string msg)
    {
        guiText.text = msg;
    }

    // 死亡提示
    void ShowEnd(object[] a)
    {
        guiText.text = "<b>You Dead!</b>\nScore: " + a[1] + "\nCoins: " + a[0] + "\nDestroyed: " + a[2];
    }

    // 胜利提示
    void ShowWin(object[] a)
    {
        guiText.text = "<b>You Win!</b>\nScore: " + a[1] + "\nCoins: " + a[0] + "\nDestroyed: " + a[2];
    }
}