using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 ResetPosition;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    private void Update()
    {
        Debug.Log("Test : " + speed);
    }
    public void ResetBall()
    {
        transform.position = new Vector3(ResetPosition.x, ResetPosition.y, -1);
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }
}
