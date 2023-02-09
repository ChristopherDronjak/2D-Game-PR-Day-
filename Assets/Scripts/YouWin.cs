using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gym")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);            
    }
}
