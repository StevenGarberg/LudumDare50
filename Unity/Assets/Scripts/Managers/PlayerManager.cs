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

        public void AddAir()
        {
            Player.AddAir();
            _breathSlider.value = Player.CurrentAir / 1000f;
            _breathPercentText.text = (Player.CurrentAir / 10f).ToString();
        }
    }
}