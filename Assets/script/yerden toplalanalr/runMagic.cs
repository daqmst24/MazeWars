using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runMagic : MonoBehaviour
{
    private playerhiz _player;
 
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerhiz>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            gameObject.SetActive(false);
            _player._speed = 8;

            Invoke("Speed",3f);
            Destroy(gameObject,6f);

        }
    }


    void Speed()
    {


        _player._speed = 5;

    }
}
