using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    public Animator camanim;

   public void Camanim()
    {

        camanim.SetTrigger("shake");

    }

}
