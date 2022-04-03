using System;
using LudumDare50.Controllers;
using LudumDare50.Unity.Managers;
using UnityEngine;

namespace LudumDare50.Behaviours
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Aircan : MonoBehaviour
    {
        private Spawner _spawner;
        
        private void Awake()
        {
            _spawner = GetComponentInParent<Spawner>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                AudioManager.Instance.Play("space-thud");
                PlayerManager.Instance.Player.AddAir();
                GameController.Instance.ConsumeAndSpawn(_spawner);
                gameObject.SetActive(false);
            }
        }
    }
}