using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Death();
            AudioManager.instance.Play("Die");
        }
    }

    private void Death()
    {
        anim.SetTrigger("death");
        
    }

    private void RestartLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
