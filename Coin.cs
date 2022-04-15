using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private float coin = 0 ;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            coin ++;
            textCoins.text = coin.ToString();
            Destroy(other.gameObject);
            if(coin == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                coin = 3;
            }
            else
            {

            }
        }
    }
}
