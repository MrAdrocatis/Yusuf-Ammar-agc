using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    #region singleton
    private static RightPaddle instance;
    public static RightPaddle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RightPaddle>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(RightPaddle).Name;
                    instance = obj.AddComponent<RightPaddle>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion singleton

    private bool isTouch;

    public void SetIsTouch(bool _isTouch)
    {
        isTouch = _isTouch;
    }

    public bool GetIsTouch()
    {
        return isTouch;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            SetIsTouch(true);
            LeftPaddle.Instance.SetIsTouch(false);
        }
    }
}
