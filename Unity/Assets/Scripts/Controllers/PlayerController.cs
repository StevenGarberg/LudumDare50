using System;
using UnityEngine;

namespace LudumDare50.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movementForce = 10.0f;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _transform.Translate(Vector2.left * Time.deltaTime * _movementForce);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _transform.Translate(Vector2.right * Time.deltaTime * _movementForce);
            }
        }
    }
}