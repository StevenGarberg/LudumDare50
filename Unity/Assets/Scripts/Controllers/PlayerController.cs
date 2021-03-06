using System;
using UnityEngine;

namespace LudumDare50.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movementForce = 10.0f;
        [SerializeField] private float _upwardForcePWRUP;
        [SerializeField] private float maxFallSpeed;
        [SerializeField] private float powerUpDestroyDelay = 1f;
        [SerializeField] private float fallSpeedChangeDuration;
        private Rigidbody2D _rigidbody2D;
        private const string StopFallPWRUP = "BoxPWRUP";
        private const string SlowFallPWRUP = "BubblePWRUP";
        private const string TemporaryPlatformPWRUP = "TempPlatformPWRUP";
        private const string SpringPWRUP = "SpringPWRUP";
        private const string FastFall = "AnvilObstacle";
        private const string PushDown = "Obstacle2";
        private const string PlusMaxFallSpeed = "HeavyWeight";

        
        private bool doubleFallSpeed = false;
        private bool halfFallSpeed = false;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(_rigidbody2D.velocity.y < maxFallSpeed)
            {
                _rigidbody2D.velocity = new Vector2(0, maxFallSpeed);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //_rigidbody2D.AddForce(Vector2.left * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
                transform.Translate(Vector3.left * Time.deltaTime * _movementForce);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //_rigidbody2D.AddForce(Vector2.right * Time.deltaTime * _movementForce, ForceMode2D.Impulse);
                transform.Translate(Vector3.right * Time.deltaTime * _movementForce);
            }
        }
        private void DoubleFallSpeed()
        {
            if(halfFallSpeed)
            {
                halfFallSpeed = false;
                maxFallSpeed = maxFallSpeed * 10;
                return;
            }
                        
            if(!doubleFallSpeed)
            {
                doubleFallSpeed = true;
                maxFallSpeed = maxFallSpeed * 10;
            }

        }
        private void HalfFallSpeed()
        {
            if(doubleFallSpeed)
            {
                doubleFallSpeed = false;
                maxFallSpeed = maxFallSpeed / 10;
                return;
            }

            if(!halfFallSpeed)
            {
                halfFallSpeed = true;
                maxFallSpeed = maxFallSpeed / 10;
            }
        }

        private void ResetMaxSpeed()
        {
            maxFallSpeed += 50;
        }


        private void OnTriggerEnter2D(Collider2D powerUpTag)
        {
            if(powerUpTag.CompareTag(StopFallPWRUP))
            {
               _rigidbody2D.AddForce(Vector2.up * _upwardForcePWRUP); 
               Destroy(powerUpTag.gameObject, powerUpDestroyDelay * Time.deltaTime);
            }

            if(powerUpTag.CompareTag(SlowFallPWRUP))
            {
                HalfFallSpeed();
                Destroy(powerUpTag.gameObject, powerUpDestroyDelay * Time.deltaTime);
                Invoke("DoubleFallSpeed", fallSpeedChangeDuration * Time.deltaTime);
            }
            
            if(powerUpTag.CompareTag(FastFall))
            {
                DoubleFallSpeed();
                Destroy(powerUpTag.gameObject, powerUpDestroyDelay * Time.deltaTime);
                Invoke(nameof(HalfFallSpeed), fallSpeedChangeDuration * Time.deltaTime);
            }

            if(powerUpTag.CompareTag(PushDown))
            {
                maxFallSpeed -= 50;
                _rigidbody2D.AddForce(Vector2.down * Time.deltaTime * 20.0f);
                Destroy(powerUpTag.gameObject, powerUpDestroyDelay * Time.deltaTime);
                Invoke(nameof(ResetMaxSpeed), 50f * Time.deltaTime);
            }
            if(powerUpTag.CompareTag(PlusMaxFallSpeed))
            {
                maxFallSpeed -= 4;
                Destroy(powerUpTag.gameObject, powerUpDestroyDelay * Time.deltaTime);
            }
        }
    }
}