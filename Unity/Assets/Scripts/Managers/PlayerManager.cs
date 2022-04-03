using System;
using System.Collections;
using LudumDare50.Controllers;
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
            while (Player.CurrentAir > 0)
            {
                yield return new WaitForSeconds(0.005f);
                Player.RemoveAir();
                UpdateUI();
            }

            GameController.Instance.GameOver();
        }

        private void UpdateUI()
        {
            _breathSlider.value = Player.CurrentAir / 1000f;
            _breathPercentText.text = $"{Player.CurrentAir / 10}%";
        }
    }
}