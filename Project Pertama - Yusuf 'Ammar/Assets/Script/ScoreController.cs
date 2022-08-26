using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text SkorKiri;
    public Text SkorKanan;

    public Score_Manager manager;
    
    private void Update()
    {
        SkorKiri.text = manager.LeftScore.ToString();
        SkorKanan.text = manager.RightScore.ToString();
    }
}
