﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private PlayerControler _player;

	// Use this for initialization
	void Start () {
	_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        _player.PlayerSpeed += 0.05f;
    }
}