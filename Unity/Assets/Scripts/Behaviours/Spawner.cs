using System;
using UnityEngine;

namespace LudumDare50.Behaviours
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _aircanBoxCollider2D;
        
        private Guid Id { get; } = Guid.NewGuid();
        
        public void Spawn()
        {
            _aircanBoxCollider2D.gameObject.SetActive(true);
        }
    }
}