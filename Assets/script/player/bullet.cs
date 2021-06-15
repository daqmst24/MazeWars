using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.script;
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{

    public Vector2 axis;
    public float speed;
    [SerializeField] public GameObject _effect;
    [SerializeField] private GameObject _effect_yelow;
    private shake sHake;
   

    [SerializeField] AudioClip _break;
  


    public void Start()
    {
        Move();
        sHake = GameObject.FindGameObjectWithTag("shake").GetComponent<shake>();

    }

    protected void Move()
    {
        GetComponent<Rigidbody2D>().velocity = axis * speed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        sHake.Camanim();
        Instantiate(_effect, transform.position, Quaternion.identity);
        collision.GetComponent<IDamageable>()?.OnDamaged(collision.transform);
        Destroy(gameObject);
      
    }





}
