using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isinlanma : MonoBehaviour
{

    [SerializeField] GameObject _anim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            
            _anim.SetActive(true);
            Invoke("loadscne2",1f);
        }
    }
    void loadscne2()
    {
        SceneManager.LoadScene(2);
       


    }
}
