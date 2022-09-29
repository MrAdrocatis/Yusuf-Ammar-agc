using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpeedPaddle : MonoBehaviour
{
    public Collider2D ball;
    public Transform left_paddle;
    public Transform right_paddle;
    public float SpeedBoost;
    public int WaitTime;
    public PowerUpManager manager;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (LeftPaddle.Instance.GetIsTouch())
                StartCoroutine(SpeedOnCertainTime(left_paddle));
            else
                StartCoroutine(SpeedOnCertainTime(right_paddle));
        }

    }

    private IEnumerator SpeedOnCertainTime(Transform paddle)
    {
        SpeedUp(paddle);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(WaitTime);

        SpeedDown(paddle);
        Destroy(gameObject);
    }

    private void SpeedUp(Transform paddle)
    {
        paddle.GetComponent<Paddle_Controller>().ActivatePUSpeedPaddle(SpeedBoost);
    }

    private void SpeedDown(Transform paddle)
    {
        paddle.GetComponent<Paddle_Controller>().DeactivatePUSpeedPaddle(SpeedBoost);
    }
}
