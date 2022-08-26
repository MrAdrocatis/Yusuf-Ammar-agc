using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Controller : MonoBehaviour
{
    public Collider2D ball;
    public bool IsRight;
    public Score_Manager manager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (IsRight)
            {
                manager.AddRightScore(1);

            }
            else
            {
                manager.AddLeftScore(1);
            }
        }
    }
}
