using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{


private  playerhiz _player;




    private void Start()
    {
     
   
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerhiz>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
             { 
    
            Destroy(gameObject);
            if (_player._currentHealth<100)
            {
                _player._currentHealth += 10;
                if (_player._currentHealth>100)
                {
                    _player._currentHealth = _player._maxHealth;
                }

                
            }

          
          
        }
   
    }
}
