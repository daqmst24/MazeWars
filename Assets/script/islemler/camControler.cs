using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControler : MonoBehaviour
{
    Transform player;
    public Vector3 yon;


    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {

        transform.position = player.position + yon;
        
    }
}
