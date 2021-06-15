using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicbullet : MonoBehaviour
{
    [SerializeField] float _speed;
    private Transform _player;
    private Vector2 target;
    [SerializeField] GameObject _effect;

    [SerializeField] float _distancer;
    [SerializeField] LayerMask _detectionLayer;
    private Vector2 distance;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(_player.position.x, _player.position.y);
    }

    private void Update()
    {


            transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
        
           
           
        
        if (transform.position.x > target.x && transform.position.y > target.y)
        {
            destroyin();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"|| collision.gameObject.tag == "duvar"|| collision.gameObject.tag == "door")
        {
            destroyin();
        }
    }

    void destroyin()
    {

        Destroy(gameObject);
        Instantiate(_effect, transform.position, transform.rotation);





    }
}
