using LudumDare50.Unity.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare50.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class WindowButton : MonoBehaviour
    {
        [SerializeField] private GameObject _window;
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("select");
                _window.SetActive(true);
            });
        }
    }
}