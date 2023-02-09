using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{

    private int Coins = 0;

    [SerializeField] private Text Scoreboard;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);
            Coins++;
            Scoreboard.text = "Coins: " + Coins;
            AudioManager.instance.Play("Coin");
        }
    }
}
