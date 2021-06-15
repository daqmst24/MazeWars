using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saksı : MonoBehaviour
{
    [SerializeField] GameObject _particel;  
    [SerializeField] GameObject _coin;   
    [SerializeField] GameObject _health;
    [SerializeField] GameObject _speedMagic;





 
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "bullet")
        {
            int sayı = Random.Range(0,5);

            if (sayı==2)
            {
                Instantiate(_coin,transform.position,Quaternion.identity);
            }
            else if(sayı==3)
            {
                Instantiate(_speedMagic, transform.position, Quaternion.identity);

            }
            else if(sayı==0)

 {  Instantiate(_health, transform.position, Quaternion.identity);
            }

            
            Instantiate(_particel, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
