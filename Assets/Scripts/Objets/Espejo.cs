﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espejo : MonoBehaviour {

    public float value;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("cadencia aumentado");
        if (collision.gameObject.tag == "Player")
        {
            Stats.cadencia = Stats.cadencia + value;
            Destroy(gameObject);
        }
    }
}
