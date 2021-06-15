using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinScrpit : MonoBehaviour
{

    gameManager MANGER;


    private void Start()
    {
        MANGER = GameObject.Find("Gamemanger").GetComponent<gameManager>();

      
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag == "Player")
        {
            MANGER._coinA += 1;
         
            Destroy(gameObject);


        }
    }
}
