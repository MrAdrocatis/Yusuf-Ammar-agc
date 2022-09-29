using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAddLongPaddle : MonoBehaviour
{
    public Transform left_paddle;
    public Transform right_paddle;
    public Collider2D ball;
    public PowerUpManager manager;
    public float PULongPaddle;
    public int WaitTime;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (LeftPaddle.Instance.GetIsTouch())
                StartCoroutine(ScaleOnCertainTime(left_paddle));
            else
                StartCoroutine(ScaleOnCertainTime(right_paddle));
        }
    }

    private IEnumerator ScaleOnCertainTime(Transform paddle)
    {
        ScaleUp(paddle);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(WaitTime);

        ScaleDown(paddle);
        Destroy(gameObject);
    }

    private void ScaleUp(Transform paddle)
    {
        paddle.localScale = new Vector3(0.5f, PULongPaddle, 1f);
    }

    private void ScaleDown(Transform paddle)
    {
        paddle.localScale = new Vector3(0.5f, 3f, 1f);
    }
}
