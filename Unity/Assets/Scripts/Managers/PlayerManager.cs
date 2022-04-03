using LudumDare50.Models;
using UnityEngine;

namespace LudumDare50.Unity.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        public Player Player { get; private set; } = new Player();
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}