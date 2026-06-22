using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public bool isPlay = true;
    public bool isIntroduction = false;
    public bool isExit = false;

    void Start()
    {
        GameObject.Find("TextHint").SendMessage("HUDon");
        GameObject.Find("TextHint").SendMessage("Show", "<b>A Game for Running!</b>");
    }

    void Update()
    {

    }

    public void OnClick()
    {
        if (isPlay)
        {
            GameObject.Find("Plane").SendMessage("Move");

            try
            {
                Application.LoadLevel("game");
            }
            catch
            {
                Application.LoadLevel(1);
            }

        }
        else if (isIntroduction)
        {
            GameObject.Find("TextHint").SendMessage("Show", "<b>A</b> : Left\n" + "<b>D</b> : Right\n" + "<b>W</b> : Jump\n" + "<b>Space Bar</b> : Jump\n" + "<b>Double Jump</b> : Two jumps\n" + "<b>Win</b> : 30 Coins OR Score ≥60\n" + "<b>Author</b> : 2304241115nz");
        }
    
        else if (isExit)
        {
            // 编辑器退出 + 打包后退出
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}