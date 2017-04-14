﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryEasy : MonoBehaviour
{
    private GameObject _player;
    public GameObject LoseMessage;
    public GameObject CointsHolder;

    public Text Score;

    private Vector3 _playerStartPos;

    private float _playerStartSpeed;

    private PlayerControler _playerSpeed;

	// Use this for initialization
	void Start ()
	{
        _player = GameObject.FindGameObjectWithTag("Player");
	    _playerStartPos = _player.transform.position;
	    _playerSpeed = _player.GetComponent<PlayerControler>();
	    _playerStartSpeed = _playerSpeed.Speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetGameEasy()
    {

        for (int i = 0; i < CointsHolder.transform.childCount; i++)
        {
            CointsHolder.transform.GetChild(i).gameObject.SetActive(true);
        }
        Score.text ="0";
        _player.transform.position = _playerStartPos;
        Debug.Log("Pos Reset");
        LoseMessage.SetActive(false);
        _playerSpeed.Speed = _playerStartSpeed;
    }

    public void ResetGameHard()
    {
        SceneManager.LoadScene(0);
    }
}