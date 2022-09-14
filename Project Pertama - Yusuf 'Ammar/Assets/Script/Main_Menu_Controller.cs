using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{
    public KeyCode Back_To_Menu;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game_Pong");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created By Yusuf Ammar");
        SceneManager.LoadScene("Credit_Scene");
    }

    public void BackToMenu()
    {

        SceneManager.LoadScene("Main_Menu");
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(Back_To_Menu))
        {
            BackToMenu();
        }
        return Vector2.zero;
    }
}
