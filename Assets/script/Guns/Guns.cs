using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    Animator anim;
    AudioSource ses;
    public AudioClip katana;
 public   GameObject game; 

    public bool attack = false;
    public bool _basıldı;

   
    void Start()
    {
        anim = GetComponent<Animator>();
        ses = GetComponent<AudioSource>();
       

    }

  
    void Update()
    {
    


    }
    public void OnnAttackButton()
    {
  
        anim.SetBool("attack", true);
        attack = true;
        ses.PlayOneShot(katana);



    }
    public void OffAttackButton()
    {
        anim.SetBool("attack", false);
        attack = false;


    }
}
