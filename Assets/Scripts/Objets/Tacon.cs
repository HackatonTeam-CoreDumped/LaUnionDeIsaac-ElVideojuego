﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacon : MonoBehaviour {

    public float value;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("speed aumentado");
        if (collision.gameObject.tag == "Player")
        {
            Stats.speed = Stats.speed + value;
            Destroy(gameObject);
        }
    }
}
