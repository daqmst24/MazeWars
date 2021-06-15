using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerbullet : MonoBehaviour
{


    public GameObject projectile;
    public Transform shotpoint;
    public float baslangic;
    private float bitis;
  


    private void Update()
    {
        if (baslangic<=0)
        {

      

        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(projectile, shotpoint.position, transform.rotation);
                baslangic = bitis;
        }
        }
        else
        {
            bitis -= Time.deltaTime;
        }
    }

 
}
