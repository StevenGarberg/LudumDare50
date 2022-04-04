using LudumDare50.Unity.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class CreditsButton : MonoBehaviour
    {
        [SerializeField] private GameObject _creditsWindow;
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("select");
                _creditsWindow.SetActive(true);
            });
        }
    }
}