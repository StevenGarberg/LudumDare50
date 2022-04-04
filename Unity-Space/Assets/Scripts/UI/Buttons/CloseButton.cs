using LudumDare50.Unity.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Buttons
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToClose;
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("space-menu");
                _objectToClose.SetActive(false);
            });
        }
    }
}