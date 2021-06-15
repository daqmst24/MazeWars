 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private RaycastHit2D _rayRight;

    [SerializeField] float _speed;
    [SerializeField] float _distance;
    [SerializeField] LayerMask _detectionLayer;
    private Transform _playerTran;
    [SerializeField] int healthEnemy = 100;
    private Animator anim;
    private AudioSource muzik;
    [SerializeField] AudioClip _deadMuzik;
    [SerializeField] GameObject _dedaEffect;
    [SerializeField] AudioClip _damage;
    [SerializeField] GameObject _enemyBlood;
    private Rigidbody2D rg;
    private Guns _guns;



    private playerhiz _playerScript;







    float _firstScale;


    private void Start()
    {
        _playerTran = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _firstScale = transform.localScale.x;
        anim = GetComponent<Animator>();
        muzik = GetComponent<AudioSource>();
        rg = GetComponent<Rigidbody2D>();
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerhiz>();
        _guns = GameObject.FindGameObjectWithTag("sword").GetComponent<Guns>();


    }
    void Update()
    {
        Distance();
        Vector2 distance = _playerTran.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance, _distance, _detectionLayer);
        if (hit.transform.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTran.position, _speed * Time.deltaTime);
            Vector2 scale = transform.localScale;
            scale.x = Mathf.Sign(distance.x) * _firstScale;
            transform.localScale = scale;
            //animatordaki speed değeri 1 olacak
            anim.SetBool("hiz", true);
        }
        else
        {
            anim.SetBool("hiz", false);
        }



    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            rg.velocity = Vector2.up * 400 * Time.deltaTime;
            healthEnemy -= 20;
            muzik.PlayOneShot(_damage);
            EnemyBlod();
        }
        else if (collision.gameObject.tag == "sword" &&_guns.attack)
        {

            rg.velocity = Vector2.up * 500 * Time.deltaTime;
            healthEnemy -= 30;
            muzik.PlayOneShot(_damage);
            EnemyBlod();
        }

        if (healthEnemy <= 0)
        {
          
       
            _speed = 0;
           

            muzik.PlayOneShot(_deadMuzik);
            anim.SetBool("isDead", true);
            Instantiate(_dedaEffect, transform.position, transform.rotation);
      
                Destroy(gameObject, 1f);

          

          

        }
    }


    void Distance()
    {

        if (_playerScript._saldırdı==true)
        {

   
        if (Vector2.Distance(transform.position,_playerTran.position)<3)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTran.position, -5 * Time.deltaTime);

                Invoke("True",0.5f);
                
            }
         
        }
   
            
      
    }
    void True()
    {

        _playerScript._saldırdı = false;

    }
    void EnemyBlod()
    {

        Instantiate(_enemyBlood, transform.position, Quaternion.identity);

    }

}
