using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int healt;
    public GameObject[] healthUI;
    void TakeDamage()
    {
        healt--;
        if (healt <= 0)
        {
            healt = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthUI[healt].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
