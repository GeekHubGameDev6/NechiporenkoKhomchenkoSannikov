﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public bool MoveToCenterComplite;
    public bool LeftMoving, RightMoving, Moving;
    private bool _leftReturnTomid, _rightReturnTomid;

    public float TurnSpeed, Speed, RotateSpeed;
    private float _angle,_startAngle;
    public float MaxAngle;


    private CharacterController _charterMove;

    private Vector3 _forwardmove, _playerLeftMaxR, _playerRightMaxR, _startRotation;

    private Transform _playerRotate;

    // Use this for initialization
    void Start()
    {
        LeftMoving = false;
        RightMoving = false;
        Moving = true;
        _charterMove = GetComponent<CharacterController>();
        _forwardmove = new Vector3(0, -1f, 1);
        _playerRotate = transform.GetChild(0);
        //_playerLeftMaxR = new Vector3(0f, 0.0f, -45f);
        //_playerRightMaxR = new Vector3(0f, 0.0f, 45f);
        //_startRotation = _playerRotate.localEulerAngles;
        _startAngle = Quaternion.Angle(transform.rotation, _playerRotate.rotation);
        _rightReturnTomid = false;
        _leftReturnTomid = false;
        Debug.Log(_playerRotate.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        _angle = Quaternion.Angle(transform.rotation, _playerRotate.rotation);
        if (Moving)
        {
            _charterMove.Move(_forwardmove * Speed);
            //gameObject.GetComponent<Animator>().SetBool("MoveComplite", MoveToCenterComplite);
            //gameObject.GetComponent<Animator>().SetBool("LeftTurn", LeftMoving);
            //gameObject.GetComponent<Animator>().SetBool("RightTurn", RightMoving);
            if (LeftMoving == false && RightMoving == false && _leftReturnTomid)
            {
                _playerRotate.Rotate(Vector3.forward, RotateSpeed);
                if (_angle < _startAngle + 2)
                {
                    _playerRotate.localEulerAngles = _startRotation;
                    _leftReturnTomid = false;
                }
            }
            if (LeftMoving == false && RightMoving == false && _rightReturnTomid)
            {
                _playerRotate.Rotate(Vector3.back, RotateSpeed);
                if (_angle < _startAngle + 2)
                {
                    _playerRotate.localEulerAngles = _startRotation;
                    _rightReturnTomid = false;
                }
            }


        }
        if (LeftMoving)
        {
            _charterMove.Move(Vector3.left * TurnSpeed);
            _leftReturnTomid = true;
            if (_angle < MaxAngle )
                _playerRotate.Rotate(Vector3.back, RotateSpeed);

        }
        if (RightMoving)
        {
            _charterMove.Move(Vector3.right * TurnSpeed );
            _rightReturnTomid = true;
            if (_angle < MaxAngle)
                _playerRotate.Rotate(Vector3.forward, RotateSpeed);

        }

    }

    public void MoveLeft()
    {
        LeftMoving = !LeftMoving;

    }
    public void MoveRight()
    {
        RightMoving = !RightMoving;
    }


}
