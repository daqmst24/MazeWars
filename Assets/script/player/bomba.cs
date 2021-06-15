using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    [SerializeField] playerhiz _player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "redenemy")
        {
            Debug.Log("girdi");

            _player.damage(3);
        }
    }
}
