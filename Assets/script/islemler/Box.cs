using Assets.script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject _breakEffect;
    [SerializeField] private GameObject _coin; 
    [SerializeField] private GameObject _can; 
    [SerializeField] private GameObject _magic;
    private int _coinNumber;
    public void OnDamaged(Transform collison)
    {
        Instantiate(_breakEffect, collison.position, Quaternion.identity);
        Destroy(gameObject);
        Coin();
       
    }

   
    void Start()
    {

      
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }


    void Coin()
    {

        _coinNumber = Random.Range(0, 5);


        if (_coinNumber==0)
        {
            Instantiate(_coin, transform.position, Quaternion.identity);
        }
        else if(_coinNumber==1)
        {
            Instantiate(_can, transform.position, Quaternion.identity);
        }       else if(_coinNumber==2)
        {
            Instantiate(_magic, transform.position, Quaternion.identity);
        }




    }
}
