using LudumDare50.Unity.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare50.Behaviours
{
    [RequireComponent(typeof(Text))]
    public class IdText : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            _text.text = $"<b>Client ID:</b> {StatsManager.Instance.Id}";
        }
    }
}