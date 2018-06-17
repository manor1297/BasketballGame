using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
    private float InitialTouchTime;
    private float FinalTouchTime;
    private Vector2 InitialTouchPosition;
    private Vector2 FinalTouchPosition;
    private float XaxisForce;
    private float YaxisForce;
    private float ZaxisForce;
    public Rigidbody ball;
    public bool canswipe = true;


    private Vector3 RequireForce;

    public void Start()
    {
        Time.timeScale = 3;
        ball.useGravity = false;
    }

    public void OnTouchDown()
    {
        if (canswipe)
        {
            InitialTouchTime = Time.time;
            InitialTouchPosition = Input.mousePosition;
        }
    }

    public void OnTouchUp()
    {
        if (canswipe)
        {
            FinalTouchTime = Time.time;
            FinalTouchPosition = Input.mousePosition;
            BallThrow();
        }
    }

    private void BallThrow()
    {
        XaxisForce = FinalTouchPosition.x - InitialTouchPosition.x;
        YaxisForce = FinalTouchPosition.y - InitialTouchPosition.y;
        ZaxisForce = FinalTouchTime - InitialTouchTime;

        RequireForce = new Vector3(-XaxisForce,YaxisForce,-ZaxisForce*80f);
        ball.useGravity = true;
        ball.isKinematic = false;
        ball.velocity = RequireForce;
        canswipe = false;
    }
}
