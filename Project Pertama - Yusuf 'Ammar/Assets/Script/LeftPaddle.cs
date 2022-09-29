using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    #region singleton
    private static LeftPaddle instance;
    public static LeftPaddle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LeftPaddle>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(LeftPaddle).Name;
                    instance = obj.AddComponent<LeftPaddle>();
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
            RightPaddle.Instance.SetIsTouch(false);
        }
    }
}
