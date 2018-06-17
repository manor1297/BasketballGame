using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        col.GetComponent<basketball>().ResetPosition();
        col.GetComponent<basketball>().DecreaseRemaining();
        col.GetComponent<basketball>().ChangeText();
    }
}
