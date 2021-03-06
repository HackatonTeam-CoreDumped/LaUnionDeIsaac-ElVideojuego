﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public int numberEnemies = 20;
    public int enemiesSpawned;
    private float x;
    private float y;
    private float z;

    private bool isColliding;
    public GameObject[] gos;

    private Vector3 pos;
    public GameObject[] obj;
    public bool maxEnemiesInstantiated = false;

    public float count = 0.2f;
    public float count2 = 1f;

    // Use this for initialization
    void Start () {
        numberEnemies = 40;
        enemiesSpawned = 0;
        count = 0.1f;
        count2 = 0f;
        maxEnemiesInstantiated = false;
	}
	
	// Update is called once per frame
	void Update () {




        count = count - Time.deltaTime;
        if (count <= 0)
        {
            EnemySpawn();
        }
    }

    //Función que hace aparecer enemigos
    void Spawn()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);     
    }

    //Función que elige la posición en la que aparecen los enemigos
    public void EnemySpawn()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length < 40 && maxEnemiesInstantiated == false)
        {
            

                x = Random.Range(-74f, 74f);
                y = Random.Range(-74f, 74f);
                z = 0;
                pos = new Vector3(x, y, z);
                transform.position = pos;


                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(transform.position), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject.tag != "Wall")
                {
                    Spawn();

                }
                enemiesSpawned++;


        }
        else
        {
            count2 = count2 - Time.deltaTime;
            if (count2 <= 0)
            {
                maxEnemiesInstantiated = true;
            }            
        }
    }
}

