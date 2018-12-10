﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingedBossController : MonoBehaviour {

    public float speed; // la velocidad con la que perseguirá el miniboss al target
    private float health; // la vida a tiempo real del miniboss
    public float healthMax; // vida total del miniboss

    private Transform target; //el objetivo al que el miniboss perseguirá 
    public float stopDistance; //distancia mínima de separación entre miniboss y player
    public float retreatDistance; //distancia a partir de la cual el miniboss debe huir del jugador

    private float timeLeftBtwShots; //controla el numero de segundos que quedan para que dispare
    public float timeBtwShots; //tiempo entre disparo y disparo
    public GameObject projectile;

	// Use this for initialization
	void Start () {
        // hacemos que el target sea el lugar donde se encuentra el jugador (GameObject con tag "Player")
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeLeftBtwShots = timeBtwShots;
        health = healthMax;
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector2.Distance(transform.position, target.position) > stopDistance) //mientras la distancia entre miniboss y jugador sea mayor que la stopDistance
        {  // movemos el miniboss a donde se encuentre el target
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, target.position) < stopDistance && (Vector2.Distance(transform.position, target.position) > retreatDistance))
        { //si el jugador se acerca a más de la distancia mínima pero no está lo suficientemente cerca para llegar a ser la distancia de "tirar pa atrás"
            transform.position = this.transform.position; //el miniboss se queda quieto
        }
        else if(Vector2.Distance(transform.position, target.position) < retreatDistance) 
        { //movemos al miniboss en dirección contraria al target
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        if(timeLeftBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity); //Quaternion.identity = no rotation 
            timeLeftBtwShots = timeBtwShots;
        }
        else
        {
            timeLeftBtwShots -= Time.deltaTime; // de esta manera nos aseguramos de que el enemigo lance bolas cada timeBtwShots segundos
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        Debug.Log("aaa");
        health-=10;
        transform.Find("BarSprite").localScale = new Vector3(health/healthMax, 1);
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
