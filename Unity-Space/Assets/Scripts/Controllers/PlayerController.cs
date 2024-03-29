﻿using System.Collections;
using LudumDare50.Unity.Managers;
using UnityEngine;

namespace LudumDare50.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movementForce = 10.0f;
        private Rigidbody2D _rigidbody2D;
        private bool _isMoving = false;

        [SerializeField] private GameObject _pauseMenu;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StartCoroutine(AudioRoutine());
        }

        private void Update()
        {
            if (GameController.Instance != null && _pauseMenu != null && Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.Instance.Play("space-menu");
                _pauseMenu.SetActive(!_pauseMenu.activeSelf);
            }
            
            if (GameController.Instance != null && GameController.Instance.IsGameOver)
            {
                if (_isMoving)
                    _isMoving = false;
                
                return;
            }
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _rigidbody2D.AddForce(Vector2.left * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
                _isMoving = true;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _rigidbody2D.AddForce(Vector2.right * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
                _isMoving = true;
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                _rigidbody2D.AddForce(Vector2.up * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
                _isMoving = true;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                _rigidbody2D.AddForce(Vector2.down * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }
        }

        private IEnumerator AudioRoutine()
        {
            while (true)
            {
                if (_isMoving)
                    AudioManager.Instance.Play("whirring");
                
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}