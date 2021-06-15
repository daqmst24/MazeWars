using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField] private Text _coinSkor;
    public int _coinA;
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _anim;
   private AudioSource muzik;
    [SerializeField] AudioClip ses;  
    [SerializeField] AudioClip _revelotioun;
    [SerializeField] GameObject _setting;  
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _dirilme;
    [SerializeField] GameObject _deadmenu;
    private playerhiz _hiz;

    [SerializeField] AudioClip saldırı;

    [SerializeField]  GameObject _playerPreaf;

    [SerializeField] GameObject can;
    private void Start()
    {
     
            _hiz = GameObject.FindGameObjectWithTag("Player").GetComponent<playerhiz>();
        muzik = GetComponent<AudioSource>();


    }

    void Update()
    {

        _coinSkor.text = _coinA.ToString();




    }


    public void Duraklat()
    {
        muzik.PlayOneShot(ses);
        Time.timeScale = 0;
        _menu.SetActive(true);

    }
    public void Resume()
    {
        muzik.PlayOneShot(ses);
        Time.timeScale = 1;
        _menu.SetActive(false);

    }  
    public void settting()
    {

        _setting.SetActive(true);
        muzik.PlayOneShot(ses);

    }
    public void backbbut()
    {

        _setting.SetActive(false);
        muzik.PlayOneShot(ses);

    }
    public void MainMenu()
    {
        muzik.PlayOneShot(ses);
        _anim.SetActive(true);
        Time.timeScale = 1;
        Invoke("loadscne1",1f);

    }  
    public void Restart()
    {
        muzik.PlayOneShot(ses);
        _anim.SetActive(true);
        Time.timeScale = 1;
        Invoke("loadscne0",1f);

    }
    void loadscne1()
    {

        SceneManager.LoadScene(0);

    }
    void loadscne0()
    {

        SceneManager.LoadScene(1);

    }
    public void Dirilme()
    {
        if (_coinA>=10)
        {

            _coinA -= 10;
        
        muzik.PlayOneShot(_revelotioun);
            _hiz._speed = 5;
        _hiz._currentHealth = 100;
        _player.SetActive(true);
            _dirilme.SetActive(false);
            _deadmenu.SetActive(false);
        }






    }
}
