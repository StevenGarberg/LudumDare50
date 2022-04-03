﻿using UnityEngine;

namespace LudumDare50.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movementForce = 10.0f;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _rigidbody2D.AddForce(Vector2.left * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _rigidbody2D.AddForce(Vector2.right * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                _rigidbody2D.AddForce(Vector2.up * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                _rigidbody2D.AddForce(Vector2.down * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
            }
        }
    }
}