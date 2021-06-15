using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhiz : MonoBehaviour
{
    public float _speed = 5f;
    Rigidbody2D rg;

    public Camera cam;
    Animator anim;
    public bool FaceRight;
    Transform oyun;
    AudioSource ses;
    [SerializeField] GameObject _blood;
    [SerializeField] AudioClip _coinSes;
    [SerializeField] AudioClip _hitMusic;
    [SerializeField] AudioClip _deadPlayer;  
    [SerializeField] AudioClip _canMusic;
    [SerializeField] GameObject _deadEffect;
    [SerializeField] GameObject _deadMenu;
    [SerializeField] Transform gunRotateOrPosision;
    [SerializeField] GameObject _revilur;

    private Enemy _enemy;
    public int _maxHealth = 100;
    public int _currentHealth;
    public HealthBar _health;
    public Joystick Joystick;
    public bool _saldırdı=false;
    public silahayar deagle;
    private bool duzlem;
    [SerializeField] bool _dead=false;
    private magicenemy _magic;



    private void Start()
    {

        _magic = GameObject.FindGameObjectWithTag("magic").GetComponent<magicenemy>();
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ses = GetComponent<AudioSource>();


        _health.SerMaxHealth(_maxHealth);
        _currentHealth = _maxHealth;
        _enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();

    }
    void Update()
    {
        _health.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            _dead = true;
            Instantiate(_deadEffect, transform.position, transform.rotation);
            ses.PlayOneShot(_deadPlayer);
            _speed = 0;

            gameObject.SetActive(false);
           
            if (_dead == true)
            {
                _deadMenu.SetActive(true);
                _revilur.SetActive(true);
                Destroy(_revilur.gameObject,5f);
            }

        }
        CharacterMovement();
        GunMovement();
      
        //mous = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {

        Vector2 Fare = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (FaceRight && Fare.x < transform.position.x)
        //{
        //    face();

        //}
        //else if (!FaceRight && Fare.x > transform.position.x)
        //{
        //    face();



        //}


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _speed * Time.fixedDeltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speed * Time.fixedDeltaTime);

          
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * _speed * Time.fixedDeltaTime);
          
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * _speed * Time.fixedDeltaTime);
       
        }
     







        //Vector2 lookDir = mous - rg.position;
        //float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        //rg.rotation = angle;
    }
   
    void face()
    {
        FaceRight = !FaceRight;


        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            ses.PlayOneShot(_coinSes);
        }
        if (collision.gameObject.tag =="can"||collision.gameObject.tag=="run")
        {
            ses.PlayOneShot(_canMusic);
        }
        if (collision.gameObject.tag == "magicBullet")
        {
        

            damage(1);

        }
    
      
    }

    public void damage(int damage)
    {
        Instantiate(_blood, transform.position, transform.rotation);
        _currentHealth -= damage;
       
        ses.PlayOneShot(_hitMusic);
      

    }
    private void CharacterMovement()
    {
   
  transform.Translate(new Vector2(Joystick.Horizontal, Joystick.Vertical) * _speed * Time.deltaTime);

        if (Joystick.Horizontal > 0 )
        {

            if (!FaceRight)
            {
                face();
            }
          

            anim.SetBool("hiz", true);


        }
        else if (Joystick.Horizontal < 0 )
        {
           
            if (FaceRight)
            {
                face();
            }
            
            anim.SetBool("hiz", true);

          
        }
        else
        {
            anim.SetBool("hiz", false);
        }
      


    }
    private void GunMovement()
    {
        if (Joystick.Horizontal > 0 || Joystick.Horizontal < 0)
        {
            gunRotateOrPosision.transform.up = new Vector2(Joystick.Horizontal, Joystick.Vertical)*10;

        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
           
            _saldırdı = true;
            damage(1);
       

        

        }

    }
   






}
