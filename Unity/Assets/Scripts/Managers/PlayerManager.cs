using System;
using System.Collections;
using LudumDare50.Models;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare50.Unity.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        [SerializeField] private Slider _breathSlider;
        [SerializeField] private Text _breathPercentText;
        
        public Player Player { get; private set; } = new Player();
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            StartCoroutine(BreathingRoutine());
        }

        public void AddAir()
        {
            Player.AddAir();
            UpdateUI();
        }

        private IEnumerator BreathingRoutine()
        {
            var interval = 0.09f;
            while (Player.CurrentAir > 0)
            {
                yield return new WaitForSeconds(0.1f);
                Player.RemoveAir();
                UpdateUI();
            }
            // TODO: End game
        }

        private void UpdateUI()
        {
            _breathSlider.value = Player.CurrentAir / 1000f;
            _breathPercentText.text = (Player.CurrentAir / 10).ToString() + "%";
        }
    }
}