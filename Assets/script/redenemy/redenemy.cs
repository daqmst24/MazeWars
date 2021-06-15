using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redenemy : MonoBehaviour
{
    private RaycastHit2D _rayRight;

    [SerializeField] float _speed;
    [SerializeField] float _distance;
    [SerializeField] LayerMask _detectionLayer;
    [SerializeField] private Transform _playerTran;

    private Animator anim;
    private AudioSource muzik;
    [SerializeField] AudioClip _deadMuzik;
    [SerializeField] GameObject _dedaEffect;
    private Rigidbody2D rg;



    float _firstScale;


    private void Start()
    {
        _playerTran = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _firstScale = transform.localScale.x;
        anim = GetComponent<Animator>();
        muzik = GetComponent<AudioSource>();
        rg = GetComponent<Rigidbody2D>();

    }
    void Update()
    {

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
        if (collision.gameObject.tag == "bomba")
        {
            muzik.PlayOneShot(_deadMuzik);
            _speed = 0;
            anim.SetTrigger("isdead");
            Instantiate(_dedaEffect, transform.position, transform.rotation);
            Destroy(gameObject, 1);



        }
        if (collision.gameObject.tag == "bullet")
        {
            muzik.PlayOneShot(_deadMuzik);
            _speed = 0;
            anim.SetTrigger("isdead");
            Instantiate(_dedaEffect, transform.position, transform.rotation);
            Destroy(gameObject, 1);
        }
    }

}

