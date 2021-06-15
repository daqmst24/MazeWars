using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class silahkontroleri : MonoBehaviour
{
    public int selectedWeapon = 0;
    public bool _silah=false;
    public bool _kılıc=false;
   private AudioSource muzik;
    [SerializeField] AudioClip degistir;

  
    void Start()
    {
        muzik = GetComponent<AudioSource>();
        SelectedWeapon();
    }

    public void Guns ()
        {
        muzik.PlayOneShot(degistir);
        int previousSelectedWeapon = selectedWeapon;

        if (selectedWeapon >= transform.childCount - 1)
            selectedWeapon = 0;
        else
            selectedWeapon++;


        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
      


    }

    public void Update()
    {

    }

     void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {

            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);


                i++;
          
        }


    }



}
