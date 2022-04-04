using LudumDare50.Unity.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class StatsButton : MonoBehaviour
    {
        [SerializeField] private GameObject _statsWindow;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("select");
                _statsWindow.SetActive(true);
            });
        }
    }
}