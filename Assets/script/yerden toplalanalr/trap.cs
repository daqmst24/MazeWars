using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    private Animator anim;
    private bool _damage = false;
    private playerhiz _player;

    void Start()
    {
        anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerhiz>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeBtwShots <= 0)
        {
            anim.SetBool("trap", true);

            _damage = true;
            Invoke("Basal",4);

        }
        else
        {
            timeBtwShots -= Time.deltaTime;

            anim.SetBool("trap", false);
            _damage = false;

        }


    }

    void Basal()
    {

        timeBtwShots = startTimeBtwShots;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _damage)
        {
            _player.damage(1);
        }
    }



}
