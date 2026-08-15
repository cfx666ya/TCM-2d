using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealline : MonoBehaviour
{
    public GameObject dialogAgain;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Deadline")
        {
            Time.timeScale = 0f;
            dialogAgain.SetActive(true);
        }
    }
}
