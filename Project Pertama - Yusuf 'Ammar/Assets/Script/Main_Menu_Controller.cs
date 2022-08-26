using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game_Pong");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created By Yusuf Ammar");
    }
}
