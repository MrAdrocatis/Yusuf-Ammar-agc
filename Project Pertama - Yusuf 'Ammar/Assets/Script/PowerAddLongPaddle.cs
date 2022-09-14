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




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            StartCoroutine(ScaleOnCertainTime(left_paddle));
        }


    }

    private IEnumerator ScaleOnCertainTime(Transform paddle)
    {
        ScaleUp(paddle);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);

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
