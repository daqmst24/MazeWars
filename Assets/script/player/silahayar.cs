using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahayar : MonoBehaviour
{

    GameObject player;
  
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShot;
    public float startTimeBtwShots;
    private bool basıldı;
    private AudioSource Muzik;
    public AudioClip deaglemuzik;
    private silahkontroleri _silahKontroler;
  
   

    

 

 
 


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        Muzik = GameObject.FindGameObjectWithTag("Finish").GetComponent<AudioSource>();
        _silahKontroler = GameObject.FindGameObjectWithTag("silahayar").GetComponent<silahkontroleri>();

    }
    void Update()
    {

        


        timeBtwShot -= Time.deltaTime;
        if (basıldı==true)
        {
          

            if (timeBtwShot <= 0)
            {

                

                GameObject bullet = Instantiate(projectile, shotPoint.position, transform.rotation);
                Bullet bulletComponent = bullet.GetComponent<Bullet>();

                bulletComponent.axis = (shotPoint.position- transform.position).normalized;
                timeBtwShot = startTimeBtwShots;
                Muzik.PlayOneShot(deaglemuzik);
              
            
            }


            
            
                basıldı = false;
              
              
            

        }
       


    }
   

  public  void Guns()
    {

        basıldı = true;

   


}
    //public void gun()
    //{

  

    //    Vector3 vec = _enemys.transform.position - transform.position;

    //   Vector3 difference = vec;


    //    difference.Normalize();
    //    float rotation_z = Mathf.Atan2(difference.y * Mathf.Sign(player.transform.localScale.x), difference.x * Mathf.Sign(player.transform.localScale.x)) * Mathf.Rad2Deg;
    //   transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);



    //}



}
