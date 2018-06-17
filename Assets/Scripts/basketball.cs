using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basketball : MonoBehaviour {

    public Text score;
    public Text remainingballs;
    public Text gameover;
    private int currentscore=0;
    public int remaining = 3;
    private Vector3 InitialPosition;
    private TouchManager touchsystem;

    void Start()
    {
        touchsystem = GameObject.FindObjectOfType<TouchManager>().GetComponent<TouchManager>();
        InitialPosition = this.transform.position;
        ChangeText();
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Ring")
        {
            remaining++;
            ScoreUpdate();
        }
    }
    private void ScoreUpdate()
    {
        currentscore++;
        score.text = currentscore.ToString();
    }
    public void DecreaseRemaining()
    {
        remaining--;
    }
    public void ChangeText()
    {
        if (remaining == (-1))
        {
            gameover.text = "GAME OVER";
        }
        else
        {
            remainingballs.text = "Remaining Balls :" + remaining.ToString();
        }
    }
    public void ResetPosition()
    {
        this.transform.position = InitialPosition + new Vector3(Random.Range(-20f,20f),0f,0f);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        touchsystem.canswipe = true;


    }
}
