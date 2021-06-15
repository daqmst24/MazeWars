using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duvar : MonoBehaviour
{
    public Animator anim;
    AudioSource ses;
    public AudioClip kapiac;
    public AudioClip kapikapat;



    private void Start()
    {
        ses = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ses.PlayOneShot(kapiac);
            anim.SetBool("acik", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ses.PlayOneShot(kapikapat);
            anim.SetBool("kapali", true);


            Invoke("door", 0.4f);

        }
    }





    void door()

    {

        anim.SetBool("acik", false);
        anim.SetBool("kapali", false);


    }

}
