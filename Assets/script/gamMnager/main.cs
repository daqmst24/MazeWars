using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    [SerializeField] GameObject _settings;
    [SerializeField] GameObject _efect;
    [SerializeField] AudioSource _ses;  
    [SerializeField] AudioClip _play;
    [SerializeField] GameObject _anim;
    private AudioSource muzik;
    [SerializeField] AudioClip ses;




    private void Start()
    {

        muzik = GetComponent<AudioSource>();
    }
    public void Baslat()
    {
        _efect.SetActive(true);
        _ses.PlayOneShot(_play);
        Invoke("bekle",1f);
       

    }

  void bekle()
    {


        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
       
        _ses.PlayOneShot(_play);
        _settings.SetActive(true);

    }
    
    
    
    
    
    public void Quit()
    {
        _ses.PlayOneShot(_play);
        Application.Quit();

    }  
    public void BackButton()
    {
        _ses.PlayOneShot(_play);

        _settings.SetActive(false);
    }

    public void anamenu()
    {

        muzik.PlayOneShot(ses);
        _anim.SetActive(true);

        Invoke("menuu",1f);

    }
    void menuu()
    {
        SceneManager.LoadScene(0);

    }
}
