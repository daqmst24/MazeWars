using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicenemy : MonoBehaviour
{
    private RaycastHit2D _rayRight;

    [SerializeField] float _speed;
    [SerializeField] float _distance;
    [SerializeField] LayerMask _detectionLayer;
    [SerializeField] private Transform _playerTran;
    [SerializeField] int healthEnemy = 100;
    [SerializeField] float _speedDont;
    private Animator anim;
    [SerializeField] GameObject _magicBlood;
    private AudioSource muzik;
    [SerializeField] AudioClip _deadMuzik;
    [SerializeField] AudioClip _damage;
    [SerializeField] AudioClip _hitAuido;
    [SerializeField] GameObject _can;
    [SerializeField] GameObject _dedaEffect;
    private Rigidbody2D rg;
    private float _timeBtwShots;
    [SerializeField] float _startTimeBtwShots;
    private bool _stop = false;
    public bool _vur;
    private Guns _guns;



    public GameObject _projectile;


    float _firstScale;


    private void Start()
    {
        _guns = GameObject.FindGameObjectWithTag("sword").GetComponent<Guns>();
        _playerTran = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _firstScale = transform.localScale.x;
        anim = GetComponent<Animator>();
        muzik = GetComponent<AudioSource>();
        rg = GetComponent<Rigidbody2D>();
        _timeBtwShots = _startTimeBtwShots;

    }
    void Update()
    {

        Vector2 distance = _playerTran.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance, _distance, _detectionLayer);
        if (Vector2.Distance(transform.position, _playerTran.position) < 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTran.position, -_speedDont * Time.deltaTime);


            anim.SetBool("hiz", false);

        }


        if (hit.transform.tag == "Player")
        {
            Vector2 scale = transform.localScale;
            scale.x = Mathf.Sign(distance.x) * _firstScale;
            transform.localScale = scale;
            anim.SetBool("hiz", true);
            transform.position = Vector2.MoveTowards(transform.position, _playerTran.position, _speed * Time.deltaTime);
            _vur = true;

        }

        else
        {
            anim.SetBool("hiz", false);
        }


        if (_timeBtwShots <= 0&&!_stop&&_vur)
        {
            muzik.PlayOneShot(_hitAuido);
            Instantiate(_projectile, transform.position, Quaternion.identity);

            _timeBtwShots = _startTimeBtwShots;
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }





    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            muzik.PlayOneShot(_damage);
            healthEnemy -= 20;
            rg.velocity = Vector2.up * 400 * Time.deltaTime;
            MagicBlood();
        }
        else if (collision.gameObject.tag == "sword"&&_guns.attack==true)
        {
           
        
             
            muzik.PlayOneShot(_damage);
            healthEnemy -= 30;
            rg.velocity = Vector2.up * 500 * Time.deltaTime;
            MagicBlood();
        }

        if (healthEnemy <= 0)
        {
            int sayı = Random.Range(0,2);
            _speed = 0;
            anim.SetBool("isDead", true);
            muzik.PlayOneShot(_deadMuzik);
            _stop = true;
            Instantiate(_dedaEffect, transform.position, transform.rotation);
            if (sayı==1)
            {
                Instantiate(_can, transform.position, Quaternion.identity);
                Destroy(gameObject);
                _stop = true;
            }
            else
            {
                Destroy(gameObject, 1f);
                _stop = true;
            }
         

             
       
         

     

                
               

        

        }
    }
    void MagicBlood()
    {

        Instantiate(_magicBlood, transform.position, Quaternion.identity);

    }



}
